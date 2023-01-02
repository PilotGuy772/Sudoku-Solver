using System;

namespace Utils
{
    public class ConsoleUtils
    {
        public static void ColorLine(object input, ConsoleColor foreColor, ConsoleColor originalColor = ConsoleColor.White)
        {
            Console.ForegroundColor = foreColor;
            Console.WriteLine(input);
            Console.ForegroundColor = originalColor;
        }

        public static void HighlightLine(object input, ConsoleColor backgroundColor, ConsoleColor originalColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(input);
            Console.ForegroundColor = originalColor;
        }

        public static void ColorWrite(object input, ConsoleColor foreColor, ConsoleColor originalColor = ConsoleColor.White)
        {
            Console.ForegroundColor = foreColor;
            Console.Write(input);
            Console.ForegroundColor = originalColor;
        }

        public static void HighlightWrite(object input, ConsoleColor backgroundColor, ConsoleColor originalColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(input);
            Console.ForegroundColor = originalColor;
        }
    }
}