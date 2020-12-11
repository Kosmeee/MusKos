using System.Collections.Generic;
using MusKos.Domain.Models;

namespace MusKos.Domain.DomainServices.Interfaces
{
    public interface IGenreDomainService
    {
        Genre Get(int id);

        List<Genre> GetAll();

        Genre GetTracks(int id);
    }
}
