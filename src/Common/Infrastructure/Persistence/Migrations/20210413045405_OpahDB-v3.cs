using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class OpahDBv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "TB_ENDERECO",
                newName: "ID_CIDADE");

            migrationBuilder.RenameIndex(
                name: "IX_TB_ENDERECO_CidadeId",
                table: "TB_ENDERECO",
                newName: "IX_TB_ENDERECO_ID_CIDADE");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "ID_CIDADE",
                table: "TB_ENDERECO",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_ENDERECO_ID_CIDADE",
                table: "TB_ENDERECO",
                newName: "IX_TB_ENDERECO_CidadeId");

            
        }
    }
}
