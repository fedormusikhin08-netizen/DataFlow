namespace DataFlow.Core;

public class GuardedBuffer<T> : Buffer<T>
{
    private readonly Func<T, bool> filter;

    public int AcceptedCount { get; private set; }

    public GuardedBuffer(Func<T, bool> filter)
    {
        this.filter = filter;
    }

    public override bool TryAdd(T item)
    {
        if (!filter(item))
        {
            Console.WriteLine($"Отклонено: {item}");
            return false;
        }

        bool added = base.TryAdd(item);
        if (added)
        {
            AcceptedCount++;
        }

        Console.WriteLine($"Добавлено: {item}");
        return added;
    }
}
