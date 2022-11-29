// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Protocols;
using SampleEFCoreApp;

Console.WriteLine("Hello, World!");

var context = new ContactDbContext();
context.Database.EnsureCreated();

var data = context.Contacts.ToList();
foreach (var c in data)
{
    Console.WriteLine(c.ContactName);
}
addContact("Suresh", "suresh@gmail.com", 9945684123);

static void addContact(string name, string email, long phoneNo)
{
    var rec = new Contact
    {
         ContactEmail = email, ContactName= name, ContactNo= phoneNo
    };
    var context = new ContactDbContext();
    context.Contacts.Add(rec);
    context.SaveChanges();
    Console.WriteLine("Added successfully");
}
