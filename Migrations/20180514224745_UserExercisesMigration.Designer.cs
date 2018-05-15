﻿// <auto-generated />
using getfit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace getfit.Migrations
{
    [DbContext(typeof(getFitDbContext))]
    [Migration("20180514224745_UserExercisesMigration")]
    partial class UserExercisesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("getfit.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Notes");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("getfit.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("getfit.UserExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Distance");

                    b.Property<string>("ExerciseName")
                        .IsRequired();

                    b.Property<int>("Reps");

                    b.Property<TimeSpan>("Time");

                    b.Property<int>("UserId");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("UserExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
