using MusKos.Domain.DomainServices.Interfaces;
using MusKos.Domain.Models;
using MusKosCore.Models;
using MusKosCore.PresentationServices.Interfaces;
using MusKosCore.Util.Mapper;

namespace MusKosCore.PresentationServices
{
    public class ArtistPresentationService : IArtistPresentationService
    {
        private readonly IArtistDomainService artistDomainService;
        private readonly IGenreDomainService genreDomainService;

        public ArtistPresentationService(IArtistDomainService artistDomainService, IGenreDomainService genreDomainService)
        {
            this.artistDomainService = artistDomainService;
            this.genreDomainService = genreDomainService;
        }

        public void ChangeArtist(ViewArtist viewArtist)
        {
            Artist artist = artistDomainService.FindArtist(viewArtist.Id);
            artist = Mapper.EditArtistToArtist(viewArtist, artist);
            artist.Genre = genreDomainService.Get(viewArtist.Genre.Id);
            artistDomainService.ChangeArtist();
        }

        public void AddArtist(ViewArtist viewArtist)
        {
            Artist artist = Mapper.ViewArtistToArtist(viewArtist);
            artist.Genre = genreDomainService.Get(viewArtist.Genre.Id);
            artistDomainService.AddArtist(artist);
        }
    }
}