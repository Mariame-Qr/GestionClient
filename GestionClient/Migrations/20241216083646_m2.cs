using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionClient.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliebts",
                table: "Cliebts");

            migrationBuilder.RenameTable(
                name: "Cliebts",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Cliebts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliebts",
                table: "Cliebts",
                column: "Id");
        }
    }
}
