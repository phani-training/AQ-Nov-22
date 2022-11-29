# .NET CORE 
### What is .NET CORE?
- It is a framwork for building .NET based Apps on multiple platforms like Mac and Linux.  It was first started in 2015 and current version is .NET 7.0 Core. 
- It comes with Visual studio or U can install seperately without a need of Visual Studio. 
- However for Code Development, U can use VS Code.
- U have Command line Utilities called Dotnet CLI that can be used for developing the Application, building and executing the Apps. 

### How to create .NET Apps in .NET CORE?
1. U can run the application from the CLI. 
2. U have the .NET CORE installed with every shippment of Windows 10 or later. 
3. U can also download the .NET CORE SDK from the Microsoft Downloads URL. 
4. To create a new Console Application, U can use 
```
dotnet new console -n SampleCoreApp
```
5. To add packages like EF or any U can use the following command:
```
dotnet add package Newtonsoft.json
```
6. To build the Project: U can use the command: dotnet build
7. To exeucute the App: U can use the command: dotnet run

### How to create EF Core App with Code First Approach
1. Install the following nuget Packages in ur project
	- Microsoft.EntityFrameworkCore
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools
2. Implement the classs for the Entity and DBContext, refer the CodeFirstApproach.cs file. 
3.Open the Package Manager Console and run the following commands:
	- add-migration migrationName-version
	- update-database
4. View the Server explorer to see the Generated database and Tables. 
5. Any modifications U do on the classes, U should run the above commands to get the newer versions of the Context Object

