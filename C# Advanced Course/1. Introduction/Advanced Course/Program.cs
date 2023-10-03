// See https://aka.ms/new-console-template for more information

using Advanced_Course;
using Advanced_Course.delegateExample;
using Advanced_Course.factory;
using Advanced_Course.funcLambdaExpr;
using HRAdministrationAPI;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<IEmployee> employees = new List<IEmployee>();
        SeedData(employees);

        employees
            .ForEach(e =>
            {
                Console
                    .WriteLine("Salary for {0} {1} is {2}", e.FirstName, e.LastName, e.Salary);
            });
        Console.WriteLine("The total salary is: {0}", employees.Sum(e => e.Salary));
        Console.WriteLine($"Total salary is: {employees.Sum(e => e.Salary)}");

        //! LINQ - Language Integrated Query
        var employedNames = employees
            .Where(e => e.Salary > 3000)
            .Select(e => e)
            .ToList();

        DelegateExample.main();
        ExampleLambda.main();
    }

    //! Generics introduce the concept of type parameters to .NET Framework types and methods.
    static void SeedData(List<IEmployee> employees)
    {
        IEmployee employee1 = EmployeeFactory.GetEmployee2(EmployeeType.Teacher,
            1, "Shon", "Fisher", 48000);
        IEmployee employee2 = EmployeeFactory.GetEmployee2(EmployeeType.Teacher,
            1, "Bob", "Fisher", 41000);
        IEmployee employee3 = EmployeeFactory.GetEmployee2(EmployeeType.Teacher,
            1, "Ruben", "Fisher", 21000);
        IEmployee employee4 = EmployeeFactory.GetEmployee2(EmployeeType.Teacher,
            1, "Mark", "Fisher", 88000);

        employees.Add(employee1);
        employees.Add(employee2);
        employees.Add(employee3);
        employees.Add(employee4);
    }
}