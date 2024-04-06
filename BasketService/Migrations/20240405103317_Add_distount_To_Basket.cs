using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketService.Migrations
{
    /// <inheritdoc />
    public partial class Add_distount_To_Basket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "Baskets",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Baskets");
        }
    }
}
