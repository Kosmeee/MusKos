using MusKos.Domain.Models;

namespace MusKos.Domain.DomainServices.Interfaces
{
    public interface IAlbumDomainService
    {
        Album Get(int id);
    }
}
