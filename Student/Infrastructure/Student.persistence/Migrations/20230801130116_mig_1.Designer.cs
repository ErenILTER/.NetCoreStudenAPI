﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Student.Persistence.Contexts;

#nullable disable

namespace Student.Persistence.Migrations
{
    [DbContext(typeof(StudentAPIDbContext))]
    [Migration("20230801130116_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Student.Domain.Entities.StudentClubs", b =>
                {
                    b.Property<Guid>("IDCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("StudentClubId")
                        .HasColumnType("integer");

                    b.Property<string>("StudentClubName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDCard");

                    b.ToTable("StudentClub");
                });

            modelBuilder.Entity("Student.Domain.Entities.StudentInformations", b =>
                {
                    b.Property<Guid>("IDCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("StudentAge")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IDCard");

                    b.ToTable("StudentInformation");
                });

            modelBuilder.Entity("StudentClubsStudentInformations", b =>
                {
                    b.Property<Guid>("StudentClubIDCard")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentInformationIDCard")
                        .HasColumnType("uuid");

                    b.HasKey("StudentClubIDCard", "StudentInformationIDCard");

                    b.HasIndex("StudentInformationIDCard");

                    b.ToTable("StudentClubsStudentInformations");
                });

            modelBuilder.Entity("StudentClubsStudentInformations", b =>
                {
                    b.HasOne("Student.Domain.Entities.StudentClubs", null)
                        .WithMany()
                        .HasForeignKey("StudentClubIDCard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student.Domain.Entities.StudentInformations", null)
                        .WithMany()
                        .HasForeignKey("StudentInformationIDCard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}