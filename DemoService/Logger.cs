using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoService
{
    class Logger
    {
        public static void logger(string message)
        {

            try
            {
                string logFilePath = "C:\\AppLogs\\DemoService";

                if (!Directory.Exists(logFilePath))
                    Directory.CreateDirectory(logFilePath);

                using(StreamWriter writter = new StreamWriter(Path.Combine(logFilePath, "DemoService.log"), true))
                {
                    writter.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:MM:ss") + " : " + message);
                }
            }
            catch(Exception e) { }
        }
    }
}
