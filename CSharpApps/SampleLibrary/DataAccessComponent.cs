using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SampleLibrary
{
    namespace Entities
    {
        public class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpAddress { get; set; }
            public double EmpSalary { get; set; }
        }
    }

    namespace Data
    {
        using Entities;
        public interface IEmployeeDB
        {
            void AddNewEmployee(Employee emp);
            void UpdateEmployee(Employee emp);
            void DeleteEmployee(int id);
            List<Employee> FindEmployee(string empName);
            Employee FindEmployee(int id);
        }

        class EmployeeDB : IEmployeeDB
        {
            #region CONSTANTS
            const string CONNECTIONSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=AQInsightsDB;Integrated Security=True";
            const string DELETE_QUERY = "DELETE FROM EMPTABLE WHERE ID = @id";
            const string UPDATE_QUERY = "UPDATE EMPTABLE SET EmpName = @name, EmpAddress = @address, EmpSalary = @salary WHERE Id = @id";
            const string SELECT_BYNAME = "SELECT * FROM EMPTABLE WHERE EMPNAME LIKE %@name%";
            const string SELECT_BYID = "SELECT * FROM EMPTABLE WHERE ID = @id";
            const string INSERT_QUERY = "Insert into EmpTable values(@name, @address, @salary)";
            #endregion

            public void AddNewEmployee(Employee emp)
            {
                using(var con = new SqlConnection(CONNECTIONSTRING)){
                    var cmd = new SqlCommand(INSERT_QUERY, con);
                    cmd.Parameters.AddWithValue("@name", emp.EmpName);
                    cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
                    cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
                    con.Open();
                    var rows = cmd.ExecuteNonQuery();
                    if (rows != 1)
                        throw new EmployeeException("Insertion failed for the database");
                }
            }

            public void DeleteEmployee(int id)
            {
                using (var con = new SqlConnection(CONNECTIONSTRING))
                {
                    var cmd = new SqlCommand(DELETE_QUERY, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    var rows = cmd.ExecuteNonQuery();
                    if (rows != 1)
                        throw new EmployeeException("Deletion failed for the database");
                }
            }

            public List<Employee> FindEmployee(string empName)
            {
                List<Employee> allEmpList = new List<Employee>();
                using(var con = new SqlConnection(CONNECTIONSTRING))
                {
                    var cmd = new SqlCommand(SELECT_BYNAME, con);
                    cmd.Parameters.AddWithValue("@name", empName);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        throw new EmployeeException($"No Record matching to the {empName} found");
                    }
                    while (reader.Read())
                    {
                        var emp = new Employee
                        {
                            EmpAddress = reader[2].ToString(),
                            EmpId = Convert.ToInt32(reader[0]),
                            EmpName = reader[1].ToString(),
                            EmpSalary = Convert.ToDouble(reader[3])
                        };
                        allEmpList.Add(emp);
                    }
                }
                return allEmpList;
            }

            public Employee FindEmployee(int id)
            {
                using (var con = new SqlConnection(CONNECTIONSTRING))
                {
                    var cmd = new SqlCommand(SELECT_BYID, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        throw new EmployeeException($"No Record matching to the {id} found");
                    }
                    while (reader.Read())
                    {
                        var emp = new Employee
                        {
                            EmpAddress = reader[2].ToString(),
                            EmpId = Convert.ToInt32(reader[0]),
                            EmpName = reader[1].ToString(),
                            EmpSalary = Convert.ToDouble(reader[3])
                        };
                        return emp;
                    }
                }
                throw new EmployeeException("No employee found with this ID");
            }

            public void UpdateEmployee(Employee emp)
            {
                using (var con = new SqlConnection(CONNECTIONSTRING))
                {
                    var cmd = new SqlCommand(UPDATE_QUERY, con);
                    cmd.Parameters.AddWithValue("@name", emp.EmpName);
                    cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
                    cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
                    cmd.Parameters.AddWithValue("@id", emp.EmpId);
                    con.Open();
                    var rows = cmd.ExecuteNonQuery();
                    if (rows != 1)
                        throw new EmployeeException("Updation failed for the database");
                }
            }
        }


        public static class EmployeeFactory
        {
            public static IEmployeeDB GetComponent() => new EmployeeDB(); 
        }
    }
}
