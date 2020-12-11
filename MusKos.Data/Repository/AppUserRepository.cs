using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models;
using MusKos.Domain.Models.Identity;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
namespace MusKos.Data.Repository
{
    public class AppUserRepository : BaseRepository<ApplicationUser>, IAppUserRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public AppUserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public int GetPlaylistId(string id)
        {
            var user = Get(id);
            unitOfWork.Entry(user).Reference(c => c.Playlist).Load();
            return user.Playlist.Id;
        }
    }
}
