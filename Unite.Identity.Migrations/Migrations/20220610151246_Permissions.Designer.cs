﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Unite.Identity.Services;

namespace Unite.Identity.Migrations.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20220610151246_Permissions")]
    partial class Permissions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Unite.Identity.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsRegistered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsRoot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Unite.Identity.Entities.UserPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<string>("Restrictions")
                        .HasColumnType("text");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("Unite.Identity.Entities.UserSession", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("Session")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Client")
                        .HasColumnType("text");

                    b.HasKey("UserId", "Session");

                    b.HasIndex("Session");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("Unite.Identity.Services.Models.EnumValue<Unite.Identity.Entities.Enums.Permission>", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Value");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Data.Read",
                            Value = "Data.Read"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Data.Write",
                            Value = "Data.Write"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Data.Edit",
                            Value = "Data.Edit"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Data.Delete",
                            Value = "Data.Delete"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Users.Read",
                            Value = "Users.Read"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Users.Write",
                            Value = "Users.Write"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Users.Edit",
                            Value = "Users.Edit"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Users.Delete",
                            Value = "Users.Delete"
                        });
                });

            modelBuilder.Entity("Unite.Identity.Entities.UserPermission", b =>
                {
                    b.HasOne("Unite.Identity.Services.Models.EnumValue<Unite.Identity.Entities.Enums.Permission>", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unite.Identity.Entities.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Unite.Identity.Entities.UserSession", b =>
                {
                    b.HasOne("Unite.Identity.Entities.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Unite.Identity.Entities.User", b =>
                {
                    b.Navigation("UserPermissions");

                    b.Navigation("UserSessions");
                });
#pragma warning restore 612, 618
        }
    }
}