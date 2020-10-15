using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstWebSite.Migrations
{
    public partial class hh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    MaLoai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    MaLoaiCha = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.MaLoai);
                    table.ForeignKey(
                        name: "FK_Loai_Loai_MaLoaiCha",
                        column: x => x.MaLoaiCha,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagKey = table.Column<string>(maxLength: 50, nullable: false),
                    TagValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagKey);
                });

            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHangHoa = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    TenHangHoa = table.Column<string>(maxLength: 100, nullable: false),
                    NgaySx = table.Column<DateTime>(nullable: false),
                    Hinh = table.Column<string>(nullable: true),
                    DonGia = table.Column<double>(nullable: false),
                    GiaBan = table.Column<double>(nullable: false),
                    Mota = table.Column<string>(maxLength: 200, nullable: true),
                    ChiTiet = table.Column<string>(nullable: true),
                    GiamGia = table.Column<double>(nullable: false),
                    DiemReview = table.Column<double>(nullable: true),
                    MaLoai = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHangHoa);
                    table.ForeignKey(
                        name: "FK_HangHoa_Loai_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loai",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HangHoaTag",
                columns: table => new
                {
                    TagKey = table.Column<string>(nullable: false),
                    MaHangHoa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoaTag", x => new { x.TagKey, x.MaHangHoa });
                    table.ForeignKey(
                        name: "FK_HangHoaTag_HangHoa_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangHoaTag_Tag_TagKey",
                        column: x => x.TagKey,
                        principalTable: "Tag",
                        principalColumn: "TagKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HinhPhus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    MaHangHoa = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhPhus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HinhPhus_HangHoa_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    IdR = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Criteria = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    HangHoaMaHangHoa = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.IdR);
                    table.ForeignKey(
                        name: "FK_Reviews_HangHoa_HangHoaMaHangHoa",
                        column: x => x.HangHoaMaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewHangHoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NgayReview = table.Column<DateTime>(nullable: false),
                    DiemReview = table.Column<byte>(nullable: false),
                    TieuChi = table.Column<int>(nullable: false),
                    MaHangHoa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewHangHoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewHangHoas_HangHoa_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HangHoa",
                        principalColumn: "MaHangHoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewHangHoas_Reviews_TieuChi",
                        column: x => x.TieuChi,
                        principalTable: "Reviews",
                        principalColumn: "IdR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_TenHangHoa",
                table: "HangHoa",
                column: "TenHangHoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HangHoaTag_MaHangHoa",
                table: "HangHoaTag",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_HinhPhus_MaHangHoa",
                table: "HinhPhus",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_MaLoaiCha",
                table: "Loai",
                column: "MaLoaiCha");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHangHoas_MaHangHoa",
                table: "ReviewHangHoas",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewHangHoas_TieuChi",
                table: "ReviewHangHoas",
                column: "TieuChi");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HangHoaMaHangHoa",
                table: "Reviews",
                column: "HangHoaMaHangHoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoaTag");

            migrationBuilder.DropTable(
                name: "HinhPhus");

            migrationBuilder.DropTable(
                name: "ReviewHangHoas");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "HangHoa");

            migrationBuilder.DropTable(
                name: "Loai");
        }
    }
}
