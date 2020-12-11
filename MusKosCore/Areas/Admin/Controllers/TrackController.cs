using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusKos.Domain.DomainServices.Interfaces;
using MusKosCore.Models;
using MusKosCore.PresentationServices.Interfaces;
using MusKosCore.Util.Mapper;

namespace MusKos.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrackController : Controller
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly ITrackPresentationService trackPresentationService;

        // GET: Admin/Track
        public TrackController(ITrackDomainService trackDomainService, ITrackPresentationService trackPresentationService)
        {
            this.trackDomainService = trackDomainService;
            this.trackPresentationService = trackPresentationService;
        }

        public ActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewTrack viewTrack;

            viewTrack = Mapper.TrackToViewTrack(trackDomainService.FindTrack(id));
            return View("EditTrack", viewTrack);
        }

        [HttpPost]
        public ActionResult Edit(ViewTrack viewTrack)
        {
            if (ModelState.IsValid)
            {
                trackPresentationService.ChangeTrack(viewTrack);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditTrack", viewTrack);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("EditTrack", new ViewTrack());
        }

        [HttpPost]
        public ActionResult Add(ViewTrack viewTrack)
        {
            if (ModelState.IsValid)
            {
                viewTrack.AddedDate = DateTime.Now;
                trackPresentationService.AddTrack(viewTrack);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditTrack", new ViewTrack());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            trackDomainService.DeleteTrack(id);

            return RedirectToAction("Index", "Admin");
        }
    }
    public class TracksViewComponent 
        : ViewComponent {
        
            private readonly ITrackDomainService trackDomainService;
        public TracksViewComponent(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }
        public IViewComponentResult Invoke()
        {
            var trackslist = trackDomainService.GetTracks();
            List<ViewTrack> viewTrackList = new List<ViewTrack>();
            foreach (var a in trackslist)
            {
                viewTrackList.Add(Mapper.TrackToViewTrack(a));
            }

            return View("ViewTracks", viewTrackList);
        }
    }
}
