using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class Fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseLitigant_CaseLitigantRole_roleId",
                table: "CaseLitigant");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseLitigant_Cases_caseId",
                table: "CaseLitigant");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseLitigant_Litigants_litigantId",
                table: "CaseLitigant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseLitigantRole",
                table: "CaseLitigantRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseLitigant",
                table: "CaseLitigant");

            migrationBuilder.RenameTable(
                name: "CaseLitigantRole",
                newName: "CasesLitigantRoles");

            migrationBuilder.RenameTable(
                name: "CaseLitigant",
                newName: "CasesLitigants");

            migrationBuilder.RenameIndex(
                name: "IX_CaseLitigant_roleId",
                table: "CasesLitigants",
                newName: "IX_CasesLitigants_roleId");

            migrationBuilder.RenameIndex(
                name: "IX_CaseLitigant_litigantId",
                table: "CasesLitigants",
                newName: "IX_CasesLitigants_litigantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CasesLitigantRoles",
                table: "CasesLitigantRoles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CasesLitigants",
                table: "CasesLitigants",
                columns: new[] { "caseId", "litigantId", "roleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CasesLitigants_CasesLitigantRoles_roleId",
                table: "CasesLitigants",
                column: "roleId",
                principalTable: "CasesLitigantRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasesLitigants_Cases_caseId",
                table: "CasesLitigants",
                column: "caseId",
                principalTable: "Cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasesLitigants_Litigants_litigantId",
                table: "CasesLitigants",
                column: "litigantId",
                principalTable: "Litigants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesLitigants_CasesLitigantRoles_roleId",
                table: "CasesLitigants");

            migrationBuilder.DropForeignKey(
                name: "FK_CasesLitigants_Cases_caseId",
                table: "CasesLitigants");

            migrationBuilder.DropForeignKey(
                name: "FK_CasesLitigants_Litigants_litigantId",
                table: "CasesLitigants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CasesLitigants",
                table: "CasesLitigants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CasesLitigantRoles",
                table: "CasesLitigantRoles");

            migrationBuilder.RenameTable(
                name: "CasesLitigants",
                newName: "CaseLitigant");

            migrationBuilder.RenameTable(
                name: "CasesLitigantRoles",
                newName: "CaseLitigantRole");

            migrationBuilder.RenameIndex(
                name: "IX_CasesLitigants_roleId",
                table: "CaseLitigant",
                newName: "IX_CaseLitigant_roleId");

            migrationBuilder.RenameIndex(
                name: "IX_CasesLitigants_litigantId",
                table: "CaseLitigant",
                newName: "IX_CaseLitigant_litigantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseLitigant",
                table: "CaseLitigant",
                columns: new[] { "caseId", "litigantId", "roleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseLitigantRole",
                table: "CaseLitigantRole",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseLitigant_CaseLitigantRole_roleId",
                table: "CaseLitigant",
                column: "roleId",
                principalTable: "CaseLitigantRole",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseLitigant_Cases_caseId",
                table: "CaseLitigant",
                column: "caseId",
                principalTable: "Cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaseLitigant_Litigants_litigantId",
                table: "CaseLitigant",
                column: "litigantId",
                principalTable: "Litigants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
