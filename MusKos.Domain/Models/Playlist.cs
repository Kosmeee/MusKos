using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Domain.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public List<Track> Tracks { get; set; } = new List<Track>();
    }
}
