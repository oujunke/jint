using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jint
{
   public class LogUtils
    {
        static StreamWriter Writer;
        static LogUtils()
        {
            Writer = new StreamWriter("text.log");
        }
        public static void Log(string log)
        {
            var printLog = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}--{log}";
            Writer.WriteLine(printLog);
            Console.WriteLine(printLog);
        }
        public static void Flush()
        {
            Writer.Flush();
        }
    }
}
