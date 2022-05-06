using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyPowerApiNew.Migrations
{
    public partial class myFirstDBChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "364d9b7d-7892-44e4-82fd-01f2131ee92a", "caa9ba1e-c6e5-4232-88b7-29723c40560c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fd7a9ff-7717-4ce0-9fed-c75829576127", "a91b05f1-f5e3-4f04-8f27-e2b6420c5f8e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fd7a9ff-7717-4ce0-9fed-c75829576127");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364d9b7d-7892-44e4-82fd-01f2131ee92a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8be12924-b551-4f75-a085-5f8fda1c938e", "a41a5473-3a26-42bd-8f94-7e326c73bde3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ddc0ae7-b044-4a4c-afcf-d08671b62206", "901534f5-895c-411d-afad-b90cb217bd3d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
