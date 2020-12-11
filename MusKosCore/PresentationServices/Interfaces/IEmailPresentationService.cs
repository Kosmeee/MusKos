using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusKosCore.PresentationServices.Interfaces
{
    public interface IEmailPresentationService
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
