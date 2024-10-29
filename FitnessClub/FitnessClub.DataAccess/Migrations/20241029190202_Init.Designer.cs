﻿// <auto-generated />
using System;
using FitnessClub.FitnessClub.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitnessClub.Migrations
{
    [DbContext(typeof(FitnessClubDbContext))]
    [Migration("20241029190202_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FitnessClub.FitnessClub.DataAccess.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("FitnessClub.FitnessClub.DataAccess.Entities.TrainingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("training");
                });

            modelBuilder.Entity("FitnessClub.FitnessClub.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ClubId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PasswordHash")
                        .HasColumnType("integer");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("UserTraining", b =>
                {
                    b.Property<int>("TrainingId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("TrainingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTraining");
                });

            modelBuilder.Entity("FitnessClub.FitnessClub.DataAccess.Entities.UserEntity", b =>
                {
                    b.HasOne("FitnessClub.FitnessClub.DataAccess.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UserTraining", b =>
                {
                    b.HasOne("FitnessClub.FitnessClub.DataAccess.Entities.TrainingEntity", null)
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessClub.FitnessClub.DataAccess.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessClub.FitnessClub.DataAccess.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
