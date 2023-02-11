using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerdeBordo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPurchased",
                table: "Purchases");

            migrationBuilder.AlterColumn<decimal>(
                name: "Shipment",
                table: "Purchases",
                type: "decimal(14,8)",
                precision: 14,
                scale: 8,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasedAmount",
                table: "Purchases",
                type: "decimal(14,8)",
                precision: 14,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(14,8)",
                precision: 14,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasedAmount",
                table: "Purchases");

            migrationBuilder.AlterColumn<decimal>(
                name: "Shipment",
                table: "Purchases",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,8)",
                oldPrecision: 14,
                oldScale: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPurchased",
                table: "Purchases",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,8)",
                oldPrecision: 14,
                oldScale: 8);
        }
    }
}
