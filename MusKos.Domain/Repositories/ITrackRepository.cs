using System.Collections.Generic;
using MusKos.Domain.Models;



namespace MusKos.Domain.Repositories
{
   public interface ITrackRepository : IBaseRepository<Track>
    {
        List<Track> GetFiveTracks();

        List<Track> GetAllWithAllAttachments();

        Track FindTrack(int id);
    }
}
