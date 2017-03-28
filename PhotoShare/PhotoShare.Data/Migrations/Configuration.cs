using System.Data.Entity.Migrations;
using PhotoShare.Models;

namespace PhotoShare.Data.Migrations
{
    internal class Configuration : DbMigrationsConfiguration<PhotoShareContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhotoShareContext context)
        {

            //context.Pictures.AddOrUpdate(p => p.Title, 
            //    new Picture() { Title = "Flower"},
            //    new Picture() { Title = "Radio" },
            //    new Picture() { Title = "Nature" },
            //    new Picture() { Title = "Orange" },
            //    new Picture() { Title = "Grape" });
            //context.Tags.AddOrUpdate(t => t.Name,
            //    new Tag() { Name = "#Dot" },
            //    new Tag() { Name = "#Fruit" },
            //    new Tag() { Name = "#Vegetable" },
            //    new Tag() { Name = "#Red" },
            //    new Tag() { Name = "#Blue" });
            //context.Towns.AddOrUpdate(t => t.Name,
            //    new Town() { Name = "Sofia", Country = "Bulgaria" },
            //    new Town() { Name = "Burgas", Country = "Bulgaria" },
            //    new Town() { Name = "Tokio", Country = "Japan" },
            //    new Town() { Name = "Sydney", Country = "Australia" },
            //    new Town() { Name = "Berlin", Country = "Germany" });
            //context.Users.AddOrUpdate(u => u.Username,
            //    new User() { Username = "Niki", Password = "XrE21ee", Email = "niki@abv.bg" },
            //    new User() { Username = "Ziki", Password = "XF21rr", Email = "Ziki@abv.bg" },
            //    new User() { Username = "Arab", Password = "XrE23tt", Email = "arab@abv.bg" },
            //    new User() { Username = "Asen", Password = "Res23aa", Email = "asen@abv.bg" },
            //    new User() { Username = "George", Password = "Seef111", Email = "george@abv.bg" });
            //context.Albums.AddOrUpdate(a => a.Name,
            //    new Album() { Name = "Esen", IsPublic = true },
            //    new Album() { Name = "Zima", IsPublic = true },
            //    new Album() { Name = "Hibriden", IsPublic = true },
            //    new Album() { Name = "Prolet", IsPublic = true },
            //    new Album() { Name = "Lqto", IsPublic = true });

            //context.SaveChanges();

            //var towns = context.Towns;
            //var users = context.Users;
            //var ar = context.AlbumRoles;
            //var albums = context.Albums;
            //var tags = context.Tags;
            //var pictures = context.Pictures;

            //users.Find(1).BornTown = towns.Find(1);
            //users.Find(1).CurrentTown = towns.Find(2);
            //users.Find(2).BornTown = towns.Find(5);
            //users.Find(2).CurrentTown = towns.Find(1);
            //users.Find(3).BornTown = towns.Find(3);
            //users.Find(4).CurrentTown = towns.Find(3);
            //users.Find(5).BornTown = towns.Find(4);
            //users.Find(5).CurrentTown = towns.Find(5);

            //users.Find(1).Friends.Add(users.Find(2));
            //users.Find(1).Friends.Add(users.Find(3));
            //users.Find(2).Friends.Add(users.Find(3));
            //users.Find(3).Friends.Add(users.Find(2));
            //users.Find(4).Friends.Add(users.Find(2));
            //users.Find(5).Friends.Add(users.Find(3));
            //users.Find(5).Friends.Add(users.Find(2));

            ////ar.AddOrUpdate(x => new {x.User.Username, x.Album.Name} ,
            ////    new AlbumRole() { Role = Role.Owner, User = users.Find(1), Album = albums.Find(2) },
            ////    new AlbumRole() { Role = Role.Viewer, User = users.Find(1), Album = albums.Find(1) },
            ////    new AlbumRole() { Role = Role.Owner, User = users.Find(2), Album = albums.Find(4) },
            ////    new AlbumRole() { Role = Role.Owner, User = users.Find(4), Album = albums.Find(1) },
            ////    new AlbumRole() { Role = Role.Viewer, User = users.Find(5), Album = albums.Find(5) });

            //albums.Find(1).Tags.Add(tags.Find(2));
            //albums.Find(1).Tags.Add(tags.Find(4));
            //albums.Find(1).Pictures.Add(pictures.Find(4));
            //albums.Find(2).Tags.Add(tags.Find(1));
            //albums.Find(2).Pictures.Add(pictures.Find(3));
            //albums.Find(3).Tags.Add(tags.Find(3));
            //albums.Find(3).Pictures.Add(pictures.Find(1));
            //albums.Find(4).Tags.Add(tags.Find(5));
            //albums.Find(4).Pictures.Add(pictures.Find(5));
            //albums.Find(5).Tags.Add(tags.Find(3));
            //albums.Find(5).Pictures.Add(pictures.Find(3));

            //context.SaveChanges();






        }
    }
}
