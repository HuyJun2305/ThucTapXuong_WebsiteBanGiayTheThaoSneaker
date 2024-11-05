using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class update_db_orderaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAdresses_Orders_OrderId",
                table: "OrderAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderAdresses",
                table: "OrderAdresses");


            migrationBuilder.RenameTable(
                name: "OrderAdresses",
                newName: "OrderAdress");

            migrationBuilder.RenameIndex(
                name: "IX_OrderAdresses_OrderId",
                table: "OrderAdress",
                newName: "IX_OrderAdress_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderAdress",
                table: "OrderAdress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAdress_Orders_OrderId",
                table: "OrderAdress",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAdress_Orders_OrderId",
                table: "OrderAdress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderAdress",
                table: "OrderAdress");

            migrationBuilder.RenameTable(
                name: "OrderAdress",
                newName: "OrderAdresses");

            migrationBuilder.RenameIndex(
                name: "IX_OrderAdress_OrderId",
                table: "OrderAdresses",
                newName: "IX_OrderAdresses_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderAdresses",
                table: "OrderAdresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAdresses_Orders_OrderId",
                table: "OrderAdresses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
