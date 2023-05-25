namespace GeometricFigures.PlaneFigures;

public class Triangle : IFigure
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;
    private readonly double _epsilon;

    public Triangle(double sideA, double sideB, double sideC, double epsilon = 10e-8)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Sides of the triangle must be positive.");

        if (sideA + sideB <= sideC
            || sideB + sideC <= sideA
            || sideA + sideC <= sideB)
            throw new ArgumentException("Triangle inequality violated");

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
        _epsilon = epsilon;
    }

    public double GetArea()
    {
        double semiPerimeter = GetPerimeter() / 2;
        return Math.Sqrt(semiPerimeter
                         * (semiPerimeter - _sideA)
                         * (semiPerimeter - _sideB)
                         * (semiPerimeter - _sideC));
    }

    public double GetPerimeter()
    {
        return _sideA + _sideB + _sideC;
    }

    public bool IsRightangledTriangle()
    {
        double smallSide1 = Math.Min(_sideA, _sideB);
        double bigSide = Math.Max(_sideA, _sideB);
        double smallSide2 = Math.Min(bigSide, _sideC);
        bigSide = Math.Max(bigSide, _sideC);

        return Math.Abs(bigSide * bigSide
                        - smallSide1 * smallSide1
                        - smallSide2 * smallSide2) < _epsilon;
    }
}
