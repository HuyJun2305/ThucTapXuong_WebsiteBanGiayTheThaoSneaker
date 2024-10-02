using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class dbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShippingUnitID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ShippingUnits",
                columns: table => new
                {
                    ShippingUnitID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingUnits", x => x.ShippingUnitID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingUnitID",
                table: "Orders",
                column: "ShippingUnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingUnits_ShippingUnitID",
                table: "Orders",
                column: "ShippingUnitID",
                principalTable: "ShippingUnits",
                principalColumn: "ShippingUnitID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingUnits_ShippingUnitID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ShippingUnits");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingUnitID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingUnitID",
                table: "Orders");
        }
    }
}
