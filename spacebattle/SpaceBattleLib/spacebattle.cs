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
}