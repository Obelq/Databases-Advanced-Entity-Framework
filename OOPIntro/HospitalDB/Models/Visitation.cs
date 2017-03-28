using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Visitation
    {
        public Visitation()
        {
            this.Patients = new List<Patient>();
            this.Doctors = new List<Doctor>();
        }

        [Key]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
