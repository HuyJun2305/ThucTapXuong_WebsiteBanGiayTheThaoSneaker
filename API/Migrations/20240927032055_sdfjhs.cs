using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class sdfjhs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPromotion_ProductDetails_ProductDetailId",
                table: "ProductDetailPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPromotion_Promotions_PromotionId",
                table: "ProductDetailPromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetailPromotion",
                table: "ProductDetailPromotion");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1bdda496-a934-4835-825f-188816859d44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6aeee130-15aa-41c0-a9de-2ea98385e88a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5e97789e-946b-4018-9791-a2e5c6093a0e"), new Guid("09a5b961-fc41-4ce7-baca-a04d207441e9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a81c0ccc-b1d3-4077-b225-afc5c06122bd"), new Guid("703141ae-4488-4a7e-aa22-7596a48d6b0c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e97789e-946b-4018-9791-a2e5c6093a0e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a81c0ccc-b1d3-4077-b225-afc5c06122bd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09a5b961-fc41-4ce7-baca-a04d207441e9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("703141ae-4488-4a7e-aa22-7596a48d6b0c"));

            migrationBuilder.RenameTable(
                name: "ProductDetailPromotion",
                newName: "ProductDetailPromotions");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPromotion_PromotionId",
                table: "ProductDetailPromotions",
                newName: "IX_ProductDetailPromotions_PromotionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetailPromotions",
                table: "ProductDetailPromotions",
                columns: new[] { "ProductDetailId", "PromotionId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("389f6c6a-c0d7-4f9e-a549-9944232cf12f"), "64cee381-e699-4a91-a06a-4bddabedbb92", "Admin", "ADMIN" },
                    { new Guid("580c0988-6077-48d6-9e4d-e1e836959169"), "51414b15-26aa-4bbe-b6e5-0d474adb9b6f", "Guest", "GUEST" },
                    { new Guid("7f494db9-b235-4eb9-a2d9-d63747cf9d70"), "427aec23-5ad2-4f7c-a7d5-f867e8102d15", "Employee", "EMPLOYEE" },
                    { new Guid("9643a999-7b00-4bf7-9007-8efc18adc105"), "b4deafde-e1ab-4b94-b691-61922248c19e", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("81e3efd3-d8fc-4ac1-92cf-ff2f46c3d043"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "560c9408-d5e4-4ff5-828c-5da5fe802820", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEN3jgZImCYXvgrVG+iNmu+d2Rt04eRbGMb7mEJV3x+S5ORp5hJOL3ADMZMBmHrBXmA==", "0123456789", false, "b90049c4-b6e5-4118-a48e-4a3f6ffde3bf", false, "admin@example.com" },
                    { new Guid("f5a63f41-da9f-4d8f-a144-359689e569fe"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "1042fc9c-5158-4d25-a6be-7613fdf8992a", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAENwMDL56k8V9s7b9YtW98KiF/hXUl/YvUlD89r8zYO+xebP+kfjN5cWMqfU9NbQcvA==", "0987654321", false, "cf6447b3-4832-4f86-9846-09c9e303edd8", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("389f6c6a-c0d7-4f9e-a549-9944232cf12f"), new Guid("81e3efd3-d8fc-4ac1-92cf-ff2f46c3d043") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9643a999-7b00-4bf7-9007-8efc18adc105"), new Guid("f5a63f41-da9f-4d8f-a144-359689e569fe") });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPromotions_ProductDetails_ProductDetailId",
                table: "ProductDetailPromotions",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPromotions_Promotions_PromotionId",
                table: "ProductDetailPromotions",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPromotions_ProductDetails_ProductDetailId",
                table: "ProductDetailPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPromotions_Promotions_PromotionId",
                table: "ProductDetailPromotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetailPromotions",
                table: "ProductDetailPromotions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("580c0988-6077-48d6-9e4d-e1e836959169"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f494db9-b235-4eb9-a2d9-d63747cf9d70"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("389f6c6a-c0d7-4f9e-a549-9944232cf12f"), new Guid("81e3efd3-d8fc-4ac1-92cf-ff2f46c3d043") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9643a999-7b00-4bf7-9007-8efc18adc105"), new Guid("f5a63f41-da9f-4d8f-a144-359689e569fe") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("389f6c6a-c0d7-4f9e-a549-9944232cf12f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9643a999-7b00-4bf7-9007-8efc18adc105"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("81e3efd3-d8fc-4ac1-92cf-ff2f46c3d043"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f5a63f41-da9f-4d8f-a144-359689e569fe"));

            migrationBuilder.RenameTable(
                name: "ProductDetailPromotions",
                newName: "ProductDetailPromotion");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetailPromotions_PromotionId",
                table: "ProductDetailPromotion",
                newName: "IX_ProductDetailPromotion_PromotionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetailPromotion",
                table: "ProductDetailPromotion",
                columns: new[] { "ProductDetailId", "PromotionId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1bdda496-a934-4835-825f-188816859d44"), "a9fe86f9-64ce-4b3a-b2ea-d37a28e263c2", "Guest", "GUEST" },
                    { new Guid("5e97789e-946b-4018-9791-a2e5c6093a0e"), "5042fef7-922f-4289-9867-d9d43d296ac3", "Admin", "ADMIN" },
                    { new Guid("6aeee130-15aa-41c0-a9de-2ea98385e88a"), "8122d6ee-a8dc-4a1b-90e6-1646309d06dd", "Employee", "EMPLOYEE" },
                    { new Guid("a81c0ccc-b1d3-4077-b225-afc5c06122bd"), "775cff15-3242-4a14-a141-00bb5f26192c", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "CIC", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageURL", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("09a5b961-fc41-4ce7-baca-a04d207441e9"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002204004364", "aeb89c8e-b134-4206-9f33-acf67cdb042b", "admin@example.com", false, null, true, null, "Admin User", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAENXyhFhmw6Rq9SYqOrifGDic10lU7++HRofEtua9R/nCUkeIuebCRrEiQAq5bn2Sqg==", "0123456789", false, "f8f5e05a-8a94-4b44-aee4-ee70e56d199d", false, "admin@example.com" },
                    { new Guid("703141ae-4488-4a7e-aa22-7596a48d6b0c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004204004364", "2af8bebf-4a10-4ad3-b28b-131d49f8afc5", "user@example.com", false, null, true, null, "Regular User", "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEAaCvMpjidCycV2XuOJvXTjg+mXTZBXMq5oxnRY3pLMsRNkqACeZTjqPHi7MB2V4RA==", "0987654321", false, "a9195600-af33-4498-9662-41b56d7c645e", false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5e97789e-946b-4018-9791-a2e5c6093a0e"), new Guid("09a5b961-fc41-4ce7-baca-a04d207441e9") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a81c0ccc-b1d3-4077-b225-afc5c06122bd"), new Guid("703141ae-4488-4a7e-aa22-7596a48d6b0c") });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPromotion_ProductDetails_ProductDetailId",
                table: "ProductDetailPromotion",
                column: "ProductDetailId",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPromotion_Promotions_PromotionId",
                table: "ProductDetailPromotion",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
