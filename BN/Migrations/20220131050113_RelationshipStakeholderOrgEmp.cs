using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class RelationshipStakeholderOrgEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_organization_tb_organizationorg_code",
                table: "tr_stakeholder");

            migrationBuilder.DropColumn(
                name: "organization",
                table: "tr_stakeholder");

            migrationBuilder.RenameColumn(
                name: "tb_organizationorg_code",
                table: "tr_stakeholder",
                newName: "org_code");

            migrationBuilder.RenameIndex(
                name: "IX_tr_stakeholder_tb_organizationorg_code",
                table: "tr_stakeholder",
                newName: "IX_tr_stakeholder_org_code");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tr_stakeholder_emp_no",
                table: "tr_stakeholder",
                column: "emp_no");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_employee_emp_no",
                table: "tr_stakeholder",
                column: "emp_no",
                principalTable: "tb_employee",
                principalColumn: "emp_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder",
                column: "org_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_employee_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder");

            migrationBuilder.DropIndex(
                name: "IX_tr_stakeholder_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.RenameColumn(
                name: "org_code",
                table: "tr_stakeholder",
                newName: "tb_organizationorg_code");

            migrationBuilder.RenameIndex(
                name: "IX_tr_stakeholder_org_code",
                table: "tr_stakeholder",
                newName: "IX_tr_stakeholder_tb_organizationorg_code");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_stakeholder",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "organization",
                table: "tr_stakeholder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_organization_tb_organizationorg_code",
                table: "tr_stakeholder",
                column: "tb_organizationorg_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
