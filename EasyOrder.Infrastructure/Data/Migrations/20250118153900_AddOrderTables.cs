using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyOrder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Unique data model identifier"),
                    TableId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false, comment: "Status of the order {e.g., Pending, Completed, Cancelled, …}"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate a record in table as deleted or not."),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of soft deleting the record in database."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Set the date of creating the record in the database."),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of last modifing the record in the database.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Unique data model identifier"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of the item ordered."),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Yhe name of the item in the order."),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of a single unit of the item."),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Additional notes or comments about the item."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate a record in table as deleted or not."),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of soft deleting the record in database."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Set the date of creating the record in the database."),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of last modifing the record in the database.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersItems_OrderId",
                table: "OrdersItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
