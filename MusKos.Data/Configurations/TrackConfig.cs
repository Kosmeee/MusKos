using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusKos.Domain.Models;

namespace MusKos.Data.Configurations
{
   public class TrackConfig : IEntityTypeConfiguration<Track>
    {


        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder
            .ToTable("Tracks")
            .HasKey(c => c.Id);
            builder
            .Property(c => c.Title).IsRequired();

            builder.HasOne(c => c.Artist)
                .WithMany(c => c.Tracks)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Album)
                .WithMany(c => c.Tracks)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Genre)
               .WithMany(c => c.Tracks)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
