using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalsFriends.Migrations
{
    public partial class AddedPassSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4f6183ea-100e-4e78-ad26-14b7de22e571",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a665cf95-5e33-4776-ad9b-691c4d228554", "9db4f160-5130-4ebe-8363-9c8929c1ab8a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5f6183ea-100e-4e78-ad26-14b7de22e571",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ede0cad0-d116-4ce4-b7df-c381b5f0a339", "fb1ebf45-5034-4c79-89cc-0c650f2c56c9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "4f6183ea-100e-4e78-ad26-14b7de22e571",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0cfba10e-f8f6-4d44-a6c2-f2771c63265a", "a09759e7-f3a4-4594-8c34-4f4c21454c04" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5f6183ea-100e-4e78-ad26-14b7de22e571",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "54acb233-157c-4858-a4b9-bf43f6f613ec", "3e2cdf29-d4b0-401d-9c9c-3b2d9bb3edaf" });
        }
    }
}
