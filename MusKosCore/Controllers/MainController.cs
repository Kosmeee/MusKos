using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusKos.Domain.DomainServices.Interfaces;

namespace MusKos.Presentation.Controllers
{
    public class MainController : Controller
    {
        private readonly ITrackDomainService trackDomainService;
       private readonly ILogger<MainController> logger;

        public MainController(ITrackDomainService trackDomainService, ILogger<MainController> logger)
        {
            this.trackDomainService = trackDomainService;
            this.logger = logger;
        }

        public ActionResult Index()
        {
            logger.LogInformation("Main page loaded");
            return View(trackDomainService.GetFiveTracks());
        }
    }
}
