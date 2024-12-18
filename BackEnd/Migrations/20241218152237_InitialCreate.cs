﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnelPowerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anéis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Poder = table.Column<string>(type: "TEXT", nullable: false),
                    Portador = table.Column<string>(type: "TEXT", nullable: false),
                    ForjadoPor = table.Column<string>(type: "TEXT", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anéis", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anéis");
        }
    }
}
