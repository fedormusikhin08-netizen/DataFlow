using DataFlow.Core;

var labels = new LabeledBuffer();
labels.TryAdd("привет");
labels.TryAdd("мир");
labels.TryAdd("отчёт");
labels.PrintAllUpper();
Console.WriteLine($"LabeledBuffer.Count = {labels.Count}");
