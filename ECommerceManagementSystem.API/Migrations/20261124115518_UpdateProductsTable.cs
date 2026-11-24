using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartItems_Product_Id",
                table: "CartItems");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_Product_Id",
                table: "CartItems",
                column: "Product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartItems_Product_Id",
                table: "CartItems");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_Product_Id",
                table: "CartItems",
                column: "Product_Id",
                unique: true);
        }
    }
}
