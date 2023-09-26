﻿// <auto-generated />
using System;
using Infrastructure.DataEx;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Design.Entity.KetQua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DiemThi")
                        .HasColumnType("float");

                    b.Property<int>("LanThi")
                        .HasColumnType("int");

                    b.Property<int>("MaMonHoc")
                        .HasColumnType("int");

                    b.Property<int>("MaSinhVien")
                        .HasColumnType("int");

                    b.Property<int?>("MonHocId")
                        .HasColumnType("int");

                    b.Property<int?>("SinhVienId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonHocId");

                    b.HasIndex("SinhVienId");

                    b.ToTable("ketQuas");
                });

            modelBuilder.Entity("Design.Entity.Khoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("khoas");
                });

            modelBuilder.Entity("Design.Entity.KhoaMon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("KhoaId")
                        .HasColumnType("int");

                    b.Property<int>("MaKhoa")
                        .HasColumnType("int");

                    b.Property<int>("MaMH")
                        .HasColumnType("int");

                    b.Property<string>("TinChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TongSoTiet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KhoaId");

                    b.ToTable("khoaMons");
                });

            modelBuilder.Entity("Design.Entity.Lop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaKhoa")
                        .HasColumnType("int");

                    b.Property<int>("SiSo")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("khoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("khoaId");

                    b.ToTable("lops");
                });

            modelBuilder.Entity("Design.Entity.MonHoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenMH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("monHocs");
                });

            modelBuilder.Entity("Design.Entity.SinhVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HocBong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LopId")
                        .HasColumnType("int");

                    b.Property<int>("MaLop")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiSinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSinhVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LopId");

                    b.ToTable("sinhViens");
                });

            modelBuilder.Entity("Design.Entity.KetQua", b =>
                {
                    b.HasOne("Design.Entity.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("MonHocId");

                    b.HasOne("Design.Entity.SinhVien", "SinhVien")
                        .WithMany()
                        .HasForeignKey("SinhVienId");

                    b.Navigation("MonHoc");

                    b.Navigation("SinhVien");
                });

            modelBuilder.Entity("Design.Entity.KhoaMon", b =>
                {
                    b.HasOne("Design.Entity.Khoa", "Khoa")
                        .WithMany()
                        .HasForeignKey("KhoaId");

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("Design.Entity.Lop", b =>
                {
                    b.HasOne("Design.Entity.Khoa", "khoa")
                        .WithMany()
                        .HasForeignKey("khoaId");

                    b.Navigation("khoa");
                });

            modelBuilder.Entity("Design.Entity.SinhVien", b =>
                {
                    b.HasOne("Design.Entity.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("LopId");

                    b.Navigation("Lop");
                });
#pragma warning restore 612, 618
        }
    }
}