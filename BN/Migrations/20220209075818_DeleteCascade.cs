using Microsoft.EntityFrameworkCore.Migrations;

namespace api_hrgis.Migrations
{
    public partial class DeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band",
                column: "course_no",
                principalTable: "tr_course_master",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band");

            migrationBuilder.AddForeignKey(
                name: "FK_tr_course_master_band_tr_course_master_course_no",
                table: "tr_course_master_band",
                column: "course_no",
                principalTable: "tr_course_master",
                principalColumn: "course_no",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
