using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyOrder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sites_SiteId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38969be1-381f-4a1d-92c8-e0914691ee8b", "2864e285-3a9b-46e4-9e8e-bd98f0d40667", "SupperAdmin", "SUPPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SiteId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2864e285-3a9b-46e4-9e8e-bd98f0d40667", 0, "57902ec8-38bf-4f27-bbb7-8c23511e53e7", "ApplicationUser", "ahmedmatem@gmail.com", true, "Ахмед Матем Ахмед", false, null, "AHMEDMATEM@GMAIL.COM", "AHMEDMATEM", null, null, false, "d06fec36-6ba1-4a0d-8a85-e1e4625006f2", null, false, "ahmedmatem" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "38969be1-381f-4a1d-92c8-e0914691ee8b", "2864e285-3a9b-46e4-9e8e-bd98f0d40667" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sites_SiteId",
                table: "AspNetUsers",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sites_SiteId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38969be1-381f-4a1d-92c8-e0914691ee8b", "2864e285-3a9b-46e4-9e8e-bd98f0d40667" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38969be1-381f-4a1d-92c8-e0914691ee8b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2864e285-3a9b-46e4-9e8e-bd98f0d40667");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sites_SiteId",
                table: "AspNetUsers",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
