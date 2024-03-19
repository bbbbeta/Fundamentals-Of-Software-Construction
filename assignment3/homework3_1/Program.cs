using System;

namespace Homework3_1
{
    //interface
    public interface Shape
    {
        double GetArea();//计算面积
        Boolean IsLegal();//合法性检测
    }

    //abstract
    public abstract class ShapeAbstract : Shape
    {
        
        public abstract double GetArea();
        public abstract bool IsLegal();
    }

    public class Rectangle : Shape
    {
        private double length { get; set; }
        private double width { get; set; }

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double GetArea() => length * width;
        public bool IsLegal() => (length >= 0 && width >= 0);
        
    }

    public class Square : ShapeAbstract
    {
        private double length { get; set; }

        public Square(double length)
        {
            this.length = length;
        }

        public override double GetArea() => length * length;
        public override bool IsLegal() => (length >= 0);
    }

    public class Triangle : Shape
    {
        private double baseLength {get;set; }
        private double height { get; set; }

        public Triangle(double baseLength,double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }
        public double GetArea()=>baseLength * height * 0.5;
        public bool IsLegal() => (baseLength >= 0 && height >= 0);


    }

    public class Circle : ShapeAbstract
    {
        private double radius { get; set; }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetArea()=>radius * radius * 0.5;
        public override bool IsLegal() => (radius >= 0);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5, 10);
            Console.WriteLine(rectangle.IsLegal() + " " + rectangle.GetArea());
            Square square = new Square(10);
            Console.WriteLine(square.IsLegal() + " " + square.GetArea());
            Triangle triangle = new Triangle(6, 8);
            Console.WriteLine(triangle.IsLegal() + " " + triangle.GetArea());
            Circle circle = new Circle(2.5);
            Console.WriteLine(circle.IsLegal() + " " + circle.GetArea());
        }
    }
}
