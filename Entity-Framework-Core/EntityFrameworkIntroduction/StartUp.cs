using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                JobTitle = x.JobTitle,
                Salary = x.Salary
            })
            .OrderBy(x => x.EmployeeId)
            .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                Salary = x.Salary
            })
            .Where(x => x.Salary > 50000)
            .OrderBy(x => x.FirstName)
            .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                DepartmentName = x.Department.Name,
                Salary = x.Salary
            })
            .Where(x => x.DepartmentName == "Research and Development")
            .OrderBy(x => x.Salary)
            .ThenByDescending(x => x.FirstName)
            .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakov.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees.Select(x => new
            {
                AddressId = x.AddressId,
                AddressText = x.Address.AddressText
            })
             .OrderByDescending(x => x.AddressId)
             .Take(10)
             .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.AddressText}");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.Manager)
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(x => x.EmployeesProjects.Any(y => y.Project.StartDate.Year >= 2001 && y.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(y => new
                    {
                        ProjectName = y.Project.Name,
                        StartDate = y.Project.StartDate,
                        EndDate = y.Project.EndDate
                    }
                        )
                })
             .Take(10)
             .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.Projects)
                {
                    result.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {(project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished")}");
                }
            }
            return result.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Town)
                .Include(a => a.Employees)
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var address in addresses)
            {
                result.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count()} employees");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeeId == 147)
                .FirstOrDefault();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                result.AppendLine($"{project.Project.Name}");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            List<Department> departments = context.Departments
                .Include(d => d.Manager)
                .Include(d => d.Employees)
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var department in departments)
            {
                result.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var project in projects)
            {
                result.AppendLine($"{project.Name}");
                result.AppendLine($"{project.Description}");
                result.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }
            return result.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.Department)
                .Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12M;
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();
            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.ToUpper().StartsWith("SA"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return result.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var relationsToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            context.RemoveRange(relationsToDelete);
            context.SaveChanges();

            var projectsToDelete = context.Projects
                .Where(p => p.ProjectId == 2)
                .FirstOrDefault();

            context.Remove(projectsToDelete);
            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var project in projects)
            {
                result.AppendLine(project.Name);
            }

            return result.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Town)
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            var employees = context.Employees
                .Include(e => e.Address)
                .Where(e => addresses.Contains(e.Address))
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            context.SaveChanges();

            int count = addresses.Count();
            context.RemoveRange(addresses);
            context.SaveChanges();

            var town = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle");

            context.Remove(town);
            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
