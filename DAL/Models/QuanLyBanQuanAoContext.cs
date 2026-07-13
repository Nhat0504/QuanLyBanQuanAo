using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class QuanLyBanQuanAoContext : DbContext
{
    public QuanLyBanQuanAoContext()
    {
    }

    public QuanLyBanQuanAoContext(DbContextOptions<QuanLyBanQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KichThuoc> KichThuocs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-6UAVURDN\\SQLEXPRESS;Database=QuanLyBanQuanAo;Trusted_Connection=True; TrustServerCertificate =True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__ChiTietH__1E4FA771EDD1EEC4");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaCthd)
                .ValueGeneratedNever()
                .HasColumnName("MaCTHD");
            entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MaChiTietSp).HasColumnName("MaChiTietSP");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SoLuong]*[DonGia])", false)
                .HasColumnType("decimal(21, 2)");

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaChiTietSp)
                .HasConstraintName("FK__ChiTietHo__MaChi__4D94879B");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK__ChiTietHo__MaHoa__4CA06362");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp).HasName("PK__ChiTietS__651D9057FE528D0E");

            entity.ToTable("ChiTietSanPham");

            entity.Property(e => e.MaChiTietSp)
                .ValueGeneratedNever()
                .HasColumnName("MaChiTietSP");

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK__ChiTietSa__MaKic__4222D4EF");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK__ChiTietSa__MaMau__412EB0B6");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK__ChiTietSa__MaSan__403A8C7D");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13B6334F1CD");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon).ValueGeneratedNever();
            entity.Property(e => e.TongTien).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDon__MaKhachH__48CFD27E");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDon__MaNhanVi__49C3F6B7");

            entity.HasOne(d => d.MaThanhToanNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaThanhToan)
                .HasConstraintName("FK__HoaDon__MaThanhT__534D60F1");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E50D25AB01");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
        });

        modelBuilder.Entity<KichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__KichThuo__22BFD66444A194C9");

            entity.ToTable("KichThuoc");

            entity.Property(e => e.MaKichThuoc).ValueGeneratedNever();
            entity.Property(e => e.TenKichThuoc).HasMaxLength(10);
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSp).HasName("PK__LoaiSanP__1224CA7C38FEB339");

            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.MaLoaiSp)
                .ValueGeneratedNever()
                .HasColumnName("MaLoaiSP");
            entity.Property(e => e.TenLoaiSp)
                .HasMaxLength(50)
                .HasColumnName("TenLoaiSP");
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac).HasName("PK__MauSac__B9A9116276E9BED4");

            entity.ToTable("MauSac");

            entity.Property(e => e.MaMauSac).ValueGeneratedNever();
            entity.Property(e => e.TenMauSac).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47711EA818");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D4435E9D1");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSanPham).ValueGeneratedNever();
            entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");
            entity.Property(e => e.TrangThai).HasMaxLength(255);
            entity.Property(e => e.TenSanPham).HasMaxLength(50);

            entity.HasOne(d => d.MaLoaiSpNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoaiSp)
                .HasConstraintName("FK__SanPham__MaLoaiS__398D8EEE");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__TaiKhoan__77B2CA4710EE40B2");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.MaNhanVienNavigation).WithOne(p => p.TaiKhoan)
                .HasForeignKey<TaiKhoan>(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaNhan__52593CB8");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__ThanhToa__D4B25844BE1DCCE9");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.MaThanhToan).ValueGeneratedNever();
            entity.Property(e => e.TenHinhThuc).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
