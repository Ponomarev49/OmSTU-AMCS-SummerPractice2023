using SpaceBattleLib;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;


namespace Specflowproj.Steps
{
    [Binding]
    public sealed class SpaceBattlDefinitions
    {
       private double[] coord {get; set;}
       private double[] speed {get; set;}
       private double[] result {get; set;}
       private Exception except {get; set;}

       [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
       public void Coord(double a, double b)
       {
            this.coord = new double[]{a,b};
       }
       [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
       public void Speed(double a, double b)
       {
            this.speed = new double[]{a,b};
       }
       [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
       public void CoordNaN()
       {
            this.coord = new double[]{double.NaN,double.NaN};
       }
       [Given(@"скорость корабля определить невозможно")]
       public void SpeedNaN()
       {
            this.speed = new double[]{double.NaN,double.NaN};
       }
       [Given(@"изменить положение в пространстве космического корабля невозможно")]
       public void CoordNot()
       {
            this.coord = new double[]{double.NaN,double.NaN};
       }
        

       [When(@"происходит прямолинейное равномерное движение без деформации")]
       public void SpaceBattle()
       {
           try{
                this.result = SpaceBattleLib.SpaceBattle.Move(coord, speed);
           }
           catch(ArgumentException e){
                except = e;
           }
       }
       

       [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
       public void move(double expect1, double expect2)
       {
             double[] expected = {expect1, expect2};
             result.Should().ContainInOrder(expected);
       }

       [Then(@"возникает ошибка Exception")]
       public void Exeptions()
       {
            except.Should().BeOfType<System.ArgumentException>();
       }
    }
}