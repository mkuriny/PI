from abc import ABC, abstractmethod
import math


class IFigure(ABC):
    @abstractmethod
    def calculate_area(self):
        pass


class Circle(IFigure):
    def __init__(self, radius):
        self.radius = radius

    def calculate_area(self):
        return math.pi * self.radius ** 2


class Square(IFigure):
    def __init__(self, side):
        self.side = side

    def calculate_area(self):
        return self.side ** 2


class Triangle(IFigure):
    def __init__(self, base, height):
        self.base = base
        self.height = height

    def calculate_area(self):
        return 0.5 * self.base * self.height


class FigureFactory:
    @staticmethod
    def create_figure(figure_type, *parameters):
        if figure_type.lower() == "circle":
            return Circle(parameters[0])
        elif figure_type.lower() == "square":
            return Square(parameters[0])
        elif figure_type.lower() == "triangle":
            return Triangle(parameters[0], parameters[1])
        else:
            raise ValueError("Unknown figure type")


if __name__ == "__main__":

    radius = float(input("Введите радиус круга: "))
    figure = FigureFactory.create_figure("circle", radius)
    print(f"Площадь круга: {figure.calculate_area()}")

    side = float(input("Введите длину стороны квадрата: "))
    figure = FigureFactory.create_figure("square", side)
    print(f"Площадь квадрата: {figure.calculate_area()}")

    base = float(input("Введите основание треугольника: "))
    height = float(input("Введите высоту треугольника: "))
    figure = FigureFactory.create_figure("triangle", base, height)
    print(f"Площадь треугольника: {figure.calculate_area()}")
