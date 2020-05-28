using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projections_films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projections_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seats_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectionId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    ReservedSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_projections_ProjectionId",
                        column: x => x.ProjectionId,
                        principalTable: "projections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "viewers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_viewers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_viewers_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "films",
                columns: new[] { "Id", "Description", "Director", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "asd", "asd", 5, "aaa" },
                    { 2, "asd", "asd", 3, "bb" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Capacity" },
                values: new object[,]
                {
                    { 1, 30 },
                    { 2, 30 }
                });

            migrationBuilder.InsertData(
                table: "projections",
                columns: new[] { "Id", "FilmId", "RoomId", "Start" },
                values: new object[,]
                {
                    { 2, 1, 1, new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, 2, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "seats",
                columns: new[] { "Id", "Column", "RoomId", "Row" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "Price", "ProjectionId", "ReservedSeats" },
                values: new object[] { 1, 1000, 1, 1 });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "Price", "ProjectionId", "ReservedSeats" },
                values: new object[] { 2, 2000, 1, 2 });

            migrationBuilder.InsertData(
                table: "viewers",
                columns: new[] { "Id", "Name", "OrderId", "PassWord" },
                values: new object[] { 1, "ASD", 1, "asd" });

            migrationBuilder.InsertData(
                table: "viewers",
                columns: new[] { "Id", "Name", "OrderId", "PassWord" },
                values: new object[] { 2, "ASD2", 2, "asdasd" });

            migrationBuilder.CreateIndex(
                name: "IX_orders_ProjectionId",
                table: "orders",
                column: "ProjectionId");

            migrationBuilder.CreateIndex(
                name: "IX_projections_FilmId",
                table: "projections",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_projections_RoomId",
                table: "projections",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_seats_RoomId",
                table: "seats",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_viewers_OrderId",
                table: "viewers",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropTable(
                name: "viewers");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "projections");

            migrationBuilder.DropTable(
                name: "films");

            migrationBuilder.DropTable(
                name: "rooms");
        }
    }
}
