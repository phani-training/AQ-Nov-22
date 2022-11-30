# Steps for Creating an End to End Application. 
### Type of the Project:
Choose ASP.NET Core Web API Project. 

### Additional Nuget Packages.
1. EntityFrameworkCore
2. EntityFrameworkCore.Tools
3. EntityFrameworkCore.SqlServer

### Models of the Application
1. Create a Folder called Models in your Project
2. Design the Models based on the Requirement
3. Use attributes like [Key], [ForeignKey] for columns, [Table] for the Table Names.
4. Create the DBContext Class and use the DBContextOptions for the Web API. 

### Tools of EF Core. 
1. Run the command: add-migration <migName>
2. Run the command: update-database

### Create the Controllers.
1. Implement the controllers based on the Project requirement. 
2. Create a Parameterized constructor or injecting the DB Context object.
3. Modify the Program.cs/StartUp.cs to provide the Injection code for DBContext and define the Connectionstrings to UR EF Classes. 

### Test the Web API
1. Use Swagger or Postman to test the Application. 
