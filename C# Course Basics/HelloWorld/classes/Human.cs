namespace HelloWorld.classes;

public class Human
{
    //? member variable
    //? By default is protected
    private string _name;
    private string _lastname;
    private int _age;

    public Human()
    {
        Console.WriteLine("Default Constructor");
    }

    public Human(string name, string lastname, int age)
    {
        _name = name;
        _lastname = lastname;
        _age = age; 
    }

    //? member
    public void IntroduceMyself()
    {
        Console.WriteLine("/greetings, {0} {1} {2}", _name, _lastname, _age);
    }
}