﻿// <auto-generated />
using System;
using CodeRollProject.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231225010540_added-all-variables-are-nullable")]
    partial class addedallvariablesarenullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"), 1L, 1);

                    b.Property<int?>("EventCreatorID")
                        .HasColumnType("int");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EventDuration")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventPlatform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.Participant", b =>
                {
                    b.Property<int>("ParticipantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipantID"), 1L, 1);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ParticipantID");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.Vote", b =>
                {
                    b.Property<int>("VoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteID"), 1L, 1);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantID")
                        .HasColumnType("int");

                    b.Property<string>("SelectedOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoteID");

                    b.ToTable("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
