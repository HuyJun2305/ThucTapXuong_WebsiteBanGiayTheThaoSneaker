using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class thanh : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18575ac4-ea0f-4767-842b-6f7fcf56bb42"), "c4dd8b24-9641-46ca-93d5-f5977362ce6f", "Admin", "ADMIN" },
                    { new Guid("77c5b827-0326-4519-8a72-f8fe3874f728"), "fe149d75-22b7-4603-ae5d-23c201f451b7", "Customer", "CUSTOMER" },
                    { new Guid("96b96c37-6009-4d81-b100-da2330b05d74"), "9630b167-bfa2-4a51-b544-e0b4707042dd", "Guest", "GUEST" },
                    { new Guid("bb893348-47bc-4a1d-8d38-7263f6632b61"), "266c1a97-ed75-4b7b-ae2c-7de3d79f6e96", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("47bdeeba-4166-4d8f-a869-f2a4f27b7b2a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "20133488-83dd-4e2a-9601-3a95f79c24cb", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEK9+AzOsKScoTpBrGftQ9BBn7EmbczCYD5OfxoHaPo8POZvdS0HM67MOBy1tWhwJhQ==", "0123456789", false, "f6cd7fa9-3979-4124-a73e-49756eb4e6c4", false, "admin@example.com" },
                    { new Guid("7fbdf91a-f9be-4467-a153-83f7f2ec1d16"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "21d33acd-5295-47d1-bf22-00e344f84f4b", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGGVIA7tMy1Bsz9hEcIAFLuR3zgOjW9kA0BSfRXPlDAyhqoleRhZyUqy0U+pHbXp0A==", "0987654321", false, "41702419-78d9-4085-8e5f-3a73ceed15c7", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("18575ac4-ea0f-4767-842b-6f7fcf56bb42"), new Guid("47bdeeba-4166-4d8f-a869-f2a4f27b7b2a") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("77c5b827-0326-4519-8a72-f8fe3874f728"), new Guid("7fbdf91a-f9be-4467-a153-83f7f2ec1d16") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("96b96c37-6009-4d81-b100-da2330b05d74"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb893348-47bc-4a1d-8d38-7263f6632b61"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("18575ac4-ea0f-4767-842b-6f7fcf56bb42"), new Guid("47bdeeba-4166-4d8f-a869-f2a4f27b7b2a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77c5b827-0326-4519-8a72-f8fe3874f728"), new Guid("7fbdf91a-f9be-4467-a153-83f7f2ec1d16") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18575ac4-ea0f-4767-842b-6f7fcf56bb42"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77c5b827-0326-4519-8a72-f8fe3874f728"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("47bdeeba-4166-4d8f-a869-f2a4f27b7b2a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7fbdf91a-f9be-4467-a153-83f7f2ec1d16"));

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
