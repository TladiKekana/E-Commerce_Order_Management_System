using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Cart_Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItem_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cart_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItem_Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "Carts",
                        principalColumn: "Cart_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_Cart_Id",
                table: "CartItems",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_Product_Id",
                table: "CartItems",
                column: "Product_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_User_Id",
                table: "Carts",
                column: "User_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
