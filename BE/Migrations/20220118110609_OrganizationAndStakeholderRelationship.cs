using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class OrganizationAndStakeholderRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "org_code",
                table: "tr_stakeholder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tr_stakeholder_org_code",
                table: "tr_stakeholder",
                column: "org_code");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder",
                column: "org_code",
                principalTable: "tb_organization",
                principalColumn: "org_code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_stakeholder_tb_organization_org_code",
                table: "tr_stakeholder");

            migrationBuilder.DropIndex(
                name: "IX_tr_stakeholder_org_code",
                table: "tr_stakeholder");

            migrationBuilder.AlterColumn<string>(
                name: "org_code",
                table: "tr_stakeholder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
