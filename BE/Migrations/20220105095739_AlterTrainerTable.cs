using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class AlterTrainerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "types",
                table: "tr_trainer",
                newName: "sname_th");

            migrationBuilder.RenameColumn(
                name: "sname_eng",
                table: "tr_trainer",
                newName: "remark");

            migrationBuilder.RenameColumn(
                name: "gname_eng",
                table: "tr_trainer",
                newName: "organization");

            migrationBuilder.RenameColumn(
                name: "fname_eng",
                table: "tr_trainer",
                newName: "gname_th");

            migrationBuilder.RenameColumn(
                name: "dept_abb_name",
                table: "tr_trainer",
                newName: "fname_th");

            migrationBuilder.AlterTable(
                name: "tr_trainer",
                comment: "ตารางเก็บข้อมูลเทรนเนอร์");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_trainer",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fname_en",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gname_en",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sname_en",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fname_en",
                table: "tr_trainer");

            migrationBuilder.DropColumn(
                name: "gname_en",
                table: "tr_trainer");

            migrationBuilder.DropColumn(
                name: "sname_en",
                table: "tr_trainer");

            migrationBuilder.DropColumn(
                name: "type",
                table: "tr_trainer");

            migrationBuilder.RenameColumn(
                name: "sname_th",
                table: "tr_trainer",
                newName: "types");

            migrationBuilder.RenameColumn(
                name: "remark",
                table: "tr_trainer",
                newName: "sname_eng");

            migrationBuilder.RenameColumn(
                name: "organization",
                table: "tr_trainer",
                newName: "gname_eng");

            migrationBuilder.RenameColumn(
                name: "gname_th",
                table: "tr_trainer",
                newName: "fname_eng");

            migrationBuilder.RenameColumn(
                name: "fname_th",
                table: "tr_trainer",
                newName: "dept_abb_name");

            migrationBuilder.AlterTable(
                name: "tr_trainer",
                oldComment: "ตารางเก็บข้อมูลเทรนเนอร์");

            migrationBuilder.AlterColumn<string>(
                name: "emp_no",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);
        }
    }
}
