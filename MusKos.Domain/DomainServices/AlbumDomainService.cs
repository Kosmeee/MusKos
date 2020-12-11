
using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;

namespace MusKos.Domain.DomainServices
{
    public class AlbumDomainService : IAlbumDomainService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork unitOfWork;

        public AlbumDomainService(IAlbumRepository albumRepository, IUnitOfWork unitOfWork)
        {
            this.albumRepository = albumRepository;
            this.unitOfWork = unitOfWork;
        }

        public Album Get(int id)
        {
            return albumRepository.Get(id);
        }
    }
}
