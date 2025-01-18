using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyOrder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_Sites_SiteId",
                table: "Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table",
                table: "Table");

            migrationBuilder.RenameTable(
                name: "Table",
                newName: "Tables");

            migrationBuilder.RenameIndex(
                name: "IX_Table_SiteId",
                table: "Tables",
                newName: "IX_Tables_SiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Sites_SiteId",
                table: "Tables",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Sites_SiteId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Table");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_SiteId",
                table: "Table",
                newName: "IX_Table_SiteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table",
                table: "Table",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_Sites_SiteId",
                table: "Table",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
