using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Models;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand
    {
        private SecurityService securityService;
        public LogoutCommand(SecurityService securityService)
        {
            this.securityService = securityService;
        }
        public string Execute()
        {
            User user = SecurityService.GetCurrentUser();

            
            SecurityService.Logout();

            return $"User {user.Username} successfully logged out!";
        }
    }
}
