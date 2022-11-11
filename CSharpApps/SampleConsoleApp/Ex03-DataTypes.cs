using System;
namespace SampleConsoleApp
{
    internal class Ex03_DataTypes
    {
        static void Main()
        {
            Console.WriteLine("Enter the ID");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();
            
            Console.WriteLine("Enter the Salary");
            double salary = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the Year of Join");
            int year = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the Month of Join as 1 to 12");
            int month = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the Date of the Month appropriately");
            int day = int.Parse(Console.ReadLine());

            DateTime dateOfJoin = new DateTime(year, month, day);

            Console.WriteLine($"The name {name} from {address} who earns a salary of Rs.{salary} has joined the Organization on {dateOfJoin.ToLongDateString()}");
        }
    }
}
