using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_CourtsGrades_courtGradeId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_courtGradeId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "courtGradeId",
                table: "Cases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "courtGradeId",
                table: "Cases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("80808080-8080-8080-8080-808080808080"),
                column: "courtGradeId",
                value: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.UpdateData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("90909090-9090-9090-9090-909090909090"),
                column: "courtGradeId",
                value: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.CreateIndex(
                name: "IX_Cases_courtGradeId",
                table: "Cases",
                column: "courtGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_CourtsGrades_courtGradeId",
                table: "Cases",
                column: "courtGradeId",
                principalTable: "CourtsGrades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
