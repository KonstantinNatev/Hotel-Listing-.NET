using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83478b29-10c4-4b53-9118-2e0f49896792", "1adbf020-0980-42cd-85cb-7e00bf5ecb95", "Admin", "ADMIN" },
                    { "c2b3e891-20f5-46a4-9b19-5d6c811234a9", "937ad137-4952-414e-89e7-d34974a47d80", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83478b29-10c4-4b53-9118-2e0f49896792");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2b3e891-20f5-46a4-9b19-5d6c811234a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "11872986-3d3d-4d3d-9038-3d2fa7da0158", "Admin", "ADMIN" },
                    { "2", "ff1dea29-eb4e-446a-8428-08f32eba6272", "User", "USER" }
                });
        }
    }
}
