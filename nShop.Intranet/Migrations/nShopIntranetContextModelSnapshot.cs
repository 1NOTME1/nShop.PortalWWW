﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nShop.Intranet.Data;

#nullable disable

namespace nShop.Intranet.Migrations
{
    [DbContext(typeof(nShopIntranetContext))]
    partial class nShopIntranetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElementZamowienia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CenaJednostkowa")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int>("ZamowienieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("ElementZamowienia");
                });

            modelBuilder.Entity("Producent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SciezkaLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producent");
                });

            modelBuilder.Entity("Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProducentId")
                        .HasColumnType("int");

                    b.Property<string>("SciezkaZdjecia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriaId");

                    b.HasIndex("ProducentId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("Recenzja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UzytkownikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Recenzja");
                });

            modelBuilder.Entity("Rola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rola");
                });

            modelBuilder.Entity("StatusZamowienia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusZamowienia");
                });

            modelBuilder.Entity("Uzytkownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolaId");

                    b.ToTable("Uzytkownik");
                });

            modelBuilder.Entity("Zamowienie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusZamowieniaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("UzytkownikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusZamowieniaId");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("nShop.Intranet.Models.CMS.Aktualnosc", b =>
                {
                    b.Property<int>("IdAktualnosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAktualnosci"));

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdAktualnosci");

                    b.ToTable("Aktualnosc");
                });

            modelBuilder.Entity("nShop.Intranet.Models.CMS.Strona", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStrony"));

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdStrony");

                    b.ToTable("Strona");
                });

            modelBuilder.Entity("nShop.Intranet.Models.Sklep.Kategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("ElementZamowienia", b =>
                {
                    b.HasOne("Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zamowienie", "Zamowienie")
                        .WithMany("ElementyZamowienia")
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("Zamowienie");
                });

            modelBuilder.Entity("Produkt", b =>
                {
                    b.HasOne("nShop.Intranet.Models.Sklep.Kategoria", "Kategoria")
                        .WithMany("Produkty")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Producent", "Producent")
                        .WithMany("Produkty")
                        .HasForeignKey("ProducentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");

                    b.Navigation("Producent");
                });

            modelBuilder.Entity("Recenzja", b =>
                {
                    b.HasOne("Produkt", "Produkt")
                        .WithMany("Recenzje")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uzytkownik", "Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Uzytkownik", b =>
                {
                    b.HasOne("Rola", "Rola")
                        .WithMany("Uzytkownicy")
                        .HasForeignKey("RolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rola");
                });

            modelBuilder.Entity("Zamowienie", b =>
                {
                    b.HasOne("StatusZamowienia", "StatusZamowienia")
                        .WithMany()
                        .HasForeignKey("StatusZamowieniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uzytkownik", "Uzytkownik")
                        .WithMany()
                        .HasForeignKey("UzytkownikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusZamowienia");

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Producent", b =>
                {
                    b.Navigation("Produkty");
                });

            modelBuilder.Entity("Produkt", b =>
                {
                    b.Navigation("Recenzje");
                });

            modelBuilder.Entity("Rola", b =>
                {
                    b.Navigation("Uzytkownicy");
                });

            modelBuilder.Entity("Zamowienie", b =>
                {
                    b.Navigation("ElementyZamowienia");
                });

            modelBuilder.Entity("nShop.Intranet.Models.Sklep.Kategoria", b =>
                {
                    b.Navigation("Produkty");
                });
#pragma warning restore 612, 618
        }
    }
}
