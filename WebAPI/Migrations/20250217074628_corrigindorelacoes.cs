using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class corrigindorelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioModelId",
                table: "Tarefas",
                column: "UsuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioId1",
                table: "Clientes",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioId1",
                table: "Clientes",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioModelId",
                table: "Tarefas",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioId1",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioModelId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_UsuarioModelId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UsuarioId1",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioModelId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Clientes");
        }
    }
}
