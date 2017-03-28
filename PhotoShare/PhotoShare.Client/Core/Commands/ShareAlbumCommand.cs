using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ShareAlbumCommand
    {
        private AlbumService albumService;
        private UserService userService;
        public ShareAlbumCommand(AlbumService albumService, UserService userService)
        {
            this.albumService = albumService;
            this.userService = userService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            var albumId = int.Parse(data[0]);
            var username = data[1];
            var permission = data[2];

            if (!albumService.IsAlbumExistsById(albumId))
            {
                throw new ArgumentException($"Album with id = {albumId} not found!");
            }
            if (!userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            if (permission != "Owner" && permission != "Viewer")
            {
                throw new Exception($"Permission must be either “Owner” or “Viewer”!");
            }
            albumService.ShareAlbum(albumId, username, permission);
            return $"Username {username} added to album {albumId} ({permission})";
        }
    }
}
