using NUnit.Framework;
using Geometry;
using Geometry.Interfaces;
namespace Geometry.Tests

{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void CircleAreaCalculationTest()
        {
            //Arrange
            double radius = 3;
            Circle circle = new Circle(radius);
            //Act
            double area = circle.calculateArea();
            //Assert
            Assert.AreEqual(Math.PI * Math.Pow(radius, 2), area, 0.001);
        }
        [Test]
        public void RightTriangleAreaCalculationTest()
        {
            //Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            //Act
            double area = triangle.calculateArea();
            //Assert
            Assert.AreEqual(6, area, 0.001);
        }
        [Test]
        public void NonRightTriangleAreaCalculationTest()
        {
            //Arrange 
            double sideA = 10;
            double sideB = 6;
            double sideC = 8;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            //Act
            double area = triangle.calculateArea();
            //Assert
            Assert.AreEqual(24, area, 0.001);
        }
        [Test]
        public void IsTriangle()
        {
            //Arrange
            double sideA = 5;
            double sideB = 3;
            double sideC = 10;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            //act
            bool result = triangle.IsTriangle();
            // Assert
            Assert.IsFalse(result, "Expected triangle to be invalid, but it was valid.");
        }
    }
}
