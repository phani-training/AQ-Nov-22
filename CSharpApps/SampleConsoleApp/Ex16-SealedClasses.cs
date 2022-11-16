using System;
/*
 * If U want UR methods not to be modified by the Sub classes, U can mark the method as sealed and the class as sealed so that the class can never be inherited or extended. Example of sealed classes are String, DateTime, Console.
 * A method can be sealed only if it is extended from another class. The base class should have modifiers like virtual, override or abstract. 
 * sealed methods can be placed in the non-sealed classes. This works very similar to final methods of Java.
 */
namespace SampleConsoleApp
{
    class ParentExample
    {
        public virtual void TestFunc() => Console.WriteLine("Test Func");
    }
    sealed class ChildExample : ParentExample
    {
        public sealed override void TestFunc()
        {
            Console.WriteLine("This is the Derived Impl and it cannot be overriden further");
        }
    }

   
    class SealedClassesExample
    {
        static void Main(string[] args)
        {
            ParentExample ex = new ChildExample();
            ex.TestFunc();
        }
    }
}