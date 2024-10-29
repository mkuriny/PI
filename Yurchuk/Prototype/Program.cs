using System;
using System.Collections.Generic;

// Интерфейс для клонирования
public interface ICloneable
{
    object Clone();
}

// Класс Page, представляющий страницу документа
public class Page : ICloneable
{
    public string Content { get; set; }

    public Page(string content)
    {
        Content = content;
    }

    // Реализация метода Clone для клонирования страницы
    public object Clone()
    {
        return new Page(Content);
    }
}

// Класс Document, представляющий документ с несколькими страницами
public class Document : ICloneable
{
    public List<Page> Pages { get; private set; }

    public Document()
    {
        Pages = new List<Page>();
    }

    // Метод для добавления страницы в документ
    public void AddPage(Page page)
    {
        Pages.Add(page);
    }

    // Реализация метода Clone для клонирования документа
    public object Clone()
    {
        Document clonedDocument = new Document();
        foreach (var page in Pages)
        {
            clonedDocument.AddPage((Page)page.Clone());
        }
        return clonedDocument;
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        // Создание документа и добавление страниц
        Document originalDocument = new Document();
        originalDocument.AddPage(new Page("Страница 1: Введение"));
        originalDocument.AddPage(new Page("Страница 2: Основная часть"));
        originalDocument.AddPage(new Page("Страница 3: Заключение"));

        // Клонирование документа
        Document clonedDocument = (Document)originalDocument.Clone();

        // Изменение содержимого клонированной страницы
        clonedDocument.Pages[0].Content = "Страница 1: Измененное введение";

        // Вывод содержимого оригинального и клонированного документа
        Console.WriteLine("Оригинальный документ:");
        foreach (var page in originalDocument.Pages)
        {
            Console.WriteLine(page.Content);
        }

        Console.WriteLine("\nКлонированный документ:");
        foreach (var page in clonedDocument.Pages)
        {
            Console.WriteLine(page.Content);
        }
    }
}