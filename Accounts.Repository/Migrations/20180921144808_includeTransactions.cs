using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class includeTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRANSACTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValue: new Guid("55c09675-6280-4214-a852-485b3d7a0e12")),
                    OPERATION_DATE = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    OPERATION_TYPE = table.Column<int>(nullable: false),
                    SOURCE_ACCOUNT_ID = table.Column<int>(nullable: false),
                    DESTINY_ACCOUNT_ID = table.Column<int>(nullable: false),
                    VALUE = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_DESTINY_ACCOUNT",
                        column: x => x.DESTINY_ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_SOURCE_ACCOUNT",
                        column: x => x.SOURCE_ACCOUNT_ID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_DESTINY_ACCOUNT_ID",
                table: "TRANSACTION",
                column: "DESTINY_ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_SOURCE_ACCOUNT_ID",
                table: "TRANSACTION",
                column: "SOURCE_ACCOUNT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRANSACTION");
        }
    }
}
