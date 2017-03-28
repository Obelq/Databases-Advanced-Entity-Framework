using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleAndAdvancedMapping;


namespace Projection
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<Employee, EmployeeDto>()
                .ForMember(em => em.ManagerLastName, cfg => cfg.MapFrom(e => e.Manager.LastName));

                });
                var context = new EmployeeContext();
            
            //SeedEmployees(context);

            var employees = context.Employees
                .Where(e => e.BirthDay.Year < 1990)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeDto>();
            foreach (var employeeDto in employees)
            {
                Console.WriteLine(employeeDto.ToString());
            }

        }

        private static void SeedEmployees(EmployeeContext context)
        {
            context.Database.Initialize(true);
            var employees = SampleEmployeesSeed();
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }

        private static List<Employee> SampleEmployeesSeed()
        {
            var managers = new List<Employee>() {
                new Employee()
                {
                    FirstName = "Steve",
                    LastName = "Jobbsen",
                    BirthDay = new DateTime(1987, 11, 11),
                    Salary = 3000.00m,
                    Address = "Sofia",
                    Subordinates=new HashSet<Employee>(){
                        new Employee()
                        {
                            FirstName = "Stephen",
                            LastName = "Bjorn",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 4300.00m,
                            Address = "Germany"
                        },
                        new Employee()
                        {
                            FirstName = "Kirilyc",
                            LastName = "Lefi",
                            BirthDay = new DateTime(1937, 11, 11),
                            Salary = 4400.00m,
                            Address = "Sofia"
                        }
                    }
                },
                new Employee()
                {
                    FirstName = "Carl",
                    LastName = "Kormac",
                    BirthDay = new DateTime(1997, 11, 11),
                    Salary = 4000.00m,
                    Address = "Sofia",
                    Subordinates=new HashSet<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Jurgen",
                            LastName = "Stratus",
                            BirthDay = new DateTime(1967, 11, 11),
                            Salary = 1000.45m,
                            Address = "Sofia",

                        },
                        new Employee()
                        {
                            FirstName = "Moni",
                            LastName = "Kozinac",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 2030.99m,
                            Address = "Sofia",

                        },
                        new Employee()
                        {
                            FirstName = "Kopp",
                            LastName = "Spidok",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary =2000.21m,
                            Address = "Sofia"
                        }
                    }
                }
            };
            return managers;
        }
    }
}
