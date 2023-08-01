using GeometryLibrary;
using System;

namespace GeometryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Program
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            try
            {
                // Пример использования классов для вычисления площадей фигур

                // Создаем объекты круга, треугольника и квадрата
                Circle circle = new Circle(5.0);
                Triangle triangle = new Triangle(3.0, 4.0, 5.0);
                Square square = new Square(4.0);

                // Вычисляем площади фигур
                double circleArea = circle.CalculateArea();
                double triangleArea = triangle.CalculateArea();
                double squareArea = square.CalculateArea();

                // Выводим результаты на экран
                Console.WriteLine($"Площадь круга с радиусом 5: {circleArea:F2}");
                Console.WriteLine($"Площадь треугольника со сторонами 3, 4 и 5: {triangleArea:F2}");
                Console.WriteLine($"Площадь квадрата со стороной 4: {squareArea:F2}");

                // Проверяем, является ли треугольник прямоугольным
                if (triangle.IsRightTriangle())
                {
                    Console.WriteLine("Треугольник является прямоугольным.");
                }
                else
                {
                    Console.WriteLine("Треугольник не является прямоугольным.");
                }
            }
            catch (ArgumentException ex)
            {
                // Выводим сообщение об ошибке, если введены некорректные значения
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

    }
}