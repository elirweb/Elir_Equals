using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Equals_Infra.Migrations
{
    public partial class equals_20200207 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acquirer",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<string>(nullable: true),
                    IdAcquirer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoRegistro = table.Column<string>(nullable: true),
                    Estabelecimento = table.Column<string>(nullable: true),
                    DataProcessamento = table.Column<string>(nullable: true),
                    PeriodoInicial = table.Column<string>(nullable: true),
                    PeriodoFinal = table.Column<string>(nullable: true),
                    Sequencial = table.Column<string>(nullable: true),
                    Adquirente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquirer", x => x.IdAcquirer);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<string>(nullable: true),
                    IdFile = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAcquirer = table.Column<int>(nullable: false),
                    StatusFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.IdFile);
                    table.ForeignKey(
                        name: "FK_File_Acquirer_IdAcquirer",
                        column: x => x.IdAcquirer,
                        principalTable: "Acquirer",
                        principalColumn: "IdAcquirer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_IdAcquirer",
                table: "File",
                column: "IdAcquirer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Acquirer");
        }
    }
}
