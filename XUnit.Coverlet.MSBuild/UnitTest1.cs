namespace XUnit.Coverlet.MSBuild;

public class UnitTests
{
    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(1, double.NegativeInfinity, 1)]
    [InlineData(6, 1, double.PositiveInfinity)]
    [InlineData(1, 1, double.NaN)]
    [InlineData(1, double.NaN, 1)]
    public void Exeptions(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => SquareEquationLib.SquareEquation.Solve(a, b, c));
    }

    [Theory]
    [InlineData(10, 1, 5)]
    public void discriminant_less_zero (double a, double b, double c)
    {
         double[] array = SquareEquationLib.SquareEquation.Solve(a, b, c);
         Assert.True(array.Length == 0);
    }

    [Theory]
    [InlineData(1, 0, 0)]
    public void discriminant_equals_zero(double a, double b, double c)
    {
        double[] array = SquareEquationLib.SquareEquation.Solve(a, b, c);
        Assert.Equal(0, Math.Abs(a*Math.Pow(array[0], 2) + b*array[0] + c),Math.Pow(10,-6));
    }

    [Theory]
    [InlineData(1, 15, 5)]
    public void discriminant_more_zero(double a, double b, double c)
    {
        double[] array = SquareEquationLib.SquareEquation.Solve(a, b, c);
        foreach (double x in array)
        {
            Assert.Equal(0, Math.Abs(a*Math.Pow(x, 2) + b*x + c),Math.Pow(10,-6));
        }
    }
}