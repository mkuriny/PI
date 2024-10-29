using System;
using System.Collections.Generic;

// Класс, представляющий комнату
public class Room
{
    public string Name { get; set; }
    public int Size { get; set; } // Размер комнаты в квадратных метрах

    public Room(string name, int size)
    {
        Name = name;
        Size = size;
    }
}

// Класс, представляющий гараж
public class Garage
{
    public int Size { get; set; } // Размер гаража в квадратных метрах

    public Garage(int size)
    {
        Size = size;
    }
}

// Класс, представляющий сад
public class Garden
{
    public int Area { get; set; } // Площадь сада в квадратных метрах

    public Garden(int area)
    {
        Area = area;
    }
}

// Класс, представляющий дом
public class House
{
    public List<Room> Rooms { get; private set; }
    public Garage Garage { get; private set; }
    public Garden Garden { get; private set; }

    public House()
    {
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }

    public void SetGarage(Garage garage)
    {
        Garage = garage;
    }

    public void SetGarden(Garden garden)
    {
        Garden = garden;
    }

    public void ShowDetails()
    {
        Console.WriteLine("Детали дома:");
        foreach (var room in Rooms)
        {
            Console.WriteLine($"Комната: {room.Name}, Размер: {room.Size} м²");
        }
        if (Garage != null)
            Console.WriteLine($"Гараж: Размер {Garage.Size} м²");
        if (Garden != null)
            Console.WriteLine($"Сад: Площадь {Garden.Area} м²");
    }
}

// Строитель для создания домов
public class HouseBuilder
{
    private House house;

    public HouseBuilder()
    {
        house = new House();
    }

    public HouseBuilder AddRoom(string name, int size)
    {
        house.AddRoom(new Room(name, size));
        return this;
    }

    public HouseBuilder AddGarage(int size)
    {
        house.SetGarage(new Garage(size));
        return this;
    }

    public HouseBuilder AddGarden(int area)
    {
        house.SetGarden(new Garden(area));
        return this;
    }

    public House Build()
    {
        return house;
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        // Создание дома с помощью билдера
        HouseBuilder builder = new HouseBuilder();
        House myHouse = builder
            .AddRoom("Гостиная", 25)
            .AddRoom("Спальня", 20)
            .AddGarage(30)
            .AddGarden(50)
            .Build();

        // Вывод деталей дома
        myHouse.ShowDetails();
    }
}