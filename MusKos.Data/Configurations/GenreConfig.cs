using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusKos.Domain.Models;

namespace MusKos.Data.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {


        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
            .ToTable("Genres")
            .HasKey(c => c.Id);
            builder
            .Property(c => c.Title).IsRequired();
            
        }
    }
}

  