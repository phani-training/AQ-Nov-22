using System;
/*
 * A Dll is a precompiled Unit that is distributed to the end users in which the code will be in a binary format. Dlls are also called as Assemblies in .NET. 
 * A DLL could be created in .NET using the Class Library Project Template. 
 * The classes created in the project are by default internal, they are available only within that project. If U want to make a class available in other projects also, U should mark the class as public.
 * When U create a DLL, it can be referenced in other projects and consumed. Dlls cannot be executed. They are associated with an EXE Project and used there. 
 * 
 */

namespace SampleLibrary
{
    //public makes this class available outside this project, which is the main intention of the dll. 
    public class MathComponent
    {
        public double AddFunction(double v1, double v2) => v2 + v1;
        public double SubtractFunction(double v1, double v2) => v1 - v2;
        public double MultiplyFunction(double v1, double v2) => v2 * v1;
        public double DivFunction(double v1, double v2) => v2 / v1;
    }
}
