using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularFirst.Migrations
{
    public partial class RelationShipWithBandCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tr_course_band",
                columns: table => new
                {
                    course_no1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    band1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tr_course_band_tb_band_band1",
                        column: x => x.band1,
                        principalTable: "tb_band",
                        principalColumn: "band",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_band_tr_course_course_no1",
                        column: x => x.course_no1,
                        principalTable: "tr_course",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tr_course_master_band",
                columns: table => new
                {
                    course_no1 = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    band1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tr_course_master_band_tb_band_band1",
                        column: x => x.band1,
                        principalTable: "tb_band",
                        principalColumn: "band",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tr_course_master_band_tr_course_master_course_no1",
                        column: x => x.course_no1,
                        principalTable: "tr_course_master",
                        principalColumn: "course_no",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "ตารางจับคู่คอร์สมาสเตอร์และแบนด์");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_band1",
                table: "tr_course_band",
                column: "band1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_band_course_no1",
                table: "tr_course_band",
                column: "course_no1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_band_band1",
                table: "tr_course_master_band",
                column: "band1");

            migrationBuilder.CreateIndex(
                name: "IX_tr_course_master_band_course_no1",
                table: "tr_course_master_band",
                column: "course_no1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tr_course_band");

            migrationBuilder.DropTable(
                name: "tr_course_master_band");
        }
    }
}
