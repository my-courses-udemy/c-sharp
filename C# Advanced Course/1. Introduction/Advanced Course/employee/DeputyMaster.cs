using HRAdministrationAPI;

namespace Advanced_Course.employee;

public class DeputyMaster : EmployeeBase
{
    public override decimal Salary
    {
        get => base.Salary + base.Salary * 0.01m;
    }
}