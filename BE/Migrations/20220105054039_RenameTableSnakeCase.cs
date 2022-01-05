using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class RenameTableSnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeRoleClaim");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleMenuClaims");

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
                name: "tb_employee",
                columns: table => new
                {
                    emp_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    resn_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prob_date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_tb_employee_role_claims", x => x.id);
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
                name: "tb_menus",
                columns: table => new
                {
                    menu_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    menu_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_menu_code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_role_menu_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
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
                name: "tr_course",
                columns: table => new
                {
                    course_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    course_name_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    days = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    open_register = table.Column<bool>(type: "bit", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time_out = table.Column<DateTime>(type: "datetime2", nullable: false),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_course", x => x.course_no);
                });

            migrationBuilder.CreateTable(
                name: "tr_employee_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emp_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posn_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posn_ename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pre_test_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_test_score = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    course_name_th = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    prev_course_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    days = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_master_course", x => x.course_no);
                });

            migrationBuilder.CreateTable(
                name: "tr_trainer",
                columns: table => new
                {
                    trainer_no = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    emp_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fname_eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_abb_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    types = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_trainer", x => x.trainer_no);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_menus_parent_menu_code",
                table: "tb_menus",
                column: "parent_menu_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_course_band");

            migrationBuilder.DropTable(
                name: "tb_course_trainer");

            migrationBuilder.DropTable(
                name: "tb_employee");

            migrationBuilder.DropTable(
                name: "tb_employee_role_claims");

            migrationBuilder.DropTable(
                name: "tb_master_course_band");

            migrationBuilder.DropTable(
                name: "tb_menus");

            migrationBuilder.DropTable(
                name: "tb_role_menu_claims");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tr_band");

            migrationBuilder.DropTable(
                name: "tr_course");

            migrationBuilder.DropTable(
                name: "tr_employee_history");

            migrationBuilder.DropTable(
                name: "tr_master_course");

            migrationBuilder.DropTable(
                name: "tr_trainer");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EMP_NO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BAND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT_ABB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIV_ABB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIV_CLS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIV_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL_ACTIVE_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FNAME_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FNAME_THA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GNAME_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GNAME_THA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OLD_EMP_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSN_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSN_ENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROB_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RESN_DATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNAME_ENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNAME_THAI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WC_ABB_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WC_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EMP_NO);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    menu_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menu_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_menu_code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.menu_code);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_parent_menu_code",
                        column: x => x.parent_menu_code,
                        principalTable: "Menu",
                        principalColumn: "menu_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
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
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menu_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenuClaims", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_parent_menu_code",
                table: "Menu",
                column: "parent_menu_code");
        }
    }
}
