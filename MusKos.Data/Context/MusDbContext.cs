

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusKos.Domain.Models.Identity;

namespace MusKos.Data.Context
{
    public class MusDbContext : IdentityDbContext<ApplicationUser>, IMusDbContext
    {
        public MusDbContext(DbContextOptions<MusDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
