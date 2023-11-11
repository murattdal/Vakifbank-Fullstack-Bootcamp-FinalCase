using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNumber = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPasswordRetryCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserRole = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserBalance = table.Column<double>(type: "float", nullable: false),
                    UserProfitMargin = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderAmount = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBasket",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    BasketQuantity = table.Column<int>(type: "int", nullable: false),
                    BasketPrice = table.Column<double>(type: "float", nullable: false),
                    BasketStatus = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBasket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingBasket_CustomerOrder_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "CustomerOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingBasket_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingBasket_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_UserId",
                schema: "dbo",
                table: "CustomerAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_UserId",
                schema: "dbo",
                table: "CustomerOrder",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasket_OrderId",
                schema: "dbo",
                table: "ShoppingBasket",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasket_ProductId",
                schema: "dbo",
                table: "ShoppingBasket",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBasket_UserId",
                schema: "dbo",
                table: "ShoppingBasket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserEmail",
                schema: "dbo",
                table: "User",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserNumber",
                schema: "dbo",
                table: "User",
                column: "UserNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShoppingBasket",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomerOrder",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
