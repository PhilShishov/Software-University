
namespace Employees.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Employees.Data;
    using Employees.Models;
    using Employees.Services.Interfaces;

    using Microsoft.EntityFrameworkCore;

    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeesContext context;
        private readonly IMapper mapper;

        public EmployeeService(EmployeesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto empDto)
        {
            var employee = this.mapper.Map<Employee>(empDto);

            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public EmployeeDto GetEmployeeById(int employeeId)
        {
            var employee = this.GetEmployeeByIdFromDb(employeeId);

            var empDto = this.mapper.Map<EmployeeDto>(employee);

            return empDto;
        }

        public void SetEmployeeBirthday(int employeeId, DateTime birthday)
        {
            var employee = this.GetEmployeeByIdFromDb(employeeId);

            employee.Birthday = birthday;
            this.context.SaveChanges();
        }

        public void SetEmployeeAddress(int employeeId, string address)
        {
            var employee = this.GetEmployeeByIdFromDb(employeeId);

            employee.Address = address;
            this.context.SaveChanges();
        }

        public string GetEmployeeInfo(int employeeId)
        {
            var empDto = this.GetEmployeeById(employeeId);

            return $"ID: {empDto.Id} - {empDto.FirstName} {empDto.LastName} - ${empDto.Salary:F2}";
        }

        public string GetEmployeePersonalInfo(int employeeId)
        {
            var empDto = this.GetEmployeeById(employeeId);

            var sb = new StringBuilder();
            sb.AppendLine($"ID: {empDto.Id} - {empDto.FirstName} {empDto.LastName} - ${empDto.Salary:F2}");

            string birthday = "[no birthday entered]";

            if (empDto.Birthday != null)
            {
                birthday = empDto.Birthday.Value.ToString("dd-MM-yyyy");
            }

            sb.AppendLine($"Birthday: {birthday}");

            string address = "[no address entered]";

            if (empDto.Address != null)
            {
                address = empDto.Address;
            }

            sb.Append($"Adress: {address}");

            return sb.ToString();
        }

        public void SetEmployeeManager(int employeeId, int managerId)
        {
            var employee = this.GetEmployeeByIdFromDb(employeeId);
            var manager = this.GetEmployeeByIdFromDb(managerId);

            if (manager.Manager != null && manager.Manager.Id == employee.Id)
            {
                throw new ArgumentException($"Employee with ID {employee.Id} is already manager of {manager.Id}!");
            }

            employee.Manager = manager;
            this.context.SaveChanges();
        }

        public string GetManagerInfo(int employeeId)
        {
            var employee = this.GetEmployeeByIdFromDb(employeeId);
            var managerDto = this.mapper.Map<ManagerDto>(employee);

            var sb = new StringBuilder();
            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.SubordinatesCount}");

            foreach (var subordinate in managerDto.Subordinates)
            {
                sb.AppendLine($"    - {subordinate.FirstName} {subordinate.LastName} - ${subordinate.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public IList<EmployeeDto> GetEmployeesOlderThan(int age)
        {
            var employees = this.context
            .Employees
            .Include(e => e.Manager)
            .Where(e => e.Birthday != null && Helpers.CalcCurrentAge(e.Birthday.Value) > age)
            .OrderByDescending(e => e.Salary)
            .ProjectTo<EmployeeDto>(this.mapper.ConfigurationProvider)
            .ToList();

            return employees;
        }

        private Employee GetEmployeeByIdFromDb(int employeeId)
        {
            var employee = this.context
                .Employees
                .Include(e => e.Subordinates)
                .SingleOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {employeeId} not found.");
            }

            return employee;
        }
    }
}
