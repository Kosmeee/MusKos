using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusKos.Domain.Models.Identity;

namespace MusKos.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
       readonly RoleManager<IdentityRole> roleManager;
       readonly UserManager<ApplicationUser> userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

       

        

        public async Task<IActionResult> Edit(string id)
        {
            // получаем пользователя
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
               
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();
                ChangeRole model = new ChangeRole
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles,
                    Nickname = user.UserName
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await userManager.AddToRolesAsync(user, addedRoles);

                await userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index","Admin");
            }

            return NotFound();
        }
    }
    public class RolesViewComponent
            : ViewComponent
    {
        
       readonly UserManager<ApplicationUser> userManager;
        public RolesViewComponent( UserManager<ApplicationUser> userManager)
        {
        
           
            this.userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {


           return View("ViewUsers", userManager.Users.ToList());
        }
    }

}

