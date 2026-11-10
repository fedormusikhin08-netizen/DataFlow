using DataFlow.Core;

var numbers = new GuardedBuffer<int>(x => x > 0);
Console.WriteLine(numbers.TryAdd(5));
Console.WriteLine(numbers.TryAdd(-3));
Console.WriteLine(numbers.TryAdd(100));
Console.WriteLine($"Count = {numbers.Count}, AcceptedCount = {numbers.AcceptedCount}");

var words = new GuardedBuffer<string>(s => !string.IsNullOrWhiteSpace(s));
Console.WriteLine(words.TryAdd("обобщение"));
Console.WriteLine(words.TryAdd(" "));
Console.WriteLine($"Count = {words.Count}, AcceptedCount = {words.AcceptedCount}");
Console.WriteLine($"numbers.AcceptedCount = {numbers.AcceptedCount}");
