

using MusKos.Domain.Models;
using MusKosCore.Models;

namespace MusKosCore.Util.Mapper
{
    public static class Mapper
    {
        public static ViewArtist ArtistToViewArtist(Artist artist)
        {
            return new ViewArtist
            {
                Albums = artist.Albums,
                Genre = artist.Genre,
                Id = artist.Id,
                Image = artist.Image,
                Nickname = artist.Nickname,
                Tracks = artist.Tracks
            };
        }

        public static Artist ViewArtistToArtist(ViewArtist artist)
        {
            return new Artist
            {
                Albums = artist.Albums,
                Genre = artist.Genre,
                Id = artist.Id,
                Image = artist.Image,
                Nickname = artist.Nickname,
                Tracks = artist.Tracks
            };
        }

        public static Artist EditArtistToArtist(ViewArtist viewArtist, Artist artist)
        {
            artist.Image = viewArtist.Image;
            artist.Nickname = viewArtist.Nickname;
            return artist;
        }

        public static ViewTrack TrackToViewTrack(Track track)
        {
            return new ViewTrack
            {
                AddedDate = track.AddedDate,
                Album = track.Album,
                Artist = track.Artist,
                Genre = track.Genre,
                Id = track.Id,
                Image = track.Image,
                Title = track.Title,
                Url = track.Url
            };
        }

        public static Track ViewTrackToTrack(ViewTrack track)
        {
            return new Track
            {
                AddedDate = track.AddedDate,
                Album = track.Album,
                Artist = track.Artist,
                Genre = track.Genre,
                Id = track.Id,
                Image = track.Image,
                Title = track.Title,
                Url = track.Url
            };
        }

        public static Track EditTrackToTrack(ViewTrack viewTrack, Track track)
        {
            track.Id = viewTrack.Id;
            track.Image = viewTrack.Image;
            track.Title = viewTrack.Title;
            track.Url = viewTrack.Url;
            return track;
        }
    }
}