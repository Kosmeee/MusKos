using System.Collections.Generic;
using MusKos.Domain.Models;


namespace MusKos.Domain.Repositories
{
   public interface IArtistRepository : IBaseRepository<Artist>
    {
        List<Artist> GetAllWithAllAttachments();

        Artist FindArtist(int id);
    }
}
