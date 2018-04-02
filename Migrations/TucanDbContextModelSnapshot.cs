﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TucanTesting.Data;
using TucanTesting.Models;

namespace TucanTesting.Migrations
{
    [DbContext(typeof(TucanDbContext))]
    partial class TucanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TucanTesting.Models.ExpectedResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long>("TestCaseId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("ExpectedResults");
                });

            modelBuilder.Entity("TucanTesting.Models.TestAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Sequence");

                    b.Property<long>("TestCaseId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestActions");
                });

            modelBuilder.Entity("TucanTesting.Models.TestCase", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BugId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsAutomated");

                    b.Property<bool>("IsEnabled");

                    b.Property<DateTime?>("LastTested");

                    b.Property<int>("Priority");

                    b.Property<long>("TestModuleId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestModuleId");

                    b.ToTable("TestCases");
                });

            modelBuilder.Entity("TucanTesting.Models.TestCondition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long>("TestCaseId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.ToTable("TestConditions");
                });

            modelBuilder.Entity("TucanTesting.Models.TestModule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long>("TestSuiteId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestSuiteId");

                    b.ToTable("TestModules");
                });

            modelBuilder.Entity("TucanTesting.Models.TestResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Status");

                    b.Property<long>("TestCaseId");

                    b.Property<long>("TestModuleId");

                    b.Property<long>("TestRunId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("TucanTesting.Models.TestRun", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long>("TestSuiteId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TestSuiteId");

                    b.ToTable("TestRuns");
                });

            modelBuilder.Entity("TucanTesting.Models.TestSuite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("TestSuites");
                });

            modelBuilder.Entity("TucanTesting.Models.ExpectedResult", b =>
                {
                    b.HasOne("TucanTesting.Models.TestCase")
                        .WithMany("ExpectedResults")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TucanTesting.Models.TestAction", b =>
                {
                    b.HasOne("TucanTesting.Models.TestCase")
                        .WithMany("TestActions")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TucanTesting.Models.TestCase", b =>
                {
                    b.HasOne("TucanTesting.Models.TestModule", "TestModule")
                        .WithMany("TestCases")
                        .HasForeignKey("TestModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TucanTesting.Models.TestCondition", b =>
                {
                    b.HasOne("TucanTesting.Models.TestCase")
                        .WithMany("TestConditions")
                        .HasForeignKey("TestCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TucanTesting.Models.TestModule", b =>
                {
                    b.HasOne("TucanTesting.Models.TestSuite")
                        .WithMany("TestModules")
                        .HasForeignKey("TestSuiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TucanTesting.Models.TestResult", b =>
                {
                    b.HasOne("TucanTesting.Models.TestRun")
                        .WithMany("TestResults")
                        .HasForeignKey("TestRunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TucanTesting.Models.TestRun", b =>
                {
                    b.HasOne("TucanTesting.Models.TestSuite", "TestSuite")
                        .WithMany()
                        .HasForeignKey("TestSuiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
