using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;


namespace MusKos.Data.Repository
{
   public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public AlbumRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
