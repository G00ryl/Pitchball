using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitchball.Migrations
{
    public partial class funny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_CaptainId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CaptainId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CaptainId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                newName: "IX_Messages_CreatorId");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 20, 0, 40, 55, 656, DateTimeKind.Utc), new byte[] { 132, 77, 254, 252, 40, 15, 138, 212, 132, 61, 103, 167, 126, 100, 217, 210, 171, 222, 168, 250, 140, 165, 106, 131, 4, 236, 179, 164, 154, 197, 86, 124, 53, 163, 250, 156, 75, 252, 198, 71, 207, 237, 221, 240, 71, 23, 225, 47, 45, 112, 225, 142, 59, 45, 16, 53, 229, 63, 97, 187, 3, 192, 226, 14 }, new byte[] { 234, 106, 77, 7, 47, 200, 100, 168, 169, 52, 74, 241, 12, 143, 198, 147, 193, 158, 133, 237, 18, 56, 208, 52, 224, 226, 142, 68, 191, 157, 165, 46, 200, 94, 49, 130, 188, 50, 92, 160, 161, 191, 75, 121, 94, 254, 130, 43, 29, 176, 99, 185, 139, 30, 7, 14, 176, 57, 53, 53, 236, 183, 17, 180, 71, 38, 78, 147, 73, 22, 7, 171, 211, 208, 67, 87, 57, 36, 130, 214, 0, 52, 191, 174, 28, 47, 242, 240, 73, 28, 216, 169, 129, 181, 187, 149, 152, 34, 123, 114, 93, 191, 95, 46, 211, 116, 88, 143, 202, 95, 159, 144, 28, 170, 93, 57, 206, 58, 63, 217, 14, 45, 181, 12, 62, 244, 88, 133 }, new DateTime(2020, 1, 20, 0, 40, 55, 656, DateTimeKind.Utc) });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_CreatorId",
                table: "Messages",
                column: "CreatorId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_CreatorId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_CreatorId",
                table: "Messages",
                newName: "IX_Messages_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CaptainId",
                table: "Messages",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 19, 15, 27, 4, 440, DateTimeKind.Utc), new byte[] { 113, 0, 25, 210, 41, 68, 150, 204, 173, 203, 229, 180, 109, 128, 92, 120, 113, 254, 65, 55, 11, 74, 240, 238, 71, 61, 29, 215, 252, 128, 219, 30, 220, 63, 230, 228, 103, 245, 79, 253, 111, 41, 54, 238, 48, 231, 165, 213, 86, 66, 49, 215, 177, 111, 218, 19, 82, 38, 51, 169, 194, 56, 84, 173 }, new byte[] { 229, 117, 133, 158, 136, 201, 186, 121, 110, 67, 150, 147, 2, 187, 67, 166, 17, 73, 205, 212, 155, 189, 180, 210, 163, 178, 117, 211, 212, 68, 27, 191, 140, 48, 114, 231, 92, 63, 183, 126, 8, 26, 190, 80, 102, 58, 103, 98, 74, 251, 251, 74, 13, 110, 206, 1, 176, 234, 143, 130, 39, 79, 207, 133, 0, 23, 91, 3, 15, 128, 76, 109, 74, 238, 211, 90, 206, 127, 239, 127, 139, 25, 42, 144, 116, 248, 109, 9, 69, 131, 64, 51, 20, 254, 41, 151, 29, 105, 190, 163, 156, 144, 39, 76, 104, 89, 33, 240, 31, 11, 234, 65, 144, 48, 135, 201, 133, 9, 178, 52, 182, 209, 183, 159, 100, 253, 165, 223 }, new DateTime(2020, 1, 19, 15, 27, 4, 440, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CaptainId",
                table: "Messages",
                column: "CaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_CaptainId",
                table: "Messages",
                column: "CaptainId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
