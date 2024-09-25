using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class updateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4ec156f-24b7-4f60-9c42-bf9fcd9704d8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e34a6dad-3379-44b5-878a-33fd47dfe3bc"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0e4d9adc-859d-46e3-a24c-d6e41574e2a9"), new Guid("7022f5d0-623a-4e66-b10a-feafc88b0967") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a895346-f123-487c-952f-b92efb5a1e2d"), new Guid("c752984f-34b1-4861-be8f-658a25cacee8") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a895346-f123-487c-952f-b92efb5a1e2d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e4d9adc-859d-46e3-a24c-d6e41574e2a9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7022f5d0-623a-4e66-b10a-feafc88b0967"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c752984f-34b1-4861-be8f-658a25cacee8"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3d027692-dbda-44f9-b68a-cb923bd8ea3e"), "f1db4628-e0b8-4e27-9f87-12b00fc5d46a", "Guest", "GUEST" },
                    { new Guid("a3af1476-e907-4ca3-9650-1bd5e4b2a6b1"), "abc90dfe-1b39-43b9-9175-e2b8f04edea2", "Employee", "EMPLOYEE" },
                    { new Guid("cc936a3b-6647-485b-a499-9f9f9a383ac0"), "27901760-48f9-488a-9f46-57e4e2b65912", "Admin", "ADMIN" },
                    { new Guid("efef958e-254f-4e59-8af8-5ec19ec78b0d"), "87fbb196-4230-4a70-8f13-b3189cfa620e", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("467aafd8-aac6-4eeb-b289-d277447b054f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "b0b43d71-63c8-404f-a4f3-c3351c3a168f", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEO5PcC1tBj2c7nR4sEh/58qz3Xf5jxAp0+6OL5lEaXYSXCTPvksZf2a0nLUYDFDdgQ==", "0987654321", false, "9da0375e-434b-4f78-8a5a-4b934bfb7b2f", false, "user@example.com" },
                    { new Guid("c3215e38-5541-4abb-b6a0-d0a857e0884d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "a04e8679-e100-441b-a9c4-831a3517c85b", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGa2mInbtObK/BJErWiLTF07KjRxMYeY6f6frPfFtVF9+Bz6o5RMF4Qt2RDChYFvUQ==", "0123456789", false, "3655bfde-a7ed-4d15-bfb3-fa9e991bd6a2", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("efef958e-254f-4e59-8af8-5ec19ec78b0d"), new Guid("467aafd8-aac6-4eeb-b289-d277447b054f") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cc936a3b-6647-485b-a499-9f9f9a383ac0"), new Guid("c3215e38-5541-4abb-b6a0-d0a857e0884d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d027692-dbda-44f9-b68a-cb923bd8ea3e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3af1476-e907-4ca3-9650-1bd5e4b2a6b1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("efef958e-254f-4e59-8af8-5ec19ec78b0d"), new Guid("467aafd8-aac6-4eeb-b289-d277447b054f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cc936a3b-6647-485b-a499-9f9f9a383ac0"), new Guid("c3215e38-5541-4abb-b6a0-d0a857e0884d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc936a3b-6647-485b-a499-9f9f9a383ac0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("efef958e-254f-4e59-8af8-5ec19ec78b0d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("467aafd8-aac6-4eeb-b289-d277447b054f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3215e38-5541-4abb-b6a0-d0a857e0884d"));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a895346-f123-487c-952f-b92efb5a1e2d"), "a940f4c0-48b0-4f10-a6a0-4e1c443c48d8", "Customer", "CUSTOMER" },
                    { new Guid("0e4d9adc-859d-46e3-a24c-d6e41574e2a9"), "31b8a115-56e4-48b0-9b2d-e928eca7b4ee", "Admin", "ADMIN" },
                    { new Guid("d4ec156f-24b7-4f60-9c42-bf9fcd9704d8"), "e850ea3a-acea-4bfc-9226-ee002c89380a", "Guest", "GUEST" },
                    { new Guid("e34a6dad-3379-44b5-878a-33fd47dfe3bc"), "c8a73407-9fc1-4396-95ff-7b0a89ee6c79", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7022f5d0-623a-4e66-b10a-feafc88b0967"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "87f2c0e8-72d3-4ac2-867b-30c086d1651f", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKyNj78/wOTIAtrEpcjenKB+A7IqymbSRM/P6PHfkp7PmPnrKFV/oOHnRXOCr87LvQ==", "0123456789", false, "30360fb2-6cf0-43b9-b1b9-bb49b5e82261", false, false, "admin@example.com" },
                    { new Guid("c752984f-34b1-4861-be8f-658a25cacee8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "898d5caf-4922-41a3-8b2b-4c3899f3f450", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDPL8xJIrTjvM1F9LHpeZqmxBnlPO10JIVNejS6ED/W83yXCqzyPXKU4kva0ZjV+fw==", "0987654321", false, "2de0749c-b9fd-45de-a945-b5a069556316", false, false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("0e4d9adc-859d-46e3-a24c-d6e41574e2a9"), new Guid("7022f5d0-623a-4e66-b10a-feafc88b0967") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("0a895346-f123-487c-952f-b92efb5a1e2d"), new Guid("c752984f-34b1-4861-be8f-658a25cacee8") });
        }
    }
}
