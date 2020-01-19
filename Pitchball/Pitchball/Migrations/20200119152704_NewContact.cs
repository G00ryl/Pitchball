using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitchball.Migrations
{
    public partial class NewContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 19, 15, 27, 4, 440, DateTimeKind.Utc), new byte[] { 113, 0, 25, 210, 41, 68, 150, 204, 173, 203, 229, 180, 109, 128, 92, 120, 113, 254, 65, 55, 11, 74, 240, 238, 71, 61, 29, 215, 252, 128, 219, 30, 220, 63, 230, 228, 103, 245, 79, 253, 111, 41, 54, 238, 48, 231, 165, 213, 86, 66, 49, 215, 177, 111, 218, 19, 82, 38, 51, 169, 194, 56, 84, 173 }, new byte[] { 229, 117, 133, 158, 136, 201, 186, 121, 110, 67, 150, 147, 2, 187, 67, 166, 17, 73, 205, 212, 155, 189, 180, 210, 163, 178, 117, 211, 212, 68, 27, 191, 140, 48, 114, 231, 92, 63, 183, 126, 8, 26, 190, 80, 102, 58, 103, 98, 74, 251, 251, 74, 13, 110, 206, 1, 176, 234, 143, 130, 39, 79, 207, 133, 0, 23, 91, 3, 15, 128, 76, 109, 74, 238, 211, 90, 206, 127, 239, 127, 139, 25, 42, 144, 116, 248, 109, 9, 69, 131, 64, 51, 20, 254, 41, 151, 29, 105, 190, 163, 156, 144, 39, 76, 104, 89, 33, 240, 31, 11, 234, 65, 144, 48, 135, 201, 133, 9, 178, 52, 182, 209, 183, 159, 100, 253, 165, 223 }, new DateTime(2020, 1, 19, 15, 27, 4, 440, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 18, 11, 52, 32, 961, DateTimeKind.Utc), new byte[] { 162, 148, 202, 124, 39, 14, 199, 54, 192, 55, 191, 179, 212, 42, 220, 55, 151, 43, 180, 49, 168, 57, 111, 238, 63, 38, 53, 81, 184, 128, 39, 160, 238, 164, 230, 167, 253, 125, 70, 27, 157, 82, 157, 7, 211, 154, 50, 190, 145, 9, 11, 140, 166, 248, 191, 205, 51, 131, 153, 48, 96, 216, 176, 99 }, new byte[] { 251, 138, 124, 124, 244, 17, 54, 164, 167, 177, 184, 93, 165, 111, 96, 135, 73, 133, 165, 175, 126, 62, 41, 163, 59, 117, 243, 17, 29, 223, 162, 153, 172, 212, 54, 54, 31, 172, 192, 23, 217, 157, 239, 170, 140, 35, 55, 153, 187, 157, 10, 133, 126, 166, 10, 126, 56, 244, 203, 31, 59, 26, 189, 106, 126, 38, 54, 166, 9, 24, 143, 207, 193, 183, 77, 27, 33, 165, 241, 97, 19, 165, 100, 218, 200, 188, 147, 31, 72, 114, 27, 65, 197, 30, 211, 250, 248, 228, 66, 151, 87, 238, 32, 215, 11, 248, 125, 101, 172, 95, 75, 85, 3, 165, 146, 84, 38, 107, 9, 32, 17, 54, 44, 254, 237, 223, 55, 85 }, new DateTime(2020, 1, 18, 11, 52, 32, 961, DateTimeKind.Utc) });
        }
    }
}
