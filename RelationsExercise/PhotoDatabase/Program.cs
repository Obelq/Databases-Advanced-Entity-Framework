using PhotoDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhotoContext();
            //context.Database.Initialize(true);

            //AddPhotographers(context);

            //AddAlbumsAndPhotos(context);
            


        }

        private static void AddAlbumsAndPhotos(PhotoContext context)
        {
            var album1 = new Album()
            {
                Name = "Cvetq",
                BackgroundColor = "red",
                IsPublic = false,
                //Photographer = context.Photographers.Find(2)

            };
            var album2 = new Album()
            {
                Name = "Circles",
                BackgroundColor = "green",
                IsPublic = true,
                //Photographer = context.Photographers.Find(3)

            };
            var album3 = new Album()
            {
                Name = "Landscapes",
                BackgroundColor = "blue",
                IsPublic = false,
                //Photographer = context.Photographers.Find(4)

            };
            var album4 = new Album()
            {
                Name = "People",
                BackgroundColor = "red",
                IsPublic = true,
                //Photographer = context.Photographers.Find(1)

            };
            context.Albums.AddRange(new[] { album1, album2, album3, album4 });

            var picture1 = new Picture()
            {
                Title = "Roza",
                Caption = "Mnogo rozi",
                Path = "C:/Pictures/",
                Album = album1
            };
            var picture2 = new Picture()
            {
                Title = "Pompa",
                Caption = "Voda",
                Path = "C:/Pictures/",
                Album = album4
            };
            var picture3 = new Picture()
            {
                Title = "Grozde",
                Caption = "Malkoto zrunce",
                Path = "C:/Pictures/",
                Album = album2
            };
            var picture4 = new Picture()
            {
                Title = "Rakiq",
                Caption = "Mnogo rakiq",
                Path = "C:/Pictures/",
                Album = album1
            };
            var picture5 = new Picture()
            {
                Title = "Treva",
                Caption = "Mnogo treva",
                Path = "C:/Pictures/",
                Album = album3
            };
            var picture6 = new Picture()
            {
                Title = "Mag",
                Caption = "Mnogo magove",
                Path = "C:/Pictures/",
                Album = album1
            };
            var picture7 = new Picture()
            {
                Title = "Rezachka",
                Caption = "Srqzvashto",
                Path = "C:/Pictures/",
                Album = album2
            };
            context.Pictures.AddRange(new[] { picture1, picture2, picture3, picture4, picture5, picture6, picture7 });
            context.SaveChanges();
        }

        private static void AddPhotographers(PhotoContext context)
        {
            var photographer1 = new Photographer()
            {
                Username = "gincho",
                Password = "1234",
                Email = "gincho@abv.bg"
            };
            var photographer2 = new Photographer()
            {
                Username = "pesho",
                Password = "1234",
                Email = "pesho@abv.bg"
            };
            var photographer3 = new Photographer()
            {
                Username = "misho",
                Password = "1234",
                Email = "misho1992toshev@abv.bg"
            };
            var photographer4 = new Photographer()
            {
                Username = "gabi",
                Password = "1234",
                Email = "gabriel@abv.bg"
            };
            context.Photographers.AddRange(new[] { photographer1, photographer2, photographer3, photographer4 });
            context.SaveChanges();
        }
    }
}
