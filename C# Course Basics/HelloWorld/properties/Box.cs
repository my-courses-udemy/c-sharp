namespace HelloWorld.properties;

public class Box
{
    //! Variables of the class
    private int _length;
    //! Other way to access a private variable
    public int Length
    {
        get { return _length; }
        set { _length = value; }
    }
    //! Auto property
    private int Width { get; set; }
    private int Volume { get; set; }
    public int Height { get; set; }

    //? public int Height
    //? {
    //?     get
    //?     {
    //?         return Height;
    //?     }
    //?     set
    //?     {
    //?         Height = value;
    //?     }
    //? }

    public void DisplayInfo()
    {
        Console.WriteLine("Lenght is {0} and height is {1}", _length, Height);
    }
}