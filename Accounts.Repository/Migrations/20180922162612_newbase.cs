using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class newbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("200ddf37-82c2-46b7-a1df-4b426bf078e9"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("3ec55caf-4684-48ca-a976-59a80a0f92f8"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("3ec55caf-4684-48ca-a976-59a80a0f92f8"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("200ddf37-82c2-46b7-a1df-4b426bf078e9"));
        }
    }
}
