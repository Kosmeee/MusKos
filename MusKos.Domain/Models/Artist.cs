using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Domain.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public Genre Genre { get; set; }

        public List<Track> Tracks { get; set; } = new List<Track>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public string Image { get; set; }
    }
}
