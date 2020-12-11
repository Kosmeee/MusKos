using MusKos.Domain.Models;


namespace MusKos.Domain.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Genre GetTracks(int id);
    }
}
