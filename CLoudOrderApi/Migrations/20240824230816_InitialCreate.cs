using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CloudOrderApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    email = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("client_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "os",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("os_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    is_paid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orser_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clouds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    os = table.Column<int>(type: "integer", nullable: false),
                    cores_number = table.Column<int>(type: "integer", nullable: false),
                    ram_volume = table.Column<int>(type: "integer", nullable: false),
                    hdd_volume = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cloud_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_clouds_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clouds_os_os",
                        column: x => x.os,
                        principalTable: "os",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_email",
                table: "clients",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clouds_order_id",
                table: "clouds",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clouds_os",
                table: "clouds",
                column: "os");

            migrationBuilder.CreateIndex(
                name: "IX_orders_client_id",
                table: "orders",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clouds");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "os");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
