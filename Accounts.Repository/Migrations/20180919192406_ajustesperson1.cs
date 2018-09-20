using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class ajustesperson1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CLIENT_ID",
                table: "ACCOUNT",
                newName: "PERSON_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ACCOUNT_CLIENT_ID",
                table: "ACCOUNT",
                newName: "IX_ACCOUNT_PERSON_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PERSON_ID",
                table: "ACCOUNT",
                newName: "CLIENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ACCOUNT_PERSON_ID",
                table: "ACCOUNT",
                newName: "IX_ACCOUNT_CLIENT_ID");
        }
    }
}
