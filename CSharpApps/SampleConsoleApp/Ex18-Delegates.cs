/*
 * Delagates are like function pointers. It is used to represent functions that could be passed as arguments to other functions. 
 * .NET gives 2 delegates called Func and Action to represent different kinds of functions as arguments. The Func<T> is used for Non-void Functions and Action is used for Void Functions. 
 * Frameworks like Win Forms, ASP.NET Web Forms have their own set of delegates for all event, thread based programming. 
 * Practical usage of Delegates are on events, async functions, multi threading, Finders or Predicates etc. 
 */
using System;

namespace SampleConsoleApp
{
    delegate void FunctionType();//Like a class
    class DelegateExample
    {
        //To take a function as arg and will call that function after certain business logic is met. 
        static void CallMe(FunctionType func)
        {
           Console.WriteLine("Some actions are done");
            func();
            Console.WriteLine("The Function has ended");
        }

        static void testFunc() => Console.WriteLine("Test Func");
        static void Main(string[] args)
        {
            CallMe(testFunc);//Passing an explicit func as arg...

            CallMe(() =>
            {
                Console.WriteLine("Passing Lambda Method as arg");
            });
        }
    }
}