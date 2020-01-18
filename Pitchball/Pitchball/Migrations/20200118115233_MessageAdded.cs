using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitchball.Migrations
{
    public partial class MessageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CaptainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Accounts_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 18, 11, 52, 32, 961, DateTimeKind.Utc), new byte[] { 162, 148, 202, 124, 39, 14, 199, 54, 192, 55, 191, 179, 212, 42, 220, 55, 151, 43, 180, 49, 168, 57, 111, 238, 63, 38, 53, 81, 184, 128, 39, 160, 238, 164, 230, 167, 253, 125, 70, 27, 157, 82, 157, 7, 211, 154, 50, 190, 145, 9, 11, 140, 166, 248, 191, 205, 51, 131, 153, 48, 96, 216, 176, 99 }, new byte[] { 251, 138, 124, 124, 244, 17, 54, 164, 167, 177, 184, 93, 165, 111, 96, 135, 73, 133, 165, 175, 126, 62, 41, 163, 59, 117, 243, 17, 29, 223, 162, 153, 172, 212, 54, 54, 31, 172, 192, 23, 217, 157, 239, 170, 140, 35, 55, 153, 187, 157, 10, 133, 126, 166, 10, 126, 56, 244, 203, 31, 59, 26, 189, 106, 126, 38, 54, 166, 9, 24, 143, 207, 193, 183, 77, 27, 33, 165, 241, 97, 19, 165, 100, 218, 200, 188, 147, 31, 72, 114, 27, 65, 197, 30, 211, 250, 248, 228, 66, 151, 87, 238, 32, 215, 11, 248, 125, 101, 172, 95, 75, 85, 3, 165, 146, 84, 38, 107, 9, 32, 17, 54, 44, 254, 237, 223, 55, 85 }, new DateTime(2020, 1, 18, 11, 52, 32, 961, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CaptainId",
                table: "Messages",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 12, 29, 16, 34, 52, 250, DateTimeKind.Utc), new byte[] { 151, 247, 27, 71, 95, 23, 234, 7, 16, 73, 78, 98, 162, 169, 85, 114, 122, 43, 122, 191, 48, 38, 69, 30, 205, 123, 198, 89, 132, 198, 177, 68, 145, 30, 235, 161, 74, 2, 121, 130, 185, 174, 196, 22, 143, 251, 233, 105, 199, 21, 181, 46, 80, 149, 70, 76, 167, 129, 43, 184, 6, 181, 61, 198 }, new byte[] { 36, 27, 137, 21, 177, 245, 191, 140, 118, 84, 66, 4, 49, 59, 159, 72, 4, 204, 47, 172, 155, 233, 115, 232, 210, 20, 139, 174, 110, 45, 215, 11, 80, 237, 215, 32, 20, 144, 6, 209, 90, 173, 196, 129, 15, 112, 179, 145, 232, 88, 195, 199, 255, 70, 13, 84, 85, 222, 201, 123, 205, 157, 107, 55, 63, 59, 220, 18, 101, 52, 43, 102, 143, 23, 162, 248, 229, 166, 173, 14, 152, 100, 50, 155, 0, 116, 170, 73, 23, 84, 63, 45, 199, 111, 6, 168, 134, 245, 181, 24, 22, 4, 170, 166, 94, 130, 86, 14, 215, 179, 37, 80, 180, 233, 183, 238, 8, 198, 47, 71, 164, 218, 220, 71, 194, 144, 20, 89 }, new DateTime(2019, 12, 29, 16, 34, 52, 250, DateTimeKind.Utc) });
        }
    }
}
