using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;
using System.Collections.Generic;

namespace MusKos.Domain.DomainServices
{
    public class PlaylistDomainService : IPlaylistDomainService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlaylistDomainService(IPlaylistRepository playlistRepository, IUnitOfWork unitOfWork)
        {
            this.playlistRepository = playlistRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddTrack(string id, int idtrack)
        {
            playlistRepository.AddTrack(id, idtrack);
            unitOfWork.SaveChanges();
        }

        public Playlist GetTracksForUser(string id)
        {
            return playlistRepository.GetTracksForUser(id);
        }
    }
}
