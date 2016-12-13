using System;
using System.Threading;

namespace Lesson004
{
    delegate void MyClarifyEventHandler(object sender, int clarifydata);

    class Program
    {
        static void Main(string[] args)
        {
            MyWorkClass aWork = new MyWorkClass();
            aWork.ProgressChanged += OnWork_ProgressChanged;
            Console.WriteLine("开始计算……");
            aWork.DoWork();
            Console.WriteLine("计算结束！");
            Console.ReadLine();
        }

        private static void OnWork_ProgressChanged(object sender, int clarifydata)
        {
            Console.Write(".");
        }
    }

    class MyWorkClass
    {
        public event MyClarifyEventHandler ProgressChanged;
        public void DoWork()
        {
            for (int i = 0; i < 100; i++)
            {
                ProgressChanged?.Invoke(this, i);
                Thread.Sleep(200);
            }
        }
    }
}
