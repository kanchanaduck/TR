using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class WorrawutSuggest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tr_course_master_band");

            migrationBuilder.DropColumn(
                name: "band_text",
                table: "tr_course_band");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_trainer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_trainer",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "trainer_no",
                table: "tr_course_trainer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "course_no",
                table: "tr_course_trainer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pre_test_grade",
                table: "tr_course_score",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "post_test_grade",
                table: "tr_course_score",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "level",
                table: "tr_course_master",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "band",
                table: "tr_course_band",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_course_trainer",
                table: "tr_course_trainer",
                columns: new[] { "course_no", "trainer_no" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tr_course_band",
                table: "tr_course_band",
                columns: new[] { "course_no", "band" });

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_trainer_trainer_no",
                table: "tr_course_trainer",
                column: "trainer_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_band",
                table: "tr_course_band",
                column: "band");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_band_tb_band_band",
                table: "tr_course_band",
                column: "band",
                principalTable: "tb_band",
                principalColumn: "band",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_band_tr_course_course_no",
                table: "tr_course_band",
                column: "course_no",
                principalTable: "tr_course",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_trainer_tr_course_course_no",
                table: "tr_course_trainer",
                column: "course_no",
                principalTable: "tr_course",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_trainer_tr_trainer_trainer_no",
                table: "tr_course_trainer",
                column: "trainer_no",
                principalTable: "tr_trainer",
                principalColumn: "trainer_no",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_band_tb_band_band",
                table: "tr_course_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_band_tr_course_course_no",
                table: "tr_course_band");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_trainer_tr_course_course_no",
                table: "tr_course_trainer");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_trainer_tr_trainer_trainer_no",
                table: "tr_course_trainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_course_trainer",
                table: "tr_course_trainer");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_trainer_trainer_no",
                table: "tr_course_trainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tr_course_band",
                table: "tr_course_band");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_band_band",
                table: "tr_course_band");

            migrationBuilder.DropColumn(
                name: "band",
                table: "tr_course_band");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tr_trainer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tr_trainer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "trainer_no",
                table: "tr_course_trainer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "course_no",
                table: "tr_course_trainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "pre_test_grade",
                table: "tr_course_score",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "post_test_grade",
                table: "tr_course_score",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<string>(
                name: "level",
                table: "tr_course_master",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "tr_course_master_band",
                columns: table => new
                {
                    band_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                },
                comment: "ตารางจับคู่คอร์สมาสเตอร์และแบนด์");
        }
    }
}
