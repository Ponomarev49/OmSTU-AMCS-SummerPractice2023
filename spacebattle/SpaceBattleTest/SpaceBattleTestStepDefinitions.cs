using FluentAssertions;
using System;
namespace Specflowproj.Steps;
using SpaceBattleLib;
using TechTalk.SpecFlow;

[Binding, Scope(Feature = "Космический бой")]
public class SpaceBattl
{
     private SpaceShip NCC_1701 =  new SpaceShip(); 
     private Exception except {get; set;}

     [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
     public void Coord(double a, double b)
     {
     NCC_1701.coord = new double[]{a,b};
     }

     [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
     public void Speed(double a, double b)
     {
     NCC_1701.speed = new double[]{a,b};
     }

     [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
     public void CoordNaN()
     {
     NCC_1701.coord = new double[]{double.NaN,double.NaN};
     }

     [Given(@"скорость корабля определить невозможно")]
     public void SpeedNaN()
     {
     NCC_1701.speed = new double[]{double.NaN,double.NaN};
     }

     [Given(@"изменить положение в пространстве космического корабля невозможно")]
     public void CoordNot()
     {
     NCC_1701.coord = new double[]{double.NaN,double.NaN};
     }
     

     [When(@"происходит прямолинейное равномерное движение без деформации")]
     public void SpaceBattle()
     {
          try
          {
               NCC_1701.coord = SpaceBattleLib.SpaceShip.Move(NCC_1701.coord, NCC_1701.speed);
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
          NCC_1701.coord.Should().ContainInOrder(expected);
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
     private SpaceShip NCC_1701 =  new SpaceShip();
     private Exception except {get; set;}
     [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
     public void Fuel_Count(double a)
     {
          NCC_1701.fuel_count = a;
     }

     [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
     public void Consaption_count(double b)
     {
          NCC_1701.consumption = b;
     }


     [When(@"происходит прямолинейное равномерное движение без деформации")]
     public void Movement()
     {
          try
          {
               NCC_1701.fuel_count = SpaceBattleLib.SpaceShip.Fuel(NCC_1701.fuel_count,NCC_1701.consumption);
          }
          catch(ArgumentException e)
          {
               except = e;
          }
     }


     [Then(@"новый объем топлива космического корабля равен (.*) ед")]
     public void Consumption(double expect)
     {
          NCC_1701.fuel_count.Should().Be(expect);
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
     private SpaceShip NCC_1701 =  new SpaceShip();
     private Exception except {get; set;}
     [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
     public void Ship_corner(double a)
     {
          NCC_1701.corner = a;
     }

     [Given(@"космический корабль, угол наклона которого невозможно определить")]
     public void Ship_corner_NaN()
     {
          NCC_1701.corner = double.NaN;
     }

     [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
     public void Ship_corner_Stop()
     {
          NCC_1701.corner = double.NaN;
     }

     [Given(@"имеет мгновенную угловую скорость (.*) град")]
     public void Ship_corner_speed(double b)
     {
          NCC_1701.corner_speed = b;
     }

     [Given(@"мгновенную угловую скорость невозможно определить")]
     public void Ship_corner_speed_NaN()
     {
          NCC_1701.corner_speed = double.NaN;
     }


     [When(@"происходит вращение вокруг собственной оси")]
     public void Rotation()
     {
          try
          {
               NCC_1701.corner = SpaceBattleLib.SpaceShip. Corner_speed(NCC_1701.corner,NCC_1701.corner_speed);
          }
          catch(ArgumentException e)
          {
               except = e;
          }
     }


     [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
     public void Consumption(double expect)
     {
          NCC_1701.corner.Should().Be(expect);
     }

     [Then(@"возникает ошибка Exception")]
     public void Exeption()
     {
          except.Should().BeOfType<System.ArgumentException>();
     }
}