using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyPowerApiNew.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddd98dda-6799-46af-a21b-59f55cadb25d", "90e14d11-ef8d-4609-8518-3ab88d3dd010", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fae00ea6-e1e7-4798-b049-b1f69c4a9489", "e61e5126-bc0a-4fcb-8ab1-8d662d796e92", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd98dda-6799-46af-a21b-59f55cadb25d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae00ea6-e1e7-4798-b049-b1f69c4a9489");
        }
    }
}
