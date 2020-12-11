using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusKos.Presentation.PresentationServices.Interfaces;

namespace MusKos.Presentation.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistPresentationService playlistPresentationService;
        public PlaylistController(IPlaylistPresentationService playlistPresentationService)
        {
            this.playlistPresentationService = playlistPresentationService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View("Index",playlistPresentationService.GetTracksForUser(userId).Tracks);
        }

        public IActionResult AddTrack(int id)
        {
            playlistPresentationService.AddTrack(User.FindFirstValue(ClaimTypes.NameIdentifier), id);
            return RedirectToAction("Index","Main");
        }
    }
}
