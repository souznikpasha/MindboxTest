using GeometryLibrary.Interfaces;
using System;

namespace GeometryLibrary
{
    // Абстрактный класс Shape представляет базовую абстрактную фигуру и определяет общий интерфейс для всех фигур.
    // Этот класс реализует интерфейс IShape, который определяет метод для вычисления площади фигуры.
    public abstract class Shape : IShape
    {
        // Абстрактный метод CalculateArea() не имеет реализации в базовом классе Shape.
        // Этот метод должен быть реализован в производных классах, чтобы вычислять площадь конкретной фигуры.
        // Каждый производный класс должен переопределить этот метод в соответствии с его логикой вычисления площади.
        public abstract double CalculateArea();
    }

    public class Circle : Shape
    {
        private double _radius;

        // Конструктор для создания круга с заданным радиусом
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус круга должен быть положительным числом больше нуля.");
            }

            _radius = radius;
        }

        // Переопределенный метод для вычисления площади круга
        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class Triangle : Shape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;

        // Конструктор для создания треугольника с заданными сторонами
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Длины сторон треугольника должны быть положительными числами больше нуля.");
            }

            // Проверяем неравенство треугольника
            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Треугольник с такими сторонами не может существовать.");
            }

            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
        }

        // Вспомогательный метод для проверки неравенства треугольника
        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        // Переопределенный метод для вычисления площади треугольника с использованием формулы Герона
        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        public override double CalculateArea()
        {
            // Используем формулу Герона для вычисления площади треугольника
            double s = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
        }

        // Метод для проверки, является ли треугольник прямоугольным (по теореме Пифагора)
        /// <summary>
        /// Проверяет является ли треугольник прямоугольным
        /// </summary>
        public bool IsRightTriangle()
        {
            // Проверяем теорему Пифагора для треугольника
            double maxSide = Math.Max(Math.Max(_sideA, _sideB), _sideC);
            double sumSquares = Math.Pow(_sideA, 2) + Math.Pow(_sideB, 2) + Math.Pow(_sideC, 2);

            // Проверяем условие теоремы Пифагора с небольшой погрешностью
            return Math.Abs(2 * Math.Pow(maxSide, 2) - sumSquares) < 0.0001;
        }
    }

    // Пример легкости добавления других фигур
    // Класс Square представляет квадрат и наследует абстрактный класс Shape.
    public class Square : Shape
    {
        private readonly double _side; // Длина стороны квадрата.

        // Конструктор класса Square принимает длину стороны квадрата и проверяет, что она положительна.
        public Square(double side)
        {
            if (side <= 0)
            {
                throw new ArgumentException("Длина стороны квадрата должна быть положительным числом больше нуля.");
            }

            _side = side;
        }

        // Переопределенный метод CalculateArea() вычисляет площадь квадрата.
        /// <summary>
        /// Вычисление площади Квадрата
        /// </summary>
        public override double CalculateArea()
        {
            return _side * _side;
        }
    }

}