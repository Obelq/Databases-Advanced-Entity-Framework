using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoDatabase.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.RegisterDate = DateTime.Now;
            this.Albums = new HashSet<PhotographerAlbum>();
            this.Tags = new HashSet<Tag>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<PhotographerAlbum> Albums { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
