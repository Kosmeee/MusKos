using MusKos.Domain.Models;
using System.Collections.Generic;

namespace MusKos.Domain.DomainServices.Interfaces
{
    public interface IPlaylistDomainService
    {
        void AddTrack(string id, int idtrack);

        Playlist GetTracksForUser(string id);
    }
}
