﻿
//练习02
/// <summary>
/// 定义一个MyFunction类，计算函数：
/// 
/// </summary>
namespace Practice
{
    class MyFunction
    {
        public double a { get; }
        public double b { get; }
        public double c { get; }
        public MyFunction(double aa,double bb,double cc)
        {
            a = aa;
            b = bb;
            c = cc;
        }
        public double Calc(double x,double y)
        {
            return a * x * x + b * y * y + a * b * x * y + c;
        }
    }
}