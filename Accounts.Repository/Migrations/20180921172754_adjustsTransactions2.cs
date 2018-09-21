using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class adjustsTransactions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("3ec55caf-4684-48ca-a976-59a80a0f92f8"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("666d53a9-c81e-4605-905b-e5ea91ceefe7"));

            migrationBuilder.AddColumn<bool>(
                name: "IS_REVERSED",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_REVERSED",
                table: "TRANSACTION");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("666d53a9-c81e-4605-905b-e5ea91ceefe7"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3ec55caf-4684-48ca-a976-59a80a0f92f8"));
        }
    }
}
