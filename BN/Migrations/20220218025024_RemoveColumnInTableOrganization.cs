using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class RemoveColumnInTableOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "tb_organization");

            migrationBuilder.DropColumn(
                name: "spare1",
                table: "tb_organization");

            migrationBuilder.DropColumn(
                name: "spare2",
                table: "tb_organization");

            migrationBuilder.DropColumn(
                name: "spare3",
                table: "tb_organization");

            migrationBuilder.DropColumn(
                name: "spare4",
                table: "tb_organization");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "tb_organization");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "tb_organization");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "tb_organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "spare1",
                table: "tb_organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "spare2",
                table: "tb_organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "spare3",
                table: "tb_organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "spare4",
                table: "tb_organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "tb_organization",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "tb_organization",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
