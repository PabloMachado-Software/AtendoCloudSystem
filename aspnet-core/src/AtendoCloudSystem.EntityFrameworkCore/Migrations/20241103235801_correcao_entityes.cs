using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtendoCloudSystem.Migrations
{
    /// <inheritdoc />
    public partial class correcao_entityes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Menu",
                table: "AppOrderItens",
                newName: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderItens_MenuId",
                table: "AppOrderItens",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderItens_AppMenus_MenuId",
                table: "AppOrderItens",
                column: "MenuId",
                principalTable: "AppMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderItens_AppMenus_MenuId",
                table: "AppOrderItens");

            migrationBuilder.DropIndex(
                name: "IX_AppOrderItens_MenuId",
                table: "AppOrderItens");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "AppOrderItens",
                newName: "Menu");
        }
    }
}
