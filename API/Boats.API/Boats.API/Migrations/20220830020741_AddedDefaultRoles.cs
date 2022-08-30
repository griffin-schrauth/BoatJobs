using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boats.API.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d2c8339-8a2c-4585-b164-762b8b246724", "b2859f90-e0b2-492c-84fd-9bec7af025ff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53ff9c2c-9c71-4af1-b330-e6ed1cbc809a", "8857aa83-33e5-485c-b80c-26081adc10ac", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2c8339-8a2c-4585-b164-762b8b246724");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ff9c2c-9c71-4af1-b330-e6ed1cbc809a");
        }
    }
}
