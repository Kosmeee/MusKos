using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace MusKos.Data.Repository
{
   public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAppUserRepository appUserRepository;
        private readonly ITrackRepository trackRepository;

        public PlaylistRepository(IUnitOfWork unitOfWork, IAppUserRepository appUserRepository, ITrackRepository trackRepository)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.appUserRepository = appUserRepository;
            this.trackRepository = trackRepository;
        }

        public void AddTrack(string id, int idtrack)
        {
            var entity = Get(appUserRepository.GetPlaylistId(id));
            unitOfWork.Entry(entity).Collection(a => a.Tracks).Load();
            
            entity.Tracks.Add(trackRepository.FindTrack(idtrack));
        }

        public Playlist GetTracksForUser(string id)
        {
            var playlist = Get(appUserRepository.GetPlaylistId(id));
            
            return GetQueryableItems()
                 .Where(c => c.Id == playlist.Id)
                 .Include(c => c.Tracks).ThenInclude(c => c.Artist)
                  .Include(c => c.Tracks).ThenInclude(c => c.Genre)
                   .Include(c => c.Tracks).ThenInclude(c => c.Album).FirstOrDefault();

          //  unitOfWork.Entry(playlist).Collection(c => c.Tracks).Load();

           
        }
    }
}
