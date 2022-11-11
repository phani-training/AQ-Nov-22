using System;

namespace SampleConsoleApp
{
    internal class Ex04_DataConversions
    {
        static void Main(string[] args)
        {
            int value = 2000;
            long longValue = value;//Implicit casting. The data conversion happens without any external help. 
            Console.WriteLine("The long value is " + longValue);

            //value = (int)longValue;//Explicit casting. The data conversion needs to be explicitly converted using C style casting. (int) is the way of casting a value to an integer. 
            value = Convert.ToInt32(longValue);
            Console.WriteLine("The value is " + value);

            Console.WriteLine("------------------Ranges of the value types---------");
            Console.WriteLine($"The range of byte is {byte.MinValue} and {byte.MaxValue}");
            Console.WriteLine($"The range of short is {short.MinValue} and {short.MaxValue}");
            Console.WriteLine($"The range of int is {int.MinValue} and {int.MaxValue}");
            Console.WriteLine($"The range of long is {long.MinValue} and {long.MaxValue}");
            Console.WriteLine($"The range of float is {float.MinValue} and {float.MaxValue}");
            Console.WriteLine($"The range of double is {double.MinValue} and {double.MaxValue}");
            Console.WriteLine($"The range of decimal is {decimal.MinValue} and {decimal.MaxValue}");
        }
        /*
         * Longer range values can be implicitly casted by the shorter range variables. 
         * U need casting when the shorter range variable has to fill the larger range data.
         * U could also use the Convert class to do the conversion. 
         * Try to create a variable of data type long and convert it to integer. let the long variable have the value as 234423432434334. Display the output. For Conversion, use the C style casting. 
         * Convert is more safe way of converting the value types. 
         * For converting string to a value type, use the type's Parse method. 
         */
    }
}
