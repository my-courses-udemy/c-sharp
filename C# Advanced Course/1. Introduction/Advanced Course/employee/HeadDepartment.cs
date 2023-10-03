using HRAdministrationAPI;

namespace Advanced_Course.employee;

public class HeadDepartment: EmployeeBase
{
    public override decimal Salary
    {
        get => base.Salary + base.Salary * 0.07m;
    }
}