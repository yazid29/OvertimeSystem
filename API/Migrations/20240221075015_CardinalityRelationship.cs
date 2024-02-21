using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class CardinalityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "tb_m_overtimes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_overtime_requests_account_id",
                table: "tb_tr_overtime_requests",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_overtime_requests_overtime_id",
                table: "tb_tr_overtime_requests",
                column: "overtime_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_account_id",
                table: "tb_tr_account_roles",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_overtimes_AccountId",
                table: "tb_m_overtimes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_manager_id",
                table: "tb_m_employees",
                column: "manager_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_id",
                table: "tb_m_accounts",
                column: "id",
                principalTable: "tb_m_employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_employees_manager_id",
                table: "tb_m_employees",
                column: "manager_id",
                principalTable: "tb_m_employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_overtimes_tb_m_accounts_AccountId",
                table: "tb_m_overtimes",
                column: "AccountId",
                principalTable: "tb_m_accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_account_id",
                table: "tb_tr_account_roles",
                column: "account_id",
                principalTable: "tb_m_accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id",
                principalTable: "tb_m_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_id",
                table: "tb_m_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_employees_manager_id",
                table: "tb_m_employees");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_overtimes_tb_m_accounts_AccountId",
                table: "tb_m_overtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_account_id",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_accounts_account_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_overtime_requests_tb_m_overtimes_overtime_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_overtime_requests_account_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_overtime_requests_overtime_id",
                table: "tb_tr_overtime_requests");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_account_roles_account_id",
                table: "tb_tr_account_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_overtimes_AccountId",
                table: "tb_m_overtimes");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_manager_id",
                table: "tb_m_employees");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "tb_m_overtimes");
        }
    }
}
