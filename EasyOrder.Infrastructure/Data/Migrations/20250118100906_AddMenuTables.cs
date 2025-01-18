using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyOrder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Unique data model identifier"),
                    SiteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Category name of the menu."),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Menu category description."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate a record in table as deleted or not."),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of soft deleting the record in database."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Set the date of creating the record in the database."),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of last modifing the record in the database.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCategories_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Unique data model identifier"),
                    MenuCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The title of the menu item."),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The description of menu item and/or its ingredients."),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price of the item."),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "Boolean flag indicating if the item is currently available."),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity or portion size (e.g., grams, millilitres, pieces)."),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "List of tags describing the item characteristics (e.g., spacy, sweet, vegan)"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Optional image Url for the menu item."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate a record in table as deleted or not."),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of soft deleting the record in database."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Set the date of creating the record in the database."),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of last modifing the record in the database.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuCategories_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_SiteId",
                table: "MenuCategories",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuCategoryId",
                table: "MenuItems",
                column: "MenuCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuCategories");
        }
    }
}
