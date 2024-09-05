using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtendoCloudSystem.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numero",
                table: "AppTables",
                newName: "Numero");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "AppTables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "AppTables");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "AppTables",
                newName: "numero");

          
        }
    }
}
