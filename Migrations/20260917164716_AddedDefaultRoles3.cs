using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83478b29-10c4-4b53-9118-2e0f49896792",
                column: "ConcurrencyStamp",
                value: "a7b8c9d0-1111-2222-3333-444455556666");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2b3e891-20f5-46a4-9b19-5d6c811234a9",
                column: "ConcurrencyStamp",
                value: "b8c9d0e1-7777-8888-9999-000011112222");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83478b29-10c4-4b53-9118-2e0f49896792",
                column: "ConcurrencyStamp",
                value: "1adbf020-0980-42cd-85cb-7e00bf5ecb95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2b3e891-20f5-46a4-9b19-5d6c811234a9",
                column: "ConcurrencyStamp",
                value: "937ad137-4952-414e-89e7-d34974a47d80");
        }
    }
}
