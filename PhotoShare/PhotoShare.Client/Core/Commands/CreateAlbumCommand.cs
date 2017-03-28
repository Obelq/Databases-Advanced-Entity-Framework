using System.Collections.Generic;
using System.Linq;
using PhotoShare.Models;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class CreateAlbumCommand
    {
        private AlbumService albumService;
        private UserService userService;
        private TagService tagService;
        public CreateAlbumCommand(AlbumService albumService, UserService userService, TagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            var userName = data[0];
            var albumTitle = data[1];
            var bgColor = data[2];
            var tags = data.Skip(3).ToList();
            Color color;

            if (!userService.IsUserExisting(userName))
            {
                throw new ArgumentException($"User {userName} not found!");
            }

            if (albumService.IsAlbumExists(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            bool isColorValid = Color.TryParse(bgColor, out color);
            if (!isColorValid)
            {
                throw new ArgumentException($"Color {bgColor} not found!");
            }
            
            if (!tagService.CheckIfTagsExists(tags))
            {
                throw new ArgumentException("Invalid tags!");
            }
            albumService.AddAlbum(userName, albumTitle, color, tags);
            return $"Album {albumTitle} successfully created!";
        }
    }
}
