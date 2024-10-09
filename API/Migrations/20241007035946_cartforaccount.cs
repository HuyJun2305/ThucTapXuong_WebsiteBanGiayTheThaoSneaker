using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class cartforaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carts_AccountId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e972a8a2-942a-4cd4-bb3e-fc945a491eec"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fef7d570-87e7-4e2c-8b2e-817ab5cde609"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("91a2f8cd-3679-4f92-a9e1-ba3f2362ecf2"), new Guid("be5a05a9-f4a0-4d64-bb77-a648547b9073") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f673fac9-d72b-4bfa-9e79-013a9e1c24db"), new Guid("ef0e2c74-b7e2-45d8-8d90-d14fb3aa2db9") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91a2f8cd-3679-4f92-a9e1-ba3f2362ecf2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f673fac9-d72b-4bfa-9e79-013a9e1c24db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be5a05a9-f4a0-4d64-bb77-a648547b9073"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ef0e2c74-b7e2-45d8-8d90-d14fb3aa2db9"));

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("39e25f9a-5511-4e65-ac1f-6ca98f16818c"), "91c73eaf-538b-4153-8217-148a651b232a", "Customer", "CUSTOMER" },
                    { new Guid("4674f9a1-530b-491d-a73e-e41ba73600da"), "ead07250-1c50-4843-9e93-cf39a4e28eb7", "Employee", "EMPLOYEE" },
                    { new Guid("a626bc29-6dcf-4c0c-947a-47801d048e53"), "2092a0c2-fae6-42fa-8822-635c8cdad791", "Admin", "ADMIN" },
                    { new Guid("ddba1fb7-f773-4eab-82de-7a55e29e696e"), "c805ed28-ef74-4731-b60c-9ec75311ed1d", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("570a38f9-96d5-421c-bb85-9ebec8d4e1e2"), 0, null, "002204004364", "98ea2715-94b9-47f3-99ca-fdc0d11b40a5", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEHe+jYb97lsVsZjHzcG+vApW3DmMfZSTTgCSKMUbBeelY5Zr7DHeq+W7CO9KPMvu4Q==", "0123456789", false, "d23d03c3-bc90-4459-8d0a-935500455c42", false, "admin@example.com" },
                    { new Guid("ef593612-0d45-4466-a89e-b570ef7963ff"), 0, null, "004204004364", "15e7f008-93a3-4ed8-bfa7-a1552d9fbb84", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGVUe1FvcRPDiW6Sez3toycgoaGnZ+R6z+Z8gVxzcarKXB0qoWEDhEnyHQ28iM4l9A==", "0987654321", false, "349bb654-5f0a-47ca-bf3c-e8957a8cde5a", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a626bc29-6dcf-4c0c-947a-47801d048e53"), new Guid("570a38f9-96d5-421c-bb85-9ebec8d4e1e2") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("39e25f9a-5511-4e65-ac1f-6ca98f16818c"), new Guid("ef593612-0d45-4466-a89e-b570ef7963ff") });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AccountId",
                table: "Carts",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_AccountId",
                table: "Address",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Carts_AccountId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4674f9a1-530b-491d-a73e-e41ba73600da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddba1fb7-f773-4eab-82de-7a55e29e696e"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a626bc29-6dcf-4c0c-947a-47801d048e53"), new Guid("570a38f9-96d5-421c-bb85-9ebec8d4e1e2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("39e25f9a-5511-4e65-ac1f-6ca98f16818c"), new Guid("ef593612-0d45-4466-a89e-b570ef7963ff") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39e25f9a-5511-4e65-ac1f-6ca98f16818c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a626bc29-6dcf-4c0c-947a-47801d048e53"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("570a38f9-96d5-421c-bb85-9ebec8d4e1e2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ef593612-0d45-4466-a89e-b570ef7963ff"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("91a2f8cd-3679-4f92-a9e1-ba3f2362ecf2"), "cf4f750f-5bd5-442b-b401-05612fa01635", "Customer", "CUSTOMER" },
                    { new Guid("e972a8a2-942a-4cd4-bb3e-fc945a491eec"), "e29e2dc2-a656-4728-b57b-5fc5372d1304", "Employee", "EMPLOYEE" },
                    { new Guid("f673fac9-d72b-4bfa-9e79-013a9e1c24db"), "624aaa4e-65d5-4169-a26c-89484863ba40", "Admin", "ADMIN" },
                    { new Guid("fef7d570-87e7-4e2c-8b2e-817ab5cde609"), "540288a5-7c8c-4eba-a55c-0c2c2b1907b5", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "IsSubscribedToNews", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("be5a05a9-f4a0-4d64-bb77-a648547b9073"), 0, null, "004204004364", "4bd78ed3-5461-4609-8d14-c4ca15948db6", "user@example.com", false, null, false, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMv/2trYgHuHk7mWioXoRZgrBetWNbLKcVN1aNFuAMNpz4cz19UZiDWgakKnS9aGTA==", "0987654321", false, "bdf674ac-b063-4cba-a0a6-46d9dbc58f57", false, "user@example.com" },
                    { new Guid("ef0e2c74-b7e2-45d8-8d90-d14fb3aa2db9"), 0, null, "002204004364", "ecacd393-0a83-4847-90eb-17832ceb7041", "admin@example.com", false, null, false, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBO3cUvD4z1FCvjosKY16BZsThKwZHEF+S3a5aVRpG16ktvLqIGTQlUR+G06hRoD1Q==", "0123456789", false, "e5b682a1-141b-41d1-b4c0-03426363d209", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("91a2f8cd-3679-4f92-a9e1-ba3f2362ecf2"), new Guid("be5a05a9-f4a0-4d64-bb77-a648547b9073") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f673fac9-d72b-4bfa-9e79-013a9e1c24db"), new Guid("ef0e2c74-b7e2-45d8-8d90-d14fb3aa2db9") });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AccountId",
                table: "Carts",
                column: "AccountId");
        }
    }
}
