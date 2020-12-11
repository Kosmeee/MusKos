using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace MusKos.Data.Repository
{
   public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public ArtistRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Artist FindArtist(int id)
        {
            var entity = Get(id);
            // unitOfWork.Entry(entity).Reference(a => a.Tracks).Load();
           // unitOfWork.Entry(entity).Reference(a => a.Albums).Load();
            unitOfWork.Entry(entity).Reference(a => a.Genre).Load();
            return entity;
        }

        public List<Artist> GetAllWithAllAttachments()
        {
            return GetQueryableItems()
                  .Include(a => a.Tracks)
                 .Include(a => a.Albums)
                 .Include(a => a.Genre)
                 .ToList();
        }
    }
}
