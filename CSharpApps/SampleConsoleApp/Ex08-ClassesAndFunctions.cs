using System;
/*
 * Members of the class could be accessed within the class using this operator. However, it is required to use this operator only if U have naming conflicts. The parameter names and the Class field names might be same, in such cases we would use this operator to refer the fields of the class.
 * Functions inside a class are required only to manipulate the members of the class. Most of the time, the fields are private. To access/modify them, U need either properties or Functions. 
 * Functions allow to take arguments that could be passed when the user calls the function. 
 * Functions will have return types if it is intended to return a value after the function completes its task. 
 * Functions can be static or instance based. If a function is not having a modifier called static, then it should be called only using an object of that class. 
*/
namespace SampleConsoleApp
{
    class DataClass
    {
        private int data1;
        private string data2;

        public void Modify(int data1, string data2)
        {
            this.data1 = data1;
            this.data2 = data2;
        }

        public string GetAllInfo()
        {
            return $"The Integer was {data1} and the string was {data2}";
        }
        public string GetStringData()
        {
            return data2;
        }

        public int GetIntData()
        {
            return data1;
        }


    }
    class Ex08_ClassesAndFunctions
    {
        static void Main()
        {
            DataClass cls = new DataClass();
            cls.Modify(123, "Some Value to the Field");
            Console.WriteLine("The string data : " + cls.GetStringData());
            Console.WriteLine("The Int data : " + cls.GetIntData());
            Console.WriteLine(cls.GetAllInfo());
        }
    }
}
