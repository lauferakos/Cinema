using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class updateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_viewers_orders_OrderId",
                table: "viewers");

            migrationBuilder.DropIndex(
                name: "IX_viewers_OrderId",
                table: "viewers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "viewers");

            migrationBuilder.AddColumn<int>(
                name: "ViewerId",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ViewerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ViewerId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_orders_ViewerId",
                table: "orders",
                column: "ViewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_viewers_ViewerId",
                table: "orders",
                column: "ViewerId",
                principalTable: "viewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_viewers_ViewerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_ViewerId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ViewerId",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "viewers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "viewers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "viewers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_viewers_OrderId",
                table: "viewers",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_viewers_orders_OrderId",
                table: "viewers",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
