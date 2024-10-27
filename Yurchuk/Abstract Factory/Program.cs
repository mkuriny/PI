using System;

// Интерфейс для стола
public interface ITable
{
    int NumberOfLegs { get; }
    void Assemble();
    void DisplayInfo();
}

// Интерфейс для стула
public interface IChair
{
    string Material { get; }
    void Assemble();
    void DisplayInfo();
}

// Класс, представляющий деревянный стол, реализующий интерфейс ITable
public class WoodenTable : ITable
{
    public int NumberOfLegs { get; private set; }

    public WoodenTable(int numberOfLegs)
    {
        NumberOfLegs = numberOfLegs;
    }

    public void Assemble()
    {
        Console.WriteLine("Собираем деревянный стол...");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Это деревянный стол с {NumberOfLegs} ножками.");
    }
}

// Класс, представляющий офисный стул, реализующий интерфейс IChair
public class OfficeChair : IChair
{
    public string Material { get; private set; }

    public OfficeChair(string material)
    {
        Material = material;
    }

    public void Assemble()
    {
        Console.WriteLine("Собираем офисный стул...");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Это офисный стул, сделанный из {Material}.");
    }
}

// Программа для демонстрации использования интерфейсов и классов
class Program
{
    static void Main()
    {
        // Создаем экземпляр деревянного стола
        ITable table = new WoodenTable(4);
        table.Assemble();
        table.DisplayInfo();

        // Создаем экземпляр офисного стула
        IChair chair = new OfficeChair("кожи");
        chair.Assemble();
        chair.DisplayInfo();
    }
}