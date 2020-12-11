using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusKos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusKos.Data.Configurations
{
    public class AlbumConfig : IEntityTypeConfiguration<Album>
    {
       

        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
            .ToTable("Albums")
            .HasKey(c => c.Id);
            builder
            .Property(c => c.Title).IsRequired();
            builder
            .HasOne(c => c.Artist)
                .WithMany(c => c.Albums);
                
        }
    }
}
