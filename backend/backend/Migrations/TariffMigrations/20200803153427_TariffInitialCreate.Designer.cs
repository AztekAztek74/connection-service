﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Models.Tariff;

namespace backend.Migrations.TariffMigrations
{
    [DbContext(typeof(TariffContext))]
    [Migration("20200803153427_TariffInitialCreate")]
    partial class TariffInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Models.Tariff.Tariff", b =>
                {
                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("AccessibleCities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ServicePrice")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("ServiceName");

                    b.ToTable("Tariffs");
                });
#pragma warning restore 612, 618
        }
    }
}
