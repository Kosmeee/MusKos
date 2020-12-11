using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace MusKos.Data.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public GenreRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Genre GetTracks(int id)
        {
            return GetQueryableItems()
                 .Where(c => c.Id == id)
                 .Include(c => c.Tracks).ThenInclude(c => c.Artist)
                  .Include(c => c.Tracks).ThenInclude(c => c.Genre)
                   .Include(c => c.Tracks).ThenInclude(c => c.Album).FirstOrDefault();
        }
    }
}
