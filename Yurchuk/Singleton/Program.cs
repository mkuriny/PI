using System;

public class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();

    // Приватный конструктор предотвращает создание экземпляров класса извне
    private Singleton()
    {
        // Инициализация, если необходимо
    }

    public static Singleton Instance
    {
        get
        {
            // Проверка на null для первого доступа
            if (instance == null)
            {
                // Блокировка для обеспечения потокобезопасности
                lock (lockObject)
                {
                    // Повторная проверка на null для предотвращения создания нескольких экземпляров
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    // Пример метода в Singleton
    public void SomeMethod()
    {
        Console.WriteLine("Метод вызван из Singleton.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Получение экземпляра Singleton и вызов метода
        Singleton singleton = Singleton.Instance;
        singleton.SomeMethod();

        // Дополнительный пример, чтобы показать, что экземпляр один и тот же
        Singleton anotherSingleton = Singleton.Instance;
        Console.WriteLine($"Экземпляры одинаковы: {singleton == anotherSingleton}");
    }
}