using System;

namespace SampleConsoleApp
{
    internal static class Util
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static int GetNumber(string question) => int.Parse(GetString(question));
        public static double GetDouble(string question) => double.Parse(GetString(question));

        public static DateTime GetDate()
        {
            int year = int.Parse(GetString("Enter the Year part"));

            int month = int.Parse(GetString("Enter the Month of Join as 1 to 12"));

            int day = int.Parse(GetString("Enter the Date of the Month appropriately"));
            return new DateTime(year, month, day);
        }
    }
}
