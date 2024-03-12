using System;

namespace Work1
{
    class isPrime
    {

    static bool IsPrime(int num)//判断是否为质数
        {
            bool result = true;
            if (num < 2)
            {
                return false;
            }
            for(int i = 2; i < num; i++)
            {
                if (num % 2 == 0)
                {
                    return false;
                }
            }
            return result;
        }
    static void Main(string[] args)
        {
            Console.WriteLine("请输入数据：");
            int num = int.Parse(Console.ReadLine());
            for(int i = 2; i < num;i++)
            {
                while (num % i == 0)
                {
                    if (IsPrime(i))
                    {
                        num = num / i;
                        Console.WriteLine(i + " ");
                    }
                }

            }
        }

    }
}
