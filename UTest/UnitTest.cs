using NUnit.Framework;
using GeometryLibrary;

namespace GeometryLibraryTests
{
    public class TriangleTests
    {
        [Test]
        public void CalculateArea_ValidTriangle_ShouldReturnCorrectArea()
        {
            // Arrange
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 5.0;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            double area = triangle.CalculateArea();

            Assert.That(area, Is.EqualTo(6.0));
        }

        [Test]
        public void CalculateArea_InvalidTriangle_ThrowsArgumentException()
        {
            double sideA = 1.0;
            double sideB = 2.0;
            double sideC = 5.0;

            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void IsRightTriangle_RightTriangle_ReturnsTrue()
        {
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 5.0;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            bool isRightTriangle = triangle.IsRightTriangle();

            Assert.IsTrue(isRightTriangle);
        }

        [Test]
        public void IsRightTriangle_NonRightTriangle_ReturnsFalse()
        {
            double sideA = 3.0;
            double sideB = 4.0;
            double sideC = 6.0;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            bool isRightTriangle = triangle.IsRightTriangle();

            Assert.IsFalse(isRightTriangle);
        }
    }
    public class CircleTests
    {
        [Test]
        public void CalculateArea_ValidRadius_ShouldReturnCorrectArea()
        {
            double radius = 5.0;
            Circle circle = new Circle(radius);

            double area = circle.CalculateArea();

            Assert.AreEqual(Math.PI * 25.0, area);
        }

        [Test]
        public void CalculateArea_ZeroRadius_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(0.0));
        }

        [Test]
        public void CalculateArea_NegativeRadius_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Circle(-3.0));
        }
    }
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void CalculateArea_ValidSide_ShouldReturnCorrectArea()
        {
            double side = 5.0;
            double expectedArea = 25.0;
            var square = new Square(side);

            double actualArea = square.CalculateArea();

            Assert.AreEqual(expectedArea, actualArea);
        }

        [Test]
        public void CalculateArea_ZeroSide_ShouldThrowArgumentException()
        {
            double side = 0.0;

            Assert.That(() => new Square(side), Throws.ArgumentException
                .With.Message.EqualTo("Длина стороны квадрата должна быть положительным числом больше нуля."));
        }

        [Test]
        public void CalculateArea_NegativeSide_ShouldThrowArgumentException()
        {
            double side = -5.0;

            Assert.That(() => new Square(side), Throws.ArgumentException
                .With.Message.EqualTo("Длина стороны квадрата должна быть положительным числом больше нуля."));
        }
    }

}