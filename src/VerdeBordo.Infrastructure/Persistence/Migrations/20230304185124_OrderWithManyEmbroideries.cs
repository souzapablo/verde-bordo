using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerdeBordo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderWithManyEmbroideries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Embroideries_OrderId",
                table: "Embroideries");

            migrationBuilder.DropColumn(
                name: "EmbroideryId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Embroideries_OrderId",
                table: "Embroideries",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Embroideries_OrderId",
                table: "Embroideries");

            migrationBuilder.AddColumn<Guid>(
                name: "EmbroideryId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Embroideries_OrderId",
                table: "Embroideries",
                column: "OrderId",
                unique: true);
        }
    }
}
