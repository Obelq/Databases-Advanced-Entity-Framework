using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftuniContext();

            //EmployeesFullInformation(context);

            //EmployeesWithSalaryOver50000(context);

            //EmployeesFromSeattle(context);

            //AddingNewAddressAndUpdatingEmployee(context);

            //FindEmployeesInPeriod(context);

            //AddressesByTownName(context);

            //EmployeeWithId147(context);

            //DepartmentsWithMoreThan5Employees(context);

            //FindLatest10Projects(context);

            //FindEmployeesByFirstName(context);

            //FindEmployeesByFirstNameStartingWIthSA(context);

            DeleteProjectById(context);

            
        }

        private static void DeleteProjectById(SoftuniContext context)
        {
            //var project = context.Projects.Find(2);
            //project.Employees.Clear();
            //context.Projects.Remove(project);
            //context.SaveChanges();
            var projects = context.Projects.Take(10);
            foreach (var p in projects)
            {
                Console.WriteLine(p.Name);
            }

        }

        private static void FindEmployeesByFirstNameStartingWIthSA(SoftuniContext context)
        {
            var employees = context.Employees.Where(e => e.FirstName.Substring(0, 2) == "Sa").ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            }
        }

        private static void FindEmployeesByFirstName(SoftuniContext context)
        {
            var employees = context
                .Employees.Where(e =>
                e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services").ToList();
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }
            context.SaveChanges();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            }
            
        }

        private static void FindLatest10Projects(SoftuniContext context)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .ThenBy(p => p.Name)
                .Skip(2).Take(10).ToList();
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            }
        }

        private static void DepartmentsWithMoreThan5Employees(SoftuniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ToList();
            foreach (var department in departments)
            {
                Console.WriteLine(department.Name + " " + department.Employee.FirstName);
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                }
            }
        }

        private static void EmployeeWithId147(SoftuniContext context)
        {
            var employee = context.Employees.Find(147);
            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            var projects = employee.Projects.Select(p => p.Name).OrderBy(p => p).ToList();
            foreach (var project in projects)
            {
                Console.WriteLine(project);
            }
        }

        private static void AddressesByTownName(SoftuniContext context)
        {
            var addresses = context.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name).Take(10).ToList();
            foreach (var a in addresses)
            {
                Console.WriteLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees");
            }
        }

        private static void FindEmployeesInPeriod(SoftuniContext context)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var employyes = context.Employees
                 .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
                 .Take(30);
            foreach (var e in employyes)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} {p.StartDate:M/d/yyyy h:mm:ss tt} {p.EndDate:M/d/yyyy h:mm:ss tt}");
                }
            }
        }

        private static void AddingNewAddressAndUpdatingEmployee(SoftuniContext context)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };
            var nakov = context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
            nakov.Address = address;
            context.SaveChanges();
            var addresses = context.Employees
                .OrderByDescending(e => e.AddressID)
                .Select(e => e.Address.AddressText)
                .Take(10);
            foreach (var a in addresses)
            {
                Console.WriteLine(a);
            }
            

        }

        private static void EmployeesFromSeattle(SoftuniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }
        }

        private static void EmployeesWithSalaryOver50000(SoftuniContext context)
        {
            var employees = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

        }

        private static void EmployeesFullInformation(SoftuniContext context)
        {
            var employees = context.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            }
        }
    }
}
