/*
Define an abstract class called Shape with an abstract method Area() . Create two derived classesCircle and Rectangle that implement the Area()
method for calculating the area of the respective shapes */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shapes
{
    internal class Program
    {
        abstract class Shape
        {
            
            public abstract double Area();
        }

        class Circle : Shape
        {
            private double radius;

            
            public Circle(double radiusofcircle) => radius = radiusofcircle;
           
            
            public override double Area() => 3.14 * radius * radius;
           
        }

        class Rectangle : Shape
        {
            private double width;
            private double height;

            
            public Rectangle(double widthofrectangle, double heightofrectangle)
            {
                width = widthofrectangle;
                height = heightofrectangle;
            }

            
            public override double Area() =>  width* height;
            
        }

        static void Main(string[] args)
        {
            Shape circle1 = new Circle(5);
            Console.WriteLine($"Area of Circle: {circle1.Area()}");

            
            Shape rectangle1 = new Rectangle(4, 6);
            Console.WriteLine($"Area of Rectangle: {rectangle1.Area()}");
        }
    }
}