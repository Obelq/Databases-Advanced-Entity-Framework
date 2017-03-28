using System.ComponentModel.DataAnnotations;

namespace PhotoDatabase.Models
{
    public class Picture
    {
        public Picture()
        {

        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public virtual Album Album { get; set; }
    }
}