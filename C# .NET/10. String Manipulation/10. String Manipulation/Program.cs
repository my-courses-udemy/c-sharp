// See https://aka.ms/new-console-template for more information

using _10._String_Manipulation;

Console.WriteLine("Hello, World!");
//! This variables are immutable
string name1 = "Hello, World!";
string name2 = "Other string";
string name3 = name1;

//! It is a declaration of a tuple
//! A tuple could has an unlimited number of variables
var nameTuple = (name1: "Alex", name2: 2, name3: true);
//? This is a restriction of the tuple, all the elements must be the same type
(string first, string second, string third) otherTuple = ("Alex", "2", "true");
var (name1ForTuple, name2ForTuple, name3ForTuple) = nameTuple;

//? it has been created a new string called name1
//? name1 free the memory and create a new string with the value of name1 + name2
name1 += name2;
Console.WriteLine(name1);
Console.WriteLine(name3);
Console.WriteLine($"Variables: {name1} {name3}");
Console.WriteLine($"Variables: {name1ForTuple} {name2ForTuple} {name3ForTuple}");

//! SUBSTRING
var firstString = "Hello, World!";
//? var substring = firstString.Substring(0, 5);
var substring = firstString[..5];
Console.WriteLine($"Substring: {substring}");

//? Replace creates a new string
var replace = firstString.Replace('e', 'o');
Console.WriteLine($"Replace method: {replace}, current firstString: {firstString}");
replace = firstString.Replace("World", "Universe");
Console.WriteLine($"Replace method: {replace}, current firstString: {firstString}");

//! ITERATE A STRING
string course = "C# Fundamentals for Beginners";
string course1 = "C# Fundamentals for Beginners";
var sub = course.IndexOf('s');
Console.WriteLine($"Index of s: {sub}");
sub = course.IndexOf("for");
Console.WriteLine($"Index of s: {sub}");

var array = course.ToCharArray();
Console.WriteLine($"Verify equal: {course.Equals(course1)}");

//! STRING BUILDER
StringBuilderExample.Example();