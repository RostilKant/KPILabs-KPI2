﻿// <auto-generated />
using System;
using AirplaneTicketService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirplaneTicketService.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20191120172924_AddTickets")]
    partial class AddTickets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirplaneTicketService.Models.Employee", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("int");

                    b.HasIndex("PlaneId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArriveAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureGate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.FlightDetails", b =>
                {
                    b.Property<string>("ArriveCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArriveCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPilot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("SecondPilot")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightDetails");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DayOfLastRepair")
                        .HasColumnType("datetime2");

                    b.Property<long>("NumOfSeats")
                        .HasColumnType("bigint");

                    b.HasKey("PlaneId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.TicketDetails", b =>
                {
                    b.Property<int>("BagsCount")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketDetails");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Employee", b =>
                {
                    b.HasOne("AirplaneTicketService.Models.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Flight", b =>
                {
                    b.HasOne("AirplaneTicketService.Models.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.FlightDetails", b =>
                {
                    b.HasOne("AirplaneTicketService.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.Ticket", b =>
                {
                    b.HasOne("AirplaneTicketService.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");
                });

            modelBuilder.Entity("AirplaneTicketService.Models.TicketDetails", b =>
                {
                    b.HasOne("AirplaneTicketService.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });
#pragma warning restore 612, 618
        }
    }
}
