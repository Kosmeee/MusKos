using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Domain.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Track> Tracks { get; set; }

        public List<Artist> Artists { get; set; }

        public string Image { get; set; }
    }
}
