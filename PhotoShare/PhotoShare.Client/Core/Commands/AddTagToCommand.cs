using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class AddTagToCommand
    {
        private TagService tagService;
        private AlbumService albumService;

        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            var albumName = data[0];
            var tagName = data[1];
            if (!albumService.IsAlbumExists(albumName))
            {
                throw new ArgumentException($"Album {albumName} do not exist!");
            }
            if (!tagService.IsTagExisting(tagName))
            {
                throw new ArgumentException($"Tag {tagName} do not exist!");
            }
            tagService.AddTagToAlbum(tagName, albumName);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
