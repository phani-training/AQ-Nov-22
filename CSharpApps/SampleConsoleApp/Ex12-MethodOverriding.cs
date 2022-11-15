/*
 * Method overriding is a feature of OOP that allows sub classes to modify the super class functions and promote a concept called Runtime Polymorphism.
 * In C#, the base class methods should be marked with a modifier called virtual
 * Derived class will use a modifier called override for the methods that U R trying to override.
 * Only methods that are virtual, override and abstract can be used to override in the class. 
 * U cannot modify the signature of the method while implementing it. 
 * If U try to override the non-virtual method, U can do that without using override keyword. This is called Method Hiding. In this case, the polymorphic feature will not be available. The Base version of the method will be called always when U invoke the method irrespective of the type of the object. 
 */
using System;
namespace SampleConsoleApp
{
    class SuperClass
    {
        public virtual void SimpleFunction() => Console.WriteLine("Simple Function implemented");

        public void NonVirtualFunction() => Console.WriteLine("Non Virtual from base class");
    }

    class SubClass : SuperClass
    {
        public override void SimpleFunction() => Console.WriteLine("Simple Function from Derived");

        public new void NonVirtualFunction() => Console.WriteLine("Non Virtual from Derived class");

    }

    class ClassFactory
    {
        public static SuperClass CreateComponent(string type)
        {
            if (type == "Super")
                return new SuperClass();
            else if (type == "Sub")
                return new SubClass();
            else
                return null;
        }
    }
    class MethodOverriding
    {
        static void Main()
        {
            SuperClass cls = null;
            Console.WriteLine("Enter the Class type as Super or Sub");
            string input = Console.ReadLine();
            cls = ClassFactory.CreateComponent(input);
            cls.SimpleFunction();//This Derived version will be called. 
            cls.NonVirtualFunction();

            //Use this only if U want the derived version to be called. 
            if(cls is SubClass)
            {
                SubClass subObj = cls as SubClass;//as can be used on reference types only..
                subObj.NonVirtualFunction();
            }
        }
    }
}