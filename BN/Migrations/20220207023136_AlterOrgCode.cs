using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class AlterOrgCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_employee_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder");

            migrationBuilder.DropIndex(
                name: "IX_tr_stakeholder_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.DropColumn(
                name: "id",
                table: "tr_stakeholder");

            migrationBuilder.DropColumn(
                name: "dept_abb_name",
                table: "tr_course_master");

            migrationBuilder.DropColumn(
                name: "dept_abb_name",
                table: "tr_course");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "org_code",
                table: "tr_course_master",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "org_code",
                table: "tr_course",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder",
                column: "emp_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_org_code",
                table: "tr_course_master",
                column: "org_code");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_org_code",
                table: "tr_course",
                column: "org_code");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_tb_organization_org_code",
                table: "tr_course",
                column: "org_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_master_tb_organization_org_code",
                table: "tr_course_master",
                column: "org_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_employee_emp_no",
                table: "tr_stakeholder",
                column: "emp_no",
                principalTable: "tb_employee",
                principalColumn: "emp_no",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_tb_organization_org_code",
                table: "tr_course");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_tb_organization_org_code",
                table: "tr_course_master");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_employee_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_master_org_code",
                table: "tr_course_master");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_org_code",
                table: "tr_course");

            migrationBuilder.DropColumn(
                name: "org_code",
                table: "tr_course_master");

            migrationBuilder.DropColumn(
                name: "org_code",
                table: "tr_course");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "tr_stakeholder",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "dept_abb_name",
                table: "tr_course_master",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dept_abb_name",
                table: "tr_course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder",
                column: "id");

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
        }
    }
}
