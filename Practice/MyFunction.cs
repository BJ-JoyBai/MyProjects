
//练习02
/// <summary>
/// 定义一个MyFunction类，计算函数：///F(x, y) = ax2+by2+abxy+c///函数系数a和b可以在构造实例时指定，然后可以用MyFunction实例对多组(x, y)进行计算。///在Main函数中测试MyFunction类的实例创建和使用
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
