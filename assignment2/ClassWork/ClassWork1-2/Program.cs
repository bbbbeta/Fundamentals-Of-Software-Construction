using System;
using System.ComponentModel.DataAnnotations;

namespace Work2
{
    class Work2
    {
        static int GetMax(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("数组为空");
                return -1;
            }

            int Max = array[0];

            foreach(int i in array)
            {
                if (i > Max)
                {
                    Max = i;
                }
            }
            return Max;
        }

        static int GetMin(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("数组为空");
                return -1;
            }

            int Min = array[0];

            foreach (int i in array)
            {
                if (i < Min)
                {
                    Min = i;
                }
            }
            return Min;
        }

        static int GetSum(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("数组为空");
                return -1;
            }

            int Sum = 0;

            foreach (int i in array)
            {
                Sum += i;
            }
            return Sum;
        }

        static int GetAverage(int[] array)
        {
            int Sum = GetSum(array);
            return GetSum(array) / array.Length;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组中整数的个数：");
            int[] array1 = new int[int.Parse(Console.ReadLine())];
            Console.WriteLine("逐个输入数组中的整数：");
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("最大值："+GetMax(array1));
            Console.WriteLine("最小值：" + GetMin(array1));
            Console.WriteLine("均值：" + GetAverage(array1));
            Console.WriteLine("和：" + GetSum(array1));
        }
    }
}