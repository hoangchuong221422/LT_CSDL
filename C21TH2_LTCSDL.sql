Create database C21TH2_LTCSDL
GO
USE [C21TH2_LTCSDL]
GO
/****** Object:  Table [dbo].[KETQUA]    Script Date: 2/24/2023 4:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KETQUA](
	[MaSV] [nvarchar](3) NOT NULL,
	[MaMH] [nvarchar](2) NOT NULL,
	[Diem] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 2/24/2023 4:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHOA](
	[MaKH] [nvarchar](2) NOT NULL,
	[TenKH] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 2/24/2023 4:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[MaMH] [nvarchar](2) NOT NULL,
	[TenMH] [nvarchar](45) NULL,
	[SoTiet] [tinyint] NULL,
	[LoaiMH] [bit] NULL,
 CONSTRAINT [PK_MONHOC] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 2/24/2023 4:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SINHVIEN](
	[MaSV] [nvarchar](3) NOT NULL,
	[HoSV] [nvarchar](25) NULL,
	[TenSV] [nvarchar](10) NULL,
	[Phai] [bit] NOT NULL,
	[NgaySinh] [datetime] NULL,
	[NoiSinh] [nvarchar](45) NULL,
	[MaKH] [nvarchar](2) NULL,
	[HocBong] [float] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [Diem]) VALUES (N'A01', N'01', 8)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [Diem]) VALUES (N'A01', N'02', 7)
INSERT [dbo].[KETQUA] ([MaSV], [MaMH], [Diem]) VALUES (N'A03', N'01', 10)
GO
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'AV', N'Anh văn')
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'HH', N'Hoá học')
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'KT', N'Kinh tế học')
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'OT', N'Cơ khí')
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'SV', N'Sinh vật học')
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'TH', N'Tin học')
INSERT [dbo].[KHOA] ([MaKH], [TenKH]) VALUES (N'VL', N'Vật lý')
GO
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'01', N'Triết học đông phương', 30, 0)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'02', N'Toán cao cấp 1', 60, 1)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'03', N'Toán cao cấp 2', 60, 1)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'04', N'Vật lý đại cương', 25, 1)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'05', N'Cơ sở dữ liệu', 45, 0)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'06', N'Lập trình hệ thống', 60, 0)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'07', N'Tiếng Pháp', 30, 1)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'08', N'Tiếng Hoa', 30, 1)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'09', N'Phân tích hệ thống', 35, 0)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'10', N'Tiếng Anh', 30, 0)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'11', N'Lập trình Hướng đối tượng', 35, 1)
INSERT [dbo].[MONHOC] ([MaMH], [TenMH], [SoTiet], [LoaiMH]) VALUES (N'12', N'Âm nhạc', 200, 0)
GO
INSERT [dbo].[SINHVIEN] ([MaSV], [HoSV], [TenSV], [Phai], [NgaySinh], [NoiSinh], [MaKH], [HocBong]) VALUES (N'A01', N'Nguyễn Ngoan', N'Cường', 1, CAST(N'1972-05-06T00:00:00.000' AS DateTime), N'Hà Nội', N'AV', 20000)
INSERT [dbo].[SINHVIEN] ([MaSV], [HoSV], [TenSV], [Phai], [NgaySinh], [NoiSinh], [MaKH], [HocBong]) VALUES (N'A02', N'Lý Anh', N'Huy', 1, CAST(N'1975-01-01T00:00:00.000' AS DateTime), N'TP.HCM', N'AV', 50000)
INSERT [dbo].[SINHVIEN] ([MaSV], [HoSV], [TenSV], [Phai], [NgaySinh], [NoiSinh], [MaKH], [HocBong]) VALUES (N'A03', N'Lê Khắc', N'Dung', 0, CAST(N'1974-08-12T00:00:00.000' AS DateTime), N'Bình Định', N'TH', 45000)
GO
