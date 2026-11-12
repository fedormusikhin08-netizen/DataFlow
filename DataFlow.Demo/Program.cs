using DataFlow.Core;

var nums = new List<int> { 5, 9, 2 };
Console.WriteLine($"FindMax на List<int> = {nums.FindMax()}");
Console.WriteLine($"FindMax на пустом List<string> = {(new List<string>().FindMax() is null ? "null" : "ошибка")}");
Console.WriteLine($"FindMax на пустом List<int> = {new List<int>().FindMax()}");
nums.PrintAll("Элемент: ");
new List<string>().PrintAll("Элемент: ");
Console.WriteLine("(пустой список ничего не напечатал)");
