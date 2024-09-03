using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtendoCloudSystem.Migrations
{
    /// <inheritdoc />
    public partial class tablemenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numero",
                table: "AppTables",
                newName: "Numero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "AppTables",
                newName: "numero");
        }
    }
}
