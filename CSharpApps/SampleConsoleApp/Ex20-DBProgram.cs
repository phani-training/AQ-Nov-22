using System;
using System.Data.SqlClient;

/*
 * ADO.NET is the data access model for connecting to external databases like RDBMS and Non Relational Databases. 
 * It comes in 2 models: Connected(Desktop Apps) and Disconnected Model(Web Apps). 
 * In Connected model, our App will connect to the database and while the connection is open, we will perform all the operations required for the App. Once the operations are done, we can close the connection allowing others to use it. Connected model gives live data but not suited for Web centric apps where the user count is large. 
 * All classes are created under System.Data.SqlClient. 
 * ADO.NET has interfaces that are implemented by the vendors of the database to give connector classes for .NET Applications. 
 * In connected model, we use the following classes:
 * xxxConnection: A Class that is used to connect to the specific database. It will have methods like Open and Close to connect and disconnect from the database. It has ConnectionString property that contains the string info about the DB connection like Servername, Database name, User Credentials and so forth...
 * xxxCommand: Represents the SQL statements that we want to execute on the database. It will be associated with the Connection to execute the statements. There are 3 ways to execute a Command: 
 * ExecuteReader For select statements
 * ExecuteNonQuery for Insert, delete and Update Statements
 * ExecuteScalar for Scalar value data(1 Record or data is obtained). 
 * xxxDataReader is an object obtained from the ExecuteReader method of the Command class that is used to read the data. 
 */
namespace SampleConsoleApp
{
    class DBProgram
    {
        #region ALLCONSTANTS
        const string CONNECTIONSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=AQInsightsDB;Integrated Security=True";
        #endregion
        static void addNewRecord(string name, string address, double salary)
        {
            string insertQuery = $"Insert into EmpTable values('{name}', '{address}', {salary})";
            //Create the Connection
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            //Create the Command
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            //Execute the Query
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //Display a Success message
        }
        static void Main(string[] args)
        {
            addNewRecord("Ramesh", "Hyderabad", 70000);
        }
    }
}