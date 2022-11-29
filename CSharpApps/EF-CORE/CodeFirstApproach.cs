using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEFCoreApp
{
    [Table("ContactTable")]
    public class Contact
    {
        public long ContactNo { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        [Key]
        public int ContactId { get; set; }
    }

    public class ContactDbContext : DbContext
    {
        //create a default constructor
        public ContactDbContext()
        {

        }
        public DbSet<Contact>? Contacts { get; set; }

        //Use this function to set the connectionstring to ur database.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=SampleDatabase;Integrated Security=True");
        }
    }
}
