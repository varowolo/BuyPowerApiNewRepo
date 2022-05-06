using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyPowerApiNew.Migrations
{
    public partial class CreateInitialRequestAndResponseTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddd98dda-6799-46af-a21b-59f55cadb25d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae00ea6-e1e7-4798-b049-b1f69c4a9489");

            migrationBuilder.CreateTable(
                name: "tblRequestAndResponseLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    RequestType = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    RequestPayload = table.Column<string>(maxLength: 5000, nullable: false),
                    RequestId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Response = table.Column<string>(maxLength: 2147483647, nullable: true),
                    RequestTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    ResponseTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    RequestUrl = table.Column<string>(maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestAndResponseLog", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8be12924-b551-4f75-a085-5f8fda1c938e", "a41a5473-3a26-42bd-8f94-7e326c73bde3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ddc0ae7-b044-4a4c-afcf-d08671b62206", "901534f5-895c-411d-afad-b90cb217bd3d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRequestAndResponseLog");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ddc0ae7-b044-4a4c-afcf-d08671b62206");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be12924-b551-4f75-a085-5f8fda1c938e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddd98dda-6799-46af-a21b-59f55cadb25d", "90e14d11-ef8d-4609-8518-3ab88d3dd010", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fae00ea6-e1e7-4798-b049-b1f69c4a9489", "e61e5126-bc0a-4fcb-8ab1-8d662d796e92", "Administrator", "ADMINISTRATOR" });
        }
    }
}
