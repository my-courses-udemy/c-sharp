using System.Diagnostics;

namespace HelloWorld.members;

public class Members
{
    //? member - private field
    private string _name;
    private string _jobTitle;

    //? member - public field
    public int _age;

    //? member - property - expose jobtitle safely
    //? properties starts with a capital letter
    public string JobTitle
    {
        get { return _jobTitle; }
        set { _jobTitle = value; }
    }

    //? public member method - called for other classes
    public void Introducing(bool isFriend)
    {
    }

    private void SharingPrivateInfo()
    {
    }
    
    //? constructor
    public Members()
    {
    }

    public Members(string name, string jobTitle, int age)
    {
        _name = name;
        _jobTitle = jobTitle;
        _age = age;
    }
    
    //? Member - finalizer - destructor
    //? It can only exist one finalizer
    //? Can't be called
    ~Members()
    {
        //! clean statements
        Console.WriteLine("Deconstruction of members object");
        Debug.Write("Deconstruction of members object");
    }
}