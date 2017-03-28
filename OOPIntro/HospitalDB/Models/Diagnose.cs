using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Diagnose
    {
        public Diagnose()
        {
            this.Patients = new List<Patient>();
        }

        [Key]
        public int DiagnoseId { get; set; }

        [StringLength(60)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        
        public virtual ICollection<Patient> Patients { get; set; }

    }
}
