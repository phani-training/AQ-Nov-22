using SampleLibrary;
using System;
/*
 * U should Add the reference of the DLL as Project Reference if the DLL is in the same s`uolution. Else U can browse the DLL location and select it.
 * U should use the namespace of the class that U want to use.
 * Only public classes of the DLL are exposed to the Client Apps.
 */
namespace SampleConsoleApp
{
    class DllDemo
    {
        static void Main(string[] args)
        {
            MathComponent com = new MathComponent();
            var result = com.AddFunction(123, 234);
            Console.WriteLine("The Result: " + result);
        }
    }
}