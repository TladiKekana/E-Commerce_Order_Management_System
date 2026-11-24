using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItems_Product_Id",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Product_Id",
                table: "OrderItems",
                column: "Product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItems_Product_Id",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Product_Id",
                table: "OrderItems",
                column: "Product_Id",
                unique: true);
        }
    }
}
