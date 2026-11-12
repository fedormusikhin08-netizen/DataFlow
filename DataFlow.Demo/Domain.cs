using DataFlow.Core;

namespace DataFlow.Demo;

public sealed class Book : IEntity, IComparable<Book>
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int Year { get; set; }

    public int CompareTo(Book? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Year.CompareTo(other.Year);
    }

    public override string ToString() => $"{Title} ({Year})";
}

public sealed class Reader : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Ticket { get; set; } = "";
    public override string ToString() => $"{Name}, билет {Ticket}";
}

public abstract class Animal
{
    public string Name { get; set; } = "";
    public override string ToString() => $"{GetType().Name} по имени {Name}";
}

public sealed class Dog : Animal
{
}
