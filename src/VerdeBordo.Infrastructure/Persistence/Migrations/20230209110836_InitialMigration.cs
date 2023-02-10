using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerdeBordo.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Suppliers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Suppliers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Price = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Suppliers_SupplierId",
                    column: x => x.SupplierId,
                    principalTable: "Suppliers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Purchases",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                AmountPurchased = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                Shipment = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: true),
                PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Purchases", x => x.Id);
                table.ForeignKey(
                    name: "FK_Purchases_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Products_SupplierId",
            table: "Products",
            column: "SupplierId");

        migrationBuilder.CreateIndex(
            name: "IX_Purchases_ProductId",
            table: "Purchases",
            column: "ProductId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Purchases");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Suppliers");
    }
}
