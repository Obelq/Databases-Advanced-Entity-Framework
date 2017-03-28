using PhotoShare.Data;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    public class DeleteUser
    {
        private UserService userService;

        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }
        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            if (!userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            if (userService.IsUserDeleted(username))
            {
                throw new InvalidOperationException($"User {username} is already deleted!");
            }

            userService.DeleteUser(username);

            return $"User {username} was deleted from the database!";

        }
    }
}
