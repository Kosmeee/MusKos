using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKosCore.Models;
using MusKosCore.PresentationServices.Interfaces;
using MusKosCore.Util.Mapper;


namespace MusKosCore.PresentationServices
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IArtistDomainService artistDomainService;
        private readonly IAlbumDomainService albumDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService, IGenreDomainService genreDomainService, IArtistDomainService artistDomainService, IAlbumDomainService albumDomainService)
        {
            this.trackDomainService = trackDomainService;
            this.genreDomainService = genreDomainService;
            this.artistDomainService = artistDomainService;
            this.albumDomainService = albumDomainService;
        }

        public void ChangeTrack(ViewTrack viewTrack)
        {
            Track track = trackDomainService.FindTrack(viewTrack.Id);
            track = Mapper.EditTrackToTrack(viewTrack, track);
            track.Artist = artistDomainService.Get(viewTrack.Artist.Id);
            track.Album = albumDomainService.Get(viewTrack.Album.Id);
            track.Genre = genreDomainService.Get(viewTrack.Genre.Id);
            trackDomainService.ChangeTrack();
        }

        public void AddTrack(ViewTrack viewTrack)
        {
            Track track = Mapper.ViewTrackToTrack(viewTrack);
            track.Artist = artistDomainService.Get(viewTrack.Artist.Id);
            track.Album = albumDomainService.Get(viewTrack.Album.Id);
            track.Genre = genreDomainService.Get(viewTrack.Genre.Id);
            trackDomainService.AddTrack(track);
        }
    }
}