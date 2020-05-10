﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlexRipper.Infrastructure.Persistence;

namespace PlexRipper.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PlexRipperDbContext))]
    [Migration("20200505170157_UpdatedAccounts")]
    partial class UpdatedAccounts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("PlexRipper.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.Plex.PlexAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthenticationToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ConfirmedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("ForumId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasPassword")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uuid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("PlexAccounts");
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.Plex.PlexAccountServer", b =>
                {
                    b.Property<long>("PlexAccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlexServerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlexAccountId", "PlexServerId");

                    b.HasIndex("PlexServerId");

                    b.ToTable("PlexAccountServers");
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.Plex.PlexServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccessToken")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Home")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Host")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocalAddresses")
                        .HasColumnType("TEXT");

                    b.Property<string>("MachineIdentifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Owned")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Scheme")
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceTitle")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Synced")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PlexServers");
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("ListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Reminder")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Colour")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.Plex.PlexAccount", b =>
                {
                    b.HasOne("PlexRipper.Domain.Entities.Account", "Account")
                        .WithOne("PlexAccount")
                        .HasForeignKey("PlexRipper.Domain.Entities.Plex.PlexAccount", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.Plex.PlexAccountServer", b =>
                {
                    b.HasOne("PlexRipper.Domain.Entities.Plex.PlexAccount", "PlexAccount")
                        .WithMany("PlexAccountServers")
                        .HasForeignKey("PlexAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlexRipper.Domain.Entities.Plex.PlexServer", "PlexServer")
                        .WithMany("PlexAccountServers")
                        .HasForeignKey("PlexServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlexRipper.Domain.Entities.TodoItem", b =>
                {
                    b.HasOne("PlexRipper.Domain.Entities.TodoList", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}