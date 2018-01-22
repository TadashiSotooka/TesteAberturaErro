using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TesteAberturaErro.Migrations
{
    public partial class Imagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Erros",
                newName: "IdErro");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Erros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Erros");

            migrationBuilder.RenameColumn(
                name: "IdErro",
                table: "Erros",
                newName: "ID");
        }
    }
}
