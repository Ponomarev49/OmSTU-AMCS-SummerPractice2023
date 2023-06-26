using Xunit;
using SquareEquationLib;

namespace PrimeService.Tests;

public class UnitTest1
{
    [Fact]
        public void AIs0Test()
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(0, 0, 0));
        }
        [Fact]
        public void InnormalArgumentTest()
        {
            var values = new double[] {double.NaN, double.PositiveInfinity, double.NegativeInfinity};
             
            foreach(double a in values)
            {
                foreach(double b in values)
                {
                    foreach(double c in values)
                    {
                        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
                    }
                }
            }
        }
        [Theory]
        [InlineData(1,1,0.24999999995, new double[] {-0.5000071})]
        [InlineData(0.5,1,0.499999999995, new double[] {-0.500002})]
        public void DiscriminantCloseToZero(double a, double b, double c, double[] excpectedRoots)
        {
            double[] methodResult;
            methodResult = SquareEquation.Solve(a,b,c);
            
            if (methodResult.Length != excpectedRoots.Length)
            {
                Assert.Fail("Number of roots not match");
            }

            for (int i = 0; i < methodResult.Length; i++)
            {
                Assert.Equal(methodResult[i], excpectedRoots[i], 6);
            }
        }

        [Theory]
        [InlineData(1, 0, 1, new double[] {})]
        [InlineData(10, 2, 10, new double[] {})]
        [InlineData(1,0,0, new double[] {0})]
        [InlineData(1,4,4, new double[] {-2})]
        [InlineData(1,0,-1, new double[] {-1, 1})]
        [InlineData(1,5,6, new double[] {-2, -3})]

        public void RootCorrectness(double a, double b, double c, double[] expectedRoots)
        {
            double[] actualRoots;
            actualRoots = SquareEquation.Solve(a, b, c);
            Array.Sort(actualRoots);
            Array.Sort(expectedRoots);

            if (expectedRoots.Length != actualRoots.Length)
            {
                Assert.Fail("Number of root does not match");
            }

            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(expectedRoots[i], actualRoots[i], 6);
            }
        }
}