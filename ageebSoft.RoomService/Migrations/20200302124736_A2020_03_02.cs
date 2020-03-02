using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ageebSoft.RoomService.Migrations
{
    public partial class A2020_03_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Custs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date1 = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    User_Add = table.Column<string>(nullable: true),
                    Date_Add = table.Column<DateTime>(nullable: true),
                    User_Edit = table.Column<string>(nullable: true),
                    Date_Edit = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date1 = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    User_Add = table.Column<string>(nullable: true),
                    Date_Add = table.Column<DateTime>(nullable: true),
                    User_Edit = table.Column<string>(nullable: true),
                    Date_Edit = table.Column<DateTime>(nullable: true),
                    DoorKey = table.Column<string>(nullable: true),
                    RoomNo = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    CustId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Custs_CustId",
                        column: x => x.CustId,
                        principalTable: "Custs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date1 = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    User_Add = table.Column<string>(nullable: true),
                    Date_Add = table.Column<DateTime>(nullable: true),
                    User_Edit = table.Column<string>(nullable: true),
                    Date_Edit = table.Column<DateTime>(nullable: true),
                    CustId = table.Column<Guid>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: true),
                    RoomsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_Custs_CustId",
                        column: x => x.CustId,
                        principalTable: "Custs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movements_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_CustId",
                table: "Movements",
                column: "CustId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_RoomsId",
                table: "Movements",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustId",
                table: "Rooms",
                column: "CustId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Custs");
        }
    }
}
