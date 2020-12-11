using MusKos.Domain.Models.Identity;

namespace MusKos.Domain.Repositories
{
    public interface IAppUserRepository : IBaseRepository<ApplicationUser>
    {
        int GetPlaylistId(string id);
    }
}
