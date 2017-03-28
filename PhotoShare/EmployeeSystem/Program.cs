using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmployeeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeesContext context = new EmployeesContext();
            Stopwatch stopwatch = new Stopwatch();
            long timePassed = 0L;
            int testCount = 1; // Amount of tests to perform
            for (int i = 0; i < testCount; i++)
            {
                // Clear all query cache
                context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
                stopwatch.Start();

                // TODO: Method to execute query
                OptimizedQuery(context);

                stopwatch.Stop();
                timePassed += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TimeSpan averageTimePassed = TimeSpan.FromMilliseconds(timePassed / (double)testCount);
            Console.WriteLine(averageTimePassed);

        }

        public static void OptimizedQuery(EmployeesContext context)
        {
            var employees = context.Employees
                .Where(e => e.Employees1
                .Any(s => s.Address.Town.Name.StartsWith("B")))
                .Distinct()
                 .ToList();

            foreach (Employee e in employees)
            {
                string result = $"{e.FirstName}";
            }

        }
        public static void ToListOrderBy(EmployeesContext context)
        {
            var employees = context.Employees.Include("Department")
                .ToList()
                .OrderBy(e => e.Department.Name)
                .ThenBy(e => e.FirstName);
        }
        public static void OrderByToList(EmployeesContext context)
        {
            var employees = context.Employees.Include("Department")
                .OrderBy(e => e.Department.Name)
                .ThenBy(e => e.FirstName)
                .ToList();
        }
        public static void QueryWithEagerLoading3(EmployeesContext context)
        {

            List<Employee> employees = context.Employees.Include("Department").Include("EmployeesProjects")
                .Where(e => e.EmployeesProjects.Count == 1).ToList();

            foreach (var e in employees)
            {
                string result = $"{e.FirstName} - {e.Department.Name}";
            }
        }

        public static void QueryWithLazyLoading3(EmployeesContext context)
        {
            var employees = context.Employees.Where(e => e.EmployeesProjects.Count == 1).ToList();
            foreach (var e in employees)
            {
                string result = $"{e.FirstName} - {e.Department.Name}";
            }
        }
        public static void QueryWithEagerLoading2(EmployeesContext context)
        {
            List<Employee> employees = context.Employees.Include("Department").Include("Address").Where(u => u.Salary > 3000).ToList();

            foreach (var e in employees)
            {
                string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            }
        }

        public static void QueryWithLazyLoading2(EmployeesContext context)
        {
            var employees = context.Employees.Where(u => u.Salary > 3000).ToList();
            foreach (var e in employees)
            {
                string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            }
        }
        public static void QueryWithEagerLoading(EmployeesContext context)
        {
            List<Employee> employees = context.Employees.Include("Department").Include("Address").ToList();

            foreach (var e in employees)
            {
                string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            }
        }

        public static void QueryWithLazyLoading(EmployeesContext context)
        {
            var employees = context.Employees.ToList();
            foreach (var e in employees)
            {
                string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            }
        }
        public static void SelectQueryWithEagerLoading(EmployeesContext context)
        {
            
            var employees = context.Employees.Include("Department").Include("Address").Select(e => new
            {
                Name = e.FirstName,
                DepartmentName = e.Department.Name,
                Address = e.Address.AddressText
            });
            foreach (var e in employees)
            {
                string result = $"{e.Name} - {e.DepartmentName} - {e.Address}";
            }
        }

        public static void SelectQueryWithLazyLoading(EmployeesContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                Name = e.FirstName,
                DepartmentName = e.Department.Name,
                Address = e.Address.AddressText
            });
            foreach (var e in employees)
            {
                string result = $"{e.Name} - {e.DepartmentName} - {e.Address}";
            }
        }
    }

    
}
