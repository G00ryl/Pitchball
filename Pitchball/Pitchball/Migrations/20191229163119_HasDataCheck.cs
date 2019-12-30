using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitchball.Migrations
{
    public partial class HasDataCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "Login", "Name", "PasswordHash", "Role", "Salt", "Surname", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2019, 12, 29, 16, 31, 19, 137, DateTimeKind.Utc), "Admin", "admin@callme.com", "Admin", "Jan", new byte[] { 183, 134, 117, 106, 149, 118, 212, 28, 41, 52, 73, 34, 36, 135, 216, 115, 174, 155, 144, 224, 42, 89, 172, 193, 118, 174, 180, 203, 219, 55, 108, 106, 96, 14, 95, 36, 204, 60, 89, 223, 56, 80, 46, 204, 71, 238, 89, 232, 45, 27, 232, 93, 41, 24, 187, 251, 156, 145, 77, 80, 147, 229, 94, 77 }, "Admin", new byte[] { 84, 226, 85, 27, 113, 144, 224, 10, 114, 52, 57, 7, 142, 215, 188, 110, 120, 231, 193, 21, 183, 68, 51, 92, 245, 47, 109, 20, 119, 84, 241, 124, 212, 158, 56, 148, 239, 231, 74, 198, 251, 187, 99, 244, 164, 17, 198, 219, 121, 163, 2, 97, 167, 26, 29, 250, 161, 130, 86, 30, 99, 183, 6, 23, 195, 192, 138, 208, 149, 195, 23, 254, 97, 112, 229, 95, 151, 54, 121, 128, 81, 88, 141, 180, 72, 249, 169, 174, 175, 9, 38, 87, 9, 205, 34, 112, 80, 66, 251, 2, 93, 39, 225, 53, 237, 224, 90, 119, 130, 194, 31, 240, 104, 196, 50, 227, 155, 128, 28, 70, 136, 69, 48, 201, 234, 49, 179, 86 }, "Nowak", new DateTime(2019, 12, 29, 16, 31, 19, 137, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
