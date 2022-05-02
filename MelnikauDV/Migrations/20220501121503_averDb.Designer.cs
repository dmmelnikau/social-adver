﻿// <auto-generated />
using System;
using MelnikauDV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MelnikauDV.Migrations
{
    [DbContext(typeof(AdvertisementContext))]
    [Migration("20220501121503_averDb")]
    partial class averDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvertisementUser", b =>
                {
                    b.Property<int>("AdvertisementsAdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("AdvertisementsAdvertisementId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AdvertisementUser");
                });

            modelBuilder.Entity("MelnikauDV.Models.AdvMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDislikes")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AdvMark");
                });

            modelBuilder.Entity("MelnikauDV.Models.Advertisement", b =>
                {
                    b.Property<int>("AdvertisementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("AdvertisementId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("MelnikauDV.Models.ProfitAdv", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("Effort")
                        .HasColumnType("int");

                    b.Property<int>("PageViews")
                        .HasColumnType("int");

                    b.Property<int>("Profit")
                        .HasColumnType("int");

                    b.Property<int>("kef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("ProfitAdvs");
                });

            modelBuilder.Entity("MelnikauDV.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        },
                        new
                        {
                            Id = 3,
                            Name = "manager"
                        });
                });

            modelBuilder.Entity("MelnikauDV.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Password = "123457",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "manager@gmail.com",
                            Password = "qwerty",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("AdvertisementUser", b =>
                {
                    b.HasOne("MelnikauDV.Models.Advertisement", null)
                        .WithMany()
                        .HasForeignKey("AdvertisementsAdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MelnikauDV.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MelnikauDV.Models.AdvMark", b =>
                {
                    b.HasOne("MelnikauDV.Models.Advertisement", "Advertisement")
                        .WithMany("AdvMarks")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MelnikauDV.Models.User", "User")
                        .WithOne("Mark")
                        .HasForeignKey("MelnikauDV.Models.AdvMark", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MelnikauDV.Models.ProfitAdv", b =>
                {
                    b.HasOne("MelnikauDV.Models.Advertisement", "Advertisement")
                        .WithMany()
                        .HasForeignKey("AdvertisementId");

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("MelnikauDV.Models.User", b =>
                {
                    b.HasOne("MelnikauDV.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MelnikauDV.Models.Advertisement", b =>
                {
                    b.Navigation("AdvMarks");
                });

            modelBuilder.Entity("MelnikauDV.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MelnikauDV.Models.User", b =>
                {
                    b.Navigation("Mark");
                });
#pragma warning restore 612, 618
        }
    }
}
