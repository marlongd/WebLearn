using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingAppApi.Migrations
{
    public partial class updatingPasswordSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Myproperty",
                table: "Users",
                newName: "PasswordSalt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "Myproperty");
        }
    }
}
