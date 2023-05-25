﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SupersHerosCRM.Data;

#nullable disable

namespace SupersHerosCRM.Migrations
{
    [DbContext(typeof(SupersHerosCRMDbContext))]
    [Migration("20230525190609_day3")]
    partial class day3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventIncident", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<int>("IncidentId")
                        .HasColumnType("integer")
                        .HasColumnName("incident_id");

                    b.HasKey("EventId", "IncidentId")
                        .HasName("pk_event_incident");

                    b.HasIndex("IncidentId")
                        .HasDatabaseName("ix_event_incident_incident_id");

                    b.ToTable("event_incident", (string)null);
                });

            modelBuilder.Entity("HeroEvent", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.HasKey("EventId", "HeroId")
                        .HasName("pk_hero_event");

                    b.HasIndex("HeroId")
                        .HasDatabaseName("ix_hero_event_hero_id");

                    b.ToTable("hero_event", (string)null);
                });

            modelBuilder.Entity("HeroIncident", b =>
                {
                    b.Property<int>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.Property<int>("IncidentId")
                        .HasColumnType("integer")
                        .HasColumnName("incident_id");

                    b.HasKey("HeroId", "IncidentId")
                        .HasName("pk_hero_incident");

                    b.HasIndex("IncidentId")
                        .HasDatabaseName("ix_hero_incident_incident_id");

                    b.ToTable("hero_incident", (string)null);
                });

            modelBuilder.Entity("SupersHerosCRM.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(0)
                        .HasColumnType("timestamp(0) with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int?>("HeroId")
                        .HasColumnType("integer")
                        .HasColumnName("hero_id");

                    b.Property<int>("IncidentId")
                        .HasColumnType("integer")
                        .HasColumnName("incident_id");

                    b.Property<double?>("Latitude")
                        .IsRequired()
                        .HasColumnType("double precision")
                        .HasColumnName("latitude");

                    b.Property<double?>("Longitude")
                        .IsRequired()
                        .HasColumnType("double precision")
                        .HasColumnName("longitude");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("pending")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_events");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_events_id");

                    b.ToTable("Events", (string)null);
                });

            modelBuilder.Entity("SupersHerosCRM.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<int[]>("IncidentId")
                        .HasMaxLength(3)
                        .HasColumnType("integer[]")
                        .HasColumnName("incident_id");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("latitude");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_heroes");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_heroes_id");

                    b.ToTable("Heroes", (string)null);
                });

            modelBuilder.Entity("SupersHerosCRM.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_incidents");

                    b.ToTable("Incidents", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Incendie"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Accident routier"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Accident fluvial"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Accident aérien"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Eboulement"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Invasion de serpents"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Fuite de gaz"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Manifestation"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Braquage"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Evasion d’un prisonnier"
                        });
                });

            modelBuilder.Entity("EventIncident", b =>
                {
                    b.HasOne("SupersHerosCRM.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_event_incident_events_event_id");

                    b.HasOne("SupersHerosCRM.Models.Incident", null)
                        .WithMany()
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_event_incident_incidents_incident_id");
                });

            modelBuilder.Entity("HeroEvent", b =>
                {
                    b.HasOne("SupersHerosCRM.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_hero_event_events_event_id");

                    b.HasOne("SupersHerosCRM.Models.Hero", null)
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_hero_event_heroes_hero_id");
                });

            modelBuilder.Entity("HeroIncident", b =>
                {
                    b.HasOne("SupersHerosCRM.Models.Hero", null)
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_hero_incident_heroes_hero_id");

                    b.HasOne("SupersHerosCRM.Models.Incident", null)
                        .WithMany()
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_hero_incident_incidents_incident_id");
                });
#pragma warning restore 612, 618
        }
    }
}