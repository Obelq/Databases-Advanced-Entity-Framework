using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SimpleAndAdvancedMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(dto => dto.SubordinatesCount,
                        configExpression => configExpression.MapFrom(e => e.Subordinates.Count));
            });
            var employee =
                new Employee()
                {
                    FirstName = "Kiro",
                    LastName = "Kirov",
                    Salary = 1900,
                    Address = "Sofia ul. Kiril 15",
                    BirthDay = new DateTime(1992, 01, 12)

                };
            List<Employee> managers = SampleEmployeesSeed();
            var managerDtos = Mapper.Map<List<Employee>,List<ManagerDto>>(managers);
            foreach (var mDto in managerDtos)
            {
                Console.WriteLine(mDto.ToString());
                
            }
            //var employeeDTO = Mapper.Map<EmployeeDto>(employee);

        }

        private static List<Employee> SampleEmployeesSeed()
        {
            var managers = new List<Employee>() {
                new Employee()
                {
                    FirstName = "Steve",
                    LastName = "Jobbsen",
                    BirthDay = new DateTime(1997, 11, 11),
                    Salary = 3000.00m,
                    Address = "Sofia",
                    IsOnHoliday = false,
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
                            BirthDay = new DateTime(1997, 11, 11),
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
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 1000.45m,
                            Address = "Sofia",
                            IsOnHoliday = false,

                        },
                        new Employee()
                        {
                            FirstName = "Moni",
                            LastName = "Kozinac",
                            BirthDay = new DateTime(1997, 11, 11),
                            Salary = 2030.99m,
                            Address = "Sofia",
                            IsOnHoliday = false,

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
