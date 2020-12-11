using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace MusKos.Data.Repository
{
   public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public TrackRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Track> GetFiveTracks()
        {
            return GetQueryableItems()
                .OrderByDescending(c => c.AddedDate)
                .Take(5)
                .Include(a => a.Album)
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToList();
        }

        public List<Track> GetAllWithAllAttachments()
        {
            return GetQueryableItems()
                 .Include(a => a.Album)
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToList();
        }

        public Track FindTrack(int id)
        {
            var entity = Get(id);
            unitOfWork.Entry(entity).Reference(a => a.Album).Load();
            unitOfWork.Entry(entity).Reference(a => a.Artist).Load();
            unitOfWork.Entry(entity).Reference(a => a.Genre).Load();
            return entity;
        }
    }
}
