using System;

public class Prototype
{
    public string Name { get; set; }

    // Конструктор с параметрами для упрощения клонирования
    public Prototype(string name)
    {
        this.Name = name;
    }

    // Метод для клонирования объекта
    public virtual Prototype Clone()
    {
        return new Prototype(this.Name);
    }
}

// Базовый класс фабрики прототипов
public abstract class PrototypeFactory<T> where T : Prototype
{
    private Dictionary<string, T> _prototypes = new();

    public void RegisterPrototype(string key, T prototype)
    {
        if (_prototypes.ContainsKey(key))
            throw new ArgumentException($"A prototype with the key '{key}' is already registered.");

        _prototypes[key] = prototype;
    }

    public T GetPrototype(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new KeyNotFoundException($"No prototype found for key '{key}'");

        return prototype as T;
    }

    public T CreateCopy(string key)
    {
        var prototype = GetPrototype(key);
        return (T)(prototype?.Clone());
    }
}

// Пример использования фабрики прототипов
public class ExamplePrototype : Prototype
{
    public int Value { get; set; }

    public ExamplePrototype(string name, int value) : base(name)
    {
        this.Value = value;
    }

    public override ExamplePrototype Clone()
    {
        return new ExamplePrototype(this.Name, this.Value);
    }
}

public class ExamplePrototypeFactory : PrototypeFactory<ExamplePrototype>
{
    public void Initialize()
    {
        var proto1 = new ExamplePrototype("Proto1", 5);
        var proto2 = new ExamplePrototype("Proto2", 7);

        RegisterPrototype("proto1", proto1);
        RegisterPrototype("proto2", proto2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var factory = new ExamplePrototypeFactory();
        factory.Initialize();

        var clone1 = factory.CreateCopy("proto1");
        Console.WriteLine($"Cloned object: {clone1.Name}, Value: {clone1.Value}");

        var clone2 = factory.CreateCopy("proto2");
        Console.WriteLine($"Cloned object: {clone2.Name}, Value: {clone2.Value}");
    }
}