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
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc11b696-d492-40c5-bd3c-262e0699ee47", null, "SupperAdmin", "SUPPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SiteId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0035682c-6f3f-421c-8d5c-7c2f784bab5f", 0, "ed1a9fdc-f4f8-4595-af0b-e07ee0989b8b", "ApplicationUser", "ahmed@gmal.com", true, "Ахмед Матем Ахмед", false, null, "AHMED@GMAL.COM", "AHMED", null, null, false, "7097fb1f-a6d2-49d0-8cb1-537855ac7c83", "", false, "ahmed" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bc11b696-d492-40c5-bd3c-262e0699ee47", "0035682c-6f3f-421c-8d5c-7c2f784bab5f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc11b696-d492-40c5-bd3c-262e0699ee47", "0035682c-6f3f-421c-8d5c-7c2f784bab5f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc11b696-d492-40c5-bd3c-262e0699ee47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0035682c-6f3f-421c-8d5c-7c2f784bab5f");
        }
    }
}
