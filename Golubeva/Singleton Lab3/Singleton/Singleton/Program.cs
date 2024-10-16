public class Logger
{
    // Статическое поле для хранения единственного экземпляра класса
    private static readonly Logger _instance = new Logger();

    // Приватный конструктор, чтобы предотвратить создание экземпляров извне
    private Logger()
    {
        // Инициализация, если необходимо
    }

    // Статическое свойство для доступа к единственному экземпляру
    public static Logger Instance
    {
        get { return _instance; }
    }

    // Метод для записи логов
    public void Log(string message)
    {
        Console.WriteLine($"Logging: {message}");
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        // Получаем единственный экземпляр Logger
        Logger logger = Logger.Instance;

        // Используем метод для записи логов
        logger.Log("This is a log message.");

        // Попытка создания нового экземпляра Logger приведет к ошибке компиляции
        // Logger newLogger = new Logger(); // Ошибка: конструктор 'Logger.Logger()' недоступен из-за своего уровня защиты
    }
}