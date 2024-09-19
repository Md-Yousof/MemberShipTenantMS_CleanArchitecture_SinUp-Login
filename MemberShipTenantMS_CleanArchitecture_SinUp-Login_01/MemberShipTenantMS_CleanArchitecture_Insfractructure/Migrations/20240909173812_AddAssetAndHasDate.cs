using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MemberShipTenantMS_CleanArchitecture_Insfractructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetAndHasDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "352aea11-2580-46b6-bc7a-9b02b81674f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b62096a-8190-4016-aaaf-77e445721d1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5076c025-2b6a-4f44-89ee-d7483b963abf");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "TenantProfile",
                columns: table => new
                {
                    TenantProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    MemberProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantProfile", x => x.TenantProfileId);
                    table.ForeignKey(
                        name: "FK_TenantProfile_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71bc39a4-94d8-4fad-877f-7f14fd3bda05", "1", "Admin", "Admin" },
                    { "817bdee2-6eea-4362-86e1-d4c79ed3221f", "2", "User", "User" },
                    { "d68e8256-74ca-4c9a-9f9e-bc074a7bf77f", "3", "HR", "HR" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "AssetName", "Description" },
                values: new object[,]
                {
                    { 1, "Asset-1", "Asset-1 Managing Admin" },
                    { 2, "Asset-2", "Asset-2 Managing Admin" },
                    { 3, "Asset-3", "Asset-3 Managing Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantProfile_AssetId",
                table: "TenantProfile",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantProfile");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71bc39a4-94d8-4fad-877f-7f14fd3bda05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "817bdee2-6eea-4362-86e1-d4c79ed3221f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d68e8256-74ca-4c9a-9f9e-bc074a7bf77f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "352aea11-2580-46b6-bc7a-9b02b81674f5", "1", "Admin", "Admin" },
                    { "4b62096a-8190-4016-aaaf-77e445721d1d", "2", "User", "User" },
                    { "5076c025-2b6a-4f44-89ee-d7483b963abf", "3", "HR", "HR" }
                });
        }
    }
}
