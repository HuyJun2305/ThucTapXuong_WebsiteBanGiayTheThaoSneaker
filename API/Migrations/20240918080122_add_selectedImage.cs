using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_selectedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41e5a304-bd8c-4a75-b633-c043a3d2ee86"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe561fe0-1f6f-4b68-b4d4-0dd86494be29"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("192bc43d-5fb8-4f3c-b33e-10337908a8d1"), new Guid("2587653e-7156-44c3-9920-4cd2eae94dda") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9c011398-9c45-4279-bb11-a8f9b8bb0d9e"), new Guid("8ff46efd-aa15-41cb-8881-03793e9f2b98") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("192bc43d-5fb8-4f3c-b33e-10337908a8d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c011398-9c45-4279-bb11-a8f9b8bb0d9e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2587653e-7156-44c3-9920-4cd2eae94dda"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8ff46efd-aa15-41cb-8881-03793e9f2b98"));

            migrationBuilder.CreateTable(
                name: "SelectedImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedImages_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SelectedImages_ColorId",
                table: "SelectedImages",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedImages");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("192bc43d-5fb8-4f3c-b33e-10337908a8d1"), "6c3d09fc-45cc-41d3-bfbd-20387d2959e7", "Admin", "ADMIN" },
                    { new Guid("41e5a304-bd8c-4a75-b633-c043a3d2ee86"), "2cd18742-99ef-40cb-8c2c-aef1cd8068b0", "Guest", "GUEST" },
                    { new Guid("9c011398-9c45-4279-bb11-a8f9b8bb0d9e"), "4432f5f5-9779-4f4c-9b88-527c6741d0a2", "Customer", "CUSTOMER" },
                    { new Guid("fe561fe0-1f6f-4b68-b4d4-0dd86494be29"), "c1649986-ca39-4778-959a-f5a63b2f4138", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2587653e-7156-44c3-9920-4cd2eae94dda"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "44d582db-78ed-4deb-8e20-f03fbb57ca1c", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAECOgIy+WDRw5XkyeVPyP8MAUd4QrwpDCfxdausyuDB/i4Xp/xAh7vKPHDNyFgm96NA==", "0123456789", false, "b931e775-ffd4-4888-933f-6f6f08f34c9e", false, false, "admin@example.com" },
                    { new Guid("8ff46efd-aa15-41cb-8881-03793e9f2b98"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "7807a9f3-59d5-48d4-a2f0-9ef815e0ce1b", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEHf9eZwVOxkFU/azUmww6ePi/ghl2/KE+Peo2SXDcz1kXsKbPHFhObtS+SSWgbn/pw==", "0987654321", false, "41350454-7fa7-4832-9865-19801dd9848f", false, false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("192bc43d-5fb8-4f3c-b33e-10337908a8d1"), new Guid("2587653e-7156-44c3-9920-4cd2eae94dda") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9c011398-9c45-4279-bb11-a8f9b8bb0d9e"), new Guid("8ff46efd-aa15-41cb-8881-03793e9f2b98") });
        }
    }
}
