using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAndAdvancedMapping
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Subordinates = new HashSet<EmployeeDto>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> Subordinates { get; set; }

        public int SubordinatesCount { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.FirstName} {this.LastName} | Employees: {this.SubordinatesCount}");
            foreach (var s in Subordinates)
            {
                sb.Append(s.ToString());
            }
            return sb.ToString();
        }
    }
}
