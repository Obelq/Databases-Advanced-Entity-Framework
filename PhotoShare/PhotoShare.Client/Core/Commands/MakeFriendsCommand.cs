using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class MakeFriendsCommand
    {
        private UserService userService;

        public MakeFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            var user1Name = data[0];
            var user2Name = data[1];

            if (!userService.IsUserExisting(user1Name))
            {
                throw new ArgumentException($"{user1Name} not found!");
            }
            if (!userService.IsUserExisting(user2Name))
            {
                throw new ArgumentException($"{user2Name} not found!");
            }
            if (userService.GetUserByUsername(user1Name).Friends.Contains(userService.GetUserByUsername(user2Name)))
            {
                throw new InvalidOperationException($"{user2Name} is already a friend to {user1Name}");
            }
            userService.MakeFriendship(user1Name, user2Name);
            return $"Friend {user2Name} added to {user1Name}";
        }
    }
}
