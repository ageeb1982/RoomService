using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ageebSoft.RoomService.Migrations
{
    public partial class A2020_03_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Custs_CustId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Rooms_RoomsId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Custs_CustId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Custs");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CustId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Movements_CustId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_RoomsId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "CustId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "RoomsId",
                table: "Movements");

            migrationBuilder.AddColumn<string>(
                name: "CustName",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustName",
                table: "Movements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movements_RoomId",
                table: "Movements",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Rooms_RoomId",
                table: "Movements",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Rooms_RoomId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_RoomId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "CustName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustName",
                table: "Movements");

            migrationBuilder.AddColumn<Guid>(
                name: "CustId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustId",
                table: "Movements",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomsId",
                table: "Movements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Custs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Date1 = table.Column<DateTime>(nullable: true),
                    Date_Add = table.Column<DateTime>(nullable: true),
                    Date_Edit = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    User_Add = table.Column<string>(nullable: true),
                    User_Edit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustId",
                table: "Rooms",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_CustId",
                table: "Movements",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_RoomsId",
                table: "Movements",
                column: "RoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Custs_CustId",
                table: "Movements",
                column: "CustId",
                principalTable: "Custs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Rooms_RoomsId",
                table: "Movements",
                column: "RoomsId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Custs_CustId",
                table: "Rooms",
                column: "CustId",
                principalTable: "Custs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
