using System;
using System.Collections.Generic;

//练习01
//用数组定义一组无序整数。
//对这组整数排序；
//提示：可以用Array.Sort方法。
//从终端输出这组整数。

//用List<int>定义一组无序整数。
//对这组整数排序；
//提示：可以用List的Sort方法。
//从终端输出这组整数。
namespace Practice
{
    class Program
    {
        delegate double F(double x);////描述方法类型

        static void Main(string[] args)
        {
            //Practice01();
            //Practice02();  
            Practice03();
        }

        public static void Practice01()
        {
            // int[] A = new int[10];
            List<int> A = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                string aText = Console.ReadLine();
                try
                {
                    // A[i] = int.Parse(aText);
                    A.Add(int.Parse(aText));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"输入[{aText}]错误[{ex.Message}],忽略本次输入");
                    //  A[i] = 0;
                }
            }
            // Array.Sort(A);
            A.Sort();
            foreach (int x in A)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();
        }

        public static void Practice02()
        {
            MyFunction aCalc = new MyFunction(1, 2, 3);
            Console.WriteLine($"Calc(1.2,2.3)={aCalc.Calc(1.2, 2.3)}");
            Console.WriteLine($"Calc(2.5,3.2)={aCalc.Calc(2.5, 3.2)}");
            Console.ReadLine();
        }

        //定义一个以委托为参数的算法框架（例如绘制指定计算函数的图形）。
        //在Main函数中测试传递不同的计算函数给这个算法框架。
        static void Draw(int[,] B,F aFunc,double x0,double x1,double y0,double y1)
        {
            for(int col=0;col<B.GetLength(1);col++)
            {
                B.Initialize();//初始化清0
                double x = x0 + (x1 - x0) * col / (B.GetLength(1) - 1);
                double y = aFunc(x);
                int row = (int)((B.GetLength(0) - 1) * (y - y1) / (y0 - y1));
                B[row, col] = 1;
            }
        }
        static void Print(int[,] B)
        {
            for(int i=0;i<B.GetLength(0);i++)
            {
                for(int j=0;j<B.GetLength(1);j++)
                {
                    Console.Write(B[i, j] == 1 ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
        public static void Practice03()
        {
            int[,] B = new int[30, 60];
            Draw(B, Math.Sin, 0, 2 * 3.14, -1, 1);
            Print(B);
            Console.ReadLine();
        }
    }
   
}
