﻿// <auto-generated />
using System;
using Confab.Modules.Attendances.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Confab.Modules.Attendances.Infrastructure.EF.Migrations
{
    [DbContext(typeof(AttendancesDbContext))]
    partial class AttendancesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("attendances")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.AttendableEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ConferenceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AttendableEvents", "attendances");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttendableEventId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ParticipantId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SlotId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Attendances", "attendances");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ConferenceId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "ConferenceId")
                        .IsUnique();

                    b.ToTable("Participants", "attendances");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.Slot", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AttendableEventId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParticipantId")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttendableEventId");

                    b.ToTable("Slots", "attendances");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("Confab.Modules.Attendances.Domain.Entities.Participant", null)
                        .WithMany("Attendances")
                        .HasForeignKey("ParticipantId");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.Slot", b =>
                {
                    b.HasOne("Confab.Modules.Attendances.Domain.Entities.AttendableEvent", null)
                        .WithMany("Slots")
                        .HasForeignKey("AttendableEventId");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.AttendableEvent", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("Confab.Modules.Attendances.Domain.Entities.Participant", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
