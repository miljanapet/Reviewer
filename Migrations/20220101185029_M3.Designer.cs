﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reviewer.Models;

namespace Reviewer.Migrations
{
    [DbContext(typeof(ReviewerContext))]
    [Migration("20220101185029_M3")]
    partial class M3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Reviewer.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BodyOfReview")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DateOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int?>("ObjectID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ObjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Reviewer.Models.ReviewedObject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("AvrageGrade")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfPublishing")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReviewerID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("ReviewerID");

                    b.ToTable("Object");
                });

            modelBuilder.Entity("Reviewer.Models.Reviewer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuperUserID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("SuperUserID");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("Reviewer.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfAdding")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Reviewer.Models.Review", b =>
                {
                    b.HasOne("Reviewer.Models.ReviewedObject", "Object")
                        .WithMany("Reviews")
                        .HasForeignKey("ObjectID");

                    b.HasOne("Reviewer.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserID");

                    b.Navigation("Object");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Reviewer.Models.ReviewedObject", b =>
                {
                    b.HasOne("Reviewer.Models.Reviewer", "Reviewer")
                        .WithMany("Objects")
                        .HasForeignKey("ReviewerID");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("Reviewer.Models.Reviewer", b =>
                {
                    b.HasOne("Reviewer.Models.User", "SuperUser")
                        .WithMany()
                        .HasForeignKey("SuperUserID");

                    b.Navigation("SuperUser");
                });

            modelBuilder.Entity("Reviewer.Models.ReviewedObject", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Reviewer.Models.Reviewer", b =>
                {
                    b.Navigation("Objects");
                });

            modelBuilder.Entity("Reviewer.Models.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
