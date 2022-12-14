// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApiDemo.Models;

namespace StudentApiDemo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentApiDemo.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.ToTable("BranchTable");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            BranchId = 2,
                            Name = "Computer Science"
                        },
                        new
                        {
                            BranchId = 3,
                            Name = "Mechanical"
                        },
                        new
                        {
                            BranchId = 4,
                            Name = "Electrical"
                        },
                        new
                        {
                            BranchId = 5,
                            Name = "Civil"
                        });
                });

            modelBuilder.Entity("StudentApiDemo.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("StudentTable");
                });

            modelBuilder.Entity("StudentApiDemo.Models.Student", b =>
                {
                    b.HasOne("StudentApiDemo.Models.Branch", "Branch")
                        .WithMany("Students")
                        .HasForeignKey("BranchId");
                });
#pragma warning restore 612, 618
        }
    }
}
