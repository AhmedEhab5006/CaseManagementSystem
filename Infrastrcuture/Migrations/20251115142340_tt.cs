using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReAssign",
                table: "Cases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("80808080-8080-8080-8080-808080808080"),
                column: "ReAssign",
                value: false);

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("90909090-9090-9090-9090-909090909090"),
                column: "ReAssign",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReAssign",
                table: "Cases");
        }
    }
}
