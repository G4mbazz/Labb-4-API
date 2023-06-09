﻿// <auto-generated />
using Labb_4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb_4_API.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230507183835_initial-create")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Models.Interests", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Playing and watching video games",
                            Title = "Gaming"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Listening and reading lyrics of various songs",
                            Title = "Music"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Sporting articles and different exercises",
                            Title = "Sports"
                        });
                });

            modelBuilder.Entity("API_Models.Link", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PersonInterestID")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PersonInterestID");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("API_Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            Name = "Mike Hawk",
                            PhoneNumber = "0705120743"
                        },
                        new
                        {
                            PersonID = 2,
                            Name = "Sara Andersson",
                            PhoneNumber = "0762958432"
                        },
                        new
                        {
                            PersonID = 3,
                            Name = "Kalle Skog",
                            PhoneNumber = "0735792358"
                        });
                });

            modelBuilder.Entity("API_Models.PersonInterest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InterestID");

                    b.HasIndex("PersonID");

                    b.ToTable("PersonInterests");
                });

            modelBuilder.Entity("API_Models.Link", b =>
                {
                    b.HasOne("API_Models.PersonInterest", "PersonInterest")
                        .WithMany()
                        .HasForeignKey("PersonInterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInterest");
                });

            modelBuilder.Entity("API_Models.PersonInterest", b =>
                {
                    b.HasOne("API_Models.Interests", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
