using System;

namespace SampleConsoleApp
{
    internal class Ex05_ArraysExample
    {

        private static void arrayClassExample()
        {
            Console.WriteLine("Enter the data type of the Array U want to create as CTS Type");
            Type type = Type.GetType(Console.ReadLine());
            if(type == null)
            {
                Console.WriteLine("Invalid Type!!!");
                return;
            }
            Console.WriteLine("Enter the Size of the Array U want to create");
            int size = int.Parse(Console.ReadLine());
            //Array is the built-In class of .NET.
            Array objInstance = Array.CreateInstance(type, size);
            for (int i = 0; i < objInstance.Length; i++)
            {
                Console.WriteLine("Enter a value of the Type " + type.Name);
                var value = Convert.ChangeType(Console.ReadLine(), type);
                objInstance.SetValue(value, i);
            }

            foreach (var no in objInstance) Console.WriteLine(no);
        }
        static void Main(string[] args)
        {
            //datatype [] identifier = new datatype[size];
            //simpleArrayExample();

            arrayClassExample();

        }

        private static void simpleArrayExample()
        {
            string[] fruits = new string[5];//5 string objects. 
            fruits[0] = "Apples";
            fruits[1] = "Mangoes";
            fruits[2] = "Bananas";
            fruits[3] = "Oranges";
            fruits[4] = "Kiwis";
            //Length property gets the no of elements in an Array
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(fruits[i]);
            }

            Console.WriteLine("using foreach statement.......");
            foreach (string fruit in fruits)
                Console.WriteLine(fruit);
        }
        /*
* Arrays in fixed in size in C#. 
* If U want dynamic Arrays, U should use Collections and Generics. 
* U can have multi-dimensional Array, Jagged Array.
* All arrays are objects of a class called System.Array. This class has also got a static method called CreateInstance that can create an Array based on inputs given by the User. 
*/
    }
}
