using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    class ListFriendsCommand
    {
        private UserService userService;

        public ListFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }
        public string Execute(string[] data)
        {
            var username = data[0];
            if (!userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            if (!userService.HasFriends(username))
            {
                throw new ArgumentException($"No friends for this user.");
            }
            var result = "Friends:" + $"{Environment.NewLine}-" + string.Join($"{Environment.NewLine}-", userService.ListUsers(username).Select(x => x.Username).ToList());
            return result;
        }
    }
}
