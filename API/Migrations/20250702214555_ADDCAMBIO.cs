using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ADDCAMBIO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_TipoProductoId",
                table: "Products",
                column: "TipoProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TipoProducto_TipoProductoId",
                table: "Products",
                column: "TipoProductoId",
                principalTable: "TipoProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TipoProducto_TipoProductoId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TipoProductoId",
                table: "Products");
        }
    }
}
