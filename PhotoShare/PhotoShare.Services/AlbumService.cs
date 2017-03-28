using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class AlbumService
    {
        public void AddAlbum(string username, string albumTitle,Color color, List<string> tags)
        {
            using (var context = new PhotoShareContext())
            {
                var album = new Album()
                {

                    Name = albumTitle,
                    BackgroundColor = color,
                    Tags = context.Tags.Where(t => tags.Contains(t.Name)).ToList()
                };
                User owner = context.Users.SingleOrDefault(u => u.Username == username);

                if (owner != null)
                {
                    var albumRole = new AlbumRole()
                    {
                        User = owner,
                        Album = album,
                        Role = Role.Owner
                    };

                    album.AlbumRoles.Add(albumRole);
                    context.Albums.Add(album);
                    context.SaveChanges();
                }
            }
            

        }

        public bool IsAlbumExists(string name)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == name);
            }
        }
        public bool IsAlbumExistsById(int id)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Id == id);
            }
        }

        public void ShareAlbum(int albumId, string username, string permission)
        {
            using (var context = new PhotoShareContext())
            {
                Role role;
                User user = context.Users.SingleOrDefault(u => u.Username == username);
                Album album = context.Albums.SingleOrDefault(a => a.Id == albumId);
                bool roleParsed = Enum.TryParse(permission, out role);
                AlbumRole albumRole = new AlbumRole()
                {
                    Role = role,
                    User = user,
                    Album = album
                };
                context.AlbumRoles.Add(albumRole);
                context.SaveChanges();
            }
        }
    }
}
