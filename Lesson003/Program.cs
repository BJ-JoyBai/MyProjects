using System;

namespace Lesson003
{
    class Program
    {
        delegate double F(double x);

        static void Draw(int[,] B, F aFunc, double x0, double x1, double y0, double y1)
        {
            B.Initialize();
            for (int col = 0; col < B.GetLength(1); col++)
            {
                double x = x0 + (x1 - x0) * col / (B.GetLength(1) - 1);
                double y = aFunc(x);
                int row = (int)((B.GetLength(0) - 1) * (y - y1) / (y0 - y1));
                B[row, col] = 1;
            }
        }
        static void Print(int[,] B)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] == 1 ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[,] B = new int[30, 60];
            Draw(B, Math.Sin, 0, 2 * 3.14, -1.2, 1.2);
            Print(B);
            Console.ReadLine();
        }
    }
}
