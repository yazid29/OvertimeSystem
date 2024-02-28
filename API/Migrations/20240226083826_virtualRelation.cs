using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class virtualRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_accounts_account_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_overtimes_overtime_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "overtime_id",
                table: "tb_tr_overtime_requests",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "account_id",
                table: "tb_tr_overtime_requests",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_accounts_account_id",
                table: "tb_tr_overtime_requests",
                column: "account_id",
                principalTable: "tb_m_accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_overtimes_overtime_id",
                table: "tb_tr_overtime_requests",
                column: "overtime_id",
                principalTable: "tb_m_overtimes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_accounts_account_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_overtimes_overtime_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.AlterColumn<Guid>(
                name: "overtime_id",
                table: "tb_tr_overtime_requests",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "account_id",
                table: "tb_tr_overtime_requests",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_accounts_account_id",
                table: "tb_tr_overtime_requests",
                column: "account_id",
                principalTable: "tb_m_accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_overtimes_overtime_id",
                table: "tb_tr_overtime_requests",
                column: "overtime_id",
                principalTable: "tb_m_overtimes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
