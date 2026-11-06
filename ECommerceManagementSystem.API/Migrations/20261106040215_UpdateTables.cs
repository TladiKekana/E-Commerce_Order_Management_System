using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_Customer_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_Product_Id",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductSuppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_Product_Id",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "Contact_Name",
                table: "Suppliers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Products",
                newName: "Supplier_Id");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Orders",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Customer_Id",
                table: "Orders",
                newName: "IX_Orders_User_Id");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Person",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_At",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Address_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Order_Number",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Inventory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Qty_Available = table.Column<int>(type: "int", nullable: false),
                    Qty_Reserved = table.Column<int>(type: "int", nullable: false),
                    Reoder_Level = table.Column<int>(type: "int", nullable: false),
                    Last_Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Inventory_Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Transation_Id = table.Column<int>(type: "int", nullable: false),
                    Payment_Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alt_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Primary = table.Column<bool>(type: "bit", nullable: false),
                    Display_Order = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Image_Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Shipment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shiping_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimated_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actual_Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shipping_Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Shipment_Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password_Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Address_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Address_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posta_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_default = table.Column<bool>(type: "bit", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Address_Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Transactions",
                columns: table => new
                {
                    Transaction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventory_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Transaction_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Ref_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transaction_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Transactions", x => x.Transaction_Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Transactions_Inventories_Inventory_Id",
                        column: x => x.Inventory_Id,
                        principalTable: "Inventories",
                        principalColumn: "Inventory_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Transactions_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Supplier_Id",
                table: "Products",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Address_Id",
                table: "Orders",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_User_Id",
                table: "Addresses",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Product_Id",
                table: "Inventories",
                column: "Product_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_Inventory_Id",
                table: "Inventory_Transactions",
                column: "Inventory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Transactions_User_Id",
                table: "Inventory_Transactions",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Order_Id",
                table: "Payments",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_Product_Id",
                table: "ProductImages",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_Order_Id",
                table: "Shipments",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_Id",
                table: "Users",
                column: "Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_Address_Id",
                table: "Orders",
                column: "Address_Id",
                principalTable: "Addresses",
                principalColumn: "Address_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_User_Id",
                table: "Orders",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_Supplier_Id",
                table: "Products",
                column: "Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Supplier_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_Address_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_User_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_Supplier_Id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Inventory_Transactions");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Products_Supplier_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Address_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Contact_Person",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Address_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_Number",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Suppliers",
                newName: "Contact_Name");

            migrationBuilder.RenameColumn(
                name: "Supplier_Id",
                table: "Products",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Orders",
                newName: "Customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_User_Id",
                table: "Orders",
                newName: "IX_Orders_Customer_Id");

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    First_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Registration_Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSuppliers",
                columns: table => new
                {
                    ProcuctSupplier_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Supplier_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSuppliers", x => x.ProcuctSupplier_Id);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Suppliers_Supplier_Id",
                        column: x => x.Supplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Product_Id",
                table: "Suppliers",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_Product_Id",
                table: "ProductSuppliers",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_Supplier_Id",
                table: "ProductSuppliers",
                column: "Supplier_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_Customer_Id",
                table: "Orders",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_Product_Id",
                table: "Suppliers",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Product_Id");
        }
    }
}
