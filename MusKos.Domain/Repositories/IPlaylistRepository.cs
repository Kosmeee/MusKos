using MusKos.Domain.Models;
using System.Collections.Generic;

namespace MusKos.Domain.Repositories
{
   public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        void AddTrack(string id, int idtrack);

        Playlist GetTracksForUser(string id);
    }
}
