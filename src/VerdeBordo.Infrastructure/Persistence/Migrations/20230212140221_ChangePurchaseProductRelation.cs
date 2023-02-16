using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerdeBordo.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class ChangePurchaseProductRelation : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Purchases_ProductId",
            table: "Purchases");

        migrationBuilder.CreateIndex(
            name: "IX_Purchases_ProductId",
            table: "Purchases",
            column: "ProductId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Purchases_ProductId",
            table: "Purchases");

        migrationBuilder.CreateIndex(
            name: "IX_Purchases_ProductId",
            table: "Purchases",
            column: "ProductId",
            unique: true);
    }
}
