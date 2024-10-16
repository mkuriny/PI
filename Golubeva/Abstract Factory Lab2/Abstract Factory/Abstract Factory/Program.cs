using System;

public interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

public interface IChair
{
    void SitOn();
}

public interface ITable
{
    void Use();
}

public class ModernChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Сидим на современном стуле.");
    }
}

public class ModernTable : ITable
{
    public void Use()
    {
        Console.WriteLine("Используем современный стол.");
    }
}

public class VictorianChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Сидим на викторианском стуле.");
    }
}

public class VictorianTable : ITable
{
    public void Use()
    {
        Console.WriteLine("Используем викторианский стол.");
    }
}

public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}

public class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ITable CreateTable()
    {
        return new VictorianTable();
    }
}

public class FurnitureClient
{
    private readonly IChair _chair;
    private readonly ITable _table;

    public FurnitureClient(IFurnitureFactory factory)
    {
        _chair = factory.CreateChair();
        _table = factory.CreateTable();
    }

    public void UseFurniture()
    {
        _chair.SitOn();
        _table.Use();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IFurnitureFactory modernFactory = new ModernFurnitureFactory();
        FurnitureClient modernClient = new FurnitureClient(modernFactory);
        modernClient.UseFurniture();

        Console.WriteLine();

        IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
        FurnitureClient victorianClient = new FurnitureClient(victorianFactory);
        victorianClient.UseFurniture();
    }
}