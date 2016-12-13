using System;

namespace Lesson005
{
    class Program
    {
        static void MyWork(A aInstance)
        {
            Console.WriteLine("开始工作……");
            aInstance.Func();
            Console.WriteLine("工作结束！");
        }
        static void Main(string[] args)
        {
            MyWork(new A());
            MyWork(new B());
            MyWork(new C());
            Console.ReadLine();
        }
    }

    class A
    {
        public virtual void Func()
        {
            Console.WriteLine("来自A的Func！");
        }
    }

    class B : A
    {
        public override void Func()
        {
            Console.WriteLine("来自B的Func!");
        }
    }

    class C : A
    {
        public override void Func()
        {
            Console.WriteLine("来自C的Func！");
        }
    }
}
