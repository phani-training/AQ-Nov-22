using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Enums are named Constants used to store numeric values represented by readable names. Enums are custom data types. U create them before U use.
namespace SampleConsoleApp
{
    enum Months
    {
        Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
    }
    internal class Ex06_Enums
    {
        static void Main(string[] args)
        {
            Months month = Months.Jun;
            Console.WriteLine("The selected Month is " + month);
            Console.WriteLine("Its internal value is " + (int)month);

            Array allMonths = Enum.GetValues(typeof(Months));//Gets all the possible values of the enum.
            foreach (var val in allMonths) Console.WriteLine(val);
            Console.WriteLine("Please enter one of the month from the above list");
            Months userSelectedMonth = (Months)Enum.Parse(typeof(Months), Console.ReadLine(), true);
            //Parse method is used to convert the input string to the Months Type. 
            Console.WriteLine("The selected Month is " + userSelectedMonth);
        }
    }
}
