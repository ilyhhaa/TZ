using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ
{
    public static class Logger
    {
        public enum LogDestination
        {
            Console,
            File
        }

        private static LogDestination _destination = LogDestination.Console;
        private static string _filePath = "log.txt";

        public static void SetDestination(LogDestination destination, string filePath = null)
        {
            _destination = destination;
            if (filePath != null)
            {
                _filePath = filePath;
            }
        }

        public static void Log(string message)
        {
            if (_destination == LogDestination.Console)
            {
                Console.WriteLine(message);
            }
            else if (_destination == LogDestination.File)
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
        }
    }
}
