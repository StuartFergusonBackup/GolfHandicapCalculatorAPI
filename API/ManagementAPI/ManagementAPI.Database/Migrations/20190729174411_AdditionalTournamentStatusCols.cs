﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementAPI.Database.Migrations
{
    public partial class AdditionalTournamentStatusCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayersScoredRecordedCount",
                table: "Tournament",
                newName: "PlayersScoresRecordedCount");

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenCancelled",
                table: "Tournament",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenCompleted",
                table: "Tournament",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenCancelled",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "HasBeenCompleted",
                table: "Tournament");

            migrationBuilder.RenameColumn(
                name: "PlayersScoresRecordedCount",
                table: "Tournament",
                newName: "PlayersScoredRecordedCount");
        }
    }
}
