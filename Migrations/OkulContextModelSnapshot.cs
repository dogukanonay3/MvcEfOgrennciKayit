﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcEf;

#nullable disable

namespace MvcEf.Migrations
{
    [DbContext(typeof(OkulContext))]
    partial class OkulContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KursOgrenci", b =>
                {
                    b.Property<int>("KurslarId")
                        .HasColumnType("int");

                    b.Property<int>("OgrencilerId")
                        .HasColumnType("int");

                    b.HasKey("KurslarId", "OgrencilerId");

                    b.HasIndex("OgrencilerId");

                    b.ToTable("KursOgrenci", (string)null);
                });

            modelBuilder.Entity("MvcEf.Models.Ders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Ders");
                });

            modelBuilder.Entity("MvcEf.Models.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DersId")
                        .HasColumnType("int");

                    b.Property<string>("GrupKodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kapasite")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DersId");

                    b.ToTable("Kurs");
                });

            modelBuilder.Entity("MvcEf.Models.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdiSoyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("OgrenciNo")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Ogrenci");
                });

            modelBuilder.Entity("KursOgrenci", b =>
                {
                    b.HasOne("MvcEf.Models.Kurs", null)
                        .WithMany()
                        .HasForeignKey("KurslarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcEf.Models.Ogrenci", null)
                        .WithMany()
                        .HasForeignKey("OgrencilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MvcEf.Models.Kurs", b =>
                {
                    b.HasOne("MvcEf.Models.Ders", "Ders")
                        .WithMany()
                        .HasForeignKey("DersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ders");
                });
#pragma warning restore 612, 618
        }
    }
}