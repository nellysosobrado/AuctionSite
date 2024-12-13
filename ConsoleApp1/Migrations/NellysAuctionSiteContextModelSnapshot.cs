﻿// <auto-generated />
using System;
using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBFirstDemo.Migrations
{
    [DbContext(typeof(NellysAuctionSiteContext))]
    partial class NellysAuctionSiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsoleApp1.Data.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("endDate");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("startDate");

                    b.Property<decimal>("StartingPrice")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("startingPrice");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Advert", (string)null);
                });

            modelBuilder.Entity("ConsoleApp1.Data.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bid", (string)null);
                });

            modelBuilder.Entity("ConsoleApp1.Data.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvertId")
                        .HasColumnType("int")
                        .HasColumnName("advert_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("ShowFirst")
                        .HasColumnType("bit")
                        .HasColumnName("showFirst");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("AdvertId");

                    b.ToTable("Photo", (string)null);
                });

            modelBuilder.Entity("ConsoleApp1.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int")
                        .HasColumnName("postalCode");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("street");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ConsoleApp1.Data.UserHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(39)
                        .HasColumnType("nvarchar(39)")
                        .HasColumnName("ipAddress");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserHistory", (string)null);
                });

            modelBuilder.Entity("ConsoleApp1.Data.Advert", b =>
                {
                    b.HasOne("ConsoleApp1.Data.User", "User")
                        .WithMany("Adverts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Advert_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleApp1.Data.Bid", b =>
                {
                    b.HasOne("ConsoleApp1.Data.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Bid_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleApp1.Data.Photo", b =>
                {
                    b.HasOne("ConsoleApp1.Data.Advert", "Advert")
                        .WithMany("Photos")
                        .HasForeignKey("AdvertId")
                        .IsRequired()
                        .HasConstraintName("FK_Photo_Advert");

                    b.Navigation("Advert");
                });

            modelBuilder.Entity("ConsoleApp1.Data.UserHistory", b =>
                {
                    b.HasOne("ConsoleApp1.Data.User", "User")
                        .WithMany("UserHistories")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserHistory_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleApp1.Data.Advert", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("ConsoleApp1.Data.User", b =>
                {
                    b.Navigation("Adverts");

                    b.Navigation("Bids");

                    b.Navigation("UserHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
