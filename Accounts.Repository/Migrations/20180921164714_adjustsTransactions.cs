using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class adjustsTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("61174623-e95c-45a7-91ca-ca7687be260a"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("55c09675-6280-4214-a852-485b3d7a0e12"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("55c09675-6280-4214-a852-485b3d7a0e12"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("61174623-e95c-45a7-91ca-ca7687be260a"));
        }
    }
}
