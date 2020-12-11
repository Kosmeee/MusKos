using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Domain.Models
{
    public class Album
    {
        public int Id { get; set; }

        public Artist Artist { get; set; }

        public List<Track> Tracks { get; set; } = new List<Track>();

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime AddedDate { get; set; }
    }
}

