using Microsoft.EntityFrameworkCore.Migrations;

namespace CotecAPI.Migrations
{
    public partial class ContactAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ContactedPersons",
                type: "varchar(255)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ContactedPersons");
        }
    }
}
