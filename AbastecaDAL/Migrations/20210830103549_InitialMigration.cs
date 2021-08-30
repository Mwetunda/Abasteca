using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbastecaDAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operadoras",
                columns: table => new
                {
                    OperadoraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadoras", x => x.OperadoraID);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataActualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimoLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    MunicipioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.MunicipioID);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    GerenteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.GerenteID);
                    table.ForeignKey(
                        name: "FK_Gerentes_Usuarios_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bombas",
                columns: table => new
                {
                    BombaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperadoraID = table.Column<int>(type: "int", nullable: false),
                    MunicipioID = table.Column<int>(type: "int", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinal = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataActualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombas", x => x.BombaID);
                    table.ForeignKey(
                        name: "FK_Bombas_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bombas_Operadoras_OperadoraID",
                        column: x => x.OperadoraID,
                        principalTable: "Operadoras",
                        principalColumn: "OperadoraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Condutors",
                columns: table => new
                {
                    CondutorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    MunicipioID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutors", x => x.CondutorID);
                    table.ForeignKey(
                        name: "FK_Condutors_Municipios_MunicipioID",
                        column: x => x.MunicipioID,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Condutors_Usuarios_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    SupervisorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    BombaID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BombaID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.SupervisorID);
                    table.ForeignKey(
                        name: "FK_Supervisors_Bombas_BombaID1",
                        column: x => x.BombaID1,
                        principalTable: "Bombas",
                        principalColumn: "BombaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supervisors_Usuarios_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bombas_MunicipioID",
                table: "Bombas",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Bombas_OperadoraID",
                table: "Bombas",
                column: "OperadoraID");

            migrationBuilder.CreateIndex(
                name: "IX_Condutors_MunicipioID",
                table: "Condutors",
                column: "MunicipioID");

            migrationBuilder.CreateIndex(
                name: "IX_Condutors_UsuarioID1",
                table: "Condutors",
                column: "UsuarioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Gerentes_UsuarioID1",
                table: "Gerentes",
                column: "UsuarioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaID",
                table: "Municipios",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_BombaID1",
                table: "Supervisors",
                column: "BombaID1");

            migrationBuilder.CreateIndex(
                name: "IX_Supervisors_UsuarioID1",
                table: "Supervisors",
                column: "UsuarioID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condutors");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropTable(
                name: "Bombas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Operadoras");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
