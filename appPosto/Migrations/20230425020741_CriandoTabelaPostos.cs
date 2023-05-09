using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appPosto.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaPostos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoGasolinaComum = table.Column<float>(type: "real", nullable: false),
                    PrecoGasolinaAditivada = table.Column<float>(type: "real", nullable: false),
                    PrecoDiesel = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postos");
        }
    }
}
