USE [master]
GO
/****** Object:  Database [QUANLYBANSACH]    Script Date: 1/15/2022 11:52:31 PM ******/
CREATE DATABASE [QUANLYBANSACH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYBANSACH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QUANLYBANSACH.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QUANLYBANSACH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QUANLYBANSACH_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QUANLYBANSACH] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYBANSACH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYBANSACH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYBANSACH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYBANSACH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QUANLYBANSACH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYBANSACH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUANLYBANSACH] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYBANSACH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYBANSACH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYBANSACH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYBANSACH] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QUANLYBANSACH] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QUANLYBANSACH]
GO
/****** Object:  Table [dbo].[chitiethoadon]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethoadon](
	[maHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[maSach] [int] NULL,
	[soLuongBan] [int] NULL,
 CONSTRAINT [PK_tb_chitiethoadon] PRIMARY KEY CLUSTERED 
(
	[maHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ctphieunhap]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ctphieunhap](
	[maPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[maSach] [int] NULL,
	[soLuongNhap] [int] NULL,
	[giaNhap] [int] NULL,
 CONSTRAINT [PK_tb_ctphieunhap] PRIMARY KEY CLUSTERED 
(
	[maPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_hoadon]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_hoadon](
	[maHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[maNhanVien] [int] NULL,
	[sdtKhachHang] [nvarchar](10) NULL,
	[ngayXuat] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_khachhang]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_khachhang](
	[sdtKhachHang] [nvarchar](10) NULL,
	[tenKhachHang] [nvarchar](50) NULL,
	[diaChiKhachHang] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_loaisach]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_loaisach](
	[maLoaiSach] [int] IDENTITY(1,1) NOT NULL,
	[tenLoaiSach] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_loaisach] PRIMARY KEY CLUSTERED 
(
	[maLoaiSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_nhacungcap]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_nhacungcap](
	[maNhaCungCap] [int] IDENTITY(1,1) NOT NULL,
	[tenNhaCungCap] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[sdtNhaCungCap] [nvarchar](50) NULL,
	[chietKhau] [int] NULL,
	[ghiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_nhacungcap] PRIMARY KEY CLUSTERED 
(
	[maNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_NhanVien]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhanVien](
	[maNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[tenNhanVien] [nvarchar](50) NULL,
	[ngaySinh] [date] NULL,
	[sdtNhanVien] [nvarchar](50) NULL,
	[gioiTinh] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_phieunhap]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_phieunhap](
	[maPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[maNhanVien] [int] NULL,
	[maNhaCungCap] [int] NULL,
	[ngayNhap] [date] NULL,
 CONSTRAINT [PK_tb_phieunhap] PRIMARY KEY CLUSTERED 
(
	[maPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_sach]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_sach](
	[maSach] [int] IDENTITY(1,1) NOT NULL,
	[maLoaiSach] [int] NULL,
	[tenSach] [nvarchar](50) NULL,
	[maTacGia] [int] NULL,
	[namXuatBan] [date] NULL,
	[giaSach] [int] NULL,
 CONSTRAINT [PK_tb_sach] PRIMARY KEY CLUSTERED 
(
	[maSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_tacgia]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_tacgia](
	[maTacGia] [int] IDENTITY(1,1) NOT NULL,
	[tenTacGia] [nvarchar](50) NULL,
	[gioiTinh] [nvarchar](50) NULL,
	[ngaySinh] [date] NULL,
	[trinhDo] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_tacgia] PRIMARY KEY CLUSTERED 
(
	[maTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_taikhoan]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_taikhoan](
	[userName] [nvarchar](50) NOT NULL,
	[passWord] [nvarchar](50) NULL,
	[position] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Hoadon]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Hoadon] AS
SELECT tenSach, giaSach
FROM tb_sach
WHERE maSach=1;
GO
/****** Object:  View [dbo].[v_CTPX]    Script Date: 1/15/2022 11:52:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_CTPX] as 
 SELECT tb_hoadon.maHoaDon, tb_NhanVien.tenNhanVien,tb_khachhang.tenKhachHang,tb_hoadon.ngayXuat,tb_sach.tenSach,tb_sach.giaSach, tb_chitiethoadon.soLuongBan, 
 (tb_chitiethoadon.soLuongBan*tb_sach.giaSach) as thanhTien,
 

 (Select Sum(tb_sach.giaSach* tb_chitiethoadon.soLuongBan) from tb_chitiethoadon,tb_sach where tb_sach.maSach=tb_chitiethoadon.maSach) as TongTien

 from
  tb_hoadon,tb_NhanVien,tb_khachhang,tb_sach,tb_chitiethoadon 
 where  
  tb_hoadon.maHoaDon=tb_chitiethoadon.maHoaDon and tb_hoadon.maNhanVien= tb_NhanVien.maNhanVien and tb_hoadon.sdtKhachHang=tb_khachhang.sdtKhachHang and tb_sach.maSach=tb_chitiethoadon.maSach
GO
ALTER TABLE [dbo].[chitiethoadon]  WITH CHECK ADD  CONSTRAINT [FK_tb_chitiethoadon_tb_sach] FOREIGN KEY([maSach])
REFERENCES [dbo].[tb_sach] ([maSach])
GO
ALTER TABLE [dbo].[chitiethoadon] CHECK CONSTRAINT [FK_tb_chitiethoadon_tb_sach]
GO
ALTER TABLE [dbo].[tb_ctphieunhap]  WITH CHECK ADD  CONSTRAINT [FK_tb_ctphieunhap_tb_phieunhap] FOREIGN KEY([maPhieuNhap])
REFERENCES [dbo].[tb_phieunhap] ([maPhieuNhap])
GO
ALTER TABLE [dbo].[tb_ctphieunhap] CHECK CONSTRAINT [FK_tb_ctphieunhap_tb_phieunhap]
GO
ALTER TABLE [dbo].[tb_ctphieunhap]  WITH CHECK ADD  CONSTRAINT [FK_tb_ctphieunhap_tb_sach] FOREIGN KEY([maSach])
REFERENCES [dbo].[tb_sach] ([maSach])
GO
ALTER TABLE [dbo].[tb_ctphieunhap] CHECK CONSTRAINT [FK_tb_ctphieunhap_tb_sach]
GO
ALTER TABLE [dbo].[tb_hoadon]  WITH CHECK ADD  CONSTRAINT [FK_tb_hoadon_tb_NhanVien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[tb_NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[tb_hoadon] CHECK CONSTRAINT [FK_tb_hoadon_tb_NhanVien]
GO
ALTER TABLE [dbo].[tb_phieunhap]  WITH CHECK ADD  CONSTRAINT [FK_tb_phieunhap_tb_nhacungcap] FOREIGN KEY([maNhaCungCap])
REFERENCES [dbo].[tb_nhacungcap] ([maNhaCungCap])
GO
ALTER TABLE [dbo].[tb_phieunhap] CHECK CONSTRAINT [FK_tb_phieunhap_tb_nhacungcap]
GO
ALTER TABLE [dbo].[tb_phieunhap]  WITH CHECK ADD  CONSTRAINT [FK_tb_phieunhap_tb_NhanVien] FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[tb_NhanVien] ([maNhanVien])
GO
ALTER TABLE [dbo].[tb_phieunhap] CHECK CONSTRAINT [FK_tb_phieunhap_tb_NhanVien]
GO
ALTER TABLE [dbo].[tb_sach]  WITH CHECK ADD  CONSTRAINT [FK_tb_sach_tb_loaisach] FOREIGN KEY([maLoaiSach])
REFERENCES [dbo].[tb_loaisach] ([maLoaiSach])
GO
ALTER TABLE [dbo].[tb_sach] CHECK CONSTRAINT [FK_tb_sach_tb_loaisach]
GO
ALTER TABLE [dbo].[tb_sach]  WITH CHECK ADD  CONSTRAINT [FK_tb_sach_tb_tacgia] FOREIGN KEY([maTacGia])
REFERENCES [dbo].[tb_tacgia] ([maTacGia])
GO
ALTER TABLE [dbo].[tb_sach] CHECK CONSTRAINT [FK_tb_sach_tb_tacgia]
GO
USE [master]
GO
ALTER DATABASE [QUANLYBANSACH] SET  READ_WRITE 
GO
