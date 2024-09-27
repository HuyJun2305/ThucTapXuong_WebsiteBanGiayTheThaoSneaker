using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class promotion_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Promotions_PromotionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PromotionId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ce8e2cf-6560-46b8-8b4d-5517ceea581e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1f79f03-f844-49e8-bc96-444ef11f5866"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7b906cdf-71c9-4b12-9aeb-1bb93034dc2b"), new Guid("6477eefa-a270-4d57-b874-39555e1386a9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a74b398d-264e-4c5f-b80e-93c2d040a07e"), new Guid("f50b8a77-8522-4214-b001-4ecbe447c9cc") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b906cdf-71c9-4b12-9aeb-1bb93034dc2b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a74b398d-264e-4c5f-b80e-93c2d040a07e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6477eefa-a270-4d57-b874-39555e1386a9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f50b8a77-8522-4214-b001-4ecbe447c9cc"));

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3e6cbd35-de7d-40ac-8352-c002bfb2df4a"), "c5348dbe-20be-4ae1-a1f9-0ac20d9f3bb1", "Customer", "CUSTOMER" },
                    { new Guid("778d8af8-47b2-476b-bf12-96ab770f7ed8"), "51adc74f-08f4-4016-9cdb-a75b4e44c507", "Guest", "GUEST" },
                    { new Guid("93ad4bf8-662b-416b-b22b-63e9b83a4694"), "e6b5fbe0-2e3f-4d86-824f-912f7cec87e4", "Admin", "ADMIN" },
                    { new Guid("bf92ae59-7d77-4cf8-9977-304666f50c19"), "7bbf188c-cc35-4580-b709-a9f596d851e1", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2f4ac9ec-5538-40eb-9309-04d3aa5d1d31"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "cec67877-97fa-4a5b-b82d-825f2c46924a", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDIvVY9LyuESEdOhkeg8BYRUNBwwZ4jkJwGXHbtLSMX3U5M9KGc4OmoMf9p2ZsbbPw==", "0987654321", false, "843886b6-314a-46c5-9a66-555abd53cbfb", false, "user@example.com" },
                    { new Guid("9ab0decf-4d1f-45ee-b286-a10a0c1af38d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "b7b3734c-9118-42ba-902e-bac767d2fccc", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMCWwhOpg7qrecUjJ8VpWVxEjrTqg5lcBknTP0ap1AyqO8NV9t6Yg3UNb/jrG3CWUw==", "0123456789", false, "549fb67b-5359-40ab-a10e-5d5eca894dbb", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3e6cbd35-de7d-40ac-8352-c002bfb2df4a"), new Guid("2f4ac9ec-5538-40eb-9309-04d3aa5d1d31") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("93ad4bf8-662b-416b-b22b-63e9b83a4694"), new Guid("9ab0decf-4d1f-45ee-b286-a10a0c1af38d") });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_PromotionId",
                table: "ProductDetails",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Promotions_PromotionId",
                table: "ProductDetails",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Promotions_PromotionId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_PromotionId",
                table: "ProductDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("778d8af8-47b2-476b-bf12-96ab770f7ed8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf92ae59-7d77-4cf8-9977-304666f50c19"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3e6cbd35-de7d-40ac-8352-c002bfb2df4a"), new Guid("2f4ac9ec-5538-40eb-9309-04d3aa5d1d31") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("93ad4bf8-662b-416b-b22b-63e9b83a4694"), new Guid("9ab0decf-4d1f-45ee-b286-a10a0c1af38d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6cbd35-de7d-40ac-8352-c002bfb2df4a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93ad4bf8-662b-416b-b22b-63e9b83a4694"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2f4ac9ec-5538-40eb-9309-04d3aa5d1d31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9ab0decf-4d1f-45ee-b286-a10a0c1af38d"));

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "ProductDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0ce8e2cf-6560-46b8-8b4d-5517ceea581e"), "f0600865-1f89-4782-9060-0fbf1b0fb394", "Employee", "EMPLOYEE" },
                    { new Guid("7b906cdf-71c9-4b12-9aeb-1bb93034dc2b"), "5ca9b665-a98c-4dbd-94e0-230da1b66b8f", "Customer", "CUSTOMER" },
                    { new Guid("a74b398d-264e-4c5f-b80e-93c2d040a07e"), "722539ab-83df-4c2b-a038-3ce6c2929699", "Admin", "ADMIN" },
                    { new Guid("e1f79f03-f844-49e8-bc96-444ef11f5866"), "c5943a85-b76b-4756-80fa-4969ebd7a127", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6477eefa-a270-4d57-b874-39555e1386a9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "3664f6fa-0b85-4fc8-90fd-5611d57f6749", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMHLNTpRX7wRCFnFb2dfSry1ZgdrTX7Qp8sQFvE45LWrKf+Lp2DOQCGxaSff9iGlVQ==", "0987654321", false, "d047a0ef-df7c-4589-b031-5f074bc577f3", false, "user@example.com" },
                    { new Guid("f50b8a77-8522-4214-b001-4ecbe447c9cc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "6a295e22-5a64-4b86-a126-63c164eef857", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEH9fjlSHtDIUmgO4Zyhc6fzMjQmh0IVQDKPNddZw+8hPidg1AChjDO3vdGiJyN6/jQ==", "0123456789", false, "2be8a5c5-5f75-4554-bb5b-7b6cbde2253e", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7b906cdf-71c9-4b12-9aeb-1bb93034dc2b"), new Guid("6477eefa-a270-4d57-b874-39555e1386a9") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a74b398d-264e-4c5f-b80e-93c2d040a07e"), new Guid("f50b8a77-8522-4214-b001-4ecbe447c9cc") });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PromotionId",
                table: "Products",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Promotions_PromotionId",
                table: "Products",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");
        }
    }
}
