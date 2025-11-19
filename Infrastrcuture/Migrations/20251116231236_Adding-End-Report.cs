using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class AddingEndReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndReport",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("80808080-8080-8080-8080-808080808080"),
                column: "EndReport",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("90909090-9090-9090-9090-909090909090"),
                column: "EndReport",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndReport",
                table: "Cases");
        }
    }
}
