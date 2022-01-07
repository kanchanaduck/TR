using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class AlterSurveyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_survey_detail",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "year",
                table: "tr_survey_file");

            migrationBuilder.DropColumn(
                name: "year",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "resign",
                table: "tr_stakeholder");

            migrationBuilder.DropColumn(
                name: "status_active",
                table: "tr_stakeholder");

            migrationBuilder.AlterTable(
                name: "tr_survey_setting",
                comment: "ตารางเก็บ period การ survey เฉพาะคอร์สของ MTP",
                oldComment: "ตารางเก็บ period การ survey");

            migrationBuilder.AddColumn<int>(
                name: "file_id",
                table: "tr_survey_file",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "tr_survey_file",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Level");

            migrationBuilder.AddColumn<string>(
                name: "year1",
                table: "tr_survey_file",
                type: "nvarchar(4)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "month",
                table: "tr_survey_detail",
                type: "int",
                nullable: false,
                comment: "เก็บเดือนที่ต้องการเรียน",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "year1",
                table: "tr_survey_detail",
                type: "nvarchar(4)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_survey_file",
                table: "tr_survey_file",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_tr_survey_file_year1",
                table: "tr_survey_file",
                column: "year1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_survey_detail_year1",
                table: "tr_survey_detail",
                column: "year1");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_survey_detail_tr_survey_setting_year1",
                table: "tr_survey_detail",
                column: "year1",
                principalTable: "tr_survey_setting",
                principalColumn: "year",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_survey_file_tr_survey_setting_year1",
                table: "tr_survey_file",
                column: "year1",
                principalTable: "tr_survey_setting",
                principalColumn: "year",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_survey_detail_tr_survey_setting_year1",
                table: "tr_survey_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_survey_file_tr_survey_setting_year1",
                table: "tr_survey_file");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_survey_file",
                table: "tr_survey_file");

            migrationBuilder.DropIndex(
                name: "IX_tr_survey_file_year1",
                table: "tr_survey_file");

            migrationBuilder.DropIndex(
                name: "IX_tr_survey_detail_year1",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "file_id",
                table: "tr_survey_file");

            migrationBuilder.DropColumn(
                name: "level",
                table: "tr_survey_file");

            migrationBuilder.DropColumn(
                name: "year1",
                table: "tr_survey_file");

            migrationBuilder.DropColumn(
                name: "year1",
                table: "tr_survey_detail");

            migrationBuilder.AlterTable(
                name: "tr_survey_setting",
                comment: "ตารางเก็บ period การ survey",
                oldComment: "ตารางเก็บ period การ survey เฉพาะคอร์สของ MTP");

            migrationBuilder.AddColumn<string>(
                name: "year",
                table: "tr_survey_file",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "month",
                table: "tr_survey_detail",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "เก็บเดือนที่ต้องการเรียน");

            migrationBuilder.AddColumn<string>(
                name: "year",
                table: "tr_survey_detail",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "resign",
                table: "tr_stakeholder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "status_active",
                table: "tr_stakeholder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_survey_detail",
                table: "tr_survey_detail",
                column: "year");
        }
    }
}
