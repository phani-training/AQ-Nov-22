using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsoleApp
{
    internal class Ex02_InputOutputDemo
    {
        static void Main(string[] apple)
        {
            Console.WriteLine("Enter the Name");
            var name = Console.ReadLine();//Always returns string.

            Console.WriteLine("Enter the Address");
            var address = Console.ReadLine();

            Console.WriteLine("Enter the Salary");
            var salary = Console.ReadLine();

            //Display it as a single text:
            Console.WriteLine($"The Name is {name} from {address} and earns a salary of {salary:C}");

        }
    }
}
