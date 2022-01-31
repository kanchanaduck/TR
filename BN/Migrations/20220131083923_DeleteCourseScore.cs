using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class DeleteCourseScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tr_course_score");

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

            migrationBuilder.AddColumn<string>(
                name: "post_test_grade",
                table: "tr_course_registration",
                type: "nvarchar(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "post_test_score",
                table: "tr_course_registration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pre_test_grade",
                table: "tr_course_registration",
                type: "nvarchar(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pre_test_score",
                table: "tr_course_registration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "scored_at",
                table: "tr_course_registration",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "scored_by",
                table: "tr_course_registration",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "post_test_grade",
                table: "tr_course_registration");

            migrationBuilder.DropColumn(
                name: "post_test_score",
                table: "tr_course_registration");

            migrationBuilder.DropColumn(
                name: "pre_test_grade",
                table: "tr_course_registration");

            migrationBuilder.DropColumn(
                name: "pre_test_score",
                table: "tr_course_registration");

            migrationBuilder.DropColumn(
                name: "scored_at",
                table: "tr_course_registration");

            migrationBuilder.DropColumn(
                name: "scored_by",
                table: "tr_course_registration");

            migrationBuilder.CreateTable(
                name: "tr_course_score",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    emp_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_test_grade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    post_test_score = table.Column<int>(type: "int", nullable: false),
                    pre_test_grade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    pre_test_score = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_score", x => new { x.course_no, x.emp_no });
                    table.ForeignKey(
                        name: "FK_tr_course_score_tb_employee_emp_no",
                        column: x => x.emp_no,
                        principalTable: "tb_employee",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_score_tr_course_course_no",
                        column: x => x.course_no,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "ตารางเก็บคะแนนและเกรด");

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
                name: "IX_tr_course_score_emp_no",
                table: "tr_course_score",
                column: "emp_no");
        }
    }
}
