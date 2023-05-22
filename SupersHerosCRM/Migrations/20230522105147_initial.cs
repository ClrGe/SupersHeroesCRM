using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupersHerosCRM.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_heroes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_incidents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hero_incident",
                columns: table => new
                {
                    heroes_id = table.Column<int>(type: "integer", nullable: false),
                    incidents_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hero_incident", x => new { x.heroes_id, x.incidents_id });
                    table.ForeignKey(
                        name: "fk_hero_incident_heroes_heroes_id",
                        column: x => x.heroes_id,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_hero_incident_incidents_incidents_id",
                        column: x => x.incidents_id,
                        principalTable: "Incidents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "Incendie" },
                    { 2, "Accident routier" },
                    { 3, "Accident fluvial" },
                    { 4, "Accident aérien" },
                    { 5, "Eboulement" },
                    { 6, "Invasion de serpents" },
                    { 7, "Fuite de gaz" },
                    { 8, "Manifestation" },
                    { 9, "Braquage" },
                    { 10, "Evasion d’un prisonnier" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_hero_incident_incidents_id",
                table: "hero_incident",
                column: "incidents_id");

            migrationBuilder.CreateIndex(
                name: "ix_heroes_id",
                table: "Heroes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hero_incident");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Incidents");
        }
    }
}
