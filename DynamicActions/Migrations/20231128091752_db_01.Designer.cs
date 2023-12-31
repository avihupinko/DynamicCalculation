﻿// <auto-generated />
using System;
using DynamicActions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynamicActions.Migrations
{
    [DbContext(typeof(DynamicActionsContext))]
    [Migration("20231128091752_db_01")]
    partial class db_01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DynamicActions.Models.DynamicAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DynamicActionType")
                        .HasColumnType("int");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DynamicActions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DynamicActionType = 0,
                            Expression = "X + Y",
                            Name = "SUM"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DynamicActionType = 0,
                            Expression = "X - Y",
                            Name = "SUB"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DynamicActionType = 1,
                            Expression = "String.Concat(X, Y)",
                            Name = "Concat"
                        });
                });

            modelBuilder.Entity("DynamicActions.Models.DynamicActionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DynamicActionId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("DynamicActionId");

                    b.ToTable("DynamicActionHistorys");
                });

            modelBuilder.Entity("DynamicActions.Models.DynamicActionHistory", b =>
                {
                    b.HasOne("DynamicActions.Models.DynamicAction", "DynamicAction")
                        .WithMany()
                        .HasForeignKey("DynamicActionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DynamicAction");
                });
#pragma warning restore 612, 618
        }
    }
}
