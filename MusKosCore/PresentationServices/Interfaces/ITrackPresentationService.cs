using MusKosCore.Models;

namespace MusKosCore.PresentationServices.Interfaces
{
    public interface ITrackPresentationService
    {
        void ChangeTrack(ViewTrack viewTrack);

        void AddTrack(ViewTrack viewTrack);
    }
}