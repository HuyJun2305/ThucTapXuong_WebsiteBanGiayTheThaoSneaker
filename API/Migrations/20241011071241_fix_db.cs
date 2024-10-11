using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fix_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9157d785-2653-4e94-8b7f-9addaf61d7af"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a4e4bbc7-049a-4ec5-8b6c-8d91d92001eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8a7ea75-89f9-4c0b-9e53-cbddcf20abb0"), new Guid("21bc0041-163c-4e68-a053-5854e6256832") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ec880d-13f9-45ce-9b0a-a66e6a3a40fe"), new Guid("b47ce617-cebe-4e77-b700-e1cec44a36e4") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("48ec880d-13f9-45ce-9b0a-a66e6a3a40fe"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8a7ea75-89f9-4c0b-9e53-cbddcf20abb0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21bc0041-163c-4e68-a053-5854e6256832"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b47ce617-cebe-4e77-b700-e1cec44a36e4"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("48ec880d-13f9-45ce-9b0a-a66e6a3a40fe"), "72845edd-f982-4551-95c3-e514a38fd623", "Customer", "CUSTOMER" },
                    { new Guid("9157d785-2653-4e94-8b7f-9addaf61d7af"), "083ce239-b38b-42ba-a95f-f3c0d9e576ee", "Employee", "EMPLOYEE" },
                    { new Guid("a4e4bbc7-049a-4ec5-8b6c-8d91d92001eb"), "1e2bb986-14f3-49cc-906f-3cc348e01e16", "Guest", "GUEST" },
                    { new Guid("f8a7ea75-89f9-4c0b-9e53-cbddcf20abb0"), "bb384b56-9a68-41e6-83fb-c591b3b9e37d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("21bc0041-163c-4e68-a053-5854e6256832"), 0, null, "002204004364", "5c680390-14c9-4340-84eb-5db213f1cf54", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGPjFyhEoNggWB531goXcAm8aA50t7o5dXxmeDLaQNh4w4U7x8q8mNtRviuPSVDJzQ==", "0123456789", false, "5b5f7e77-d937-4e3d-84fc-1370cb1d2231", false, "admin@example.com" },
                    { new Guid("b47ce617-cebe-4e77-b700-e1cec44a36e4"), 0, null, "004204004364", "722764d2-5282-46ea-97a9-0af681308ee5", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEAcQQuexAthUsAcakpnUJoWF2AWzS9JukOfFIa1h1uSDwC0/EXfHfb9BJOCVPJtang==", "0987654321", false, "f4c0eaa9-6f90-4beb-8abd-c75181595722", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f8a7ea75-89f9-4c0b-9e53-cbddcf20abb0"), new Guid("21bc0041-163c-4e68-a053-5854e6256832") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("48ec880d-13f9-45ce-9b0a-a66e6a3a40fe"), new Guid("b47ce617-cebe-4e77-b700-e1cec44a36e4") });
        }
    }
}
