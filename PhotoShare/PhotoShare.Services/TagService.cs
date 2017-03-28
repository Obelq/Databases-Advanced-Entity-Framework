using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class TagService
    {
        public void AddTag(string tag)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }
        }

        public bool IsTagExisting(string tag)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tag);
            }
        }

        public bool CheckIfTagsExists(List<string> tags)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                foreach (var tag in tags)
                {
                    if (!context.Tags.Any(t => t.Name == tag))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void AddTagToAlbum(string tagName, string albumName)
        {
            using (var context = new PhotoShareContext())
            {
                Tag tag = context.Tags.SingleOrDefault(x => x.Name == tagName);
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                if (album != null && !album.Tags.Contains(tag))
                {
                    album.Tags.Add(tag);
                    context.SaveChanges();
                }
            }
        }
    }
}
