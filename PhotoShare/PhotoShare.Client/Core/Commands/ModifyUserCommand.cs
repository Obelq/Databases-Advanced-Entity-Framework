using System.Linq;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ModifyUserCommand
    {
        private UserService userService;
        private TownService townService;

        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            var username = data[0];
            var property = data[1];
            var value = data[2];

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var user = this.userService.GetUserByUsername(username);

            if (property == "Password")
            {
                if (!(value.Any(c => char.IsLower(c)) && value.Any(c => char.IsDigit(c))))
                {
                    throw new ArgumentException($"Value {value} not valid!\nInvalid password!");
                }
                user.Password = value;
            }
            else if (property == "BornTown")
            {
                if (this.townService.IsTownExist(value))
                {
                    throw new ArgumentException($"Value {value} not valid!\nTown not found");
                }
                user.BornTown = townService.GetTownByTownName(value);
            }
            else if (property == "Current Town")
            {
                if (this.townService.IsTownExist(value))
                {
                    throw new ArgumentException($"Value {value} not valid!\nTown not found");
                }
                user.CurrentTown = townService.GetTownByTownName(value);
            }
            else
            {
                throw new ArgumentException($"Property {property} not supported!");
            }
            this.userService.UpdateUser(user);

            return $"User {username} {property} is {value}.";
        }
    }
}
