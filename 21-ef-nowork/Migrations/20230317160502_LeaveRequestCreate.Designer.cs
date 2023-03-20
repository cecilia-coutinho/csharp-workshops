﻿// <auto-generated />
using System;
using LeaveManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230317160502_LeaveRequestCreate")]
    partial class LeaveRequestCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LeaveManagementSystem.Models.Employee", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<float>("LeaveBalance")
                        .HasColumnType("real");

                    b.HasKey("StaffId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LeaveManagementSystem.Models.LeaveRequest", b =>
                {
                    b.Property<int>("LeaveRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveRequestId"), 1L, 1);

                    b.Property<int>("FkLeaveTypeId")
                        .HasColumnType("int");

                    b.Property<int>("FkStaffId")
                        .HasColumnType("int");

                    b.Property<int>("FkStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LeaveRequestId");

                    b.ToTable("LeaveRequests");
                });
#pragma warning restore 612, 618
        }
    }
}