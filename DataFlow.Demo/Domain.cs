namespace DataFlow.Demo;

public abstract class Animal
{
    public string Name { get; set; } = "";
    public override string ToString() => $"{GetType().Name} по имени {Name}";
}

public sealed class Dog : Animal
{
}
