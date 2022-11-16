using System;
namespace SampleConsoleApp
{
    /*
     * U can create Static Constructors in C#. This is used to provide dependencies to static variables of the class. 
     * Constructors are required to inject the dependencies for UR object creation. 
     * If UR class has a base class that has only parameterized constructor, then UR class constructor should explicitly call it at the constructor level using base keyword. base always points to the immediate base class.
     */
    class BaseClass
    {
        public BaseClass(string arg) 
        {
            Console.WriteLine("base Version of string arg");
        }
    }
    class SimpleExample : BaseClass
    {
        private string data;
        public SimpleExample() : base("Sample Arg")//Default constructors
        {
            Console.WriteLine("Object instance is created");
        }
        //
        public SimpleExample(string data) : this()//Parameterized constructor
        {
            this.data = data;
            Console.WriteLine("Object instance is created with arg " + data);
        }
    }
    class InterfaceExample
    {
        static void Main(string[] args)
        {
            SimpleExample ex = new SimpleExample();//parenthesis is the formal way to call the constructor of the class
            for (int i = 0; i < 100; i++)
            {
                SimpleExample test = new SimpleExample("Arg" + i);
            }
        }
    }
}