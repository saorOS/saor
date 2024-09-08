using System;
using Console = System.Console;

namespace saór.Core
{
    public static class Events
    {
        /// <summary>
        /// Resets the color to default.
        /// </summary>
        public static void Clean()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Returns a Neutral string, setting white foreground color.
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <param name="message">Message of the action.</param>
        /// <returns>Returns a string with the requested name and message.</returns>
        public static string Neutral(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            return name + ": " + message;
        }

        /// <summary>
        /// Returns a Warning string, setting yellow foreground color.
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <param name="message">Message of the action.</param>
        /// <returns>Returns a string with the requested name and message.</returns>
        public static string Warning(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return name + ": " + message;
        }

        /// <summary>
        /// Returns a Success string, setting green foreground color.
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <param name="message">Message of the action.</param>
        /// <returns>Returns a string with the requested name and message.</returns>
        public static string Success(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return name + ": " + message;
        }

        /// <summary>
        /// Returns a Fatal Error string, setting dark red foreground color.
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <param name="message">Message of the action.</param>
        /// <returns>Returns a string with the requested name and message.</returns>
        public static string FatalError(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            return name + ": " + message;
        }

        /// <summary>
        /// Returns a Error string, setting red foreground color.
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <param name="message">Message of the action.</param>
        /// <returns>Returns a string with the requested name and message.</returns>
        public static string Error(string name, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return name + ": " + message;
        }
    }
}
