//日志结构
using System;
using System.IO;

namespace Lesson008
{
    static class L
    {
        //分割不同的日志,使用者最小负担
       
        static public string LogFileName = "runtime.log"; //确定日志文件
        //避免并发操作，主线程受到干扰，将aLog记录到内部缓冲器，
        static public void W(string aLog)
        {
            //包装，以时间包装
            string aContent = $"[{DateTime.Now:yyyy-MM--dd HH:mm:ss}] {aLog}";
            File.AppendAllText(LogFileName,aContent);
        }
    }
}
