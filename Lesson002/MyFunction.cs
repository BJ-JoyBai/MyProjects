namespace Lesson002
{
    class MyFunction
    {
        public MyFunction(double aa, double ab, double ac)
        {
            a = aa;
            b = ab;
            c = ac;
        }
        public double Calc(double x, double y)
        {
            return a * x * x + b * y * y + a * b * x * y + c;
        }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
    }
}
