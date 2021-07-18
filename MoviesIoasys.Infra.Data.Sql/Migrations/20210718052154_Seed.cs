using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesIoasys.Infra.Data.Sql.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[,]
                {
                    { new Guid("aecd9fdc-c732-4066-a620-c83d931e6893"), null, "Leonardo DI Caprio" },
                    { new Guid("b73b3d56-ce9a-4644-a339-aaf96f26a3ad"), null, "Morgan Freeman" },
                    { new Guid("0a9d5004-3c5e-4e70-bda9-26cf5310476c"), null, "Robert De Niro" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("92bad319-e3d1-4818-ab99-57bfdaa68ab4"), "Ação" },
                    { new Guid("54fdf761-83c3-4362-b0fd-8069b49d8313"), "Comédia" },
                    { new Guid("8eb9f73f-4530-497b-95ce-56ba59556564"), "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("91d89dbf-4099-4f8f-b48f-f57cdabcf773"), "Howard Hawks" },
                    { new Guid("636303b9-2906-4f40-8b52-92cdbb687b00"), "Martin Scorsese" },
                    { new Guid("7dd08154-4793-496e-82cd-e2640edfff82"), "Sidney Lumet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("0a9d5004-3c5e-4e70-bda9-26cf5310476c"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("aecd9fdc-c732-4066-a620-c83d931e6893"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("b73b3d56-ce9a-4644-a339-aaf96f26a3ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("54fdf761-83c3-4362-b0fd-8069b49d8313"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8eb9f73f-4530-497b-95ce-56ba59556564"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("92bad319-e3d1-4818-ab99-57bfdaa68ab4"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("636303b9-2906-4f40-8b52-92cdbb687b00"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("7dd08154-4793-496e-82cd-e2640edfff82"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("91d89dbf-4099-4f8f-b48f-f57cdabcf773"));
        }
    }
}
