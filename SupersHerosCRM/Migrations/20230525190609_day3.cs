using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SupersHerosCRM.Migrations
{
    /// <inheritdoc />
    public partial class day3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(type: "text", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    incident_id = table.Column<int>(type: "integer", nullable: false),
                    hero_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false, defaultValue: "pending"),
                    created_at = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    incident_id = table.Column<int[]>(type: "integer[]", maxLength: 3, nullable: true)
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
                name: "hero_event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "integer", nullable: false),
                    hero_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hero_event", x => new { x.event_id, x.hero_id });
                    table.ForeignKey(
                        name: "fk_hero_event_events_event_id",
                        column: x => x.event_id,
                        principalTable: "Events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_hero_event_heroes_hero_id",
                        column: x => x.hero_id,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_incident",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "integer", nullable: false),
                    incident_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_incident", x => new { x.event_id, x.incident_id });
                    table.ForeignKey(
                        name: "fk_event_incident_events_event_id",
                        column: x => x.event_id,
                        principalTable: "Events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_event_incident_incidents_incident_id",
                        column: x => x.incident_id,
                        principalTable: "Incidents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hero_incident",
                columns: table => new
                {
                    hero_id = table.Column<int>(type: "integer", nullable: false),
                    incident_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hero_incident", x => new { x.hero_id, x.incident_id });
                    table.ForeignKey(
                        name: "fk_hero_incident_heroes_hero_id",
                        column: x => x.hero_id,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_hero_incident_incidents_incident_id",
                        column: x => x.incident_id,
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
                name: "ix_event_incident_incident_id",
                table: "event_incident",
                column: "incident_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_id",
                table: "Events",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_hero_event_hero_id",
                table: "hero_event",
                column: "hero_id");

            migrationBuilder.CreateIndex(
                name: "ix_hero_incident_incident_id",
                table: "hero_incident",
                column: "incident_id");

            migrationBuilder.CreateIndex(
                name: "ix_heroes_id",
                table: "Heroes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_incident");

            migrationBuilder.DropTable(
                name: "hero_event");

            migrationBuilder.DropTable(
                name: "hero_incident");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Incidents");
        }
    }
}
