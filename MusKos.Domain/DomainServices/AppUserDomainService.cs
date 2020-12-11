using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models.Identity;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;

namespace MusKos.Domain.DomainServices
{
    public class AppUserDomainService : IAppUserDomainService
    {
        private readonly IAppUserRepository appUserRepository;

        public AppUserDomainService(IAppUserRepository appUserRepository)
        {
            this.appUserRepository = appUserRepository;
        }

        public int GetPlaylistId(string id)
        {
           return appUserRepository.GetPlaylistId(id);
        }
    }
}
