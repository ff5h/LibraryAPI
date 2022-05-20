using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class fix_orders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketId1",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId1",
                table: "Orders",
                column: "BasketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketId1",
                table: "Orders",
                column: "BasketId1",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}
