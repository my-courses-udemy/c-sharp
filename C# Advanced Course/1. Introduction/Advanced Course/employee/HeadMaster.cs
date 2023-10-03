using HRAdministrationAPI;

namespace Advanced_Course.employee;

public class HeadMaster : EmployeeBase
{
    public override decimal Salary
    {
        get => base.Salary + base.Salary * 0.02m;
    }
}