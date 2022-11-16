using System;
/*
 * In .NET Exceptions are objects of a class Derived from System.Exception. 
 * Exceptions are thrown using throw keyword. 
 * Exceptions are to be caught in ur application. 
 * try...catch...finally are used to handle Exceptions in .NET.
 * Every try should have a catch or finally or both. finally or catch is must. 
 * .NET itself has Exceptions for common errors that are encountered in the Applications: FileNotFoundException, IndexOutOfRangeException, DivideByZeroException, OverFlowException, FormatException, SqlException, ArgumentException and many more. 
 */
namespace SampleConsoleApp
{
    class ExceptionHandlingExample
    {
        static void basicExample()
        {
        RETRY:
            try
            {
                Console.WriteLine("Enter a number");
                int inputValue = int.Parse(Console.ReadLine());
                Console.WriteLine("The input is " + inputValue);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Expected a whole number");
                Console.WriteLine(ex.Message);
                goto RETRY;
            }
            catch (OverflowException ofEx)
            {
                Console.WriteLine($"The number should be within the range of {int.MinValue} and {int.MaxValue}");
                Console.WriteLine(ofEx.Message);
                goto RETRY;
            }
            finally
            {
                Console.WriteLine("Clean up operation, executed always");
            }
        }
        static void Main(string[] args)
        {
            //basicExample();
            //IndexOutOfRangeExceptionDemo();
            //DivideByZeroExceptionDemo();
            
        }

        private static void DivideByZeroExceptionDemo()
        {
            int denominator = int.Parse(Util.GetString("Enter the Division value"));//Input should be 0...
            Console.WriteLine("The Division is " + (123/denominator));
        }

        private static void IndexOutOfRangeExceptionDemo()
        {
            int[] elements = new int[4];
            elements[5] = 1234;
        }
    }
}