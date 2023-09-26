using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "monHocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "khoaMons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhoa = table.Column<int>(type: "int", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: true),
                    MaMH = table.Column<int>(type: "int", nullable: false),
                    TinChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongSoTiet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaMons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khoaMons_khoas_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "khoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiSo = table.Column<int>(type: "int", nullable: false),
                    MaKhoa = table.Column<int>(type: "int", nullable: false),
                    khoaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lops_khoas_khoaId",
                        column: x => x.khoaId,
                        principalTable: "khoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sinhViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HocBong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLop = table.Column<int>(type: "int", nullable: false),
                    LopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sinhViens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sinhViens_lops_LopId",
                        column: x => x.LopId,
                        principalTable: "lops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ketQuas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSinhVien = table.Column<int>(type: "int", nullable: false),
                    SinhVienId = table.Column<int>(type: "int", nullable: true),
                    MaMonHoc = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<int>(type: "int", nullable: true),
                    LanThi = table.Column<int>(type: "int", nullable: false),
                    DiemThi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ketQuas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ketQuas_monHocs_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "monHocs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ketQuas_sinhViens_SinhVienId",
                        column: x => x.SinhVienId,
                        principalTable: "sinhViens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ketQuas_MonHocId",
                table: "ketQuas",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_ketQuas_SinhVienId",
                table: "ketQuas",
                column: "SinhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_khoaMons_KhoaId",
                table: "khoaMons",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_lops_khoaId",
                table: "lops",
                column: "khoaId");

            migrationBuilder.CreateIndex(
                name: "IX_sinhViens_LopId",
                table: "sinhViens",
                column: "LopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ketQuas");

            migrationBuilder.DropTable(
                name: "khoaMons");

            migrationBuilder.DropTable(
                name: "monHocs");

            migrationBuilder.DropTable(
                name: "sinhViens");

            migrationBuilder.DropTable(
                name: "lops");

            migrationBuilder.DropTable(
                name: "khoas");
        }
    }
}
