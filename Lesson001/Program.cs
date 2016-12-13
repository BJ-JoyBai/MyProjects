using System;
using System.Collections.Generic;

namespace Lesson001
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                string aText = Console.ReadLine();
                try
                {
                    A.Add(int.Parse(aText));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"输入【{aText}】错误【{ex.Message}】，忽略本次输入。");
                }
            }
            A.Sort();
            foreach (int x in A)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
    }
}
