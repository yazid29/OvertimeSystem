using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    nik = table.Column<string>(type: "nchar(6)", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    salary = table.Column<int>(type: "int", nullable: false),
                    joined_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    manager_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_employees_tb_m_employees_manager_id",
                        column: x => x.manager_id,
                        principalTable: "tb_m_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    password = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    expired = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    is_used = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_employees_id",
                        column: x => x.id,
                        principalTable: "tb_m_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_m_overtimes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    total_hours = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    document = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_overtimes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_overtimes_tb_m_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tb_m_accounts",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tr_account_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    account_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    role_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "tb_m_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_account_roles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_tr_overtime_requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    account_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    overtime_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_overtime_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_overtime_requests_tb_m_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "tb_m_accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_tr_overtime_requests_tb_m_overtimes_overtime_id",
                        column: x => x.overtime_id,
                        principalTable: "tb_m_overtimes",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_manager_id",
                table: "tb_m_employees",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_overtimes_AccountId",
                table: "tb_m_overtimes",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_account_id",
                table: "tb_tr_account_roles",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_id",
                table: "tb_tr_account_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_overtime_requests_account_id",
                table: "tb_tr_overtime_requests",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_overtime_requests_overtime_id",
                table: "tb_tr_overtime_requests",
                column: "overtime_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_account_roles");

            migrationBuilder.DropTable(
                name: "tb_tr_overtime_requests");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_overtimes");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_employees");
        }
    }
}
