using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class User_MigrationNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "User",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "User",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_CPF",
                table: "User",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_CPF",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "User");
        }
    }
}
