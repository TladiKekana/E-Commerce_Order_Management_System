using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_Product_Id",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Transactions_Inventories_Inventory_Id",
                table: "Inventory_Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_Product_Id",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ref_Number",
                table: "Inventory_Transactions");

            migrationBuilder.DropColumn(
                name: "Transaction_Type",
                table: "Inventory_Transactions");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Inventory_Transactions",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_Id",
                table: "Inventory_Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "InventotyItemId",
                table: "Inventory_Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Inventory_Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantityChanged",
                table: "Inventory_Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "Inventory_Id");

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    InventoryItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    QuantityOnHand = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.InventoryItemId);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_InventotyItemId",
                table: "Inventory_Transactions",
                column: "InventotyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_Product_Id",
                table: "Inventory_Transactions",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ProductId",
                table: "InventoryItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Transactions_InventoryItems_InventotyItemId",
                table: "Inventory_Transactions",
                column: "InventotyItemId",
                principalTable: "InventoryItems",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Transactions_Inventory_Inventory_Id",
                table: "Inventory_Transactions",
                column: "Inventory_Id",
                principalTable: "Inventory",
                principalColumn: "Inventory_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Transactions_Products_Product_Id",
                table: "Inventory_Transactions",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Transactions_InventoryItems_InventotyItemId",
                table: "Inventory_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Transactions_Inventory_Inventory_Id",
                table: "Inventory_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Transactions_Products_Product_Id",
                table: "Inventory_Transactions");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Transactions_InventotyItemId",
                table: "Inventory_Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Transactions_Product_Id",
                table: "Inventory_Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "InventotyItemId",
                table: "Inventory_Transactions");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Inventory_Transactions");

            migrationBuilder.DropColumn(
                name: "QuantityChanged",
                table: "Inventory_Transactions");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "Inventories");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Inventory_Transactions",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Inventory_Id",
                table: "Inventory_Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ref_Number",
                table: "Inventory_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transaction_Type",
                table: "Inventory_Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "Inventory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Product_Id",
                table: "Inventories",
                column: "Product_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_Product_Id",
                table: "Inventories",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Transactions_Inventories_Inventory_Id",
                table: "Inventory_Transactions",
                column: "Inventory_Id",
                principalTable: "Inventories",
                principalColumn: "Inventory_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
