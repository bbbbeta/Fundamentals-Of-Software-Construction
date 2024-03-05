using System;
using System.Xml.XPath;

namespace Demo_01
{
    class Calculate
    {
        public void Work(double a, double b, char c)
        {
            double result = 0.0;

            switch (c)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    else
                    {
                        Console.WriteLine("除数不能为0！请重新输入除数：");
                        double b1 = double.Parse(Console.ReadLine());
                        Work(a, b1, c);
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("输入符号有误！请重新输入符号：");
                    char c1 = char.Parse(Console.ReadLine());
                    Work(a, b, c1);
                    return;
                    break;
            }
            Console.WriteLine("{0}{1}{2}={3}", a, c, b, result);

        }
        static void Main(String[] args)
        {
            Console.WriteLine("请输入第一个数字：");
            double first = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入第二个数字：");
            double second = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符（+-*/）");
            char cal = char.Parse(Console.ReadLine());
            Calculate calculator = new Calculate();
            calculator.Work(first, second, cal);

        }
    }
}

