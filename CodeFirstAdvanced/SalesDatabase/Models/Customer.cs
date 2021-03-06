﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Models
{
    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> SalesForCustomer { get; set; }
    }
}
