using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusArrivalDeparture_BusOperationPlans_BusScheduleId",
                table: "BusArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_BusStationSchedule_BusStations_StationId",
                table: "BusStationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusOperationPlans_BusScheduleId",
                table: "BusStops");

            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusStations_StationId",
                table: "BusStops");

            migrationBuilder.DropForeignKey(
                name: "FK_BusTickets_BusOperationPlans_ScheduleId",
                table: "BusTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_BusTickets_BusSeats_SeatId",
                table: "BusTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneArrivalDeparture_PlaneOperationPlans_PlaneScheduleId",
                table: "PlaneArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneStationSchedule_PlaneStations_StationId",
                table: "PlaneStationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneStops_PlaneOperationPlans_PlaneScheduleId",
                table: "PlaneStops");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneStops_PlaneStations_StationId",
                table: "PlaneStops");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneTickets_PlaneOperationPlans_ScheduleId",
                table: "PlaneTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneTickets_PlaneSeats_SeatId",
                table: "PlaneTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainArrivalDeparture_TrainOperationPlans_TrainScheduleId",
                table: "TrainArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStationSchedule_TrainStations_StationId",
                table: "TrainStationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStops_TrainOperationPlans_TrainScheduleId",
                table: "TrainStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStops_TrainStations_StationId",
                table: "TrainStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_TrainOperationPlans_ScheduleId",
                table: "TrainTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_TrainSeats_SeatId",
                table: "TrainTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_Wagons_WagonId",
                table: "TrainTickets");

            migrationBuilder.DropIndex(
                name: "IX_TrainTickets_ScheduleId",
                table: "TrainTickets");

            migrationBuilder.DropIndex(
                name: "IX_TrainTickets_SeatId",
                table: "TrainTickets");

            migrationBuilder.DropIndex(
                name: "IX_BusTickets_SeatId",
                table: "BusTickets");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "PassengerCount",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "PassengerFirstName",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "PassengerLastName",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "TrainTickets");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "PlaneTickets");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "PlaneTickets");

            migrationBuilder.DropColumn(
                name: "PassengerCount",
                table: "PlaneTickets");

            migrationBuilder.DropColumn(
                name: "PassengerFirstName",
                table: "PlaneTickets");

            migrationBuilder.DropColumn(
                name: "PassengerLastName",
                table: "PlaneTickets");

            migrationBuilder.DropColumn(
                name: "PlaneScheduleId",
                table: "PlaneTickets");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "BusTickets");

            migrationBuilder.DropColumn(
                name: "BusScheduleId",
                table: "BusTickets");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "BusTickets");

            migrationBuilder.DropColumn(
                name: "PassengerFirstName",
                table: "BusTickets");

            migrationBuilder.DropColumn(
                name: "PassengerLastName",
                table: "BusTickets");

            migrationBuilder.RenameColumn(
                name: "WagonId",
                table: "TrainTickets",
                newName: "TrainOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "TrainScheduleId",
                table: "TrainTickets",
                newName: "TrainId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainTickets_WagonId",
                table: "TrainTickets",
                newName: "IX_TrainTickets_TrainOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "TrainScheduleId",
                table: "TrainStops",
                newName: "TrainStationId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "TrainStops",
                newName: "TrainOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStops_TrainScheduleId",
                table: "TrainStops",
                newName: "IX_TrainStops_TrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStops_StationId",
                table: "TrainStops",
                newName: "IX_TrainStops_TrainOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "TrainStationSchedule",
                newName: "TrainStationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStationSchedule_StationId",
                table: "TrainStationSchedule",
                newName: "IX_TrainStationSchedule_TrainStationId");

            migrationBuilder.RenameColumn(
                name: "TrainScheduleId",
                table: "TrainArrivalDeparture",
                newName: "TrainOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainArrivalDeparture_TrainScheduleId",
                table: "TrainArrivalDeparture",
                newName: "IX_TrainArrivalDeparture_TrainOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "PlaneTickets",
                newName: "PlaneOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "PlaneTickets",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneTickets_SeatId",
                table: "PlaneTickets",
                newName: "IX_PlaneTickets_PlaneOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneTickets_ScheduleId",
                table: "PlaneTickets",
                newName: "IX_PlaneTickets_PlaneId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "PlaneStops",
                newName: "PlaneStationId");

            migrationBuilder.RenameColumn(
                name: "PlaneScheduleId",
                table: "PlaneStops",
                newName: "PlaneOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneStops_StationId",
                table: "PlaneStops",
                newName: "IX_PlaneStops_PlaneStationId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneStops_PlaneScheduleId",
                table: "PlaneStops",
                newName: "IX_PlaneStops_PlaneOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "PlaneStationSchedule",
                newName: "PlaneStationId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneStationSchedule_StationId",
                table: "PlaneStationSchedule",
                newName: "IX_PlaneStationSchedule_PlaneStationId");

            migrationBuilder.RenameColumn(
                name: "PlaneScheduleId",
                table: "PlaneArrivalDeparture",
                newName: "PlaneOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneArrivalDeparture_PlaneScheduleId",
                table: "PlaneArrivalDeparture",
                newName: "IX_PlaneArrivalDeparture_PlaneOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "BusTickets",
                newName: "BusType");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "BusTickets",
                newName: "BusOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "PassengerCount",
                table: "BusTickets",
                newName: "BusId");

            migrationBuilder.RenameIndex(
                name: "IX_BusTickets_ScheduleId",
                table: "BusTickets",
                newName: "IX_BusTickets_BusOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "BusStops",
                newName: "BusStationId");

            migrationBuilder.RenameColumn(
                name: "BusScheduleId",
                table: "BusStops",
                newName: "BusOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BusStops_StationId",
                table: "BusStops",
                newName: "IX_BusStops_BusStationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusStops_BusScheduleId",
                table: "BusStops",
                newName: "IX_BusStops_BusOperationPlanId");

            migrationBuilder.RenameColumn(
                name: "StationId",
                table: "BusStationSchedule",
                newName: "BusStationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusStationSchedule_StationId",
                table: "BusStationSchedule",
                newName: "IX_BusStationSchedule_BusStationId");

            migrationBuilder.RenameColumn(
                name: "BusScheduleId",
                table: "BusArrivalDeparture",
                newName: "BusOperationPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_BusArrivalDeparture_BusScheduleId",
                table: "BusArrivalDeparture",
                newName: "IX_BusArrivalDeparture_BusOperationPlanId");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BookingHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_TrainId",
                table: "TrainTickets",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTickets_BusId",
                table: "BusTickets",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusArrivalDeparture_BusOperationPlans_BusOperationPlanId",
                table: "BusArrivalDeparture",
                column: "BusOperationPlanId",
                principalTable: "BusOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStationSchedule_BusStations_BusStationId",
                table: "BusStationSchedule",
                column: "BusStationId",
                principalTable: "BusStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusOperationPlans_BusOperationPlanId",
                table: "BusStops",
                column: "BusOperationPlanId",
                principalTable: "BusOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusStations_BusStationId",
                table: "BusStops",
                column: "BusStationId",
                principalTable: "BusStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTickets_BusOperationPlans_BusOperationPlanId",
                table: "BusTickets",
                column: "BusOperationPlanId",
                principalTable: "BusOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTickets_Buses_BusId",
                table: "BusTickets",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneArrivalDeparture_PlaneOperationPlans_PlaneOperationPlanId",
                table: "PlaneArrivalDeparture",
                column: "PlaneOperationPlanId",
                principalTable: "PlaneOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneStationSchedule_PlaneStations_PlaneStationId",
                table: "PlaneStationSchedule",
                column: "PlaneStationId",
                principalTable: "PlaneStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneStops_PlaneOperationPlans_PlaneOperationPlanId",
                table: "PlaneStops",
                column: "PlaneOperationPlanId",
                principalTable: "PlaneOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneStops_PlaneStations_PlaneStationId",
                table: "PlaneStops",
                column: "PlaneStationId",
                principalTable: "PlaneStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneTickets_PlaneOperationPlans_PlaneOperationPlanId",
                table: "PlaneTickets",
                column: "PlaneOperationPlanId",
                principalTable: "PlaneOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneTickets_Planes_PlaneId",
                table: "PlaneTickets",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainArrivalDeparture_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainArrivalDeparture",
                column: "TrainOperationPlanId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStationSchedule_TrainStations_TrainStationId",
                table: "TrainStationSchedule",
                column: "TrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStops_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainStops",
                column: "TrainOperationPlanId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStops_TrainStations_TrainStationId",
                table: "TrainStops",
                column: "TrainStationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainTickets",
                column: "TrainOperationPlanId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_Trains_TrainId",
                table: "TrainTickets",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusArrivalDeparture_BusOperationPlans_BusOperationPlanId",
                table: "BusArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_BusStationSchedule_BusStations_BusStationId",
                table: "BusStationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusOperationPlans_BusOperationPlanId",
                table: "BusStops");

            migrationBuilder.DropForeignKey(
                name: "FK_BusStops_BusStations_BusStationId",
                table: "BusStops");

            migrationBuilder.DropForeignKey(
                name: "FK_BusTickets_BusOperationPlans_BusOperationPlanId",
                table: "BusTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_BusTickets_Buses_BusId",
                table: "BusTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneArrivalDeparture_PlaneOperationPlans_PlaneOperationPlanId",
                table: "PlaneArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneStationSchedule_PlaneStations_PlaneStationId",
                table: "PlaneStationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneStops_PlaneOperationPlans_PlaneOperationPlanId",
                table: "PlaneStops");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneStops_PlaneStations_PlaneStationId",
                table: "PlaneStops");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneTickets_PlaneOperationPlans_PlaneOperationPlanId",
                table: "PlaneTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaneTickets_Planes_PlaneId",
                table: "PlaneTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainArrivalDeparture_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainArrivalDeparture");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStationSchedule_TrainStations_TrainStationId",
                table: "TrainStationSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStops_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainStops_TrainStations_TrainStationId",
                table: "TrainStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_TrainOperationPlans_TrainOperationPlanId",
                table: "TrainTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTickets_Trains_TrainId",
                table: "TrainTickets");

            migrationBuilder.DropIndex(
                name: "IX_TrainTickets_TrainId",
                table: "TrainTickets");

            migrationBuilder.DropIndex(
                name: "IX_BusTickets_BusId",
                table: "BusTickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookingHistories");

            migrationBuilder.RenameColumn(
                name: "TrainOperationPlanId",
                table: "TrainTickets",
                newName: "WagonId");

            migrationBuilder.RenameColumn(
                name: "TrainId",
                table: "TrainTickets",
                newName: "TrainScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainTickets_TrainOperationPlanId",
                table: "TrainTickets",
                newName: "IX_TrainTickets_WagonId");

            migrationBuilder.RenameColumn(
                name: "TrainStationId",
                table: "TrainStops",
                newName: "TrainScheduleId");

            migrationBuilder.RenameColumn(
                name: "TrainOperationPlanId",
                table: "TrainStops",
                newName: "StationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStops_TrainStationId",
                table: "TrainStops",
                newName: "IX_TrainStops_TrainScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStops_TrainOperationPlanId",
                table: "TrainStops",
                newName: "IX_TrainStops_StationId");

            migrationBuilder.RenameColumn(
                name: "TrainStationId",
                table: "TrainStationSchedule",
                newName: "StationId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainStationSchedule_TrainStationId",
                table: "TrainStationSchedule",
                newName: "IX_TrainStationSchedule_StationId");

            migrationBuilder.RenameColumn(
                name: "TrainOperationPlanId",
                table: "TrainArrivalDeparture",
                newName: "TrainScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainArrivalDeparture_TrainOperationPlanId",
                table: "TrainArrivalDeparture",
                newName: "IX_TrainArrivalDeparture_TrainScheduleId");

            migrationBuilder.RenameColumn(
                name: "PlaneOperationPlanId",
                table: "PlaneTickets",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "PlaneTickets",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneTickets_PlaneOperationPlanId",
                table: "PlaneTickets",
                newName: "IX_PlaneTickets_SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneTickets_PlaneId",
                table: "PlaneTickets",
                newName: "IX_PlaneTickets_ScheduleId");

            migrationBuilder.RenameColumn(
                name: "PlaneStationId",
                table: "PlaneStops",
                newName: "StationId");

            migrationBuilder.RenameColumn(
                name: "PlaneOperationPlanId",
                table: "PlaneStops",
                newName: "PlaneScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneStops_PlaneStationId",
                table: "PlaneStops",
                newName: "IX_PlaneStops_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneStops_PlaneOperationPlanId",
                table: "PlaneStops",
                newName: "IX_PlaneStops_PlaneScheduleId");

            migrationBuilder.RenameColumn(
                name: "PlaneStationId",
                table: "PlaneStationSchedule",
                newName: "StationId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneStationSchedule_PlaneStationId",
                table: "PlaneStationSchedule",
                newName: "IX_PlaneStationSchedule_StationId");

            migrationBuilder.RenameColumn(
                name: "PlaneOperationPlanId",
                table: "PlaneArrivalDeparture",
                newName: "PlaneScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_PlaneArrivalDeparture_PlaneOperationPlanId",
                table: "PlaneArrivalDeparture",
                newName: "IX_PlaneArrivalDeparture_PlaneScheduleId");

            migrationBuilder.RenameColumn(
                name: "BusType",
                table: "BusTickets",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "BusOperationPlanId",
                table: "BusTickets",
                newName: "ScheduleId");

            migrationBuilder.RenameColumn(
                name: "BusId",
                table: "BusTickets",
                newName: "PassengerCount");

            migrationBuilder.RenameIndex(
                name: "IX_BusTickets_BusOperationPlanId",
                table: "BusTickets",
                newName: "IX_BusTickets_ScheduleId");

            migrationBuilder.RenameColumn(
                name: "BusStationId",
                table: "BusStops",
                newName: "StationId");

            migrationBuilder.RenameColumn(
                name: "BusOperationPlanId",
                table: "BusStops",
                newName: "BusScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_BusStops_BusStationId",
                table: "BusStops",
                newName: "IX_BusStops_StationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusStops_BusOperationPlanId",
                table: "BusStops",
                newName: "IX_BusStops_BusScheduleId");

            migrationBuilder.RenameColumn(
                name: "BusStationId",
                table: "BusStationSchedule",
                newName: "StationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusStationSchedule_BusStationId",
                table: "BusStationSchedule",
                newName: "IX_BusStationSchedule_StationId");

            migrationBuilder.RenameColumn(
                name: "BusOperationPlanId",
                table: "BusArrivalDeparture",
                newName: "BusScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_BusArrivalDeparture_BusOperationPlanId",
                table: "BusArrivalDeparture",
                newName: "IX_BusArrivalDeparture_BusScheduleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "TrainTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "TrainTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PassengerCount",
                table: "TrainTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PassengerFirstName",
                table: "TrainTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerLastName",
                table: "TrainTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "TrainTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "TrainTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "PlaneTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "PlaneTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PassengerCount",
                table: "PlaneTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PassengerFirstName",
                table: "PlaneTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerLastName",
                table: "PlaneTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlaneScheduleId",
                table: "PlaneTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "BusTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BusScheduleId",
                table: "BusTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "BusTickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PassengerFirstName",
                table: "BusTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerLastName",
                table: "BusTickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_ScheduleId",
                table: "TrainTickets",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_SeatId",
                table: "TrainTickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTickets_SeatId",
                table: "BusTickets",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusArrivalDeparture_BusOperationPlans_BusScheduleId",
                table: "BusArrivalDeparture",
                column: "BusScheduleId",
                principalTable: "BusOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStationSchedule_BusStations_StationId",
                table: "BusStationSchedule",
                column: "StationId",
                principalTable: "BusStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusOperationPlans_BusScheduleId",
                table: "BusStops",
                column: "BusScheduleId",
                principalTable: "BusOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusStops_BusStations_StationId",
                table: "BusStops",
                column: "StationId",
                principalTable: "BusStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTickets_BusOperationPlans_ScheduleId",
                table: "BusTickets",
                column: "ScheduleId",
                principalTable: "BusOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusTickets_BusSeats_SeatId",
                table: "BusTickets",
                column: "SeatId",
                principalTable: "BusSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneArrivalDeparture_PlaneOperationPlans_PlaneScheduleId",
                table: "PlaneArrivalDeparture",
                column: "PlaneScheduleId",
                principalTable: "PlaneOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneStationSchedule_PlaneStations_StationId",
                table: "PlaneStationSchedule",
                column: "StationId",
                principalTable: "PlaneStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneStops_PlaneOperationPlans_PlaneScheduleId",
                table: "PlaneStops",
                column: "PlaneScheduleId",
                principalTable: "PlaneOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneStops_PlaneStations_StationId",
                table: "PlaneStops",
                column: "StationId",
                principalTable: "PlaneStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneTickets_PlaneOperationPlans_ScheduleId",
                table: "PlaneTickets",
                column: "ScheduleId",
                principalTable: "PlaneOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaneTickets_PlaneSeats_SeatId",
                table: "PlaneTickets",
                column: "SeatId",
                principalTable: "PlaneSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainArrivalDeparture_TrainOperationPlans_TrainScheduleId",
                table: "TrainArrivalDeparture",
                column: "TrainScheduleId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStationSchedule_TrainStations_StationId",
                table: "TrainStationSchedule",
                column: "StationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStops_TrainOperationPlans_TrainScheduleId",
                table: "TrainStops",
                column: "TrainScheduleId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainStops_TrainStations_StationId",
                table: "TrainStops",
                column: "StationId",
                principalTable: "TrainStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_TrainOperationPlans_ScheduleId",
                table: "TrainTickets",
                column: "ScheduleId",
                principalTable: "TrainOperationPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_TrainSeats_SeatId",
                table: "TrainTickets",
                column: "SeatId",
                principalTable: "TrainSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTickets_Wagons_WagonId",
                table: "TrainTickets",
                column: "WagonId",
                principalTable: "Wagons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
