﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

       
        public int? BuyerId { get; set; }

        public int SellerId { get; set; }

        public virtual User Buyer { get; set; }

        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
