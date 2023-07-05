﻿﻿namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double[] answer;
        double eps = Math.Pow(10,-6);
        if (Math.Abs(a)<eps) 
        {
            throw new System.ArgumentException();
        }
        if
        (
            (double.IsInfinity(a))||(double.IsNaN(a))||
            (double.IsInfinity(b))||(double.IsNaN(b))||
            (double.IsInfinity(c))||(double.IsNaN(c))
        )
        {
            throw new System.ArgumentException();
        }
        double d = b * b - 4 * a * c;
        if (d < 0 && !(Math.Abs(d) < eps))
        {
            answer = new double[0];
        }
        else if (d < eps)
        {
            answer = new double[1];
            answer[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
        }
        else
        {
            answer = new double[2];
            answer[0] = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            answer[1] = c / answer[0];
        }
        return answer;
    }
}
