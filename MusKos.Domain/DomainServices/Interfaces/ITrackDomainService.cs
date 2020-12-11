using System.Collections.Generic;
using MusKos.Domain.Models;

namespace MusKos.Domain.DomainServices.Interfaces
{
   public interface ITrackDomainService
    {
        List<Track> GetFiveTracks();

        List<Track> GetTracks();

        Track FindTrack(int id);

        void DeleteTrack(int id);

        void AddTrack(Track track);

        void ChangeTrack();
    }
}
