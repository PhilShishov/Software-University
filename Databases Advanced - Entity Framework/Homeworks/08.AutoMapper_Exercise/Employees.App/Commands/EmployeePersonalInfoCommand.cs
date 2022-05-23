
namespace EmployeesMapping.App.Commands
{
    using Employees.Services.Interfaces;

    using EmployeesMapping.App.Commands.Interfaces;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeService employeeService;

        public EmployeePersonalInfoCommand(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] arguments)
        {
            int employeeId = int.Parse(arguments[0]);

            return this.employeeService.GetEmployeePersonalInfo(employeeId);
        }
    }
}