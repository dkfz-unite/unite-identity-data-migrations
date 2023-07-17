﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Unite.Identity.Data.Services;

#nullable disable

namespace Unite.Identity.Data.Migrations.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Unite.Identity.Data.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Label")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("Priority")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Provider", (string)null);
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsRoot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("ProviderId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.UserPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<string>("Restrictions")
                        .HasColumnType("text");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions", (string)null);
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.UserSession", b =>
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

                    b.ToTable("UserSessions", (string)null);
                });

            modelBuilder.Entity("Unite.Identity.Data.Services.Models.EnumValue<Unite.Identity.Data.Entities.Enums.Permission>", b =>
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

                    b.ToTable("Permissions", (string)null);

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

            modelBuilder.Entity("Unite.Identity.Data.Entities.User", b =>
                {
                    b.HasOne("Unite.Identity.Data.Entities.Provider", "Provider")
                        .WithMany("Users")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.UserPermission", b =>
                {
                    b.HasOne("Unite.Identity.Data.Services.Models.EnumValue<Unite.Identity.Data.Entities.Enums.Permission>", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unite.Identity.Data.Entities.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.UserSession", b =>
                {
                    b.HasOne("Unite.Identity.Data.Entities.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.Provider", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Unite.Identity.Data.Entities.User", b =>
                {
                    b.Navigation("UserPermissions");

                    b.Navigation("UserSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
