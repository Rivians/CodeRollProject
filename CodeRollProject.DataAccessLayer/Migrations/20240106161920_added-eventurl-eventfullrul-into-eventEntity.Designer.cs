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
    [Migration("20240106161920_added-eventurl-eventfullrul-into-eventEntity")]
    partial class addedeventurleventfullrulintoeventEntity
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

                    b.Property<string>("EventFullUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventPlatform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.EventUser", b =>
                {
                    b.Property<int>("EventUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventUserID"), 1L, 1);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("EventUserID");

                    b.HasIndex("EventID");

                    b.HasIndex("UserID");

                    b.ToTable("EventsUsers");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
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

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VoteOption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoteID");

                    b.HasIndex("EventID");

                    b.HasIndex("UserID");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.EventUser", b =>
                {
                    b.HasOne("CodeRollProject.EntityLayer.Concrete.Event", "Event")
                        .WithMany("EventsUsers")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRollProject.EntityLayer.Concrete.User", "User")
                        .WithMany("EventsUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.Vote", b =>
                {
                    b.HasOne("CodeRollProject.EntityLayer.Concrete.Event", "Event")
                        .WithMany("Votes")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeRollProject.EntityLayer.Concrete.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.Event", b =>
                {
                    b.Navigation("EventsUsers");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("CodeRollProject.EntityLayer.Concrete.User", b =>
                {
                    b.Navigation("EventsUsers");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
