using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boats.API.Migrations
{
    public partial class addedDefaultBoats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d2c8339-8a2c-4585-b164-762b8b246724");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ff9c2c-9c71-4af1-b330-e6ed1cbc809a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9c216f63-fd8a-47dd-a33e-1334b89e2ed2", "19548a34-9acc-41f1-a529-0c0267bc3bc7", "Administrator", "ADMINISTRATOR" },
                    { "c5c0de25-5488-46ae-aedd-65e948f01210", "a3c4fbbc-f1be-45b7-80a9-ccebab543731", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Boats",
                columns: new[] { "Id", "Amount", "County", "Date", "JobDesciption", "JobTitle", "Name", "State", "Zipcode" },
                values: new object[,]
                {
                    { new Guid("44ffbdd3-7191-470c-95a6-0b856f5acd24"), 50f, "Royal Palm Beach", "1/15/2023", "Boat is dirty", "Cleaner", "TestingBoat", "Florida", "33411" },
                    { new Guid("96628f44-7560-400d-8012-63dd9449783c"), 75f, "Royal Palm Beach", "1/16/2023", "Boat is Still dirty", "Washer", "TestingBoatTwo", "Florida", "33411" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c216f63-fd8a-47dd-a33e-1334b89e2ed2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5c0de25-5488-46ae-aedd-65e948f01210");

            migrationBuilder.DeleteData(
                table: "Boats",
                keyColumn: "Id",
                keyValue: new Guid("44ffbdd3-7191-470c-95a6-0b856f5acd24"));

            migrationBuilder.DeleteData(
                table: "Boats",
                keyColumn: "Id",
                keyValue: new Guid("96628f44-7560-400d-8012-63dd9449783c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d2c8339-8a2c-4585-b164-762b8b246724", "b2859f90-e0b2-492c-84fd-9bec7af025ff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53ff9c2c-9c71-4af1-b330-e6ed1cbc809a", "8857aa83-33e5-485c-b80c-26081adc10ac", "Administrator", "ADMINISTRATOR" });
        }
    }
}
