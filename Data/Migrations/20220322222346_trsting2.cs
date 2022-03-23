using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSGrupp3.Data.Migrations
{
    public partial class trsting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_Id",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_Id",
                table: "Courses",
                column: "Id",
                unique: true);
        }
    }
}
