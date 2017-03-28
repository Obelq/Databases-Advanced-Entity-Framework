using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string DistributorName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
