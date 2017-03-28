using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public enum ResourceEnum
    {
        video,
        presentation,
        document,
        other
    }
    public class Resource
    {
        public Resource()
        {

        }
        public Resource(string name, ResourceEnum typeOfResource, string url, Course course)
        {
            this.Licenses = new HashSet<License>();
            this.ResourceName = name;
            this.TypeOfResource = typeOfResource;
            this.URL = url;
            this.Course = course;
            
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string ResourceName { get; set; }

        [Required]
        public ResourceEnum TypeOfResource { get; set; }

        [Required]
        public string URL { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
