using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetabledocumentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaveAcessoArmazenamento",
                table: "Documentos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivo",
                table: "Documentos",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveAcessoArmazenamento",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "NomeArquivo",
                table: "Documentos");
        }
    }
}
