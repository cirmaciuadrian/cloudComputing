using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_StudentClassClassID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentClassClassID",
                table: "Students",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentClassClassID",
                table: "Students",
                newName: "IX_Students_ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassID",
                table: "Students",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "Students",
                newName: "StudentClassClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassID",
                table: "Students",
                newName: "IX_Students_StudentClassClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_StudentClassClassID",
                table: "Students",
                column: "StudentClassClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
