using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class thanh01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("882770c5-c11b-4705-9842-3f60ac54e9a7"), "983a4dd3-c233-40f6-beaf-243f05da70fc", "Guest", "GUEST" },
                    { new Guid("a2891426-b7c3-487e-8244-a2ad4189347c"), "b230a7ef-b6d5-4885-a55f-8c667dd76d53", "Customer", "CUSTOMER" },
                    { new Guid("af050f2c-0fc7-48f0-b12e-55a5c342dac5"), "253d1687-40bf-4e39-87c7-c8badecb3260", "Admin", "ADMIN" },
                    { new Guid("cd31d980-38f6-49b8-97c4-d954bbcb39be"), "54ab7021-ee7c-4c1b-8c46-b61956dc89c3", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("708749d0-ddc4-41f9-8350-3544df3a58b8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "3c7d50c4-1275-4a7b-94ac-2021e694effa", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDJcd+lKysqrJz6qFtt1aMTVbzYNhJXLAZNOVQR5T2ZvHh2EctPGtp5rAMcEtObXzg==", "0987654321", false, "2b4e0b1e-5808-44ab-b8d9-2e38d991767d", false, "user@example.com" },
                    { new Guid("ba518611-9bda-4e01-b5e4-d3e6ecbcc06b"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "5a7514f3-f780-4dee-b0ee-644a06466d9c", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEHqYbIiGi60nu2139W7OSfgYj7oHYntpSVqHnq79Ko33jBYzbq83QIZf+uz4YIsB7Q==", "0123456789", false, "88f0a4bc-3448-42e8-92c7-93b94abe9747", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a2891426-b7c3-487e-8244-a2ad4189347c"), new Guid("708749d0-ddc4-41f9-8350-3544df3a58b8") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("af050f2c-0fc7-48f0-b12e-55a5c342dac5"), new Guid("ba518611-9bda-4e01-b5e4-d3e6ecbcc06b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("882770c5-c11b-4705-9842-3f60ac54e9a7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd31d980-38f6-49b8-97c4-d954bbcb39be"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a2891426-b7c3-487e-8244-a2ad4189347c"), new Guid("708749d0-ddc4-41f9-8350-3544df3a58b8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("af050f2c-0fc7-48f0-b12e-55a5c342dac5"), new Guid("ba518611-9bda-4e01-b5e4-d3e6ecbcc06b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2891426-b7c3-487e-8244-a2ad4189347c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("af050f2c-0fc7-48f0-b12e-55a5c342dac5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("708749d0-ddc4-41f9-8350-3544df3a58b8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba518611-9bda-4e01-b5e4-d3e6ecbcc06b"));

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
    }
}
