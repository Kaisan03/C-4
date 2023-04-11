﻿// <auto-generated />
using System;
using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DuAnBanGiayCs4.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Anh", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url1")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url2")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Url3")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Anhs");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ChiTietSanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GiaBan")
                        .HasColumnType("int");

                    b.Property<int>("GiaNhap")
                        .HasColumnType("int");

                    b.Property<Guid>("IdAnh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdLoai")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdNsx")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSize")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAnh");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdLoai");

                    b.HasIndex("IdNsx");

                    b.HasIndex("IdSize");

                    b.HasIndex("IdSp");

                    b.ToTable("ChiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ChucVu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenCv")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChucVus");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.GioHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung")
                        .IsUnique();

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.GioHangChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<Guid>("IdCtsp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdGioHang")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCtsp");

                    b.HasIndex("IdGioHang");

                    b.ToTable("GioHangChiTiets");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdNguoiDung")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdNguoiDung");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.HoaDonChiTiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<Guid>("IdCtsp")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCtsp");

                    b.HasIndex("IdHD");

                    b.ToTable("HoaDonChiTiets");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Loai", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Loais");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.MauSac", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenMau")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MauSacs");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Nsx", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenNsx")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nsxes");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SoSize")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ThanhToan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhuongThucThanhToan")
                        .HasColumnType("int");

                    b.Property<int>("SoTienDaThanhToan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHD");

                    b.ToTable("ThanhToans");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTenDem")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("IdCv")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("NgayCapNhatThongTin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sdt")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("IdCv");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ChiTietSanPham", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.Anh", "Anh")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("IdAnh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.MauSac", "MauSac")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.Loai", "Loai")
                        .WithMany("chiTietSanPhams")
                        .HasForeignKey("IdLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.Nsx", "Nsx")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("IdNsx")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.Size", "Size")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("IdSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.SanPham", "SanPham")
                        .WithMany("ChiTietSanPhams")
                        .HasForeignKey("IdSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anh");

                    b.Navigation("Loai");

                    b.Navigation("MauSac");

                    b.Navigation("Nsx");

                    b.Navigation("SanPham");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.GioHang", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.User", "User")
                        .WithOne("GioHang")
                        .HasForeignKey("DuAnBanGiayCs4.Models.GioHang", "IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.GioHangChiTiet", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.ChiTietSanPham", "ChiTietSanPham")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdCtsp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.GioHang", "GioHang")
                        .WithMany("GioHangChiTiets")
                        .HasForeignKey("IdGioHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietSanPham");

                    b.Navigation("GioHang");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.HoaDon", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.User", "User")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdNguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.HoaDonChiTiet", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.ChiTietSanPham", "ChiTietSanPham")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdCtsp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAnBanGiayCs4.Models.HoaDon", "HoaDon")
                        .WithMany("HoaDonChiTiets")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietSanPham");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ThanhToan", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.HoaDon", "HoaDon")
                        .WithMany("ThanhToans")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.User", b =>
                {
                    b.HasOne("DuAnBanGiayCs4.Models.ChucVu", "ChucVu")
                        .WithMany("Users")
                        .HasForeignKey("IdCv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Anh", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ChiTietSanPham", b =>
                {
                    b.Navigation("GioHangChiTiets");

                    b.Navigation("HoaDonChiTiets");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.ChucVu", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.GioHang", b =>
                {
                    b.Navigation("GioHangChiTiets");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.HoaDon", b =>
                {
                    b.Navigation("HoaDonChiTiets");

                    b.Navigation("ThanhToans");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Loai", b =>
                {
                    b.Navigation("chiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.MauSac", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Nsx", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.Size", b =>
                {
                    b.Navigation("ChiTietSanPhams");
                });

            modelBuilder.Entity("DuAnBanGiayCs4.Models.User", b =>
                {
                    b.Navigation("GioHang")
                        .IsRequired();

                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}
