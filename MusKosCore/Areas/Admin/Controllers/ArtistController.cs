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
    public class ArtistController : Controller
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IArtistPresentationService artistPresentationService;

        // GET: Admin/Artist
        public ArtistController(IArtistDomainService artistDomainService, IArtistPresentationService artistPresentationService)
        {
            this.artistDomainService = artistDomainService;
            this.artistPresentationService = artistPresentationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewArtist viewArtist = new ViewArtist();

            viewArtist = Mapper.ArtistToViewArtist(artistDomainService.FindArtist(id));
            return View("EditArtist", viewArtist);
        }

        [HttpPost]
        public ActionResult Edit(ViewArtist viewArtist)
        {
            if (ModelState.IsValid)
            {
                artistPresentationService.ChangeArtist(viewArtist);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditArtist", viewArtist);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("EditArtist", new ViewArtist());
        }

        [HttpPost]
        public ActionResult Add(ViewArtist viewArtist)
        {
            if (ModelState.IsValid)
            {
                artistPresentationService.AddArtist(viewArtist);
                return RedirectToAction("Index", "Admin");
            }

            return View("EditArtist", new ViewArtist());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            artistDomainService.DeleteArtist(id);

            return RedirectToAction("Index", "Admin");
        }
    }
    public class ArtistsViewComponent
            : ViewComponent
    {
        private readonly IArtistDomainService artistDomainService;
        public ArtistsViewComponent(IArtistDomainService artistDomainService)
        {
            this.artistDomainService = artistDomainService;
        }
        public IViewComponentResult Invoke()
        {
            var artistslist = artistDomainService.GetArtists();
            List<ViewArtist> viewArtistList = new List<ViewArtist>();
            foreach (var a in artistslist)
            {
                viewArtistList.Add(Mapper.ArtistToViewArtist(a));
            }

            return View("ViewArtists", viewArtistList);
        }
    }
}
