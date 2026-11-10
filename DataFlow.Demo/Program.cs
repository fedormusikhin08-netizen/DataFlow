using DataFlow.Core;

var probe = new Buffer<int>();
Console.WriteLine(probe.TryAdd(1));
Console.WriteLine(probe.TryAdd(2));
Console.WriteLine(probe.TryAdd(3));
Console.WriteLine(probe.Count);
