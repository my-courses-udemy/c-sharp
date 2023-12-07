namespace _2._Generics.models;

public class Employee : IComparable<Employee>
{
    public int id { get; set; }
    public string? Name { get; set; }


    public override string ToString()
    {
        return $"id: {id}, Name: {Name}";
    }


    public int CompareTo(Employee? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var idComparison = id.CompareTo(other.id);
        if (idComparison != 0) return idComparison;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}