using System;

namespace Work3
{
    class OutputPrime
    {
        static bool JudgePrime(int num)
        {
            bool result = true;
            if (num < 2)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
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
            bool[] isPrime = new bool[100];
            
            for(int i=1;i<isPrime.Length;i++)
            {
                isPrime[i-1] = true;
            }
            isPrime[0] = isPrime[1] = false;

            for (int i = 2; i < 100; i++)
            {
                if (JudgePrime(i))
                {
                    for(int j = 2 * i; j < isPrime.Length; j+=i)
                    {
                        isPrime[j-1] = false;
                    }
                }
            }

            for(int i = 2; i < 100; i++)
            {
                if (isPrime[i-1])
                {
                    Console.WriteLine(i+" ");
                }
            }

        } 
    }
}