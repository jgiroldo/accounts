using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class baseDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF_CNPJ = table.Column<string>(nullable: false),
                    NAME = table.Column<string>(maxLength: 100, nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(nullable: true),
                    SOCIAL_NAME = table.Column<string>(nullable: true),
                    COMPANY_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATION_DATE = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    PARENT_ACCOUNT = table.Column<int>(nullable: true),
                    MASTER_ACCOUNT = table.Column<int>(nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    PERSON_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(maxLength: 100, nullable: false),
                    BALANCE = table.Column<float>(nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_PERSON",
                        column: x => x.PERSON_ID,
                        principalTable: "PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValue: new Guid("b0b76420-fd44-4610-87f1-2c6661e810b4")),
                    OPERATION_DATE = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    OPERATION_TYPE = table.Column<int>(nullable: false),
                    SOURCE_ACCOUNT_ID = table.Column<int>(nullable: true),
                    DESTINY_ACCOUNT_ID = table.Column<int>(nullable: true),
                    VALUE = table.Column<float>(nullable: false),
                    IS_REVERSED = table.Column<bool>(nullable: false, defaultValue: false)
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
                name: "IX_ACCOUNT_PERSON_ID",
                table: "ACCOUNT",
                column: "PERSON_ID");

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

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "PERSON");
        }
    }
}
