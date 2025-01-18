using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyOrder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSiteRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "User full name.");

            migrationBuilder.AddColumn<string>(
                name: "SiteId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Unique identifier of the site user/staff participate in.");

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Unique data model identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the site."),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Type of the site (e.g., Restaurant, Pizzeria, Cafe, Buffet, Pub, Bar and Gril)"),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "The name of the city site belongs to."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate a record in table as deleted or not."),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of soft deleting the record in database."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Set the date of creating the record in the database."),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of last modifing the record in the database.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                },
                comment: "Represents the model of food and beverage establishments.");

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Unique data model identifier"),
                    SiteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "The name of the table (could be just a number)"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Unique long length token for the table."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate a record in table as deleted or not."),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of soft deleting the record in database."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Set the date of creating the record in the database."),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Set the date of last modifing the record in the database.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SiteId",
                table: "AspNetUsers",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_SiteId",
                table: "Table",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sites_SiteId",
                table: "AspNetUsers",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sites_SiteId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SiteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "AspNetUsers");
        }
    }
}
