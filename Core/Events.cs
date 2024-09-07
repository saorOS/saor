using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace saór.Core
{
    public static class Events
    {
        public static void Neutral()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string Neutral(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            return name + ": " + message;
        }
        public static string Warning(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return name + ": " + message;
        }
        public static string Success(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return name + ": " + message;
        }
        public static string FatalError(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return name + ": " + message;
        }
        public static string Error(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return name + ": " + message; 
        }
    }
}
