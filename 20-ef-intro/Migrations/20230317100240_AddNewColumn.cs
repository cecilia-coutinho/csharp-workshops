using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstEntity.Migrations
{
    public partial class AddNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Address",
            table: "Employees",
            nullable: true,
            defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
