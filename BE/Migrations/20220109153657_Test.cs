using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_tr_course_band_bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_band_tb_band_band1",
                table: "tr_course_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_tr_course_master_band_bandcourse_no",
                table: "tr_course_master");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_score_tr_course_yearcourse_no",
                table: "tr_course_score");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_trainer_tr_course_course_no1",
                table: "tr_course_trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_trainer_tr_trainer_trainer_no1",
                table: "tr_course_trainer");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_trainer_course_no1",
                table: "tr_course_trainer");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_trainer_trainer_no1",
                table: "tr_course_trainer");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_score_yearcourse_no",
                table: "tr_course_score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_course_master_band",
                table: "tr_course_master_band");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_master_bandcourse_no",
                table: "tr_course_master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_course_band",
                table: "tr_course_band");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_band_band1",
                table: "tr_course_band");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropColumn(
                name: "emp_no",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "course_no1",
                table: "tr_course_trainer");

            migrationBuilder.DropColumn(
                name: "trainer_no1",
                table: "tr_course_trainer");

            migrationBuilder.DropColumn(
                name: "yearcourse_no",
                table: "tr_course_score");

            migrationBuilder.DropColumn(
                name: "bandcourse_no",
                table: "tr_course_master");

            migrationBuilder.DropColumn(
                name: "band1",
                table: "tr_course_band");

            migrationBuilder.DropColumn(
                name: "bandcourse_no",
                table: "tr_course");

            migrationBuilder.RenameColumn(
                name: "band",
                table: "tr_course_master_band",
                newName: "band_text");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "tb_role_menu_claims",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "tb_role_menu_claims",
                newName: "updated_by");

            migrationBuilder.AlterTable(
                name: "tr_course_master_band",
                comment: "ตารางจับคู่คอร์สมาสเตอร์และแบนด์");

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

            migrationBuilder.AddColumn<string>(
                name: "course_no",
                table: "tr_course_trainer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trainer_no",
                table: "tr_course_trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AlterColumn<string>(
                name: "course_no",
                table: "tr_course_master_band",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<string>(
                name: "course_no",
                table: "tr_course_band",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "band_text",
                table: "tr_course_band",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "old_emp_no",
                table: "tb_employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "status_active",
                table: "tb_band",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "tb_band",
                columns: new[] { "band", "status_active" },
                values: new object[,]
                {
                    { "E", null },
                    { "J1", null },
                    { "J2", null },
                    { "J3", null },
                    { "J4", null },
                    { "M1", null },
                    { "M2", null },
                    { "JP", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tr_survey_detail_emp_no1",
                table: "tr_survey_detail",
                column: "emp_no1");

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
                name: "FK_tr_survey_detail_tb_employee_emp_no1",
                table: "tr_survey_detail");

            migrationBuilder.DropIndex(
                name: "IX_tr_survey_detail_emp_no1",
                table: "tr_survey_detail");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "E");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "J1");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "J2");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "J3");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "J4");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "JP");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "M1");

            migrationBuilder.DeleteData(
                table: "tb_band",
                keyColumn: "band",
                keyValue: "M2");

            migrationBuilder.DropColumn(
                name: "emp_no1",
                table: "tr_survey_detail");

            migrationBuilder.DropColumn(
                name: "course_no",
                table: "tr_course_trainer");

            migrationBuilder.DropColumn(
                name: "trainer_no",
                table: "tr_course_trainer");

            migrationBuilder.DropColumn(
                name: "course_no",
                table: "tr_course_score");

            migrationBuilder.DropColumn(
                name: "band_text",
                table: "tr_course_band");

            migrationBuilder.DropColumn(
                name: "old_emp_no",
                table: "tb_employee");

            migrationBuilder.RenameColumn(
                name: "band_text",
                table: "tr_course_master_band",
                newName: "band");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "tb_role_menu_claims",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "tb_role_menu_claims",
                newName: "update_by");

            migrationBuilder.AlterTable(
                name: "tr_course_master_band",
                oldComment: "ตารางจับคู่คอร์สมาสเตอร์และแบนด์");

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

            migrationBuilder.AddColumn<string>(
                name: "course_no1",
                table: "tr_course_trainer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainer_no1",
                table: "tr_course_trainer",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "course_no",
                table: "tr_course_master_band",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "course_no",
                table: "tr_course_band",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "band1",
                table: "tr_course_band",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_course_master_band",
                table: "tr_course_master_band",
                column: "course_no");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_course_band",
                table: "tr_course_band",
                column: "course_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_trainer_course_no1",
                table: "tr_course_trainer",
                column: "course_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_trainer_trainer_no1",
                table: "tr_course_trainer",
                column: "trainer_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_score_yearcourse_no",
                table: "tr_course_score",
                column: "yearcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_bandcourse_no",
                table: "tr_course_master",
                column: "bandcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_band1",
                table: "tr_course_band",
                column: "band1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_bandcourse_no",
                table: "tr_course",
                column: "bandcourse_no");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_tr_course_band_bandcourse_no",
                table: "tr_course",
                column: "bandcourse_no",
                principalTable: "tr_course_band",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_band_tb_band_band1",
                table: "tr_course_band",
                column: "band1",
                principalTable: "tb_band",
                principalColumn: "band",
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

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_trainer_tr_course_course_no1",
                table: "tr_course_trainer",
                column: "course_no1",
                principalTable: "tr_course",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_trainer_tr_trainer_trainer_no1",
                table: "tr_course_trainer",
                column: "trainer_no1",
                principalTable: "tr_trainer",
                principalColumn: "trainer_no",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
