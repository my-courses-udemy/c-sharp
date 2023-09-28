// See https://aka.ms/new-console-template for more information

using _7._PascalTriangle.pascal;

Console.WriteLine("Hello, World!");
var pascalTriangle = new PascalTriangle();

Console.WriteLine("Input the number of rows");
var size = Convert.ToInt32(Console.ReadLine());

pascalTriangle.CreateTriangle(++size);