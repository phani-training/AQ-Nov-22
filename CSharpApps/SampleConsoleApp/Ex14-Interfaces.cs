/*
 * Interfaces are improvised version of Abstract class where all the methods will be abstract. 
 * Interface members are public only. 
 * A class that implements the interface must implement all the methods of the interface with public scope. 
 * A class can implement multiple interfaces at the same level. 
 * interfaces are created using interface keyword and recommended to be prefixed with I. 
 */

using System;
using System.Data;

namespace SampleConsoleApp
{
    interface IAccountManager
    {
        void CreateNewAccount(int id, string name, double amount);
        void UpdateAccount(int id, string name);
        void DeleteAccount(int id);
        DataTable GetAllAccounts();
    }

    class FileAccountManager : IAccountManager
    {
        public void CreateNewAccount(int id, string name, double amount)
        {
            Console.WriteLine($"The Account is created for Mr.{name} with Balance of Rs.{amount} and ID as {id} in the FileSystem");
        }

        public void DeleteAccount(int id)
        {
            Console.WriteLine($"The Acount by ID {id} is deleted");
        }

        public DataTable GetAllAccounts()
        {
            var table = new DataTable("Accounts");
            table.Columns.Add("AccountId", typeof(int));
            table.Columns.Add("Holder", typeof(string));
            table.Columns.Add("Balance", typeof(double));

            var row = table.NewRow();
            row[0] = 123;
            row[1] = "Phaniraj";
            row[2] = 67000;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 124;
            row[1] = "Madan";
            row[2] = 57000;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 125;
            row[1] = "Nanda";
            row[2] = 65000;
            table.Rows.Add(row);
            return table;
        }

        public void UpdateAccount(int id, string name)
        {
            Console.WriteLine("The Account is updated");
        }
    }

    class InterfaceExample
    {
        static void Main(string[] args)
        {
            IAccountManager mgr = new FileAccountManager();
            mgr.CreateNewAccount(123, "Phaniraj", 45000);
            var accounts = mgr.GetAllAccounts();
            foreach(DataRow row in accounts.Rows)
            {
                Console.WriteLine($"The Holder: {row[1]}.\nBalance: {row[2]}");
            }
        }
    }
}