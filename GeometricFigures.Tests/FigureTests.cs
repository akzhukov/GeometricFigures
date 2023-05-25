using GeometricFigures.PlaneFigures;
using Xunit;

namespace Tests;

public class FigureTests
{
    private readonly double _epsilon = 10e-8;

    [Fact]
    public void CircleArea()
    {
        // Arrange
        double radius = 2;
        Circle circle = new(radius);

        // Act
        double result = circle.GetArea();

        // Assert
        Assert.True(Math.PI * radius * radius - result < _epsilon);
    }

    [Fact]
    public void NoPositiveRadiusCircle()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }

    [Fact]
    public void CirclePerimeter()
    {
        // Arrange
        double radius = 3;
        Circle circle = new(radius);

        // Act
        double result = circle.GetPerimeter();

        // Assert
        Assert.True(2 * Math.PI * radius - result < _epsilon);
    }

    [Fact]
    public void TriagleArea()
    {
        // Arrange
        Triangle triagle = new(3, 4, 5);

        // Act
        double result = triagle.GetArea();

        // Assert
        Assert.True(6 - result < _epsilon);
    }

    [Fact]
    public void TriaglePerimeter()
    {
        // Arrange
        double a = 3, b = 4, c = 5;
        Triangle triagle = new(a, b, c);

        // Act
        double result = triagle.GetPerimeter();

        // Assert
        Assert.True(a + b + c - result < _epsilon);
    }

    [Fact]
    public void TriagleInequalty()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 2));
        Assert.Throws<ArgumentException>(() => new Triangle(5, 12, 5));
    }

    [Fact]
    public void NoRightangledTriangle()
    {
        // Arrange
        Triangle triagle = new(10, 8, 10);

        // Act
        bool result = triagle.IsRightangledTriangle();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void RightangledTriangle()
    {
        // Arrange
        Triangle triagle = new(6, 8, 10);

        // Act
        bool result = triagle.IsRightangledTriangle();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void RightangledTriangleEpsilon()
    {
        // Arrange
        Triangle triagle = new(3, 4, 5.01, 0.2);

        // Act
        bool result = triagle.IsRightangledTriangle();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CalculateFigureAreaWithoutFigureType()
    {
        // Arrange
        IFigure figure1 = new Triangle(3, 4, 5);
        IFigure figure2 = new Circle(3);

        // Act
        double figure1Area = figure1.GetArea();
        double figure2Area = figure2.GetArea();

        // Assert
        Assert.True(figure1Area > 0);
        Assert.True(figure2Area > 0);
    }
}