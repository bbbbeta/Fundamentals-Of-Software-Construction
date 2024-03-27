using System;
using System.Collections.Generic;

namespace GenericApplication
{
    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    // 泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        // 添加ForEach方法
        public void ForEach(Action<Node<T>> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current);
                current = current.Next;
            }
        }

        // 计算最大值和最小值
        public void CalculateMinMax(out int min, out int max)
        {
            min = max = 0;
            int count = 0;
            Node<T> current = head;

            while (current != null)
            {
                int value = (int)(object)current.Data;
                count++;

                if (count == 1)
                {
                    min = max = value;
                }
                else
                {
                    min = Math.Min(min, value);
                    max = Math.Max(max, value);
                }

                current = current.Next;
            }

            // 如果链表为空，则min和max保持为0
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            // 使用ForEach方法打印链表元素
            intlist.ForEach(node => Console.WriteLine(node.Data));

            // 计算总和
            int sum = 0;
            intlist.ForEach(node => sum += (int)(object)node.Data);
            Console.WriteLine($"Sum: {sum}");

            // 计算最大值和最小值
            int min, max;
            intlist.CalculateMinMax(out min, out max);
            Console.WriteLine($"Min: {min}, Max: {max}");
        }
    }
}