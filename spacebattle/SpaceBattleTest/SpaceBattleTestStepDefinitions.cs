using FluentAssertions;
using System;
namespace Specflowproj.Steps;
using SpaceBattleLib;
using TechTalk.SpecFlow;

[Binding, Scope(Feature = "Космический бой")]
public class SpaceBattl
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
          try
          {
               this.result = SpaceBattleLib.SpaceBattle.Move(coord, speed);
          }
          catch(ArgumentException e)
          {
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

[Binding, Scope(Feature = "Топливо")]
public class Space_Fuel
{
     private double fuel_count {get; set;}
     private double consumption {get; set;}
     private Exception except {get; set;}
     [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
     public void Fuel_Count(double a)
     {
          this.fuel_count = a;
     }

     [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
     public void Consaption_count(double b)
     {
          this.consumption = b;
     }


     [When(@"происходит прямолинейное равномерное движение без деформации")]
     public void Movement()
     {
          try
          {
               this.fuel_count = SpaceBattleLib.SpaceBattle.Fuel(fuel_count,consumption);
          }
          catch(ArgumentException e)
          {
               except = e;
          }
     }


     [Then(@"новый объем топлива космического корабля равен (.*) ед")]
     public void Consumption(double expect)
     {
          fuel_count.Should().Be(expect);
     }

     [Then(@"возникает ошибка Exception")]
     public void Exeption()
     {
          except.Should().BeOfType<System.ArgumentException>();
     }
}
[Binding, Scope(Feature = "Угол")]
public class Space_corner
{
     private double corner {get; set;}
     private double corner_speed {get; set;}
     private Exception except {get; set;}
     [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
     public void Ship_corner(double a)
     {
          this.corner = a;
     }

     [Given(@"космический корабль, угол наклона которого невозможно определить")]
     public void Ship_corner_NaN()
     {
          this.corner = double.NaN;
     }

     [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
     public void Ship_corner_Stop()
     {
          this.corner = double.NaN;
     }

     [Given(@"имеет мгновенную угловую скорость (.*) град")]
     public void Ship_corner_speed(double b)
     {
          this.corner_speed = b;
     }

     [Given(@"мгновенную угловую скорость невозможно определить")]
     public void Ship_corner_speed_NaN()
     {
          this.corner_speed = double.NaN;
     }


     [When(@"происходит вращение вокруг собственной оси")]
     public void Rotation()
     {
          try
          {
               this.corner = SpaceBattleLib.SpaceBattle. Corner_speed(corner,corner_speed);
          }
          catch(ArgumentException e)
          {
               except = e;
          }
     }


     [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
     public void Consumption(double expect)
     {
          corner.Should().Be(expect);
     }

     [Then(@"возникает ошибка Exception")]
     public void Exeption()
     {
          except.Should().BeOfType<System.ArgumentException>();
     }
}