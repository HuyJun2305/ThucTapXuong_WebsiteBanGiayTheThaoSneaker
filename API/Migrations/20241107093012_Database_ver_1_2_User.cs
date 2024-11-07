using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Database_ver_1_2_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6e62d7f3-49b6-494c-a195-b95086293114"), "3894342e-589a-44e0-8f0b-22cbdc4f85c4", "Customer", "CUSTOMER" },
                    { new Guid("a0170155-e574-4e7b-97cf-594a64d5a835"), "2e30b026-fd91-4d3d-8f43-516f0feb172e", "Guest", "GUEST" },
                    { new Guid("ae8055f2-2857-45bc-bf01-8736ba7fcb3c"), "d98e4d10-6da9-4541-accb-35b2e778104d", "Employee", "EMPLOYEE" },
                    { new Guid("dbcad146-270b-4d07-83be-63a785454509"), "0dc0839f-1e2c-46e5-a3f5-06c60df6c919", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6f1f238e-f3e2-47bb-91a2-ec1add7e82b5"), 0, null, "004204004364", "84a1eb53-1f16-40e8-a24c-722159ffd890", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAELMhfTSqemC8HF9ALbknC5pqaS/xUXmx1KIMLctqjMVfhwcf7ljmUNfIWfFAc29VAw==", "0987654321", false, "e18ac49e-58dc-4533-9abd-bc3522a94a3f", false, "user@example.com" },
                    { new Guid("895f3097-98ac-4a6a-a775-4eef172f936a"), 0, null, "002204004364", "019f512e-b878-4bfa-b0b8-f5fa80666a58", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAENprusmgFfVmFwFpqxbHt4uRpcB8OHm3PFgAZ2LCjqlClD6/2hWnKS3Fq7RMvEtVJA==", "0123456789", false, "5d8b7416-2440-40bb-b84e-d02487c62d02", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("6e62d7f3-49b6-494c-a195-b95086293114"), new Guid("6f1f238e-f3e2-47bb-91a2-ec1add7e82b5") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("dbcad146-270b-4d07-83be-63a785454509"), new Guid("895f3097-98ac-4a6a-a775-4eef172f936a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a0170155-e574-4e7b-97cf-594a64d5a835"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae8055f2-2857-45bc-bf01-8736ba7fcb3c"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6e62d7f3-49b6-494c-a195-b95086293114"), new Guid("6f1f238e-f3e2-47bb-91a2-ec1add7e82b5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dbcad146-270b-4d07-83be-63a785454509"), new Guid("895f3097-98ac-4a6a-a775-4eef172f936a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e62d7f3-49b6-494c-a195-b95086293114"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dbcad146-270b-4d07-83be-63a785454509"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6f1f238e-f3e2-47bb-91a2-ec1add7e82b5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("895f3097-98ac-4a6a-a775-4eef172f936a"));
        }
    }
}
