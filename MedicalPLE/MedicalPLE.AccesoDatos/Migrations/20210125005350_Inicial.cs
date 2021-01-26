using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalPLE.AccesoDatos.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDepartamento = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Eps",
                columns: table => new
                {
                    EpsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEps = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eps", x => x.EpsId);
                });

            migrationBuilder.CreateTable(
                name: "Estadocivil",
                columns: table => new
                {
                    EstadocivilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstadocivil = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadocivil", x => x.EstadocivilId);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    UrlImagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipodoc",
                columns: table => new
                {
                    TipodocId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipodoc = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipodoc", x => x.TipodocId);
                });

            migrationBuilder.CreateTable(
                name: "Tiposangre",
                columns: table => new
                {
                    TiposangreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTiposangre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiposangre", x => x.TiposangreId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    FechaCreacion = table.Column<string>(nullable: true),
                    UrlImagen = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCiudad = table.Column<string>(maxLength: 500, nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipodocId = table.Column<int>(nullable: false),
                    NumeroDocumento = table.Column<string>(maxLength: 200, nullable: false),
                    NombresApellidos = table.Column<string>(maxLength: 500, nullable: false),
                    TiposangreId = table.Column<int>(nullable: false),
                    EstadocivilId = table.Column<int>(nullable: false),
                    Fechanacimiento = table.Column<DateTime>(nullable: true),
                    Datanumeric_18_0 = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    Lugarnacimiento = table.Column<string>(maxLength: 500, nullable: false),
                    Nacionalidad = table.Column<string>(maxLength: 500, nullable: false),
                    GeneroId = table.Column<int>(nullable: false),
                    Embarazo = table.Column<bool>(nullable: false),
                    UltimaMestruacion = table.Column<DateTime>(nullable: true),
                    EpsId = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Barrio = table.Column<string>(maxLength: 300, nullable: false),
                    Correo = table.Column<int>(nullable: false),
                    Fijo = table.Column<string>(maxLength: 100, nullable: false),
                    Celular = table.Column<string>(maxLength: 300, nullable: false),
                    NombreResponsable = table.Column<string>(maxLength: 500, nullable: false),
                    FijoResponsable = table.Column<string>(maxLength: 100, nullable: false),
                    CelularResponsable = table.Column<string>(maxLength: 200, nullable: false),
                    ParentescoResponsable = table.Column<string>(maxLength: 200, nullable: false),
                    NombreReferida = table.Column<string>(maxLength: 500, nullable: false),
                    FijoReferido = table.Column<string>(maxLength: 100, nullable: false),
                    CelularReferido = table.Column<string>(maxLength: 200, nullable: false),
                    ReferidoPor = table.Column<string>(nullable: false),
                    NombreAcompanante = table.Column<string>(maxLength: 500, nullable: false),
                    FijoAcompanante = table.Column<string>(maxLength: 100, nullable: false),
                    CelularAcompanante = table.Column<string>(maxLength: 200, nullable: false),
                    ParentescoAcompanante = table.Column<string>(maxLength: 500, nullable: false),
                    NombreMadreMenor = table.Column<string>(maxLength: 500, nullable: false),
                    CedulaMadreMenor = table.Column<string>(maxLength: 100, nullable: false),
                    TelefonoMadreMenor = table.Column<string>(maxLength: 200, nullable: false),
                    OcupacionMadreMenor = table.Column<string>(maxLength: 300, nullable: false),
                    NombrePadreCuidadorMenor = table.Column<string>(maxLength: 500, nullable: false),
                    CedulaPadreCuidadorMenor = table.Column<string>(maxLength: 200, nullable: false),
                    TelefonoPadreCuidadorMenor = table.Column<string>(maxLength: 200, nullable: false),
                    OcupacionPadreCuidadorMenor = table.Column<string>(maxLength: 200, nullable: false),
                    ParentescoPadreCuidador = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Paciente_Eps_EpsId",
                        column: x => x.EpsId,
                        principalTable: "Eps",
                        principalColumn: "EpsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Estadocivil_EstadocivilId",
                        column: x => x.EstadocivilId,
                        principalTable: "Estadocivil",
                        principalColumn: "EstadocivilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Tipodoc_TipodocId",
                        column: x => x.TipodocId,
                        principalTable: "Tipodoc",
                        principalColumn: "TipodocId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Tiposangre_TiposangreId",
                        column: x => x.TiposangreId,
                        principalTable: "Tiposangre",
                        principalColumn: "TiposangreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_CategoriaId",
                table: "Articulo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_DepartamentoId",
                table: "Ciudad",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EpsId",
                table: "Paciente",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EstadocivilId",
                table: "Paciente",
                column: "EstadocivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_GeneroId",
                table: "Paciente",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_TipodocId",
                table: "Paciente",
                column: "TipodocId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_TiposangreId",
                table: "Paciente",
                column: "TiposangreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Eps");

            migrationBuilder.DropTable(
                name: "Estadocivil");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Tipodoc");

            migrationBuilder.DropTable(
                name: "Tiposangre");
        }
    }
}
