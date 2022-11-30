using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiDemo.Models
{
    [Table("StudentTable")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
    [Table("BranchTable")]
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options) :base(options)
        {

        }

        //Properties for the data:
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Branch>().HasData(
                new Branch { BranchId = 1, Name = "Electronics" },    
                new Branch { BranchId = 2, Name = "Computer Science" },    
                new Branch { BranchId = 3, Name = "Mechanical" },    
                new Branch { BranchId = 4, Name = "Electrical" },    
                new Branch { BranchId = 5, Name = "Civil" }
            );
        }
    }
}
