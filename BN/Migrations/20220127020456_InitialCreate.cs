using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_band",
                columns: table => new
                {
                    band = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_band", x => x.band);
                });

            migrationBuilder.CreateTable(
                name: "tb_employee",
                columns: table => new
                {
                    emp_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    old_emp_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sname_eng = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    gname_eng = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fname_eng = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    sname_tha = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    gname_tha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fname_tha = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    div_cls = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    div_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    div_abb_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dept_code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dept_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    wc_code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    wc_abb_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    wc_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    band = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    posn_code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    posn_ename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    resn_date = table.Column<DateTime>(type: "date", nullable: true),
                    prob_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_employee", x => x.emp_no);
                });

            migrationBuilder.CreateTable(
                name: "tb_employee_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_employee_role_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_menus",
                columns: table => new
                {
                    menu_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_menu_code = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_menus", x => x.menu_code);
                    table.ForeignKey(
                        name: "FK_tb_menus_tb_menus_parent_menu_code",
                        column: x => x.parent_menu_code,
                        principalTable: "tb_menus",
                        principalColumn: "menu_code",
                        onDelete: ReferentialAction.Restrict);
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
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_role_menu_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    menu_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role_menu_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "bit", nullable: true),
                    passwordhash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tr_center",
                columns: table => new
                {
                    center_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_center", x => x.center_no);
                },
                comment: "ตารางเก็บข้อมูลcenter");

            migrationBuilder.CreateTable(
                name: "tr_course",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    course_name_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    days = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    open_register = table.Column<bool>(type: "bit", nullable: true),
                    date_start = table.Column<DateTime>(type: "date", nullable: false),
                    date_end = table.Column<DateTime>(type: "date", nullable: false),
                    time_in = table.Column<TimeSpan>(type: "time", nullable: false),
                    time_out = table.Column<TimeSpan>(type: "time", nullable: false),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course", x => x.course_no);
                });

            migrationBuilder.CreateTable(
                name: "tr_course_master",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    course_name_th = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    prev_course_no = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    days = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_master", x => x.course_no);
                    table.ForeignKey(
                        name: "FK_tr_course_master_tr_course_master_prev_course_no",
                        column: x => x.prev_course_no,
                        principalTable: "tr_course_master",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "ตารางเก็บข้อมูลคอร์ส 6 หลัก เพื่อช่วยในการเปิดคอร์ส");

            migrationBuilder.CreateTable(
                name: "tr_stakeholder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emp_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_no = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "เลขคอร์ส 6 หลัก"),
                    month = table.Column<int>(type: "int", nullable: false, comment: "เก็บเดือนที่ต้องการเรียน"),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                },
                comment: "ตารางเก็บข้อมูลการ survey");

            migrationBuilder.CreateTable(
                name: "tr_survey_file",
                columns: table => new
                {
                    file_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "เก็บ division หรือ department ที่ committee คนนั้นรับผิดชอบ"),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Level"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_survey_file", x => x.file_id);
                },
                comment: "ตารางเก็บไฟล์ในการ survey");

            migrationBuilder.CreateTable(
                name: "tr_survey_setting",
                columns: table => new
                {
                    year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    date_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_survey_setting", x => x.year);
                },
                comment: "ตารางเก็บ period การ survey เฉพาะคอร์สของ MTP");

            migrationBuilder.CreateTable(
                name: "tr_trainer",
                columns: table => new
                {
                    trainer_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    sname_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gname_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fname_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sname_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gname_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fname_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainer_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_active = table.Column<bool>(type: "bit", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_trainer", x => x.trainer_no);
                },
                comment: "ตารางเก็บข้อมูลเทรนเนอร์");

            migrationBuilder.CreateTable(
                name: "tr_course_band",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    band = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_band", x => new { x.course_no, x.band });
                    table.ForeignKey(
                        name: "FK_tr_course_band_tb_band_band",
                        column: x => x.band,
                        principalTable: "tb_band",
                        principalColumn: "band",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_band_tr_course_course_no",
                        column: x => x.course_no,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tr_course_registration",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    emp_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    seq_no = table.Column<int>(type: "int", nullable: false),
                    last_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    register_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    register_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manager_approved_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    manager_approved_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manager_approved_checked = table.Column<bool>(type: "bit", nullable: true),
                    center_approved_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    center_approved_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    center_approved_checked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_registration", x => new { x.course_no, x.emp_no });
                    table.ForeignKey(
                        name: "FK_tr_course_registration_tb_employee_emp_no",
                        column: x => x.emp_no,
                        principalTable: "tb_employee",
                        principalColumn: "emp_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_registration_tr_course_course_no",
                        column: x => x.course_no,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "เปิ้ลอธิบายตารางนี้ให้ฟังหน่อย");

            migrationBuilder.CreateTable(
                name: "tr_course_score",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    emp_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pre_test_score = table.Column<int>(type: "int", nullable: false),
                    pre_test_grade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    post_test_score = table.Column<int>(type: "int", nullable: false),
                    post_test_grade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "tr_course_master_band",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    band = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_master_band", x => new { x.course_no, x.band });
                    table.ForeignKey(
                        name: "FK_tr_course_master_band_tb_band_band",
                        column: x => x.band,
                        principalTable: "tb_band",
                        principalColumn: "band",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_master_band_tr_course_master_course_no",
                        column: x => x.course_no,
                        principalTable: "tr_course_master",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "ตารางจับคู่คอร์สมาสเตอร์และแบนด์");

            migrationBuilder.CreateTable(
                name: "tr_course_trainer",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    trainer_no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course_trainer", x => new { x.course_no, x.trainer_no });
                    table.ForeignKey(
                        name: "FK_tr_course_trainer_tr_course_course_no",
                        column: x => x.course_no,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_trainer_tr_trainer_trainer_no",
                        column: x => x.trainer_no,
                        principalTable: "tr_trainer",
                        principalColumn: "trainer_no",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_tb_menus_parent_menu_code",
                table: "tb_menus",
                column: "parent_menu_code");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_band",
                table: "tr_course_band",
                column: "band");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_prev_course_no",
                table: "tr_course_master",
                column: "prev_course_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_band_band",
                table: "tr_course_master_band",
                column: "band");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_registration_emp_no",
                table: "tr_course_registration",
                column: "emp_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_score_emp_no",
                table: "tr_course_score",
                column: "emp_no");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_trainer_trainer_no",
                table: "tr_course_trainer",
                column: "trainer_no");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_employee_role_claims");

            migrationBuilder.DropTable(
                name: "tb_menus");

            migrationBuilder.DropTable(
                name: "tb_role");

            migrationBuilder.DropTable(
                name: "tb_role_menu_claims");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tr_center");

            migrationBuilder.DropTable(
                name: "tr_course_band");

            migrationBuilder.DropTable(
                name: "tr_course_master_band");

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
                name: "tr_course_master");

            migrationBuilder.DropTable(
                name: "tb_employee");

            migrationBuilder.DropTable(
                name: "tr_course");

            migrationBuilder.DropTable(
                name: "tr_trainer");
        }
    }
}
