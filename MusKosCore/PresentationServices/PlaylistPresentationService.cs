using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKos.Presentation.PresentationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusKos.Presentation.PresentationServices
{
    public class PlaylistPresentationService : IPlaylistPresentationService
    {
        private readonly IPlaylistDomainService playlistDomainService;
        public PlaylistPresentationService(IPlaylistDomainService playlistDomainService)
        {
            this.playlistDomainService = playlistDomainService;
        }
        public void AddTrack(string id, int idtrack)
        {
            playlistDomainService.AddTrack(id, idtrack);
        }

        public Playlist GetTracksForUser(string id)
        {
            return playlistDomainService.GetTracksForUser(id);
        }
    }
}
