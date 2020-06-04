﻿// <auto-generated />
using System;
using JustAMusician.Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JustAMusician.Backend.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20200604152737_OwnerIdFix")]
    partial class OwnerIdFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JustAMusician.Backend.Entities.Band", b =>
                {
                    b.Property<int>("BandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bandId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<int?>("leaderId");

                    b.HasKey("BandId");

                    b.HasIndex("leaderId");

                    b.ToTable("bands");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("genreId");

                    b.Property<int?>("BandId");

                    b.Property<int?>("GenreId1");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.Property<int?>("UserId");

                    b.HasKey("GenreId");

                    b.HasIndex("BandId");

                    b.HasIndex("GenreId1");

                    b.HasIndex("UserId");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("instrumentId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<int?>("TypeInstrumentTypeId");

                    b.Property<int?>("UserId");

                    b.HasKey("InstrumentId");

                    b.HasIndex("TypeInstrumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("instruments");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.InstrumentType", b =>
                {
                    b.Property<int>("InstrumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("instrumentTypeId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type");

                    b.HasKey("InstrumentTypeId");

                    b.ToTable("instrumentType");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("linkId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnName("url");

                    b.Property<int?>("UserId");

                    b.HasKey("LinkId");

                    b.HasIndex("UserId");

                    b.ToTable("links");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("orderId");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnName("body");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnName("createdAt");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updatedAt");

                    b.Property<int>("ownerId");

                    b.HasKey("OrderId");

                    b.HasIndex("ownerId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Relations.BandGenre", b =>
                {
                    b.Property<int>("BandId");

                    b.Property<int>("GenreId");

                    b.Property<int>("Id");

                    b.HasKey("BandId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BandGenre");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Relations.UserBand", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BandId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "BandId");

                    b.HasIndex("BandId");

                    b.ToTable("UserBand");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Relations.UserGenre", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("GenreId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("UserGenre");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tagId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<int?>("OrderId");

                    b.HasKey("TagId");

                    b.HasIndex("OrderId");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userId");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnName("about");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnName("nickname");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("passwordHash");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnName("salt")
                        .HasMaxLength(16);

                    b.Property<DateTime>("SignedUpAt")
                        .HasColumnName("signedUpAt");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Band", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.User", "Leader")
                        .WithMany()
                        .HasForeignKey("leaderId");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Genre", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.Band")
                        .WithMany("Genres")
                        .HasForeignKey("BandId");

                    b.HasOne("JustAMusician.Backend.Entities.Genre")
                        .WithMany("SubGenres")
                        .HasForeignKey("GenreId1");

                    b.HasOne("JustAMusician.Backend.Entities.User")
                        .WithMany("Genres")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Instrument", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.InstrumentType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeInstrumentTypeId");

                    b.HasOne("JustAMusician.Backend.Entities.User")
                        .WithMany("Instruments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Link", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.User")
                        .WithMany("Links")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Order", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("ownerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Relations.BandGenre", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.Band", "Band")
                        .WithMany("BandGenres")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustAMusician.Backend.Entities.Genre", "Genre")
                        .WithMany("BandGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Relations.UserBand", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.Band", "Band")
                        .WithMany("UserBands")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustAMusician.Backend.Entities.User", "User")
                        .WithMany("UserBands")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Relations.UserGenre", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.Genre", "Genre")
                        .WithMany("UserGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustAMusician.Backend.Entities.User", "User")
                        .WithMany("UserGenres")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustAMusician.Backend.Entities.Tag", b =>
                {
                    b.HasOne("JustAMusician.Backend.Entities.Order")
                        .WithMany("Tags")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
