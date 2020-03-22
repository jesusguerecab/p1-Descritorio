using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(nullable: true),
                    PizzaDetails = table.Column<string>(nullable: true),
                    PizzaPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true),
                    StoreAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDateTime = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    OrderPizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    PizzaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => x.OrderPizzaId);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "PizzaDetails", "PizzaName", "PizzaPrice" },
                values: new object[,]
                {
                    { 1L, "Uncooked Pizza Dough", "The Worst Pizza", 1.00m },
                    { 10L, "Eugh", "The Puffer", 9.00m },
                    { 8L, "Traditional Crust, Large Size, Mozarella Cheese, Pesto Dollops, White Sauce, Chicken, Green Bell Peppers, Red Onions", "The Hallowus", 8.00m },
                    { 7L, "Thin Crust, Small Size, Tomato Sauce, Mozarella Cheese, Ground Beef, Allspice", "The Sweat", 7.00m },
                    { 6L, "Paper, Pencil", "The Me Hoy Minoy", 6.00m },
                    { 9L, "Thick Crust, Tomato Sauce, Bacon, Eggs, Cheese, Corn", "The Pupit", 9.00m },
                    { 4L, "Thick Crust, Large Size, Tomato Sauce, Tomato Sauce, Tomato Sauce, Tomato Sauce", "The Fred", 4.00m },
                    { 3L, "Thin Crust, Medium Size, ", "The Dominic", 3.00m },
                    { 2L, "Cooked Pizza Dough", "The Best Pizza", 2.00m },
                    { 5L, "Traditional Crust, Tomato Sauce, Mozarella Cheese", "The Frank", 5.00m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "StoreAddress", "StoreName" },
                values: new object[,]
                {
                    { 1L, "16573 Wallaby Ln", "Fred's Pizzeria" },
                    { 2L, "6678 This Street St", "Not Your Mom's Pizza" },
                    { 3L, "29394 Calhoun Dr", "My Mom's Pizza" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "LastName", "UserAddress" },
                values: new object[,]
                {
                    { 4L, "Ted4", "Willis4", "Place4" },
                    { 1L, "Ted1", "Willis1", "Place1" },
                    { 2L, "Ted2", "Willis2", "Place2" },
                    { 3L, "Ted3", "Willis3", "Place3" },
                    { 5L, "Ted5", "Willis5", "Place5" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "OrderDateTime", "StoreId", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L },
                    { 2L, new DateTime(2020, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), 2L, 1L },
                    { 3L, new DateTime(2020, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified), 3L, 2L },
                    { 4L, new DateTime(2020, 2, 11, 2, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2L },
                    { 5L, new DateTime(2020, 2, 12, 2, 0, 0, 0, DateTimeKind.Unspecified), 2L, 3L },
                    { 6L, new DateTime(2020, 2, 13, 3, 0, 0, 0, DateTimeKind.Unspecified), 3L, 3L },
                    { 7L, new DateTime(2020, 3, 21, 3, 0, 0, 0, DateTimeKind.Unspecified), 1L, 4L },
                    { 8L, new DateTime(2020, 3, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 2L, 4L },
                    { 9L, new DateTime(2020, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 3L, 5L }
                });

            migrationBuilder.InsertData(
                table: "OrderPizza",
                columns: new[] { "OrderPizzaId", "OrderId", "PizzaId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 2L },
                    { 3L, 3L, 3L },
                    { 4L, 4L, 4L },
                    { 5L, 5L, 5L },
                    { 6L, 6L, 6L },
                    { 7L, 7L, 7L },
                    { 8L, 8L, 8L },
                    { 9L, 9L, 9L },
                    { 10L, 9L, 10L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrderId",
                table: "OrderPizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzaId",
                table: "OrderPizza",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
