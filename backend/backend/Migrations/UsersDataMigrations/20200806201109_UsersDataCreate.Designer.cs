﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Models.UsersData;

namespace backend.Migrations.UsersDataMigrations
{
    [DbContext(typeof(UsersDataContext))]
    [Migration("20200806201109_UsersDataCreate")]
    partial class UsersDataCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Models.UsersData.UsersData", b =>
                {
                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AdditionalPhone")
                        .HasColumnType("int");

                    b.Property<string>("Coment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HandlingReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("SelectedTariffs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Address");

                    b.ToTable("UsersDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
