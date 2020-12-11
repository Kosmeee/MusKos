using System.Collections.Generic;
using MusKos.Domain.Models;

namespace MusKos.Domain.DomainServices.Interfaces
{
    public interface IArtistDomainService
    {
        Artist Get(int id);

        List<Artist> GetArtists();

        Artist FindArtist(int id);

        void DeleteArtist(int id);

        void AddArtist(Artist artist);

        void ChangeArtist();
    }
}
