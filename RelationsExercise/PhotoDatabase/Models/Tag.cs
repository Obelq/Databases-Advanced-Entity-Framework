using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoDatabase.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Photographers = new HashSet<Photographer>();
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Index("Name", IsUnique = true), StringLength(500)]
        public string Name { get; set; }

        public virtual ICollection<Photographer> Photographers { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
