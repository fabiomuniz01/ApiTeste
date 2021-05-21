using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class OpahDBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NM_USU_INCLUSAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NM_USU_ALTERACAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RG = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EMAIL_ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    COD_EMPRESA = table.Column<int>(type: "int", nullable: false),
                    NM_USU_INCLUSAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NM_USU_ALTERACAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RUA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BAIRRO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NUMERO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TIPO_ENDERECO = table.Column<int>(type: "int", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: true),
                    NM_USU_INCLUSAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NM_USU_ALTERACAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEndereco",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TB_CLIENTE_ID = table.Column<int>(type: "int", nullable: false),
                    TB_ENDERECO_ID = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    NM_USU_INCLUSAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NM_USU_ALTERACAO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DT_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEndereco", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClienteEndereco_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteEndereco_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEndereco_ClienteId",
                table: "ClienteEndereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEndereco_EnderecoId",
                table: "ClienteEndereco",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteEndereco");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Cidade");
        }
    }
}
