using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class behaviorRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_employees_manager_id",
                table: "tb_m_employees");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_employees_manager_id",
                table: "tb_m_employees",
                column: "manager_id",
                principalTable: "tb_m_employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_employees_tb_m_employees_manager_id",
                table: "tb_m_employees");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_employees_tb_m_employees_manager_id",
                table: "tb_m_employees",
                column: "manager_id",
                principalTable: "tb_m_employees",
                principalColumn: "id");
        }
    }
}
