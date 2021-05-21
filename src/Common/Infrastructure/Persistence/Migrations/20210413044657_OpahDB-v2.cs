using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class OpahDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "TB_ENDERECO");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "TB_CLIENTE");

            migrationBuilder.RenameTable(
                name: "ClienteEndereco",
                newName: "TB_CLIENTE_ENDERECO");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "TB_CIDADE");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_CidadeId",
                table: "TB_ENDERECO",
                newName: "IX_TB_ENDERECO_CidadeId");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "TB_CLIENTE_ENDERECO",
                newName: "ID_ENDERECO");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "TB_CLIENTE_ENDERECO",
                newName: "ID_CLIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_ClienteEndereco_EnderecoId",
                table: "TB_CLIENTE_ENDERECO",
                newName: "IX_TB_CLIENTE_ENDERECO_ID_ENDERECO");

            migrationBuilder.RenameIndex(
                name: "IX_ClienteEndereco_ClienteId",
                table: "TB_CLIENTE_ENDERECO",
                newName: "IX_TB_CLIENTE_ENDERECO_ID_CLIENTE");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TB_ENDERECO",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "TB_CLIENTE_ENDERECO",
                newName: "ClienteEndereco");

            migrationBuilder.RenameTable(
                name: "TB_CLIENTE",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "TB_CIDADE",
                newName: "Cidade");

            migrationBuilder.RenameIndex(
                name: "IX_TB_ENDERECO_CidadeId",
                table: "Endereco",
                newName: "IX_Endereco_CidadeId");

            migrationBuilder.RenameColumn(
                name: "ID_ENDERECO",
                table: "ClienteEndereco",
                newName: "EnderecoId");

            migrationBuilder.RenameColumn(
                name: "ID_CLIENTE",
                table: "ClienteEndereco",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_CLIENTE_ENDERECO_ID_ENDERECO",
                table: "ClienteEndereco",
                newName: "IX_ClienteEndereco_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_CLIENTE_ENDERECO_ID_CLIENTE",
                table: "ClienteEndereco",
                newName: "IX_ClienteEndereco_ClienteId");
        }
    }
}
