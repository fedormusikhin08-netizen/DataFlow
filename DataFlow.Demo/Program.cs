using DataFlow.Core;
using DataFlow.Demo;

var master = new Book { Id = 1, Title = "Мастер и Маргарита", Year = 1967 };
var war = new Book { Id = 2, Title = "Война и мир", Year = 1869 };
var catalog = new List<Book>
{
    master,
    war,
    new Book { Id = 3, Title = "Пикник на обочине", Year = 1972 }
};
Console.WriteLine($"FindMax на List<Book> = {catalog.FindMax()!.Title}");
catalog.PrintAll("Книга: ");
