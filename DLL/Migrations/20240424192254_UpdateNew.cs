using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainArrivalDeparture_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainArrivalDeparture_TrainStationSchedule_TrainStationScheduleId",
                table: "TrainArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStationSchedule_TrainStations_TrainStationId",
                table: "TrainStationSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainStationSchedule",
                table: "TrainStationSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainArrivalDeparture",
                table: "TrainArrivalDeparture");

            migrationBuilder.RenameTable(
                name: "TrainStationSchedule",
                newName: "TrainStationSchedules");

            migrationBuilder.RenameTable(
                name: "TrainArrivalDeparture",
                newName: "TrainArrivalsDepartures");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "TrainSeats",
                newName: "SeatType");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStationSchedule_TrainStationId",
                table: "TrainStationSchedules",
                newName: "IX_TrainStationSchedules_TrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainArrivalDeparture_TrainStationScheduleId",
                table: "TrainArrivalsDepartures",
                newName: "IX_TrainArrivalsDepartures_TrainStationScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainArrivalDeparture_TrainOperationPlanId",
                table: "TrainArrivalsDepartures",
                newName: "IX_TrainArrivalsDepartures_TrainOperationPlanId");

            migrationBuilder.AddColumn<int>(
                name: "WagonType",
                table: "Wagons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateType",
                table: "TrainSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainType",
                table: "Trains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainStationSchedules",
                table: "TrainStationSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainArrivalsDepartures",
                table: "TrainArrivalsDepartures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainArrivalsDepartures_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainArrivalsDepartures",
                column: "TrainOperationPlanId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainArrivalsDepartures_TrainStationSchedules_TrainStationScheduleId",
                table: "TrainArrivalsDepartures",
                column: "TrainStationScheduleId",
                principalTable: "TrainStationSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStationSchedules_TrainStations_TrainStationId",
                table: "TrainStationSchedules",
                column: "TrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainArrivalsDepartures_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainArrivalsDepartures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainArrivalsDepartures_TrainStationSchedules_TrainStationScheduleId",
                table: "TrainArrivalsDepartures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStationSchedules_TrainStations_TrainStationId",
                table: "TrainStationSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainStationSchedules",
                table: "TrainStationSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainArrivalsDepartures",
                table: "TrainArrivalsDepartures");

            migrationBuilder.DropColumn(
                name: "WagonType",
                table: "Wagons");

            migrationBuilder.DropColumn(
                name: "StateType",
                table: "TrainSeats");

            migrationBuilder.DropColumn(
                name: "TrainType",
                table: "Trains");

            migrationBuilder.RenameTable(
                name: "TrainStationSchedules",
                newName: "TrainStationSchedule");

            migrationBuilder.RenameTable(
                name: "TrainArrivalsDepartures",
                newName: "TrainArrivalDeparture");

            migrationBuilder.RenameColumn(
                name: "SeatType",
                table: "TrainSeats",
                newName: "IsAvailable");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStationSchedules_TrainStationId",
                table: "TrainStationSchedule",
                newName: "IX_TrainStationSchedule_TrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainArrivalsDepartures_TrainStationScheduleId",
                table: "TrainArrivalDeparture",
                newName: "IX_TrainArrivalDeparture_TrainStationScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainArrivalsDepartures_TrainOperationPlanId",
                table: "TrainArrivalDeparture",
                newName: "IX_TrainArrivalDeparture_TrainOperationPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainStationSchedule",
                table: "TrainStationSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainArrivalDeparture",
                table: "TrainArrivalDeparture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainArrivalDeparture_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainArrivalDeparture",
                column: "TrainOperationPlanId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainArrivalDeparture_TrainStationSchedule_TrainStationScheduleId",
                table: "TrainArrivalDeparture",
                column: "TrainStationScheduleId",
                principalTable: "TrainStationSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStationSchedule_TrainStations_TrainStationId",
                table: "TrainStationSchedule",
                column: "TrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
