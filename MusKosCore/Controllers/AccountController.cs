using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusKos.Domain.Models.Identity;
using MusKosCore.Models;
using MusKosCore.PresentationServices.Interfaces;
using System.Threading.Tasks;

namespace MusKos.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailPresentationService emailService;
        private readonly ILogger<MainController> logger;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailPresentationService emailService, ILogger<MainController> logger)
        {
            UserManager = userManager;
            this.signInManager = signInManager;
            this.emailService = emailService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Main");
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Nickname, Playlist = new Domain.Models.Playlist() };
                // добавляем пользователя
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    await emailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Confirm your email here-> <a href='{callbackUrl}'>link</a><-");
                    logger.LogInformation("Email sent");
                    return View("ConfirmEmail");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        logger.LogError("Error in Registration Model Form");
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Main");
            else
                return View("Error");
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Main");
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Nickname);
                if (user != null)
                {
                   
                    if (!await UserManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Please, confirm your email");
                        return View(model);
                    }
                }
 
                var result = await signInManager.PasswordSignInAsync(model.Nickname, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in");
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong combination of login + password");
                }
            }
            return View(model);
        }

       
        public async Task<IActionResult> Logout()
        {
            
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out");
            return RedirectToAction("Index", "Main");
        }
    }
}