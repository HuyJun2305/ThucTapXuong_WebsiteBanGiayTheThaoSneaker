using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Change_ProductDetail_Id_to_String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e4dbcb1-ef66-426c-9e53-e2e32038eef9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb1416e2-f356-4fc6-a6b9-00fcba6a5b64"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d3f91231-9771-448f-80b5-5dd9013258d3"), new Guid("8413eb47-0deb-456f-b321-ef1c45d6e1d1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("833f4b66-a189-47f7-a621-cc3b8f7b4f79"), new Guid("a49482af-118a-4da0-9a0a-5f8a7d676f12") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("833f4b66-a189-47f7-a621-cc3b8f7b4f79"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f91231-9771-448f-80b5-5dd9013258d3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8413eb47-0deb-456f-b321-ef1c45d6e1d1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a49482af-118a-4da0-9a0a-5f8a7d676f12"));

            migrationBuilder.DropForeignKey("FK_OrderDetails_ProductDetails_ProductDetailId", "OrderDetails");
			migrationBuilder.DropForeignKey("FK_CartDetails_ProductDetails_ProductDetailId", "CartDetails");
			migrationBuilder.DropPrimaryKey("PK_ProductDetails", "ProductDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ProductDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

			migrationBuilder.AlterColumn<string>(
                name: "ProductDetailId",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDetailId",
                table: "CartDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

			migrationBuilder.AddPrimaryKey("PK_ProductDetails", "ProductDetails", "Id");
            migrationBuilder.AddForeignKey("FK_OrderDetails_ProductDetails_ProductDetailId", "OrderDetails", "ProductDetailId", "ProductDetails");
			migrationBuilder.AddForeignKey("FK_CartDetails_ProductDetails_ProductDetailId", "CartDetails", "ProductDetailId", "ProductDetails");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDetailId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductDetailId",
                table: "CartDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5e4dbcb1-ef66-426c-9e53-e2e32038eef9"), "e4c66d29-8f02-4cfe-aacd-33bf4eb1df48", "Guest", "GUEST" },
                    { new Guid("833f4b66-a189-47f7-a621-cc3b8f7b4f79"), "d873516e-56a6-400c-95b3-e99a1d20cbb7", "Customer", "CUSTOMER" },
                    { new Guid("cb1416e2-f356-4fc6-a6b9-00fcba6a5b64"), "2510dfb1-8cb3-4641-b2ce-b8a903d4d319", "Employee", "EMPLOYEE" },
                    { new Guid("d3f91231-9771-448f-80b5-5dd9013258d3"), "365b6097-2f61-45ae-b5d4-fa85661626eb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8413eb47-0deb-456f-b321-ef1c45d6e1d1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "4abbc5e4-ddc1-4673-83bd-1d7676aebbf6", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFDB1aRD5MkLAp8TUPgabEAZScWp3nchiEAA2S2PXWSWMGUELR9qS096IZOGQnWn8w==", "0123456789", false, "711f5cbd-92e4-4724-9fc7-c966f60ba219", false, "admin@example.com" },
                    { new Guid("a49482af-118a-4da0-9a0a-5f8a7d676f12"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "4c5a2423-ddc1-4392-8a34-66b9ea826052", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEL+KFGMfg7iNHan/fuDvKMkxr64CqKthjdA8eRkHnJz4/TvOQrVwSz8hBrFXOFtGFg==", "0987654321", false, "4b9bcd28-19f6-41d8-adda-47f2bad830c5", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d3f91231-9771-448f-80b5-5dd9013258d3"), new Guid("8413eb47-0deb-456f-b321-ef1c45d6e1d1") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("833f4b66-a189-47f7-a621-cc3b8f7b4f79"), new Guid("a49482af-118a-4da0-9a0a-5f8a7d676f12") });
        }
    }
}
