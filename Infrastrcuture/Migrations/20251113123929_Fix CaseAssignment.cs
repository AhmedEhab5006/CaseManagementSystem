using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class FixCaseAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesAssignments_Lawyers_assignedUserId",
                table: "CasesAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesAssignments_AspNetUsers_assignedUserId",
                table: "CasesAssignments",
                column: "assignedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesAssignments_AspNetUsers_assignedUserId",
                table: "CasesAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesAssignments_Lawyers_assignedUserId",
                table: "CasesAssignments",
                column: "assignedUserId",
                principalTable: "Lawyers",
                principalColumn: "Id");
        }
    }
}
