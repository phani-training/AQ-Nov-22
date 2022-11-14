using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Inputs to a function is like providing the dependencies for the function so that it performs the task required and returns the data if the data computed has to be used outside this function.
//A Function will take args as Pass by Value. Any change U make to the parameter of the function will not affect the original value passed by the caller of this function. 
//A ref parameter will allow the functional Changes made to the parameter available after it returns to the caller. 
//Out parameter also does the same, but the caller of the function need not initialize the value before passing it to the function. 
//If UR method needs to have variable no of args then U can go for params. There can be only one params for a function. params should be the last parameter of the function. params is passed by value all the time.  

namespace SampleConsoleApp
{
    class MathComponent
    {
        public double AddFunction(double v1, double v2)
        {
            return v1 + v2;
        }

        public double SubFunction(double v1, double v2) => v1 - v2;
        public double MulFunction(double v1, double v2) => v1 * v2;
        public double DivFunction(double v1, double v2) => v1 / v2;

        public double Square(double v1) => v1 * v1;
        public double SquareRoot(double v1) => Math.Sqrt(v1);

    }
    class Ex09_Functions
    {
        static void testFunc(ref int value)
        {
            Console.WriteLine("The value passed: " + value);
            value = (value + 123 - 34 + value) * 3;
            Console.WriteLine("The value Modified: " + value);
        }

        static void mathOperation(double v1, double v2, ref double addedValue, ref double subtractedValue, out double divValue)
        {
            addedValue = v1 + v2;
            subtractedValue = v1 - v2;
            if (v2 != 0) divValue = v1 / v2; else divValue = 0;
        }
        
        static double AddFunction(params double [] values)
        {
            var result = 0.0;
            foreach (var value in values)
            {
                result += value;
            }
            return result;
        }

        static string FullName(params string[] names)
        {
            string fullName = string.Empty;
            foreach (var name in names)
            {
                fullName += name + " ";
            }
            return fullName.Trim();
        }
        static MathComponent component = new MathComponent();
        static void Main()
        {

            //double addedValue = 0, subtractedValue = 0, divValue;
            //mathOperation(123, 23, ref addedValue, ref subtractedValue, out divValue);
            //Console.WriteLine($"The Added value: {addedValue} and Subtracted Value: {subtractedValue}");
            //Console.WriteLine($"The Divided value : {divValue: ##.##}");

            //double v1 = double.Parse(Util.GetString("Enter the First Value"));
            //double v2 = double.Parse(Util.GetString("Enter the Second Value"));
            //string operand = Util.GetString("Enter the Operation as + or - or X or /");
            //PerformOperation( v1, v2, operand);

            //int value = 100;
            //testFunc(ref value);
            //Console.WriteLine("The value after the function call : " + value);    

            var result = AddFunction(12,14,45);
            Console.WriteLine(result);

            Console.WriteLine("Enter the First Name");
            string fName = Console.ReadLine();

            Console.WriteLine("Enter the Middle Name");
            string mName = Console.ReadLine();

            Console.WriteLine("Enter the Last Name");
            string lName = Console.ReadLine();

            string fullName = FullName(fName, mName, lName);
            Console.WriteLine("The name is " + fullName);
        }

        private static void PerformOperation(double v1, double v2, string operand)
        {
            switch (operand)
            {
                case "+":
                    Console.WriteLine(component.AddFunction(v1, v2));
                    break;
                case "-":
                    Console.WriteLine(component.SubFunction(v1, v2));
                    break;
                case "X":
                    Console.WriteLine(component.MulFunction(v1, v2));
                    break;
                case "/":
                    Console.WriteLine(component.DivFunction(v1, v2));
                    break;
                default:
                    break;
            }
        }
    }
}
