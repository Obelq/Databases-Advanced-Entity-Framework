using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Patients = new List<Patient>();
        }

        [Key]
        public int MedicamentId { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
