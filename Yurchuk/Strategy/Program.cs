using System;


// Интерфейс для стратегий форматирования
public interface ITextFormatter
{
    string Format(string text);
}

// Стратегия для жирного текста
public class BoldTextFormatter : ITextFormatter
{
    public string Format(string text)
    {
        return $"<b>{text}</b>"; // HTML-тег для жирного текста
    }
}

// Стратегия для курсивного текста
public class ItalicTextFormatter : ITextFormatter
{
    public string Format(string text)
    {
        return $"<i>{text}</i>"; // HTML-тег для курсивного текста
    }
}

// Стратегия для подчеркнутого текста
public class UnderlineTextFormatter : ITextFormatter
{
    public string Format(string text)
    {
        return $"<u>{text}</u>"; // HTML-тег для подчеркнутого текста
    }
}

public class TextFormatterContext
{
    private ITextFormatter _formatter;

    public TextFormatterContext(ITextFormatter formatter)
    {
        _formatter = formatter;
    }

    public void SetFormatter(ITextFormatter formatter)
    {
        _formatter = formatter;
    }

    public string FormatText(string text)
    {
        return _formatter.Format(text);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример текста для форматирования
        string text = "Привет, мир!";

        // Создаем контекст с выбранной стратегией
        TextFormatterContext context = new TextFormatterContext(new BoldTextFormatter());
        Console.WriteLine("Bold: " + context.FormatText(text));

        // Меняем стратегию на курсив
        context.SetFormatter(new ItalicTextFormatter());
        Console.WriteLine("Italic: " + context.FormatText(text));

        // Меняем стратегию на подчеркивание
        context.SetFormatter(new UnderlineTextFormatter());
        Console.WriteLine("Underline: " + context.FormatText(text));
    }
}