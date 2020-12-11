using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusKos.Domain.DomainServices.Interfaces;

namespace MusKos.Presentation.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreDomainService genreDomainService;

        public GenreController(IGenreDomainService genreDomainService)
        {
            this.genreDomainService = genreDomainService;
        }

        public ViewResult Index()
        {
            return View(genreDomainService.GetAll());
        }

        public ViewResult GetTracks(int id)
        {
            var genre = genreDomainService.GetTracks(id);
            return View("ViewTracks", genre);
        }

    }
}
