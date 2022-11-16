using System;
namespace SampleConsoleApp
{
    interface IExample
    {
        void Demo();
    }

    interface ISimple
    {
        void Demo();
    }

    class SimpleExample : IExample, ISimple
    {
        public void Demo() => Console.WriteLine("General Demo");
        void ISimple.Demo() => Console.WriteLine("Simple Demo");
        void IExample.Demo() => Console.WriteLine("Example Demo");
    }
    class ExplicitInterfaceExample
    {
        static void Main(string[] args)
        {
            SimpleExample simEx = new SimpleExample();
            simEx.Demo();

            ISimple sim = new SimpleExample();
            sim.Demo();

            IExample ex = new SimpleExample();
            ex.Demo();
        }
    }
}