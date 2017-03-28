using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HospitalDB.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Visitations = new List<Visitation>();
            this.Diagnoses = new List<Diagnose>();
            this.Medicaments = new List<Medicament>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]([.\-_A-Za-z]*[A-Za-z])*@[A-Za-z]+\.[A-Za-z]+$")]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        public bool HasMedicalInsurance { get; set; }


        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }

        


    }
}
