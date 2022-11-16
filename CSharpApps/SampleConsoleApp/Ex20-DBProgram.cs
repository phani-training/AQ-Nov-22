using System;
using System.Data.SqlClient;
namespace SampleConsoleApp
{
    class DBProgram
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AQInsightsDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SElECT * FROM EMPTABLE", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["EmpName"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}