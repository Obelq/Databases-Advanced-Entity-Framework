using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class TownService
    {
        public void AddTown(string townName, string country)
        {
            Town town = new Town
            {
                Name = townName,
                Country = country
            };

            using (var context = new PhotoShareContext())
            {
                context.Towns.Add(town);
                context.SaveChanges();
            }
        }
        public bool IsTownExist(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

        public Town GetTownByTownName(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name == townName);
            }
        }
    }
}
