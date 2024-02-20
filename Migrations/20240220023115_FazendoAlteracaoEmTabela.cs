using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciamento_de_Tarefas.Migrations
{
    /// <inheritdoc />
    public partial class FazendoAlteracaoEmTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusCivil",
                table: "Usuarios",
                newName: "EstadoCivil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoCivil",
                table: "Usuarios",
                newName: "StatusCivil");
        }
    }
}
