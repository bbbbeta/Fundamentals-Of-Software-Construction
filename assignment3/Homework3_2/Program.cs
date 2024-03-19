using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Homework3_2
{
    public static class ShapeFactory
    {
        public static Shape Create(String typeOfShape) {
            Random random = new Random();
            switch(typeOfShape)
            {
                case "Rectangle":
                    return new Rectangle { length = random.Next(1, 10), width = random.Next(1, 10) };
                case "Square":
                    return new Square { length = random.Next(1, 10) };
                case "Triangle":
                    return new Triangle { baselength = random.Next(1, 10) ,height=random.Next(1,10)};
                default:
                    throw new ArgumentException("类型错误");
            }
        }

    }

    public interface Shape
    {
        double GetArea();
    }

    // 长方形类
    public class Rectangle : Shape
    {
        public double length { get; set; }
        public double width { get; set; }
        public double GetArea() => length * width;
    }

    // 正方形类
    public class Square : Shape
    {
        public double length { get; set; }
        public double GetArea() => length * length;
    }

    // 三角形类
    public class Triangle : Shape
    {
        public double baselength { get; set; }
        public double height { get; set; }
        public double GetArea() => 0.5 * baselength * height;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double areaSum = 0;
            string[] shapeTypes = { "Rectangle", "Square", "Triangle" };
            for (int i = 0; i < 10; i++)
            {
                string typeOfShape = shapeTypes[new Random().Next(0, shapeTypes.Length)];
                Shape shape = ShapeFactory.Create(typeOfShape);
                areaSum += shape.GetArea();
            }

            Console.WriteLine($"10个形状的总面积为: {areaSum}");
        }
    }
}
