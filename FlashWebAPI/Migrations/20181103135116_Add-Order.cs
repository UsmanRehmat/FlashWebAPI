using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlashWebAPI.Migrations
{
    public partial class AddOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(nullable: false),
                    Assembly = table.Column<string>(nullable: true),
                    EndingSN = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    StartingSN = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
