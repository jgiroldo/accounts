using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class adjustsTransactions1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SOURCE_ACCOUNT_ID",
                table: "TRANSACTION",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("666d53a9-c81e-4605-905b-e5ea91ceefe7"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("61174623-e95c-45a7-91ca-ca7687be260a"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SOURCE_ACCOUNT_ID",
                table: "TRANSACTION",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("61174623-e95c-45a7-91ca-ca7687be260a"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("666d53a9-c81e-4605-905b-e5ea91ceefe7"));
        }
    }
}
