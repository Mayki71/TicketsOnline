using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APITicketsOnline.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generos_musicales",
                columns: table => new
                {
                    genero_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos_musicales", x => x.genero_id);
                });

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    pais_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.pais_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "ciudades",
                columns: table => new
                {
                    ciudad_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudades", x => x.ciudad_id);
                    table.ForeignKey(
                        name: "FK_ciudades_paises_pais_id",
                        column: x => x.pais_id,
                        principalTable: "paises",
                        principalColumn: "pais_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rol_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_rol_id",
                        column: x => x.rol_id,
                        principalTable: "roles",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    orden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    fecha_orden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.orden_id);
                    table.ForeignKey(
                        name: "FK_ordenes_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizadores",
                columns: table => new
                {
                    organizador_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    nombre_empresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizadores", x => x.organizador_id);
                    table.ForeignKey(
                        name: "FK_organizadores_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    pago_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orden_id = table.Column<int>(type: "int", nullable: false),
                    metodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ultimos_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marca_tarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.pago_id);
                    table.ForeignKey(
                        name: "FK_pagos_ordenes_orden_id",
                        column: x => x.orden_id,
                        principalTable: "ordenes",
                        principalColumn: "orden_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "conciertos",
                columns: table => new
                {
                    concierto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ciudad_id = table.Column<int>(type: "int", nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    organizador_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conciertos", x => x.concierto_id);
                    table.ForeignKey(
                        name: "FK_conciertos_ciudades_ciudad_id",
                        column: x => x.ciudad_id,
                        principalTable: "ciudades",
                        principalColumn: "ciudad_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conciertos_generos_musicales_genero_id",
                        column: x => x.genero_id,
                        principalTable: "generos_musicales",
                        principalColumn: "genero_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conciertos_organizadores_organizador_id",
                        column: x => x.organizador_id,
                        principalTable: "organizadores",
                        principalColumn: "organizador_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipos_de_entrada",
                columns: table => new
                {
                    tipo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    concierto_id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_de_entrada", x => x.tipo_id);
                    table.ForeignKey(
                        name: "FK_tipos_de_entrada_conciertos_concierto_id",
                        column: x => x.concierto_id,
                        principalTable: "conciertos",
                        principalColumn: "concierto_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entradas",
                columns: table => new
                {
                    entrada_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orden_id = table.Column<int>(type: "int", nullable: false),
                    tipo_id = table.Column<int>(type: "int", nullable: false),
                    codigo_qr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas", x => x.entrada_id);
                    table.ForeignKey(
                        name: "FK_entradas_ordenes_orden_id",
                        column: x => x.orden_id,
                        principalTable: "ordenes",
                        principalColumn: "orden_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entradas_tipos_de_entrada_tipo_id",
                        column: x => x.tipo_id,
                        principalTable: "tipos_de_entrada",
                        principalColumn: "tipo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudades_pais_id",
                table: "ciudades",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "IX_conciertos_ciudad_id",
                table: "conciertos",
                column: "ciudad_id");

            migrationBuilder.CreateIndex(
                name: "IX_conciertos_genero_id",
                table: "conciertos",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_conciertos_organizador_id",
                table: "conciertos",
                column: "organizador_id");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_orden_id",
                table: "entradas",
                column: "orden_id");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_tipo_id",
                table: "entradas",
                column: "tipo_id");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_usuario_id",
                table: "ordenes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_organizadores_usuario_id",
                table: "organizadores",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_orden_id",
                table: "pagos",
                column: "orden_id");

            migrationBuilder.CreateIndex(
                name: "IX_tipos_de_entrada_concierto_id",
                table: "tipos_de_entrada",
                column: "concierto_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rol_id",
                table: "usuarios",
                column: "rol_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entradas");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "tipos_de_entrada");

            migrationBuilder.DropTable(
                name: "ordenes");

            migrationBuilder.DropTable(
                name: "conciertos");

            migrationBuilder.DropTable(
                name: "ciudades");

            migrationBuilder.DropTable(
                name: "generos_musicales");

            migrationBuilder.DropTable(
                name: "organizadores");

            migrationBuilder.DropTable(
                name: "paises");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
