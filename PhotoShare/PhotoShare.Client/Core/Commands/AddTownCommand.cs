using System;
using PhotoShare.Data;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class AddTownCommand
    {
        private TownService townService;

        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            if (this.townService.IsTownExist(townName))
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }
            this.townService.AddTown(townName,country);
            
            return townName + " was added successfully!";

        }

        
    }
}
