using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCProject.DAL.Data.Migrations
{
    public partial class SentaxError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfCertion",
                table: "Department",
                newName: "DateOfCreation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "Department",
                newName: "DateOfCertion");
        }
    }
}
