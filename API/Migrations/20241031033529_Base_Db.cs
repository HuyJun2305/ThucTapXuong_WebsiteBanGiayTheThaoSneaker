using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Base_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_AccountId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_AccountId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_AccountId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("12694620-509d-4d9a-b312-c8de1cc35f20"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a275704b-ad10-4548-a525-e231cc552846"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ed2e30d9-64ae-4761-9eee-08ec82b64cf4"), new Guid("8abdbfd0-6823-4be8-9942-3820c3eb684c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a5fafed-5e7c-4d49-810c-97e37884eefc"), new Guid("c8842bc0-9f2a-41fd-8c8d-d1bfc954c6ca") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a5fafed-5e7c-4d49-810c-97e37884eefc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ed2e30d9-64ae-4761-9eee-08ec82b64cf4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8abdbfd0-6823-4be8-9942-3820c3eb684c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c8842bc0-9f2a-41fd-8c8d-d1bfc954c6ca"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Addresses");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("13b7f1ca-2a8f-433b-9027-780444c378a4"), "1bc5397b-8df2-4e0f-95a6-c82f2f45b3f6", "Guest", "GUEST" },
                    { new Guid("65526b16-b7f3-4567-8764-804d33d58bea"), "12ebaf29-9938-489b-b99f-a1f9e1837e45", "Customer", "CUSTOMER" },
                    { new Guid("b17142ec-962f-4ce3-b777-663994297d69"), "e7a68ea4-956d-4c9b-bf1c-a964d2425273", "Admin", "ADMIN" },
                    { new Guid("fbf0ba2a-31cc-49a0-aab2-47f324be7f46"), "ef005723-53c8-4a40-8910-8ee7c3a84755", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1ee84435-8122-4ef9-85ed-8147861e7e60"), 0, null, "002204004364", "db2c67be-7ce2-49a7-8d82-6f61051c3667", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEETL0jU/ryWUCfXaOD0X6BoHb1fzosp/I3cxpe2RXmtpSoNK7iQ+49imH7UlbiDhzA==", "0123456789", false, "7e1fc84d-c411-4bdd-9f9d-3860c5ab345c", false, "admin@example.com" },
                    { new Guid("862e3c19-87f7-42e0-9645-d5eb79d5d155"), 0, null, "004204004364", "06fd48fe-5644-4ca1-aa61-5c2c28ae96c5", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAECUlAekYoQSZ4TWG1j7y2AmP06ENh00K4Fo51x4FlbygtdZ++iDPGIrPHxPS80ZbKA==", "0987654321", false, "56ca5bd6-4e4a-41bc-bc33-0ed01662ea64", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b17142ec-962f-4ce3-b777-663994297d69"), new Guid("1ee84435-8122-4ef9-85ed-8147861e7e60") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("65526b16-b7f3-4567-8764-804d33d58bea"), new Guid("862e3c19-87f7-42e0-9645-d5eb79d5d155") });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AccountId",
                table: "Carts",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_AccountId",
                table: "Addresses",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_AccountId",
                table: "Carts",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_AccountId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_AccountId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_AccountId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("13b7f1ca-2a8f-433b-9027-780444c378a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fbf0ba2a-31cc-49a0-aab2-47f324be7f46"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b17142ec-962f-4ce3-b777-663994297d69"), new Guid("1ee84435-8122-4ef9-85ed-8147861e7e60") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("65526b16-b7f3-4567-8764-804d33d58bea"), new Guid("862e3c19-87f7-42e0-9645-d5eb79d5d155") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65526b16-b7f3-4567-8764-804d33d58bea"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b17142ec-962f-4ce3-b777-663994297d69"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1ee84435-8122-4ef9-85ed-8147861e7e60"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("862e3c19-87f7-42e0-9645-d5eb79d5d155"));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a5fafed-5e7c-4d49-810c-97e37884eefc"), "3c80b00b-9f72-4f49-ad59-9acaf18d8ed5", "Customer", "CUSTOMER" },
                    { new Guid("12694620-509d-4d9a-b312-c8de1cc35f20"), "f6adae70-7735-4599-8a8c-70662fc5b23f", "Guest", "GUEST" },
                    { new Guid("a275704b-ad10-4548-a525-e231cc552846"), "6deeb837-87f2-430b-bc2c-c5327588e318", "Employee", "EMPLOYEE" },
                    { new Guid("ed2e30d9-64ae-4761-9eee-08ec82b64cf4"), "b66fea73-d1c3-4408-95a2-7b7a804dbc20", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8abdbfd0-6823-4be8-9942-3820c3eb684c"), 0, null, "002204004364", "0645c9e6-e261-4148-bbf5-a696cf8f5484", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAENVRP8vdZKt5ssrnztBuYKD6Lq6DdfSCMxAnDU/gWDw+tToQ3ykobhuWhAZCEeLu2A==", "0123456789", false, "3a2832b6-d03d-4c2b-80c3-4d7e9c119f59", false, "admin@example.com" },
                    { new Guid("c8842bc0-9f2a-41fd-8c8d-d1bfc954c6ca"), 0, null, "004204004364", "e4b0b82f-b2e9-4bb1-8369-5adda2ccfb3f", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEEZ3/AP3NhrwPzykVM5QlbpqkJfJYCoFpjG2wLJxz4DmftZVXGLlXri5cBG7BvCHQg==", "0987654321", false, "f53b2501-1d35-488b-99e0-a506736b7396", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ed2e30d9-64ae-4761-9eee-08ec82b64cf4"), new Guid("8abdbfd0-6823-4be8-9942-3820c3eb684c") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("0a5fafed-5e7c-4d49-810c-97e37884eefc"), new Guid("c8842bc0-9f2a-41fd-8c8d-d1bfc954c6ca") });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AccountId",
                table: "Carts",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_AccountId",
                table: "Addresses",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_ApplicationUserId",
                table: "Addresses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_AccountId",
                table: "Carts",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
