using MusKosCore.Models;

namespace MusKosCore.PresentationServices.Interfaces
{
    public interface IArtistPresentationService
    {
        void ChangeArtist(ViewArtist viewArtist);

        void AddArtist(ViewArtist viewArtist);
    }
}