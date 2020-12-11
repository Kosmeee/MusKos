using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusKos.Domain.Models;

namespace MusKos.Data.Configurations
{
   public class PlaylistConfig : IEntityTypeConfiguration<Playlist>
    {


        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder
            .ToTable("Playlists")
            .HasKey(c => c.Id);
            builder.HasMany(c => c.Tracks)
                .WithMany(c => c.Playlists)
                .UsingEntity(j => j.ToTable("PlaylistTrack"));
        }
    }
}

