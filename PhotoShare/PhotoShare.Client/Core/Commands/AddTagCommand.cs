using System;
using PhotoShare.Data;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using Models;

    using Utilities;

    public class AddTagCommand
    {
        private TagService tagService;

        public AddTagCommand(TagService tagService)
        {
            this.tagService = tagService;
        }
        // AddTag <tag>
        public string Execute(string[] data)
        {
            string tag = data[0].ValidateOrTransform();
            if (tagService.IsTagExisting(tag))
            {
                throw new ArgumentException($"Tag {tag} exists!");
            }
            tagService.AddTag(tag);

            return "Tag" + tag + " was added successfully!";
        }
    }
}
