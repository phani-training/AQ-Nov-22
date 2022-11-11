using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp
{
    internal static class Util
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        } 

        public static DateTime GetDate()
        {
            int year = int.Parse(GetString("Enter the Year of Birth"));

            int month = int.Parse(GetString("Enter the Month of Join as 1 to 12"));

            int day = int.Parse(GetString("Enter the Date of the Month appropriately"));
            return new DateTime(year, month, day);
        }
    }
}
