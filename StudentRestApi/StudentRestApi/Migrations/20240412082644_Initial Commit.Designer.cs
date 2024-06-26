﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentRestApi.Models;

#nullable disable

namespace StudentRestApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240412082644_Initial Commit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentRestApi.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            DepartmentId = 1,
                            Email = "ritik@gmail.com",
                            FirstName = "Ritik",
                            Gender = 0,
                            LastName = "Bhati"
                        },
                        new
                        {
                            StudentId = 2,
                            DepartmentId = 2,
                            Email = "vinay@gmail.com",
                            FirstName = "Vinay",
                            Gender = 0,
                            LastName = "Bhati"
                        },
                        new
                        {
                            StudentId = 3,
                            DepartmentId = 3,
                            Email = "rajdeep@gmail.com",
                            FirstName = "Rajdeep",
                            Gender = 0,
                            LastName = "Bhati"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
