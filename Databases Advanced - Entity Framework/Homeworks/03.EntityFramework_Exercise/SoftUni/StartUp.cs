
namespace SoftUni
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        //public static string GetEmployeesFullInformation(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.LastName,
        //            e.MiddleName,
        //            e.JobTitle,
        //            e.Salary,
        //            e.EmployeeId
        //        })
        //        .OrderBy(x => x.EmployeeId)
        //        .ToList();

        //    foreach (var employee in employees)
        //    {
        //        sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees
        //        .Where(e => e.Salary > 50000)
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.Salary,
        //        })
        //        .OrderBy(e => e.FirstName)
        //        .ToList();

        //    foreach (var employee in employees)
        //    {
        //        sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees
        //        .Where(e => e.Department.Name == "Research and Development")
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.LastName,
        //            e.Department.Name,
        //            e.Salary,
        //        })
        //        .OrderBy(e => e.Salary)
        //        .ThenByDescending(e => e.FirstName)
        //        .ToList();

        //    foreach (var employee in employees)
        //    {
        //        sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string AddNewAddressToEmployee(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var address = new Address
        //    {
        //        AddressText = "Vitoshka 15",
        //        TownId = 4
        //    };

        //    //context.Addresses.Add(address);

        //    var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
        //    nakov.Address = address;

        //    context.SaveChanges();

        //    var employeeAddresses = context.Employees
        //        .OrderByDescending(e => e.AddressId)
        //        .Select(e => e.Address.AddressText)
        //        .Take(10)
        //        .ToList();

        //    foreach (var employeeAddress in employeeAddresses)
        //    {
        //        sb.AppendLine($"{employeeAddress}");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetEmployeesInPeriod(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees
        //        .Where(e => e.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year <= 2003))
        //        .Select(e => new
        //        {
        //            EmployeeFullName = e.FirstName + " " + e.LastName,
        //            ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
        //            Projects = e.EmployeesProjects.Select(p => new
        //            {
        //                ProjectName = p.Project.Name,
        //                StartDate = p.Project.StartDate,
        //                EndDate = p.Project.EndDate,
        //            })
        //            .ToList()
        //        })
        //        .Take(10)
        //        .ToList();

        //    foreach (var employee in employees)
        //    {
        //        sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

        //        foreach (var project in employee.Projects)
        //        {
        //            var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        //            var endDate = project.EndDate.HasValue ?
        //                project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
        //                : "not finished";

        //            sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
        //        }
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetAddressesByTown(SoftUniContext context)
        //{

        //    StringBuilder sb = new StringBuilder();

        //    var addresses = context.Addresses
        //        .Select(a => new
        //        {
        //            AddressText = a.AddressText,
        //            TownName = a.Town.Name,
        //            EmployeeCount = a.Employees.Count,
        //        })
        //        .OrderByDescending(a => a.EmployeeCount)
        //        .ThenBy(a => a.TownName)
        //        .ThenBy(a => a.AddressText)
        //        .Take(10)
        //        .ToList();

        //    foreach (var address in addresses)
        //    {
        //        sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetEmployee147(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employee147 = context.Employees
        //        .Where(e => e.EmployeeId == 147)
        //        .Select(e => new
        //        {
        //            EmployeeFullName = e.FirstName + " " + e.LastName,
        //            e.JobTitle,
        //            Projects = e.EmployeesProjects
        //                    .Select(ep => ep.Project.Name)
        //                    .OrderBy(p => p)
        //                    .ToList()
        //        })
        //            .First();

        //    sb.AppendLine($"{employee147.EmployeeFullName} - {employee147.JobTitle}{Environment.NewLine}{String.Join(Environment.NewLine, employee147.Projects)} ");

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var departments = context.Departments
        //        .Where(e => e.Employees.Count > 5)
        //        .OrderBy(e => e.Employees.Count)
        //        .ThenBy(d => d.Name)
        //        .Select(d => new
        //        {
        //            DepartmentName = d.Name,
        //            ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
        //            Employees = d.Employees.Select(e => new
        //            {
        //                EmployeeFullName = e.FirstName + " " + e.LastName,
        //                JobTitle = e.JobTitle
        //            })
        //            .OrderBy(e => e.EmployeeFullName)
        //            .ToList()
        //        })
        //        .ToList();

        //    foreach (var department in departments)
        //    {
        //        sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

        //        foreach (var employee in department.Employees)
        //        {
        //            sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
        //        }
        //    }

        //    return sb.ToString().TrimEnd();
        //}


        //public static string GetLatestProjects(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var projects = context.Projects
        //        .OrderByDescending(p => p.StartDate)
        //        .Take(10)
        //        .Select(p => new
        //        {
        //            ProjectName = p.Name,
        //            ProjectDescription = p.Description,
        //            StartDate = p.StartDate
        //        })
        //        .OrderBy(p => p.ProjectName)
        //        .ToList();

        //    foreach (var project in projects)
        //    {
        //        var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

        //        sb.AppendLine($"{project.ProjectName}{Environment.NewLine}{project.ProjectDescription}{Environment.NewLine}{project.StartDate}");
        //    }
        //    return sb.ToString().TrimEnd();
        //}

        //public static string IncreaseSalaries(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    context.Employees
        //    .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
        //        .Contains(e.Department.Name))
        //    .ToList()
        //    .ForEach(e => e.Salary *= 1.12m);

        //    context.SaveChanges();

        //    var employees =  context.Employees
        //        .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
        //            .Contains(e.Department.Name))
        //        .OrderBy(e => e.FirstName)
        //        .ThenBy(e => e.LastName)
        //        .ToList();

        //    foreach (var employee in employees)
        //    {
        //        sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        //public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var employees = context.Employees
        //        .Where(e => EF.Functions.Like(e.FirstName, "sa%"))
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.LastName,
        //            JobTitle = e.JobTitle,
        //            Salary = e.Salary
        //        })
        //        .OrderBy(e => e.FirstName)
        //        .ThenBy(e => e.LastName)
        //        .ToList();

        //    foreach (var employee in employees)
        //    {
        //        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            var employeeProjects = context.EmployeesProjects.Where(p => p.ProjectId == 2).ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            //foreach (var employeeProject in employeeProjects)
            //{
            //    context.EmployeesProjects.Remove(employeeProject);
            //}

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            foreach (var currentProject in projects)
            {
                sb.AppendLine(currentProject);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            //string townName = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList()
                .ForEach(e => e.AddressId = null);

            int addressesCount = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .Count();

            context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            context.Towns
                .Remove(context.Towns
                    .SingleOrDefault(t => t.Name == "Seattle"));

            context.SaveChanges();

            sb.AppendLine($"{addressesCount} {(addressesCount == 1 ? "address" : "addresses")} in Seattle {(addressesCount == 1 ? "was" : "were")} deleted");

            return sb.ToString().TrimEnd();
        }
    }
}
