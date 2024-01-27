/*
circle => S = pi*r^2
triangle => P/2 = (A + B + C)/2 => S = sqrt(P*(P-A)*(P-B)*(P-C))
Юнит-тесты
Легкость добавления других фигур + был создан интерфейс 
Вычисление площади фигуры без знания типа фигуры в compile-time
Проверку на то, является ли треугольник прямоугольным*/
using Geometry.Interfaces;
using System;

//Circle
public class Circle : IShape
{
    public double Radius { get;}
    //Constructor for circle
    public Circle(double radius)
    {
        Radius = radius;
    }
    public double calculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
//Triangle
public class Triangle : IShape
{
    public double SideA {  get; }
    public double SideB { get; }
    public double SideC { get; }
    //constructor for triangle
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    public bool IsTriangle()
    {
        return ((SideA + SideB > SideC) && (SideA + SideC > SideB) && (SideB + SideC > SideA));
    }
    //here Im check for squareness
    public bool IsRightTriangle()
    {
        if (IsTriangle())
        {
            //here S = 1/2 * catheter * catheter
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);
            //Pifagore theoremy
            return (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2));
        }
        return false;
    }
    public double calculateArea()
    {
        if (IsTriangle())
        {
            if (IsRightTriangle()) //if right just find a hepotenuse and catheters, after multiple this catheters
            {
                double hepotenuse = Math.Max(SideA, Math.Max(SideB, SideC));
                double catheter1, catheter2;
                if (hepotenuse == SideA)
                {
                    catheter1 = SideB;
                    catheter2 = SideC;
                }
                else if (hepotenuse == SideB)
                {
                    catheter1 = SideA;
                    catheter2 = SideC;
                }
                else
                {
                    catheter1 = SideA;
                    catheter2 = SideB;
                }
                return 0.5 * (catheter1 * catheter2);
            }
            else //if not right triangle find a halfOfPerimetr and use a formula
            {
                double halfOfPerimetr = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(halfOfPerimetr * (halfOfPerimetr - SideA) * (halfOfPerimetr - SideB) * (halfOfPerimetr - SideC));
            }
        }
        return -1;
    }
}
