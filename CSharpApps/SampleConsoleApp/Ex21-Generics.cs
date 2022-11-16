
using SampleConsoleApp.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Arrays have limitations, so we have a group of classes for handling data that could be dynamic, store in a required manner under the namespace System.Collections. 
 * ArrayList, HashTable are some of the classes. Collections store the data as objects. It is not type-safe. 
 * In .NET 2.0, Generic Collections were introduced that were type safe. They work like Templates of C++. Now all Apps use Generics only. 
 * List<T> is similar to arrays but is dynamic. U can insert the element anywhere in the list and remove from any location. It is easy to iterate. 
 * List<T> does not check for Duplicates. To store Unique values, we use HashSet<T>
 * Dictionary<K,V> stores the data in the form of key value pairs. Key is unique and value may not be unique. The Uniqueness of the Key is determined using the HashCode Concept that we saw in the HashSet example. 
 * All Classes of Collections do implement an interface called: IEnumerable
 * IEnumerable->IEnumerable<T>->ICollection<T>->IList<T>, ISet<T>, IDictionary<K,V>.
 * IEnumerable gives a Function called GetEnumerator that returns an IEnumerator object which we can iterate thro the collection. 
 */
namespace SampleConsoleApp
{
    
    class GenericsDemo
    {
        static void Main(string[] args)
        {
            //arrayListExample();
            //listExample();
            //hashSetExample();
            //hashSetEmployeeExample();
            //dictionaryExample();
            //queueExample();
        }

        private static void queueExample()
        {
            Queue<string> items = new Queue<string>();
            items.Enqueue("Item1"); //Adds the item to the queue
            items.Enqueue("Item2");
            items.Enqueue("Item3");
            items.Enqueue("Item4");
            items.Dequeue();//Removes the first item in the queue. U cannot remove any item in b/w in a Queue. 
            Console.WriteLine("The count: " + items.Count);
            foreach (var item in items) Console.WriteLine(item);
        }

        private static void dictionaryExample()
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            users.Add("phaniraj", "welcome123");//Adds the new key-value pair. If the key already exists, it throws an Exception. 
            users["gopal"] = "testing123";//Adds a new Key-value pair, if the key exists, it replaces the value. 

            Console.WriteLine("The count: " + users.Count);
            foreach(KeyValuePair<string, string> pair in users)
                Console.WriteLine($"Key->{pair.Key}, Value->{pair.Value}");
        }

        private static void hashSetEmployeeExample()
        {
            HashSet<Employee> empList = new HashSet<Employee>();
            empList.Add(new Employee { EmpId = 1, EmpName = "Suresh", EmpAddress = "Mysore", EmpSalary = 45000 });
            empList.Add(new Employee { EmpId = 2, EmpName = "Suresh", EmpAddress = "Mysore", EmpSalary = 45000 });
            empList.Add(new Employee { EmpId = 1, EmpName = "Suresh", EmpAddress = "Mysore", EmpSalary = 45000 });
            empList.Add(new Employee { EmpId = 1, EmpName = "Suresh", EmpAddress = "Mysore", EmpSalary = 45000 });
            empList.Add(new Employee { EmpId = 1, EmpName = "Suresh", EmpAddress = "Mysore", EmpSalary = 45000 });
            Console.WriteLine("The Total EmpCount is {0}", empList.Count);//Expected 1...
            foreach (var emp in empList)
            {
                Console.WriteLine(emp);//Console.WriteLine always evaluates the Value to its String version by calling ToString method of the object. 
            }
        }

        private static void hashSetExample()
        {
            HashSet<string> cart = new HashSet<string>();
            bool answer = true;
            while (answer)
            {
                if(!cart.Add(Util.GetString("Enter the Item to add to cart")))
                {
                    Console.WriteLine("item already added into the cart");
                }
                Console.WriteLine("The Total no of Items in the cart: {0}", cart.Count);
                answer = Util.GetString("DO U want to add new Item to cart? Press Y or N").ToUpper() == "Y";
            }
            

        }

        private static void listExample()
        {
            List<string> fruits = new List<string>();//Create the instance of the List...
            fruits.Add("Apples");
            fruits.Add("Big Apples");
            fruits.Add("Costly Apples");
            fruits.Add("Pine Apples");
            fruits.Add("Custard Apples");
            Console.WriteLine("The total Apple list: " + fruits.Count);
            fruits.Remove("Costly Apples");
            Console.WriteLine("The total Apple list: " + fruits.Count);

            foreach (var item in fruits) Console.WriteLine( item);

        }

        private static void arrayListExample()
        {
            ArrayList list = new ArrayList();
            list.Add(213);//Numbers
            list.Add("Apples");//Strings
            list.Add(true);//booleans
            list.Add(new int[] { 123, 23, 45, 6, 77, 8 });//Array
            list.Add(new { ItemId = 123, ItemName = "SampleName" });//object..
            //U canot perform common operations on this collection object. So the programmer should be very carefull while working with old Collection Classes
            for(int i =0; i < list.Count; i++)
                Console.WriteLine(list[i]);
        }
    }
}

/*
 * Create a User Info app that allows users to register and login. It should be a menu driven program on Console that allows the users to either signup or signin. The App does not do anything else other than these 2 operations. If the User has logged properly, the Login Success message should be displayed, else the login failure message be displayed. 
 */