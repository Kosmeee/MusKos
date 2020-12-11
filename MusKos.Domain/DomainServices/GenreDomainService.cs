using System.Collections.Generic;
using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKos.Domain.Repositories;
using MusKos.Domain.UnitOfWork;

namespace MusKos.Domain.DomainServices
{
    public class GenreDomainService : IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenreDomainService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            this.genreRepository = genreRepository;
            this.unitOfWork = unitOfWork;
        }

        public Genre Get(int id)
        {
            return genreRepository.Get(id);
        }

        public List<Genre> GetAll()
        {
            return genreRepository.GetAll();
        }

       public Genre GetTracks(int id)
        {
            return genreRepository.GetTracks(id);
        }
    }
}
