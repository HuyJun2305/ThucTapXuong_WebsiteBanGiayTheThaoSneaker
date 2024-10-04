using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01a2bda4-1f6e-4dec-9d68-42d68cf43178"), "b2f5a37d-dbbb-4327-a36d-5994feae98ae", "Customer", "CUSTOMER" },
                    { new Guid("2dcb23b8-d3bd-473d-99db-9868e8b7b0bd"), "d53a1022-9e50-4dca-ad68-586b83afcd90", "Guest", "GUEST" },
                    { new Guid("60b0d5a5-1206-4cbf-a492-ee631a6cae21"), "9fa1b52b-71bb-4bf0-ad70-ebbde6e26eaf", "Admin", "ADMIN" },
                    { new Guid("703ccb94-654e-4595-b791-caea3237364a"), "dbc028af-3157-4fa8-9d75-94079b9a9203", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("f7795340-7f05-41a2-a8c3-04438e47f949"), 0, null, "002204004364", "7fb3d977-0d18-4278-91f6-e23847b75ab5", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGWI5AMNOml7AK9a34aGJodMyhr65ruER+L51WD2D45ux3fZ3t3UekI7bcl7MAuEEQ==", "0123456789", false, "8d4d4138-dc96-4a22-a06e-16b73dec68a4", false, "admin@example.com" },
                    { new Guid("fb2e6c10-c1e3-47d6-b8eb-419cdba5d216"), 0, null, "004204004364", "26a10a9a-80f9-4ec2-addf-d0d499e4ff8c", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEECrwpHqojFoUWccReVKnkY9+2FGCqm/0QeRSOKo8aoWGX+VemC1fk+CFjB0VJ/dLw==", "0987654321", false, "62408109-667f-428f-b66f-d944185d1e4b", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("60b0d5a5-1206-4cbf-a492-ee631a6cae21"), new Guid("f7795340-7f05-41a2-a8c3-04438e47f949") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("01a2bda4-1f6e-4dec-9d68-42d68cf43178"), new Guid("fb2e6c10-c1e3-47d6-b8eb-419cdba5d216") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2dcb23b8-d3bd-473d-99db-9868e8b7b0bd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("703ccb94-654e-4595-b791-caea3237364a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("60b0d5a5-1206-4cbf-a492-ee631a6cae21"), new Guid("f7795340-7f05-41a2-a8c3-04438e47f949") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("01a2bda4-1f6e-4dec-9d68-42d68cf43178"), new Guid("fb2e6c10-c1e3-47d6-b8eb-419cdba5d216") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01a2bda4-1f6e-4dec-9d68-42d68cf43178"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60b0d5a5-1206-4cbf-a492-ee631a6cae21"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f7795340-7f05-41a2-a8c3-04438e47f949"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fb2e6c10-c1e3-47d6-b8eb-419cdba5d216"));
        }
    }
}
