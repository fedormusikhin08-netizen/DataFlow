using DataFlow.Core;

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
