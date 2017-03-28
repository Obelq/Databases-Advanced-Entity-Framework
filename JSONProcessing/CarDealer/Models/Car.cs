using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Parts = new List<Part>();
            this.Sales = new List<Sale>();
        }
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
