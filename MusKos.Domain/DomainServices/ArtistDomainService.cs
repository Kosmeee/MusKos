using System.Collections.Generic;
using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;

namespace MusKos.Domain.DomainServices
{
    public class ArtistDomainService : IArtistDomainService
    {
        private readonly IArtistRepository artistRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArtistDomainService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            this.artistRepository = artistRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddArtist(Artist artist)
        {
            artistRepository.Add(artist);
            unitOfWork.SaveChanges();
        }

        public void ChangeArtist()
        {
            unitOfWork.SaveChanges();
        }

        public void DeleteArtist(int id)
        {
            artistRepository.DeleteById(id);
            unitOfWork.SaveChanges();
        }

        public Artist FindArtist(int id)
        {
            return artistRepository.FindArtist(id);
        }

        public List<Artist> GetArtists()
        {
            return artistRepository.GetAllWithAllAttachments();
        }

        public Artist Get(int id)
        {
            return artistRepository.Get(id);
        }
    }
}