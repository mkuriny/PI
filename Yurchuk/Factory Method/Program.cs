using System;

public abstract class IFigure
{
    public abstract double CalculateArea();
}

public class Circle : IFigure
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Square : IFigure
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double CalculateArea()
    {
        return side * side;
    }
}

public class Triangle : IFigure
{
    private double baseLength;
    private double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * baseLength * height;
    }
}

public static class FigureFactory
{
    public static IFigure CreateFigure(string figureType, params double[] parameters)
    {
        switch (figureType.ToLower())
        {
            case "circle":
                return new Circle(parameters[0]);
            case "square":
                return new Square(parameters[0]);
            case "triangle":
                return new Triangle(parameters[0], parameters[1]);
            default:
                throw new ArgumentException("Unknown figure type");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите радиус круга: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        IFigure figure = FigureFactory.CreateFigure("circle", radius);
        Console.WriteLine($"Площадь круга: {figure.CalculateArea()}");

        Console.Write("Введите длину стороны квадрата: ");
        double side = Convert.ToDouble(Console.ReadLine());
        figure = FigureFactory.CreateFigure("square", side);
        Console.WriteLine($"Площадь квадрата: {figure.CalculateArea()}");

        Console.Write("Введите основание треугольника: ");
        double baseLength = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите высоту треугольника: ");
        double height = Convert.ToDouble(Console.ReadLine());
        figure = FigureFactory.CreateFigure("triangle", baseLength, height);
        Console.WriteLine($"Площадь треугольника: {figure.CalculateArea()}");
    }
}