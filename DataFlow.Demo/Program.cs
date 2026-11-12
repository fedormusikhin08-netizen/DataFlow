using DataFlow.Core;
using DataFlow.Demo;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Блок A: иерархии обобщённых классов ===");
var titles = new LabeledBuffer();
titles.TryAdd("мастер и маргарита");
titles.TryAdd("война и мир");
titles.TryAdd("пикник на обочине");
titles.PrintAllUpper();
Console.WriteLine($"LabeledBuffer.Count = {titles.Count}");
Console.WriteLine();

Console.WriteLine("--- GuardedBuffer<Book>: только книги после 1950 года ---");
var modern = new GuardedBuffer<Book>(b => b.Year >= 1950);
var master = new Book { Id = 1, Title = "Мастер и Маргарита", Year = 1967 };
var war = new Book { Id = 2, Title = "Война и мир", Year = 1869 };
var picnic = new Book { Id = 3, Title = "Пикник на обочине", Year = 1972 };
Console.WriteLine($"TryAdd(Мастер и Маргарита) = {modern.TryAdd(master)}");
Console.WriteLine($"TryAdd(Война и мир) = {modern.TryAdd(war)}");
Console.WriteLine($"Count = {modern.Count}, AcceptedCount = {modern.AcceptedCount} — после отказа");
Console.WriteLine($"TryAdd(Пикник на обочине) = {modern.TryAdd(picnic)}");
Console.WriteLine($"Count = {modern.Count}, AcceptedCount = {modern.AcceptedCount}");
Console.WriteLine();

Console.WriteLine("--- GuardedBuffer<Reader>: только с непустым билетом ---");
var readers = new GuardedBuffer<Reader>(r => !string.IsNullOrWhiteSpace(r.Ticket));
Console.WriteLine($"TryAdd(Алина) = {readers.TryAdd(new Reader { Id = 1, Name = "Алина", Ticket = "T-001" })}");
Console.WriteLine($"TryAdd(Борис) = {readers.TryAdd(new Reader { Id = 2, Name = "Борис", Ticket = " " })}");
Console.WriteLine($"Count = {readers.Count}, AcceptedCount = {readers.AcceptedCount}");
Console.WriteLine($"Счётчики независимы: modern.AcceptedCount = {modern.AcceptedCount}, readers.AcceptedCount = {readers.AcceptedCount}");
Console.WriteLine();

Console.WriteLine("=== Блок B: обобщённая структура, делегат и метод ===");
var price = new Record<decimal>(1200m, "Цена");
Console.WriteLine($"Исходная запись: {price}");
var discounted = RecordMapper.Map(price, (decimal p) => p * 0.9m, "Со скидкой");
Console.WriteLine($"decimal → decimal: {discounted}");
var priceTag = RecordMapper.Map(price, (decimal p) => p >= 1000m ? "дорогая" : "дешёвая", "Категория");
Console.WriteLine($"decimal → string: {priceTag}");
var year = new Record<int>(1967, "Год");
Console.WriteLine($"Исходная запись: {year}");
Console.WriteLine($"int → int: {RecordMapper.Map(year, (int y) => 2026 - y, "Возраст книги")}");
Console.WriteLine($"int → bool: {RecordMapper.Map(year, (int y) => y >= 2000, "Современная")}");
Console.WriteLine();

Console.WriteLine("=== Блок C: обобщённые интерфейсы ===");
var books = new InMemoryRepository<Book>();
books.Add(master);
books.Add(war);
Console.WriteLine($"GetById(2) = {books.GetById(2)!.Title}");
Console.WriteLine($"GetById(99) = {(books.GetById(99) is null ? "null" : "ошибка")}");

var readersRepo = new InMemoryRepository<Reader>();
readersRepo.Add(new Reader { Id = 1, Name = "Алина", Ticket = "T-001" });
Console.WriteLine($"GetById(1) у читателей = {readersRepo.GetById(1)!.Name}");
Console.WriteLine($"Счётчики независимы: books.Count = {books.Count}, readersRepo.Count = {readersRepo.Count}");

var container = new Container<Dog>(new Dog { Name = "Шарик" });
IContainer<Animal> animal = container;
Console.WriteLine($"IContainer<Animal>.GetItem() = {animal.GetItem()}");
Console.WriteLine();

Console.WriteLine("=== Блок D: методы расширения ===");
var numbers = new List<int> { 5, 9, 2 };
Console.WriteLine($"FindMax на List<int> = {numbers.FindMax()}");
Console.WriteLine($"FindMax на пустом List<string> = {(new List<string>().FindMax() is null ? "null" : "ошибка")}");
Console.WriteLine($"FindMax на пустом List<int> = {new List<int>().FindMax()}");
var catalog = new List<Book> { master, war, picnic };
Console.WriteLine($"FindMax на List<Book> = {catalog.FindMax()!.Title}");
numbers.PrintAll("Элемент: ");
catalog.PrintAll("Книга: ");
new List<string>().PrintAll("Элемент: ");
Console.WriteLine("(пустой список ничего не напечатал)");
