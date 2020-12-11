using Microsoft.AspNetCore.Identity;

namespace MusKos.Domain.Models.Identity
{
   public class ApplicationUser : IdentityUser
    {
        public Playlist Playlist { get; set; }
    }
}
