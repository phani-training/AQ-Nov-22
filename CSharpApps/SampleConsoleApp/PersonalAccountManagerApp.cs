using System;
using System.IO;
/*
 * Objective: To create an Application that will be used by an individual to manage his personal expenses for a month. 
 * Entity: Expense: Id, Description, Amount, Date.  
 * Repository Class: Functions of the CRUD operations of UR App.
 * UI Class: That takes inputs and displays the outputs of the Application. 
 */
namespace SampleConsoleApp
{
    class Expense
    {
        private static int no = 0; //This is used for auto generating a number.

        public Expense()
        {
            ExpenseID = ++no;
        }                            
        public int ExpenseID { get; private set; }//It cannot be set outside the class. 
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }  
    }

    class ExpenseManager
    {
        //Store the data:
        Expense[] allExpenses = null;
        private readonly int size; //read only members can be set only in the constructor and once set, cannot be modified anywhere.
        public ExpenseManager(int size)
        {
            this.size = size;
            allExpenses = new Expense[size];
        }


        public void AddNewExpense(string desc, int amount, DateTime date)
        {
            for (int i = 0; i < size; i++)
            {
                if(allExpenses[i] == null)
                {
                    allExpenses[i] = new Expense
                    {
                        Amount = amount, Description = desc, Date = date
                    };
                    return;//exit the loop after the insertion is completed. 
                }
            }
        }

        public Expense[] GetAllExpenses()
        {
            return allExpenses;
        }

        public void DeleteExpense(int id)
        {
            for (int i = 0; i < size; i++)
            {
                if((allExpenses[i]!=null) && (allExpenses[i].ExpenseID == id))
                {
                    allExpenses[i] = null;//Removal of the data.there is no delete operator in C#. 
                    return;//exit the function...
                }

            }
        }


        public Expense GetExpenseDetails(int id)
        {
            //Iterate thru the loop, find the first occurance of the Expense with matching id, return the Expense.
            for (int i = 0; i < size; i++)
            {
                if ((allExpenses[i] != null) && (allExpenses[i].ExpenseID == id))
                    return allExpenses[i];
            }
            throw new Exception("No record found!!!");
        }
        public void UpdateExpense(int id, Expense newDetails)
        {
            for (int i = 0; i < size; i++)
            {
                if ((allExpenses[i] != null) && (allExpenses[i].ExpenseID == id))
                {
                    allExpenses[i].Description = newDetails.Description;
                    allExpenses[i].Amount = newDetails.Amount;
                    allExpenses[i].Date = newDetails.Date;                 
                    return;//exit the function...
                }

            }
        }


    }

    class PersonalAccountManagerApp
    {
        const string fileName = @"C:\Trainings\AQ-Dotnet\CSharpApps\SampleConsoleApp\ExpenseManagerMenu.txt";
        static ExpenseManager mgr = new ExpenseManager(int.Parse(Util.GetString("Enter the Max No of Expenses for the App")));
        static void Main()
        {
            string menu = File.ReadAllText(fileName);
            bool process = true;
            do
            {
                int choice = int.Parse(Util.GetString(menu));
                process = processMenu(choice);
                Util.GetString("Press Enter to clear the Menu");
                Console.Clear();
            } while (process);
        }

        static bool processMenu(int choice) 
        {
            switch (choice)
            {
                case 1:
                    addNewExpense();
                    return true;
                case 2:
                    updateExpense();
                    return true;
                case 3:
                    deleteExpense();
                    return true;
                case 4:
                    displayAllRecords();
                    return true;
                default:
                    return false;
            }
        }

        private static void deleteExpense()
        {
            var id = int.Parse(Util.GetString("Enter the Id of the expense to delete"));
            mgr.DeleteExpense(id);
            Console.WriteLine("Expense deleted successfully to the System!!!!");
        }

        private static void updateExpense()
        {
            //Get the current expense.
            var id = int.Parse(Util.GetString("Enter the Id of the expense to update"));
            var desc = Util.GetString("Enter the Description details of the Expense");
            var amount = int.Parse(Util.GetString("Enter the Amount of the expense"));
            var date = Util.GetDate();
            var expense = mgr.GetExpenseDetails(id);
            expense.Description = desc;
            expense.Date = date;
            expense.Amount = amount;
            mgr.UpdateExpense(id, expense);
            Console.WriteLine("Expense added successfully to the System!!!!");
        }

        private static void displayAllRecords()
        {
            var records = mgr.GetAllExpenses();
            foreach (var rec in records)
            {
                if(rec!=null)
                Console.WriteLine($"Date: {rec.Date.ToLongDateString()}\nDescription: {rec.Description}\nTotal Amount: {rec.Amount}\nRecord ID: {rec.ExpenseID}");
            }
        }

        private static void addNewExpense()
        {
            var desc = Util.GetString("Enter the Description details of the Expense");
            var amount = int.Parse(Util.GetString("Enter the Amount of the expense"));
            var date = Util.GetDate();
            mgr.AddNewExpense(desc, amount, date);
            Console.WriteLine("Expense added successfully to the System!!!!");
        }
    }
}
