using System;
/*
 * System.Object is the base class for all data types in .NET. Object class is the class that provides the common functions for all the Data types of .NET for both value and reference types. Even for the custom classes and structs U create will be derived from System. Object.
 * C# has a keyword called object to represent System.Object. 
 * object can hold any kind of data U want. This is called as BOXING. The actual data type is boxed into the object type and stored. BOXING is implicit. 
 * If the boxed variable has to perform any specific operations, it should be typecasted back to the same type from which it was boxed. This is called UNBOXING. This is explicit casting.  
 * If U R developing a function whose data type is not known at compile Time, U can set the return type of the function as object. 
 * With object, U get a common set of functions that can be applied on all types:
 * ToString to get the string representation of the variable
 * Equals Method to perform the logical Equivalence of the variable.
 * GetType method to get the actual data type of the boxed variable. 
 * GetHashCode method is used to get ID of the object in the CLR. 
 */

namespace SampleConsoleApp
{
    class Ex10_Objects
    {
        static void Main(string[] args)
        {
            object value = 123; //object holding int value
            Console.WriteLine(value.GetType().FullName);
        
            int intValue = (int)value;//UNBOXING is explicit
            Console.WriteLine(++intValue);
            value = "SomeThing";//object holding a string value;
            Console.WriteLine(value.GetType().Name);

            Console.WriteLine(value.ToString().ToUpper());
        }
    }
}
