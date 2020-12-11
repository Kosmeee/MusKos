using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusKos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Data.Configurations
{
   public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
            .ToTable("Artists")
            .HasKey(c => c.Id);
            builder
            .Property(c => c.Nickname).IsRequired();
            builder
            .HasOne(c => c.Genre)
                .WithMany(c => c.Artists);

        }
    }
}
