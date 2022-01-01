﻿// <auto-generated />
using EmployeeManagement.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "89 Chiaroscuro Rd, Portland, USA",
                            Email = "thomashardy@mail.com",
                            Name = "Thomas Hardy",
                            Phone = "(171) 555-222"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Obere Str. 57, Berlin, Germany",
                            Email = "dominiqueperrier@mail.com",
                            Name = "Dominique Perrier",
                            Phone = "(313) 555-5735"
                        },
                        new
                        {
                            Id = 3,
                            Address = "25, Rue lauriston, Paris, France",
                            Email = "mariaanders@mail.com",
                            Name = "Maria Anders",
                            Phone = "(503) 555-9931"
                        },
                        new
                        {
                            Id = 4,
                            Address = "C/ Araquil, 67, Marid, Spain",
                            Email = "franwilson@mail.com",
                            Name = "Fran Wilson",
                            Phone = "(204) 619-5731"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Via Monte Blanco 34, Turin, Italy",
                            Email = "martinblank@mail.com",
                            Name = "Martin Blank",
                            Phone = "(480) 631-2097"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
