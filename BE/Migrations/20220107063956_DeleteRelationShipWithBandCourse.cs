using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class DeleteRelationShipWithBandCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_tr_course_band_bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_tr_course_master_band_bandcourse_no",
                table: "tr_course_master");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_score_tr_course_yearcourse_no",
                table: "tr_course_score");

            migrationBuilder.DropTable(
                name: "tr_course_band");

            migrationBuilder.DropTable(
                name: "tr_course_master_band");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_score_yearcourse_no",
                table: "tr_course_score");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_master_bandcourse_no",
                table: "tr_course_master");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropColumn(
                name: "emp_no",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "yearcourse_no",
                table: "tr_course_score");

            migrationBuilder.DropColumn(
                name: "bandcourse_no",
                table: "tr_course_master");

            migrationBuilder.DropColumn(
                name: "bandcourse_no",
                table: "tr_course");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tr_trainer",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "resign",
                table: "tr_trainer",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "emp_no1",
                table: "tr_survey_detail",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_course_score",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_course_score",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "course_no",
                table: "tr_course_score",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_at",
                table: "tr_course_registration",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "manager_approved_checked",
                table: "tr_course_registration",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "manager_approved_at",
                table: "tr_course_registration",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "center_approved_checked",
                table: "tr_course_registration",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "center_approved_at",
                table: "tr_course_registration",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_course_master",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tr_course_master",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_course_master",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_course",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time_out",
                table: "tr_course",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "time_in",
                table: "tr_course",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tr_course",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "open_register",
                table: "tr_course",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_start",
                table: "tr_course",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_end",
                table: "tr_course",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_course",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_center",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_center",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tb_band",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "tr_course_mastercourse_no",
                table: "tb_band",
                type: "nvarchar(7)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tr_coursecourse_no",
                table: "tb_band",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tr_survey_detail_emp_no1",
                table: "tr_survey_detail",
                column: "emp_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_band_tr_course_mastercourse_no",
                table: "tb_band",
                column: "tr_course_mastercourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tb_band_tr_coursecourse_no",
                table: "tb_band",
                column: "tr_coursecourse_no");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_band_tr_course_master_tr_course_mastercourse_no",
                table: "tb_band",
                column: "tr_course_mastercourse_no",
                principalTable: "tr_course_master",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_band_tr_course_tr_coursecourse_no",
                table: "tb_band",
                column: "tr_coursecourse_no",
                principalTable: "tr_course",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_survey_detail_tb_employee_emp_no1",
                table: "tr_survey_detail",
                column: "emp_no1",
                principalTable: "tb_employee",
                principalColumn: "emp_no",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_band_tr_course_master_tr_course_mastercourse_no",
                table: "tb_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_band_tr_course_tr_coursecourse_no",
                table: "tb_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_survey_detail_tb_employee_emp_no1",
                table: "tr_survey_detail");

            migrationBuilder.DropIndex(
                name: "IX_tr_survey_detail_emp_no1",
                table: "tr_survey_detail");

            migrationBuilder.DropIndex(
                name: "IX_tb_band_tr_course_mastercourse_no",
                table: "tb_band");

            migrationBuilder.DropIndex(
                name: "IX_tb_band_tr_coursecourse_no",
                table: "tb_band");

            migrationBuilder.DropColumn(
                name: "emp_no1",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "course_no",
                table: "tr_course_score");

            migrationBuilder.DropColumn(
                name: "tr_course_mastercourse_no",
                table: "tb_band");

            migrationBuilder.DropColumn(
                name: "tr_coursecourse_no",
                table: "tb_band");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tr_trainer",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "resign",
                table: "tr_trainer",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emp_no",
                table: "tr_survey_detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_course_score",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_course_score",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "yearcourse_no",
                table: "tr_course_score",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "register_at",
                table: "tr_course_registration",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<bool>(
                name: "manager_approved_checked",
                table: "tr_course_registration",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "manager_approved_at",
                table: "tr_course_registration",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<bool>(
                name: "center_approved_checked",
                table: "tr_course_registration",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "center_approved_at",
                table: "tr_course_registration",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_course_master",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tr_course_master",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_course_master",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "bandcourse_no",
                table: "tr_course_master",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time_out",
                table: "tr_course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time_in",
                table: "tr_course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tr_course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "open_register",
                table: "tr_course",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_start",
                table: "tr_course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_end",
                table: "tr_course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_course",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "bandcourse_no",
                table: "tr_course",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_center",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_center",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tb_band",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tr_course_band",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    band1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_band", x => x.course_no);
                    table.ForeignKey(
                        name: "FK_tr_course_band_tb_band_band1",
                        column: x => x.band1,
                        principalTable: "tb_band",
                        principalColumn: "band",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tr_course_master_band",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    band = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_master_band", x => x.course_no);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_score_yearcourse_no",
                table: "tr_course_score",
                column: "yearcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_bandcourse_no",
                table: "tr_course_master",
                column: "bandcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_bandcourse_no",
                table: "tr_course",
                column: "bandcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_band1",
                table: "tr_course_band",
                column: "band1");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_tr_course_band_bandcourse_no",
                table: "tr_course",
                column: "bandcourse_no",
                principalTable: "tr_course_band",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_master_tr_course_master_band_bandcourse_no",
                table: "tr_course_master",
                column: "bandcourse_no",
                principalTable: "tr_course_master_band",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_score_tr_course_yearcourse_no",
                table: "tr_course_score",
                column: "yearcourse_no",
                principalTable: "tr_course",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
