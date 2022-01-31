using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class AddTableOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tb_organizationorg_code",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_organization",
                columns: table => new
                {
                    org_code = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Center (1) > Division (2) > Department(3) > Work center(4)"),
                    level_seq = table.Column<int>(type: "int", nullable: false),
                    level_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    org_abb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    org_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_org_code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spare4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_organization", x => x.org_code);
                    table.ForeignKey(
                        name: "FK_tb_organization_tb_organization_parent_org_code",
                        column: x => x.parent_org_code,
                        principalTable: "tb_organization",
                        principalColumn: "org_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tr_stakeholder_tb_organizationorg_code",
                table: "tr_stakeholder",
                column: "tb_organizationorg_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_organization_parent_org_code",
                table: "tb_organization",
                column: "parent_org_code");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_organization_tb_organizationorg_code",
                table: "tr_stakeholder",
                column: "tb_organizationorg_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_organization_tb_organizationorg_code",
                table: "tr_stakeholder");

            migrationBuilder.DropTable(
                name: "tb_organization");

            migrationBuilder.DropIndex(
                name: "IX_tr_stakeholder_tb_organizationorg_code",
                table: "tr_stakeholder");

            migrationBuilder.DropColumn(
                name: "tb_organizationorg_code",
                table: "tr_stakeholder");
        }
    }
}
