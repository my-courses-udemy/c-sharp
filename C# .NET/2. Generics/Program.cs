// See https://aka.ms/new-console-template for more information

using _2._Generics;
using _2._Generics.models;

Console.WriteLine("Hello, World!");
string[] arr = { "z", "b", "a", "c", "d", "hello" };
int[] arrInt = { 3, 2, 1 };

SortArray<string> sortArray = new SortArray<string>();
sortArray.BubbleSort(arr);

var result = arr.ToList()
    .Aggregate((s, s1) => s + " " + s1);
Console.WriteLine(result);

Employee[] employees =
{
    new() { id = 2, Name = "John" }, new() { id = 1, Name = "Mary" },
    new() { id = 1, Name = "Aaron" },
    new() { id = 5, Name = "Peter" }, new() { id = 4, Name = "Paul" }
};
var sortArrayEmployee = new SortArray<Employee>();
sortArrayEmployee.BubbleSort(employees);
employees.ToList().ForEach(Console.WriteLine);