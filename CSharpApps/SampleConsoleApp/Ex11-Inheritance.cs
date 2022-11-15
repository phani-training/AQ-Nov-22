using System;
/*
 * Inheritance is based on Open-Closed Principle of OOP. 
 * C# supports Single Inheritance. U can have only one base class at any level. 
 * Base class is one that extends to another class. It is also refered as Super Class, Parent Class.  
 * Derived class is one which is using the extended feature. It is also called as Sub Class, Child Class etc. 
 * All the public members of the base class become the public members of the derived class. 
 * There is no concept of Private Inheritance in C#.
 * If a method is defined in the base class, and U want to modify that method in the derived class, we can do it using Method overriding. 
 */
namespace SampleConsoleApp
{
    class BaseClass
    {
        public void BaseFunc() => Console.WriteLine("base Function");
    }

    class DerivedClass : BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Function");
    }
    class Ex11_Inheritance
    {
        static void Main(string[] args)
        {
            DerivedClass cls = new DerivedClass();
            cls.BaseFunc();
            cls.DerivedFunc();
        }
    }
}
