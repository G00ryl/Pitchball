using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pitchball.Migrations
{
    public partial class PitchModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingHours",
                table: "Pitches");

            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "Pitches");

            migrationBuilder.AddColumn<string>(
                name: "Lighting",
                table: "Pitches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pitches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surface",
                table: "Pitches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lighting",
                table: "Pitches");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pitches");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Pitches");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosingHours",
                table: "Pitches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningHours",
                table: "Pitches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
