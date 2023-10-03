using Advanced_Course.employee;
using HRAdministrationAPI;

namespace Advanced_Course.factory;

public static class EmployeeFactory
{
    public static IEmployee GetEmployee(EmployeeType employeeType,
        int id, string firstName, string lastName, decimal salary)
    {
        return employeeType switch
        {
            EmployeeType.Teacher => new Teacher
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            },
            EmployeeType.HeadDepartment => new HeadDepartment
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            },
            EmployeeType.DeputyHeadMaster => new DeputyMaster
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            },
            _ => throw new ArgumentOutOfRangeException(nameof(employeeType),
                employeeType, "Invalid employee type")
        };
    }

    public static IEmployee GetEmployee2(EmployeeType employeeType,
        int id, string firstName, string lastName, decimal salary)
    {
        IEmployee employee = employeeType switch
        {
            EmployeeType.Teacher => FactoryPattern<IEmployee, Teacher>.GetInstance(),
            EmployeeType.HeadDepartment => FactoryPattern<IEmployee, HeadDepartment>.GetInstance(),
            EmployeeType.DeputyHeadMaster => FactoryPattern<IEmployee, DeputyMaster>.GetInstance(),
            _ => null
        } ?? throw new InvalidOperationException("Invalid employee type");

        employee.Id = id;
        employee.FirstName = firstName;
        employee.LastName = lastName;
        employee.Salary = salary;

        return employee;
    }
}