using MusKos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusKos.Presentation.PresentationServices.Interfaces
{
    public interface IPlaylistPresentationService
    {
        Playlist GetTracksForUser(string id);

        void AddTrack(string id, int idtrack);
    }
}
