using System;
using System.Collections.Generic;


public interface INotificationObserver
{
    void Update(string message);
}

public class EmailObserver : INotificationObserver
{
    private string _email;

    public EmailObserver(string email)
    {
        _email = email;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Отправлено по электронной почте {_email}: {message}");
    }
}

public class SMSObserver : INotificationObserver
{
    private string _phoneNumber;

    public SMSObserver(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Отправлено по SMS {_phoneNumber}: {message}");
    }
}

public class NotificationService
{
    private List<INotificationObserver> _observers = new List<INotificationObserver>();

    public void Subscribe(INotificationObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unsubscribe(INotificationObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}

class Program
{
    static void Main()
    {
        var notificationService = new NotificationService();

        var emailUser = new EmailObserver("user@example.com");
        var smsUser = new SMSObserver("+1234567890");

        notificationService.Subscribe(emailUser);
        notificationService.Subscribe(smsUser);

        notificationService.Notify("Важное уведомление!");

        // Отписываем SMS-пользователя и отправляем еще одно уведомление
        notificationService.Unsubscribe(smsUser);
        notificationService.Notify("Новое обновление!");
    }
}