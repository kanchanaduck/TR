using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class StakeholderCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder");

            migrationBuilder.DropColumn(
                name: "level",
                table: "tr_stakeholder");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "org_code",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder",
                columns: new[] { "emp_no", "org_code", "role" });

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band",
                column: "course_no",
                principalTable: "tr_course_master",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder",
                column: "org_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "tr_stakeholder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "org_code",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "tr_stakeholder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_stakeholder",
                table: "tr_stakeholder",
                column: "emp_no");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band",
                column: "course_no",
                principalTable: "tr_course_master",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder",
                column: "org_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
