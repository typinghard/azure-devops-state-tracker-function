﻿// <auto-generated />
using System;
using AzureDevopsStateTracker.Data;
using AzureDevopsStateTracker.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AzureDevopsStateTracker.Migrations
{
    [DbContext(typeof(AzureDevopsStateTrackerContext))]
    [Migration("20210719163846_AzureDevopsStateTrackerInitial")]
    partial class AzureDevopsStateTrackerInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema(DataBaseConfig.SchemaName)
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AzureDevopsStateTracker.Entities.TimeByState", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("varchar(200)");

                    b.Property<double>("TotalTime")
                        .HasColumnType("float");

                    b.Property<double>("TotalWorkedTime")
                        .HasColumnType("float");

                    b.Property<string>("WorkItemId")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemId");

                    b.ToTable("TimeByStates");
                });

            modelBuilder.Entity("AzureDevopsStateTracker.Entities.WorkItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Activity")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("AreaPath")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("AssignedTo")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Effort")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("IterationPath")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("OriginalEstimate")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("StoryPoints")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Tags")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TeamProject")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("WorkItemParentId")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("AzureDevopsStateTracker.Entities.WorkItemChange", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewState")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("OldDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OldState")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("WorkItemId")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemId");

                    b.ToTable("WorkItemsChange");
                });

            modelBuilder.Entity("AzureDevopsStateTracker.Entities.TimeByState", b =>
                {
                    b.HasOne("AzureDevopsStateTracker.Entities.WorkItem", "WorkItem")
                        .WithMany("TimeByStates")
                        .HasForeignKey("WorkItemId");
                });

            modelBuilder.Entity("AzureDevopsStateTracker.Entities.WorkItemChange", b =>
                {
                    b.HasOne("AzureDevopsStateTracker.Entities.WorkItem", "WorkItem")
                        .WithMany("WorkItemsChanges")
                        .HasForeignKey("WorkItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
