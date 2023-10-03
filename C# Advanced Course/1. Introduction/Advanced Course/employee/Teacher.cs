using HRAdministrationAPI;

namespace Advanced_Course.employee;

public class Teacher : EmployeeBase
{
    public override decimal Salary
    {
        get => base.Salary + base.Salary * 0.03m;
    }
}