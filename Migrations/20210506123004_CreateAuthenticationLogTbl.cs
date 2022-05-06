using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyPowerApiNew.Migrations
{
    public partial class CreateAuthenticationLogTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "608c5728-3829-4d68-a678-ead574db3cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82a24b0-990b-4636-a42d-fb0178f87ab3");

            migrationBuilder.CreateTable(
                name: "tblAuthRequestAndResponseLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    RequestType = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    RequestPayload = table.Column<string>(maxLength: 5000, nullable: false),
                    RequestId = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Response = table.Column<string>(maxLength: 2147483647, nullable: true),
                    RequestTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    ResponseTimestamp = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuthRequestAndResponseLog", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae8b5c2d-d1e7-49e8-98c0-58fdac90902f", "69ce0872-996a-4f78-9562-b4a3fa5e483f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "067dafd5-1dc2-45bd-8699-6f6f92a1576f", "5852f599-f562-4360-8119-ab0d7d8b92f8", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAuthRequestAndResponseLog");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "067dafd5-1dc2-45bd-8699-6f6f92a1576f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae8b5c2d-d1e7-49e8-98c0-58fdac90902f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e82a24b0-990b-4636-a42d-fb0178f87ab3", "f53e370a-23ff-4e9c-9917-2f5f6ca5866e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "608c5728-3829-4d68-a678-ead574db3cee", "6cfd5769-3535-4917-99b4-1cbe4e10151e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
