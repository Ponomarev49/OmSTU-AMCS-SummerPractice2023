﻿﻿namespace SpaceBattleLib;

public class SpaceBattle
{
    
    public static double[] Move(double[] coord, double[] speed)
    {
        double[] answer;
        if
        (
            (double.IsNaN(coord[0]))||(double.IsNaN(coord[1]))||
            (double.IsNaN(speed[0]))||(double.IsNaN(speed[1]))
        )
        throw new System.ArgumentException();
        else
        {
            answer = new double[2];
            answer[0] = coord[0]+speed[0];
            answer[1] = coord[1]+speed[1];
        }
        return answer;
    }

    public static double Fuel(double fuel_count ,double consumption)
    {
        if (fuel_count > consumption)
        {
            fuel_count-=consumption;
        }
        else throw new System.ArgumentException();
        return fuel_count;
    }

    public static double Corner_speed(double corner,double corner_speed)
    {
        if ((double.IsNaN(corner))||(double.IsNaN(corner_speed)))  
        throw new System.ArgumentException();
        else corner+=corner_speed;
        return corner;
    }
}