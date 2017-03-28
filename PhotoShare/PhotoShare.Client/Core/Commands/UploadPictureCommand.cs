using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class UploadPictureCommand
    {
        private PictureService pictureService;
        private AlbumService albumService;

        public UploadPictureCommand(PictureService pictureService, AlbumService albumService)
        {
            this.pictureService = pictureService;
            this.albumService = albumService;
        }
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            var albumName = data[0];
            var pictureTitle = data[1];
            var pictureFilePath = data[2];
            if (!albumService.IsAlbumExists(albumName))
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }
            pictureService.UploadPicture(albumName,pictureTitle, pictureFilePath);
            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
