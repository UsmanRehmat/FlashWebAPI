using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlashWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InDoorAssemblyLines",
                columns: table => new
                {
                    InDoorAssemblyLineId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Barcode = table.Column<string>(nullable: true),
                    BarcodeScanningTime = table.Column<DateTime>(nullable: true),
                    BlowerMotorQRCode = table.Column<string>(nullable: true),
                    Capacitance = table.Column<double>(nullable: true),
                    Current = table.Column<double>(nullable: true),
                    ElectricalBoxQRCode = table.Column<string>(nullable: true),
                    EvaporatorBarcode = table.Column<string>(nullable: true),
                    ExitTime = table.Column<DateTime>(nullable: false),
                    Inductance = table.Column<double>(nullable: true),
                    Power = table.Column<double>(nullable: true),
                    RFIDTag = table.Column<string>(nullable: true),
                    RPM = table.Column<double>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Voltage = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InDoorAssemblyLines", x => x.InDoorAssemblyLineId);
                });

            migrationBuilder.CreateTable(
                name: "OutDoorAssemblyLines",
                columns: table => new
                {
                    OutDoorAssemblyLineId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AmbientTemperature = table.Column<double>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    CompressorNumber = table.Column<string>(nullable: true),
                    CondesorQRCode = table.Column<string>(nullable: true),
                    Current = table.Column<double>(nullable: true),
                    DeltaTemperature = table.Column<double>(nullable: true),
                    Frequancy = table.Column<double>(nullable: true),
                    GasAmount = table.Column<double>(nullable: true),
                    GasName = table.Column<string>(nullable: true),
                    GrillTemperature = table.Column<double>(nullable: true),
                    LineExitTime = table.Column<DateTime>(nullable: true),
                    LineStartTime = table.Column<DateTime>(nullable: true),
                    MotorQRCode = table.Column<string>(nullable: true),
                    PCBQRCode = table.Column<string>(nullable: true),
                    Power = table.Column<double>(nullable: true),
                    Pressure = table.Column<double>(nullable: true),
                    PressureAtHeatingTest = table.Column<double>(nullable: true),
                    PressureAtPerformanceTest = table.Column<double>(nullable: true),
                    RFIDTag = table.Column<string>(nullable: true),
                    StartingTime = table.Column<DateTime>(nullable: true),
                    TempratureAtHeatingTest = table.Column<double>(nullable: true),
                    TempratureAtPerformanceTest = table.Column<double>(nullable: true),
                    VaccumingPressure = table.Column<double>(nullable: true),
                    Voltage = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutDoorAssemblyLines", x => x.OutDoorAssemblyLineId);
                });

            migrationBuilder.CreateTable(
                name: "StationFaults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Assembly = table.Column<string>(nullable: true),
                    Faults = table.Column<string>(nullable: true),
                    StationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationFaults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Assembly = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Station = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "QualityTests",
                columns: table => new
                {
                    QualityTestId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Assembly = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    CorrectiveAction = table.Column<string>(nullable: true),
                    CurrentRepairingUnit = table.Column<bool>(nullable: true),
                    CurrentTestUnit = table.Column<bool>(nullable: true),
                    DiagnosisFault = table.Column<string>(nullable: true),
                    InDoorAssemblyLineId = table.Column<int>(nullable: true),
                    OperatorName = table.Column<string>(nullable: true),
                    OutDoorAssemblyLineId = table.Column<int>(nullable: true),
                    PreleminaryFault = table.Column<string>(nullable: true),
                    RepairingInTime = table.Column<DateTime>(nullable: true),
                    RepairingOutTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    TestInTime = table.Column<DateTime>(nullable: true),
                    TestName = table.Column<string>(nullable: true),
                    TestOutTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityTests", x => x.QualityTestId);
                    table.ForeignKey(
                        name: "FK_QualityTests_InDoorAssemblyLines_InDoorAssemblyLineId",
                        column: x => x.InDoorAssemblyLineId,
                        principalTable: "InDoorAssemblyLines",
                        principalColumn: "InDoorAssemblyLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityTests_OutDoorAssemblyLines_OutDoorAssemblyLineId",
                        column: x => x.OutDoorAssemblyLineId,
                        principalTable: "OutDoorAssemblyLines",
                        principalColumn: "OutDoorAssemblyLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Action = table.Column<string>(nullable: true),
                    Diagnostic = table.Column<string>(nullable: true),
                    StationFaultsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveAction_StationFaults_StationFaultsId",
                        column: x => x.StationFaultsId,
                        principalTable: "StationFaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAction_StationFaultsId",
                table: "CorrectiveAction",
                column: "StationFaultsId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityTests_InDoorAssemblyLineId",
                table: "QualityTests",
                column: "InDoorAssemblyLineId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityTests_OutDoorAssemblyLineId",
                table: "QualityTests",
                column: "OutDoorAssemblyLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectiveAction");

            migrationBuilder.DropTable(
                name: "QualityTests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StationFaults");

            migrationBuilder.DropTable(
                name: "InDoorAssemblyLines");

            migrationBuilder.DropTable(
                name: "OutDoorAssemblyLines");
        }
    }
}
