using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesIoasys.Infra.Data.Sql.Migrations
{
    public partial class Adiçãodeemailesenhanousuarioretiradadaidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
