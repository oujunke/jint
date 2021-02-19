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
            Writer.WriteLine(log);
            Console.WriteLine(log);
        }
    }
}
