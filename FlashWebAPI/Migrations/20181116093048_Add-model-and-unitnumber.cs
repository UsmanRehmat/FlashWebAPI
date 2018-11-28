using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlashWebAPI.Migrations
{
    public partial class Addmodelandunitnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "InDoorAssemblyLines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "InDoorAssemblyLines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "InDoorAssemblyLines");

            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "InDoorAssemblyLines");
        }
    }
}
