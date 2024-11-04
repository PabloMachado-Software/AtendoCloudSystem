using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtendoCloudSystem.Migrations
{
    /// <inheritdoc />
    public partial class Todas_entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AppTables_TableId",
                table: "AppOrders");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "AppOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    TipoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxaServico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPayments_AppOrders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOrderItens_OrderId",
                table: "AppOrderItens",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPayments_OrderID",
                table: "AppPayments",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderItens_AppOrders_OrderId",
                table: "AppOrderItens",
                column: "OrderId",
                principalTable: "AppOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AppTables_TableId",
                table: "AppOrders",
                column: "TableId",
                principalTable: "AppTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderItens_AppOrders_OrderId",
                table: "AppOrderItens");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AppTables_TableId",
                table: "AppOrders");

            migrationBuilder.DropTable(
                name: "AppPayments");

            migrationBuilder.DropIndex(
                name: "IX_AppOrderItens_OrderId",
                table: "AppOrderItens");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "AppOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AppTables_TableId",
                table: "AppOrders",
                column: "TableId",
                principalTable: "AppTables",
                principalColumn: "Id");
        }
    }
}
