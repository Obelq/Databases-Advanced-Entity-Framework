using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class PictureService
    {
        public void UploadPicture(string albumName, string pictureTitle, string pictureFilePath)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Picture picture = new Picture()
                {
                    Title = pictureTitle,
                    Path = pictureFilePath
                };
                picture.Albums.Add(album);
                context.Pictures.Add(picture);
                context.SaveChanges();
            }
        }
    }
}
