using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class AlterEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "tb_role_menu_claims",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "tb_role_menu_claims",
                newName: "updated_by");

            migrationBuilder.AddColumn<string>(
                name: "old_emp_no",
                table: "tb_employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "old_emp_no",
                table: "tb_employee");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "tb_role_menu_claims",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "tb_role_menu_claims",
                newName: "update_by");
        }
    }
}
