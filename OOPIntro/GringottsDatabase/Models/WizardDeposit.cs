﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
    public class WizardDeposit
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(60)]
        public string LastName { get; set; }
        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        public int Age { get; set; }

        [StringLength(100)]
        public string MagicWandCreator { get; set; }

        [Range(1, 32767)]
        public int MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup { get; set; }


        public DateTime DepositStartDate { get; set; }


        public decimal DepositAmount { get; set; }


        public decimal DepositInterest { get; set; }


        public decimal DepositCharge { get; set; }


        public DateTime DepositExpirationDate { get; set; }


        public bool IsDepositExpired { get; set; }



    }
}
