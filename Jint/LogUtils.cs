using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jint
{
    public class LogUtils
    {
        private static readonly StreamWriter s_writer;
        static LogUtils()
        {
            s_writer = new StreamWriter("text.log");
        }
        public static void Log(string log)
        {
            var printLog = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}--{log}";
            s_writer.WriteLine(printLog);
            Console.WriteLine(printLog);
        }
        public static void Flush()
        {
            s_writer.Flush();
        }
    }
}
