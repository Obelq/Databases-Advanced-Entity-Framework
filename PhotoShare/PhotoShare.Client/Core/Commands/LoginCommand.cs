using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Models;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    class LoginCommand
    {
        private SecurityService securityService;
        public LoginCommand(SecurityService securityService)
        {
            this.securityService = securityService;
        }
        public string Execute(string[] data)
        {
            var username = data[0];
            var password = data[1];

            SecurityService.Login(username, password);
            return $"User {username} successfully logged in!";
        }
    }
}
