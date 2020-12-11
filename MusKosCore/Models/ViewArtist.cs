using System.Collections.Generic;
using MusKos.Domain.Models;

namespace MusKosCore.Models
{
    public class ViewArtist
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public Genre Genre { get; set; }

        public List<Track> Tracks { get; set; }

        public List<Album> Albums { get; set; }

        public string Image { get; set; }
    }
}