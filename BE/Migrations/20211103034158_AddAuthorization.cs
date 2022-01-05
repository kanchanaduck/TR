using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class AddAuthorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSeeMenu");

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
                    table.PrimaryKey("PK_EmployeeRoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
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
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_RoleMenuClaims", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeRoleClaim");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleMenuClaims");

            migrationBuilder.CreateTable(
                name: "UserSeeMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    menu_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeeMenu", x => x.Id);
                });
        }
    }
}
