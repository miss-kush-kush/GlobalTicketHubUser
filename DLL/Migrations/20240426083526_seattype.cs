using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLL.Migrations
{
    /// <inheritdoc />
    public partial class seattype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_Trains_TrainId",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "StudentCardNumber",
                table: "TrainTickets");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "TrainTickets",
                newName: "TrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainTickets_TrainId",
                table: "TrainTickets",
                newName: "IX_TrainTickets_TrainStationId");

            migrationBuilder.AddColumn<int>(
                name: "TrainLineId",
                table: "TrainTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SeatType",
                table: "TrainSeats",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_TrainLineId",
                table: "TrainTickets",
                column: "TrainLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_TrainLines_TrainLineId",
                table: "TrainTickets",
                column: "TrainLineId",
                principalTable: "TrainLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_TrainStations_TrainStationId",
                table: "TrainTickets",
                column: "TrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_TrainLines_TrainLineId",
                table: "TrainTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_TrainStations_TrainStationId",
                table: "TrainTickets");

            migrationBuilder.DropIndex(
                name: "IX_TrainTickets_TrainLineId",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "TrainLineId",
                table: "TrainTickets");

            migrationBuilder.RenameColumn(
                name: "TrainStationId",
                table: "TrainTickets",
                newName: "TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainTickets_TrainStationId",
                table: "TrainTickets",
                newName: "IX_TrainTickets_TrainId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "TrainTickets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentCardNumber",
                table: "TrainTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "SeatType",
                table: "TrainSeats",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_Trains_TrainId",
                table: "TrainTickets",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
