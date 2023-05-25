namespace GeometricFigures.PlaneFigures;

public class Circle : IFigure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius of the circle must be positive.");
        _radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}
