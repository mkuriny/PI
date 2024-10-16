using System;

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email Notification: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS Notification: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Push Notification: {message}");
    }
}

public static class NotificationFactory
{
    public static INotification CreateNotification(string type)
    {
        switch (type.ToLower())
        {
            case "email":
                return new EmailNotification();
            case "sms":
                return new SMSNotification();
            case "push":
                return new PushNotification();
            default:
                throw new ArgumentException("Invalid notification type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotification notification = NotificationFactory.CreateNotification("email");
        notification.Send("Hello, this is a test email!");

        notification = NotificationFactory.CreateNotification("sms");
        notification.Send("Hello, this is a test SMS!");

        notification = NotificationFactory.CreateNotification("push");
        notification.Send("Hello, this is a test push notification!");
    }
}