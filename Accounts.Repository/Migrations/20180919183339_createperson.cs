using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Repository.Migrations
{
    public partial class createperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACCOUNT_CLIENT",
                table: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF_CNPJ = table.Column<string>(nullable: false),
                    NAME = table.Column<string>(maxLength: 100, nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(nullable: false),
                    SOCIAL_NAME = table.Column<string>(nullable: true),
                    COMPANY_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ACCOUNT_PERSON",
                table: "ACCOUNT",
                column: "CLIENT_ID",
                principalTable: "PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACCOUNT_PERSON",
                table: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "PERSON");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ACCOUNT_CLIENT",
                table: "ACCOUNT",
                column: "CLIENT_ID",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
