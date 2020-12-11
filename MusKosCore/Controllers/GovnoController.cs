using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MusKos.Presentation.Controllers
{
    [Authorize]
    public class GovnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
