using System;
using System.Linq;

namespace Lesson011
{
    class Program
    {
        static void Main(string[] args)
        {
            /* int[] aDatas = new int[] { 8, 15, 10, 22, 98, 7, 43, 87, 52, 19 };
             // 检索符合条件的数据
             var aQuery = from r in aDatas where r > 30 select r;
             foreach (int x in aQuery) Console.WriteLine(x);
             Console.ReadLine();*/
            string[] aDatas = { "Java", "C#", "C++", "Delphi", "VB.net", "VC.net", "C++ Builder", "Kylix", "Perl", "Python" };
            var aQuery = from r in aDatas
                         group r by r.Length into aGroup
                         orderby aGroup.Key
                         select aGroup;//根据长度分组
            foreach (var aDataGroup in aQuery)
            {
                Console.WriteLine($"长度为{aDataGroup.Key}的分组：");
                // Console.WriteLine("长度为{0}的分组", aDataGroup.Key);
                foreach (var aData in aDataGroup) Console.WriteLine(aData);
            }
            Console.ReadLine();
            var aQuery1 = from r in aDatas
                         group r by r.Substring(0, 1) into aGroup
                         orderby aGroup.Key
                         select aGroup;//根据首字母分组
        }
    }
}
