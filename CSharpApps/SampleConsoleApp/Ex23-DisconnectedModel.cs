using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleConsoleApp
{
    class DisconnecedExample
    {
        const string CONNECTIONSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=AQInsightsDB;Integrated Security=True";
        static DataTable getAllRecords()
        {
            SqlConnection con = new SqlConnection(CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand("SELECT * FROM EMPTABLE", con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("SomeName");
            ada.Fill(ds, "TableName");
            Console.WriteLine("The Current ConnectionState: " + con.State);
            return ds.Tables["TableName"];
        }
        static void Main(string[] args)
        {
            var records = getAllRecords();
            foreach(DataRow row in records.Rows)
            {
                Console.WriteLine($"{row[1]} comes from {row[2]}");
            }
        }
    }
}