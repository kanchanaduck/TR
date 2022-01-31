using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class RelationOfEmployeeStakeholder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_center",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_employee_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.DropIndex(
                name: "IX_tr_stakeholder_emp_no",
                table: "tr_stakeholder");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_stakeholder",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_center",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }
    }
}
