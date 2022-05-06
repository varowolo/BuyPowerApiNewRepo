using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyPowerApiNew.Migrations
{
    public partial class ClientColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fd7a9ff-7717-4ce0-9fed-c75829576127");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364d9b7d-7892-44e4-82fd-01f2131ee92a");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "tblRequestAndResponseLog",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e82a24b0-990b-4636-a42d-fb0178f87ab3", "f53e370a-23ff-4e9c-9917-2f5f6ca5866e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "608c5728-3829-4d68-a678-ead574db3cee", "6cfd5769-3535-4917-99b4-1cbe4e10151e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "608c5728-3829-4d68-a678-ead574db3cee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82a24b0-990b-4636-a42d-fb0178f87ab3");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "tblRequestAndResponseLog");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "364d9b7d-7892-44e4-82fd-01f2131ee92a", "caa9ba1e-c6e5-4232-88b7-29723c40560c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fd7a9ff-7717-4ce0-9fed-c75829576127", "a91b05f1-f5e3-4f04-8f27-e2b6420c5f8e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
