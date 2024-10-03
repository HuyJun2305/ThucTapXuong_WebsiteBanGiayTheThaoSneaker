using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class updatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b57230de-8dc9-4f1c-b551-29ab6ae577e2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f437e50c-e547-4152-9ff5-ca2117f570e8"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1497ead0-d056-41d8-9fe3-d2c823bd134b"), new Guid("833d2f44-cdc0-4ad9-9b67-ebff9b1ab122") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1493d0ea-dcf6-4728-9ec6-0e5980731e6e"), new Guid("f6ac835b-82be-4df8-807f-e82c48609e78") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1493d0ea-dcf6-4728-9ec6-0e5980731e6e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1497ead0-d056-41d8-9fe3-d2c823bd134b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("833d2f44-cdc0-4ad9-9b67-ebff9b1ab122"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f6ac835b-82be-4df8-807f-e82c48609e78"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0c6d3beb-547d-4b6e-a398-b29a4c979f87"), "0224cd6c-cb1a-4303-bb55-edd29f1adfab", "Employee", "EMPLOYEE" },
                    { new Guid("3f54387a-951d-43b3-8a5c-42412372615f"), "b1ee270e-6e7a-4b2e-8acf-fdcab9e76af9", "Customer", "CUSTOMER" },
                    { new Guid("8aa98453-4a47-4343-9f1e-4b33df537815"), "eec9a9b9-e512-49dc-9912-a93b5acd5036", "Admin", "ADMIN" },
                    { new Guid("a42f7370-7cc3-42ce-8730-ec654e06e382"), "52a84a12-d578-444d-be35-61b6813c0453", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6a276dff-cffa-4616-8475-81397a3b9540"), 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "a065777f-bd79-4fc7-8cae-f115cfdfc649", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAECopz1ESB00zB/noCEXUihg8n7sD2obitOPCsUzD4wfUFA7nTo6ZJJm9MzKw1F1RGA==", "0123456789", false, "922814af-e437-418c-9f89-4c6cc1a5b04c", false, "admin@example.com" },
                    { new Guid("c8be4485-0707-4b94-b274-95adb4f106fd"), 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "3d47c9cd-fbcb-4340-a7e6-7bd5ce838a94", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAED9qJUt1I7K4jbqFBodo04KyDNskW1E8HK9XuG/gjD7MVClO+niVnSoOaabkBcPN7w==", "0987654321", false, "7afb9cd2-3f95-4ccb-ae3f-439167485a37", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8aa98453-4a47-4343-9f1e-4b33df537815"), new Guid("6a276dff-cffa-4616-8475-81397a3b9540") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3f54387a-951d-43b3-8a5c-42412372615f"), new Guid("c8be4485-0707-4b94-b274-95adb4f106fd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c6d3beb-547d-4b6e-a398-b29a4c979f87"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a42f7370-7cc3-42ce-8730-ec654e06e382"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8aa98453-4a47-4343-9f1e-4b33df537815"), new Guid("6a276dff-cffa-4616-8475-81397a3b9540") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3f54387a-951d-43b3-8a5c-42412372615f"), new Guid("c8be4485-0707-4b94-b274-95adb4f106fd") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f54387a-951d-43b3-8a5c-42412372615f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8aa98453-4a47-4343-9f1e-4b33df537815"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6a276dff-cffa-4616-8475-81397a3b9540"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c8be4485-0707-4b94-b274-95adb4f106fd"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1493d0ea-dcf6-4728-9ec6-0e5980731e6e"), "e2c63468-1c51-4fb2-adf0-b7fb6817ff75", "Admin", "ADMIN" },
                    { new Guid("1497ead0-d056-41d8-9fe3-d2c823bd134b"), "e1b269e1-0d0b-445e-a171-c78fad515322", "Customer", "CUSTOMER" },
                    { new Guid("b57230de-8dc9-4f1c-b551-29ab6ae577e2"), "d0315cf8-58ab-43b8-9a0a-fb5dc1bda3b5", "Guest", "GUEST" },
                    { new Guid("f437e50c-e547-4152-9ff5-ca2117f570e8"), "55b1c492-2c3e-474d-8b5c-3f6b2027e8e7", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("833d2f44-cdc0-4ad9-9b67-ebff9b1ab122"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "66452ab4-351f-4a9f-8029-5bdf8c853f3d", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEEQcjB4KJWMrFeUiAHLnijRLd8m5ptBGsTSX1B+oFHKh0ECdQHCAT6Od+8Zqrs3NyA==", "0987654321", false, "23f5433a-3413-4ea2-bb6d-3090f520b57a", false, "user@example.com" },
                    { new Guid("f6ac835b-82be-4df8-807f-e82c48609e78"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "e69dc719-ea28-42ff-adb5-27fd9622826f", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJNMYJg9Dha69eN2F9Rffw4B7BTwGGkcjcvJJxGcvCzIIPahCkfxuEyG2iSXlTSreQ==", "0123456789", false, "9e7c3106-80b9-4e51-84d8-7b99a414261d", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1497ead0-d056-41d8-9fe3-d2c823bd134b"), new Guid("833d2f44-cdc0-4ad9-9b67-ebff9b1ab122") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1493d0ea-dcf6-4728-9ec6-0e5980731e6e"), new Guid("f6ac835b-82be-4df8-807f-e82c48609e78") });
        }
    }
}
