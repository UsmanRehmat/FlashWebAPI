﻿// <auto-generated />
using FlashWebAPI.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace FlashWebAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20181021163540_Update-Test")]
    partial class UpdateTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("FlashWebAPI.Models.CorrectiveAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Diagnostic");

                    b.Property<int?>("StationFaultsId");

                    b.HasKey("Id");

                    b.HasIndex("StationFaultsId");

                    b.ToTable("CorrectiveAction");
                });

            modelBuilder.Entity("FlashWebAPI.Models.InDoorAssemblyLine", b =>
                {
                    b.Property<int>("InDoorAssemblyLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Barcode");

                    b.Property<DateTime?>("BarcodeScanningTime");

                    b.Property<string>("BlowerMotorQRCode");

                    b.Property<double?>("Capacitance");

                    b.Property<double?>("Current");

                    b.Property<string>("ElectricalBoxQRCode");

                    b.Property<string>("EvaporatorBarcode");

                    b.Property<DateTime>("ExitTime");

                    b.Property<double?>("Inductance");

                    b.Property<double?>("Power");

                    b.Property<string>("RFIDTag");

                    b.Property<double?>("RPM");

                    b.Property<DateTime>("StartTime");

                    b.Property<double?>("Voltage");

                    b.HasKey("InDoorAssemblyLineId");

                    b.ToTable("InDoorAssemblyLines");
                });

            modelBuilder.Entity("FlashWebAPI.Models.OutDoorAssemblyLine", b =>
                {
                    b.Property<int>("OutDoorAssemblyLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("AmbientTemperature");

                    b.Property<string>("Barcode");

                    b.Property<string>("CompressorNumber");

                    b.Property<string>("CondesorQRCode");

                    b.Property<double?>("Current");

                    b.Property<double?>("DeltaTemperature");

                    b.Property<double?>("Frequancy");

                    b.Property<double?>("GasAmount");

                    b.Property<string>("GasName");

                    b.Property<double?>("GrillTemperature");

                    b.Property<DateTime?>("LineExitTime");

                    b.Property<DateTime?>("LineStartTime");

                    b.Property<string>("MotorQRCode");

                    b.Property<string>("PCBQRCode");

                    b.Property<double?>("Power");

                    b.Property<double?>("Pressure");

                    b.Property<double?>("PressureAtHeatingTest");

                    b.Property<double?>("PressureAtPerformanceTest");

                    b.Property<string>("RFIDTag");

                    b.Property<DateTime?>("StartingTime");

                    b.Property<double?>("TempratureAtHeatingTest");

                    b.Property<double?>("TempratureAtPerformanceTest");

                    b.Property<double?>("VaccumingPressure");

                    b.Property<double?>("Voltage");

                    b.HasKey("OutDoorAssemblyLineId");

                    b.ToTable("OutDoorAssemblyLines");
                });

            modelBuilder.Entity("FlashWebAPI.Models.QualityTest", b =>
                {
                    b.Property<int>("QualityTestId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Assembly");

                    b.Property<string>("Barcode");

                    b.Property<string>("CorrectiveAction");

                    b.Property<bool?>("CurrentRepairingUnit");

                    b.Property<bool?>("CurrentTestUnit");

                    b.Property<string>("DiagnosisFault");

                    b.Property<string>("FaultType");

                    b.Property<int?>("InDoorAssemblyLineId");

                    b.Property<string>("OperatorName");

                    b.Property<int?>("OutDoorAssemblyLineId");

                    b.Property<string>("PreleminaryFault");

                    b.Property<DateTime?>("RepairingInTime");

                    b.Property<DateTime?>("RepairingOutTime");

                    b.Property<bool?>("Status");

                    b.Property<DateTime?>("TestInTime");

                    b.Property<string>("TestName");

                    b.Property<DateTime?>("TestOutTime");

                    b.HasKey("QualityTestId");

                    b.HasIndex("InDoorAssemblyLineId");

                    b.HasIndex("OutDoorAssemblyLineId");

                    b.ToTable("QualityTests");
                });

            modelBuilder.Entity("FlashWebAPI.Models.StationFaults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Assembly");

                    b.Property<string>("Faults");

                    b.Property<string>("StationName");

                    b.HasKey("Id");

                    b.ToTable("StationFaults");
                });

            modelBuilder.Entity("FlashWebAPI.Models.User", b =>
                {
                    b.Property<string>("UserName");

                    b.Property<string>("Assembly");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Station");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlashWebAPI.Models.CorrectiveAction", b =>
                {
                    b.HasOne("FlashWebAPI.Models.StationFaults")
                        .WithMany("CorrectiveActions")
                        .HasForeignKey("StationFaultsId");
                });

            modelBuilder.Entity("FlashWebAPI.Models.QualityTest", b =>
                {
                    b.HasOne("FlashWebAPI.Models.InDoorAssemblyLine", "InDoor")
                        .WithMany("QualityTests")
                        .HasForeignKey("InDoorAssemblyLineId");

                    b.HasOne("FlashWebAPI.Models.OutDoorAssemblyLine", "OutDoor")
                        .WithMany("QualityTests")
                        .HasForeignKey("OutDoorAssemblyLineId");
                });
#pragma warning restore 612, 618
        }
    }
}
