using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class ajustestransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("c4b8cf66-a4bc-4b66-9441-78f1ecf0cb8e"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("200ddf37-82c2-46b7-a1df-4b426bf078e9"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "TRANSACTION",
                nullable: false,
                defaultValue: new Guid("200ddf37-82c2-46b7-a1df-4b426bf078e9"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("c4b8cf66-a4bc-4b66-9441-78f1ecf0cb8e"));
        }
    }
}
