using SampleConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        const string UPDATE_QUERY = "UPDATE EMPTABLE SET EmpName = @name, EmpAddress = @address, EmpSalary = @salary where Id = @id";

        const string DELETE_QUERY = "DeleteEmployee"; //Stored Proc Name....

        const string SELECT_QUERY = "SELECT * FROM EMPTABLE";
        #endregion


        static Employee[] getAllEmployees()
        {
            List<Employee> empList = new List<Employee>();
            using(SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                SqlCommand cmd = new SqlCommand(SELECT_QUERY, con);
                con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var emp = new Employee
                        {
                            EmpId = Convert.ToInt32(reader[0]),
                            EmpName = reader[1].ToString(),
                            EmpAddress = reader[2].ToString(),
                            EmpSalary = Convert.ToDouble(reader[3])
                        };
                        empList.Add(emp);
                    }
                    return empList.ToArray();
            }
        }
        static void deleteRecord(int id)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(DELETE_QUERY, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                var rowsAffecfed = cmd.ExecuteNonQuery();
                if (rowsAffecfed != 1)
                    throw new Exception("No Record found to delete");
            }
            finally
            {
                con.Close();
            }
        }
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
                throw ex;
            }
            finally
            {
                con.Close();
            }
            //Display a Success message
        }

        static void updateRecord(int id, string name, string address, double salary)
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(UPDATE_QUERY, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 1)
                    throw new Exception("No Record found to update");
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            addNewRecord("Ramesh", "Hyderabad", 70000);
            try
            {
                var records = getAllEmployees();
                foreach(var emp in records)
                    Console.WriteLine(emp);
                //deleteRecord(4);
                //updateRecord(4, "Ramesh Reddy", "Panjagutta, Hyderabad", 65000);
                Console.WriteLine("Record Deleted Succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}