using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class TableFirstVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_course_band");

            migrationBuilder.DropTable(
                name: "tb_course_trainer");

            migrationBuilder.DropTable(
                name: "tb_master_course_band");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tr_band");

            migrationBuilder.DropTable(
                name: "tr_employee_history");

            migrationBuilder.DropTable(
                name: "tr_master_course");

            migrationBuilder.DropColumn(
                name: "type",
                table: "tr_trainer");

            migrationBuilder.DropColumn(
                name: "role_id",
                table: "tb_employee_role_claims");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "tb_employee_role_claims");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "tr_course",
                newName: "date_start");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "tr_course",
                newName: "date_end");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "tb_employee_role_claims",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "tb_employee_role_claims",
                newName: "updated_by");

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "resign",
                table: "tr_trainer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "trainer_type",
                table: "tr_trainer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "place",
                table: "tr_course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bandcourse_no",
                table: "tr_course",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "tb_employee_role_claims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "tb_employee_role_claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "emp_no1",
                table: "tb_employee_role_claims",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "role_id1",
                table: "tb_employee_role_claims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_band",
                columns: table => new
                {
                    band = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_band", x => x.band);
                });

            migrationBuilder.CreateTable(
                name: "tb_role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "tr_center",
                columns: table => new
                {
                    center_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_center", x => x.center_no);
                },
                comment: "ตารางเก็บข้อมูลcenter");

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

            migrationBuilder.CreateTable(
                name: "tr_course_registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_no1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    emp_no1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    seq_no = table.Column<int>(type: "int", nullable: false),
                    last_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    register_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    register_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manager_approved_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    manager_approved_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manager_approved_checked = table.Column<bool>(type: "bit", nullable: false),
                    center_approved_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    center_approved_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    center_approved_checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_registration", x => x.id);
                    table.ForeignKey(
                        name: "FK_tr_course_registration_tb_employee_emp_no1",
                        column: x => x.emp_no1,
                        principalTable: "tb_employee",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tr_course_registration_tr_course_course_no1",
                        column: x => x.course_no1,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "เปิ้ลอธิบายตารางนี้ให้ฟังหน่อย");

            migrationBuilder.CreateTable(
                name: "tr_course_score",
                columns: table => new
                {
                    yearcourse_no = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    emp_no1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    pre_test_score = table.Column<int>(type: "int", nullable: false),
                    pre_test_grade = table.Column<int>(type: "int", nullable: false),
                    post_test_score = table.Column<int>(type: "int", nullable: false),
                    post_test_grade = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tr_course_score_tb_employee_emp_no1",
                        column: x => x.emp_no1,
                        principalTable: "tb_employee",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tr_course_score_tr_course_yearcourse_no",
                        column: x => x.yearcourse_no,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "ตารางเก็บคะแนนและเกรด");

            migrationBuilder.CreateTable(
                name: "tr_course_trainer",
                columns: table => new
                {
                    course_no1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    trainer_no1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tr_course_trainer_tr_course_course_no1",
                        column: x => x.course_no1,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tr_course_trainer_tr_trainer_trainer_no1",
                        column: x => x.trainer_no1,
                        principalTable: "tr_trainer",
                        principalColumn: "trainer_no",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tr_stakeholder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    sname_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gname_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fname_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resign = table.Column<bool>(type: "bit", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_stakeholder", x => x.id);
                },
                comment: "ตารางเก็บข้อมูลผู้ที่เกี่ยวข้อง");

            migrationBuilder.CreateTable(
                name: "tr_survey_detail",
                columns: table => new
                {
                    year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_no = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "เลขคอร์ส 6 หลัก"),
                    month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_survey_detail", x => x.year);
                },
                comment: "ตารางเก็บข้อมูลการ survey");

            migrationBuilder.CreateTable(
                name: "tr_survey_file",
                columns: table => new
                {
                    year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "เก็บ division หรือ department ที่ committee คนนั้นรับผิดชอบ"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                },
                comment: "ตารางเก็บไฟล์ในการ survey");

            migrationBuilder.CreateTable(
                name: "tr_survey_setting",
                columns: table => new
                {
                    year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    date_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_survey_setting", x => x.year);
                },
                comment: "ตารางเก็บ period การ survey");

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
                name: "tr_course_master",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    course_name_th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    prev_course_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    days = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    bandcourse_no = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_master", x => x.course_no);
                    table.ForeignKey(
                        name: "FK_tr_course_master_tr_course_master_band_bandcourse_no",
                        column: x => x.bandcourse_no,
                        principalTable: "tr_course_master_band",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "ตารางเก็บข้อมูลคอร์ส 6 หลัก เพื่อช่วยในการเปิดคอร์ส");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_bandcourse_no",
                table: "tr_course",
                column: "bandcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tb_employee_role_claims_emp_no1",
                table: "tb_employee_role_claims",
                column: "emp_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_employee_role_claims_role_id1",
                table: "tb_employee_role_claims",
                column: "role_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_band1",
                table: "tr_course_band",
                column: "band1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_bandcourse_no",
                table: "tr_course_master",
                column: "bandcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_registration_course_no1",
                table: "tr_course_registration",
                column: "course_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_registration_emp_no1",
                table: "tr_course_registration",
                column: "emp_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_score_emp_no1",
                table: "tr_course_score",
                column: "emp_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_score_yearcourse_no",
                table: "tr_course_score",
                column: "yearcourse_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_trainer_course_no1",
                table: "tr_course_trainer",
                column: "course_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_trainer_trainer_no1",
                table: "tr_course_trainer",
                column: "trainer_no1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_employee_role_claims_tb_employee_emp_no1",
                table: "tb_employee_role_claims",
                column: "emp_no1",
                principalTable: "tb_employee",
                principalColumn: "emp_no",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_employee_role_claims_tb_role_role_id1",
                table: "tb_employee_role_claims",
                column: "role_id1",
                principalTable: "tb_role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_tr_course_band_bandcourse_no",
                table: "tr_course",
                column: "bandcourse_no",
                principalTable: "tr_course_band",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_employee_role_claims_tb_employee_emp_no1",
                table: "tb_employee_role_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_employee_role_claims_tb_role_role_id1",
                table: "tb_employee_role_claims");

            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_tr_course_band_bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tr_center");

            migrationBuilder.DropTable(
                name: "tr_course_band");

            migrationBuilder.DropTable(
                name: "tr_course_master");

            migrationBuilder.DropTable(
                name: "tr_course_registration");

            migrationBuilder.DropTable(
                name: "tr_course_score");

            migrationBuilder.DropTable(
                name: "tr_course_trainer");

            migrationBuilder.DropTable(
                name: "tr_stakeholder");

            migrationBuilder.DropTable(
                name: "tr_survey_detail");

            migrationBuilder.DropTable(
                name: "tr_survey_file");

            migrationBuilder.DropTable(
                name: "tr_survey_setting");

            migrationBuilder.DropTable(
                name: "tb_band");

            migrationBuilder.DropTable(
                name: "tr_course_master_band");

            migrationBuilder.DropIndex(
                name: "IX_tr_course_bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropIndex(
                name: "IX_tb_employee_role_claims_emp_no1",
                table: "tb_employee_role_claims");

            migrationBuilder.DropIndex(
                name: "IX_tb_employee_role_claims_role_id1",
                table: "tb_employee_role_claims");

            migrationBuilder.DropColumn(
                name: "resign",
                table: "tr_trainer");

            migrationBuilder.DropColumn(
                name: "trainer_type",
                table: "tr_trainer");

            migrationBuilder.DropColumn(
                name: "bandcourse_no",
                table: "tr_course");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "tb_employee_role_claims");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "tb_employee_role_claims");

            migrationBuilder.DropColumn(
                name: "emp_no1",
                table: "tb_employee_role_claims");

            migrationBuilder.DropColumn(
                name: "role_id1",
                table: "tb_employee_role_claims");

            migrationBuilder.RenameColumn(
                name: "date_start",
                table: "tr_course",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "date_end",
                table: "tr_course",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "tb_employee_role_claims",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "tb_employee_role_claims",
                newName: "update_date");

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "tr_trainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "place",
                table: "tr_course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "role_id",
                table: "tb_employee_role_claims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "tb_employee_role_claims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_course_band",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    band = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_course_band", x => x.course_no);
                });

            migrationBuilder.CreateTable(
                name: "tb_course_trainer",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    trainer_no = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_course_trainer", x => x.course_no);
                });

            migrationBuilder.CreateTable(
                name: "tb_master_course_band",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    band = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_master_course_band", x => x.course_no);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "tr_band",
                columns: table => new
                {
                    band = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_band", x => x.band);
                });

            migrationBuilder.CreateTable(
                name: "tr_employee_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emp_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posn_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posn_ename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_test_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pre_test_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_employee_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tr_master_course",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_name_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    days = table.Column<int>(type: "int", nullable: false),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prev_course_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_active = table.Column<bool>(type: "bit", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_master_course", x => x.course_no);
                });
        }
    }
}
