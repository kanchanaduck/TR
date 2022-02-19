using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class AddColumninEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "tb_employee",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "center_code",
                table: "tb_employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "center_name",
                table: "tb_employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sex_en",
                table: "tb_employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sex_th",
                table: "tb_employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthday",
                table: "tb_employee");

            migrationBuilder.DropColumn(
                name: "center_code",
                table: "tb_employee");

            migrationBuilder.DropColumn(
                name: "center_name",
                table: "tb_employee");

            migrationBuilder.DropColumn(
                name: "sex_en",
                table: "tb_employee");

            migrationBuilder.DropColumn(
                name: "sex_th",
                table: "tb_employee");
        }
    }
}
