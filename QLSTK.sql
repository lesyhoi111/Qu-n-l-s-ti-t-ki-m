﻿CREATE DATABASE QLSTK
GO

USE QLSTK
GO

CREATE TABLE SOTIETKIEM
(
	MaSoTK CHAR(9),
	MaKH CHAR(9),
	MaLoaiTK CHAR(9),
	MaNV CHAR(9),
	MaChiNhanh CHAR(4),
	NgayMoSo SMALLDATETIME,
	SoDuSo MONEY,
	TuDongGiaHan BIT,
	PRIMARY KEY (MaSoTK),

)

CREATE TABLE KHACHHANG
(
	MaKH CHAR(9),
	CCCD INT,
	TenKH NVARCHAR(50),
	NgaySinh SMALLDATETIME,
	GioiTinh NVARCHAR(15),
	DiaChi NVARCHAR(150),
	SDT INT,
	Email VARCHAR(50),
	ChiNhanhNhapTT CHAR(4),
	NhanVienNhapTT CHAR(9),
	NgayThamGia SMALLDATETIME,
	PRIMARY KEY (MaKH),
)
CREATE TABLE NHANVIEN
(
	MaNV CHAR(9),
	CCCD INT,
	TenNV NVARCHAR(50),
	NgaySinh SMALLDATETIME,
	GioiTinh NVARCHAR(15),
	DiaChi NVARCHAR(150),
	SDT INT,
	Email VARCHAR(50),
	ChiNhanhLV CHAR(4),
	ChucVu NVARCHAR(50),
	MatKhau VARCHAR(65),
	PRIMARY KEY (MaNV),
)

CREATE TABLE CHINHANH(
	MaCN CHAR(4),
	TenCN NVARCHAR(70),
	DiaChi NVARCHAR(150),
	PRIMARY KEY (MaCN),
)

CREATE TABLE LOAITIETKIEM(
	MaLoaiTK CHAR(9),
	TenLoaiTK NVARCHAR(50),
	ThoiHan SMALLINT,
	LaiXuat FLOAT(24),
	PRIMARY KEY (MaLoaiTK),
)

CREATE TABLE PHIEUGOITIEN(
	MaPhieu CHAR(9),
	MaSoTK CHAR(9),
	MaNV CHAR(9),
	NgayGoi SMALLDATETIME,
	SoTienGoi MONEY,
	PRIMARY KEY (MaPhieu),
)

CREATE TABLE PHIEURUTTIEN(
	MaPhieu CHAR(9),
	MaSoTK CHAR(9),
	MaNV CHAR(9),
	NgayRut SMALLDATETIME,
	SoTienRut MONEY,
	PRIMARY KEY (MaPhieu),
)
CREATE TABLE BAOCAODOANHSO(
	MaBC CHAR(9),
	Ngay SMALLDATETIME,
	MaCN CHAR(4),
	PRIMARY KEY (MaBC),
)

CREATE TABLE CT_BAOCAODOANHSO(
	MaBC CHAR(9),
	MaLoaiTK CHAR(9),
	TongThu MONEY,
	TongChi MONEY,
	PRIMARY KEY (MaBC,MaLoaiTK),
)
CREATE TABLE BAOCAOMODONGSO(
	MaBC CHAR(9),
	MaLoaiTK CHAR(9),
	Thang SMALLDATETIME,
	MaCN CHAR(4),
	PRIMARY KEY (MaBC),
)

CREATE TABLE CT_BAOCAOMODONGSO(
	MaBC CHAR(9),
	Ngay SMALLDATETIME,
	SoMo SMALLINT,
	SoDong SMALLINT, 
	PRIMARY KEY (MaBC, Ngay),
)
CREATE TABLE BAOCAOLUONGGIAODICHNV(
	MaBC CHAR(9),
	Thang SMALLDATETIME,
	MaCN CHAR(4),
	PRIMARY KEY (MaBC),
)
CREATE TABLE CT_BAOCAOLUONGGIAODICHNV(
	MaBC CHAR(9),
	MaNV CHAR(9),
	MoSo SMALLINT,
	RutTien SMALLINT,
	GoiTien SMALLINT, 
	LuongTienRut MONEY,
	LuongTienGoi MONEY,
	PRIMARY KEY (MaBC, MaNV),
)
CREATE TABLE BAOCAOKHACHHANGTIEMNANG(
	MaBC CHAR(9),
	Thang SMALLDATETIME,
	MaCN CHAR(4),
	PRIMARY KEY (MaBC),
)
CREATE TABLE CT_BAOCAOKHACHHANGTIEMNANG(
	MaBC CHAR(9),
	MaKH CHAR(9),
	TongTienGoi MONEY,
	PRIMARY KEY (MaBC, MaKH),
)

CREATE TABLE THAMSO(
	SoTienGoiToithieuBD MONEY,
	SoTienGoiThemToiThieu MONEY,
	SoNgayDuocRutSauGoi SMALLINT,
)

SET DATEFORMAT MDY

ALTER TABLE SOTIETKIEM ADD CONSTRAINT FK_MAKH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
ALTER TABLE SOTIETKIEM ADD CONSTRAINT FK_MALOAITK FOREIGN KEY (MaLoaiTK) REFERENCES LOAITIETKIEM(MaLoaiTK)
ALTER TABLE SOTIETKIEM ADD CONSTRAINT FK_MANV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
ALTER TABLE SOTIETKIEM ADD CONSTRAINT FK_MACHINHANH FOREIGN KEY (MaChiNhanh) REFERENCES CHINHANH(MaCN)

ALTER TABLE KHACHHANG ADD CONSTRAINT FK_CHINHANHNHAPTT FOREIGN KEY (ChiNhanhNhapTT) REFERENCES CHINHANH(MaCN)
ALTER TABLE KHACHHANG ADD CONSTRAINT FK_NHANVIENNHAPTT FOREIGN KEY (NhanVienNhapTT) REFERENCES NHANVIEN(MaNV)

ALTER TABLE NHANVIEN ADD CONSTRAINT FK_CHINHANHLV FOREIGN KEY (ChiNhanhLV) REFERENCES CHINHANH(MaCN)

ALTER TABLE PHIEUGOITIEN ADD CONSTRAINT FK_MASOTK FOREIGN KEY (MaSoTK) REFERENCES SOTIETKIEM(MaSoTK)
ALTER TABLE PHIEUGOITIEN ADD CONSTRAINT FK_MANVPGT FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)

ALTER TABLE PHIEURUTTIEN ADD CONSTRAINT FK_MASOTKRT FOREIGN KEY (MaSoTK) REFERENCES SOTIETKIEM(MaSoTK)
ALTER TABLE PHIEURUTTIEN ADD CONSTRAINT FK_MANVGT FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)

ALTER TABLE BAOCAODOANHSO ADD CONSTRAINT FK_MACNDS FOREIGN KEY (MaCN) REFERENCES CHINHANH(MaCN)

ALTER TABLE CT_BAOCAODOANHSO ADD CONSTRAINT FK_MABCDS FOREIGN KEY (MaBC) REFERENCES BAOCAODOANHSO(MaBC)
ALTER TABLE CT_BAOCAODOANHSO ADD CONSTRAINT FK_MALOAITKDS FOREIGN KEY (MaLoaiTK) REFERENCES LOAITIETKIEM(MaLoaiTK)

ALTER TABLE BAOCAOMODONGSO ADD CONSTRAINT FK_MALOAITKMD FOREIGN KEY (MaLoaiTK) REFERENCES LOAITIETKIEM(MaLoaiTK)
ALTER TABLE BAOCAOMODONGSO ADD CONSTRAINT FK_MACNMD FOREIGN KEY (MaCN) REFERENCES CHINHANH(MaCN)

ALTER TABLE CT_BAOCAOMODONGSO ADD CONSTRAINT FK_MABCMD FOREIGN KEY (MaBC) REFERENCES BAOCAOMODONGSO(MaBC)

ALTER TABLE BAOCAOLUONGGIAODICHNV ADD CONSTRAINT FK_MACNGDNV FOREIGN KEY (MaCN) REFERENCES CHINHANH(MaCN)

ALTER TABLE CT_BAOCAOLUONGGIAODICHNV ADD CONSTRAINT FK_MABCGDNV FOREIGN KEY (MaBC) REFERENCES BAOCAOLUONGGIAODICHNV(MaBC)
ALTER TABLE CT_BAOCAOLUONGGIAODICHNV ADD CONSTRAINT FK_MANVGDNV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)

ALTER TABLE BAOCAOKHACHHANGTIEMNANG ADD CONSTRAINT FK_MACNKHTN FOREIGN KEY (MaCN) REFERENCES CHINHANH(MaCN)

ALTER TABLE CT_BAOCAOKHACHHANGTIEMNANG ADD CONSTRAINT FK_MABCKHTN FOREIGN KEY (MaBC) REFERENCES BAOCAOKHACHHANGTIEMNANG(MaBC)
ALTER TABLE CT_BAOCAOKHACHHANGTIEMNANG ADD CONSTRAINT FK_MAKHKHTN FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)

ALTER TABLE KHACHHANG ADD CONSTRAINT check_GioiTinh check(GioiTinh = N'Nam' or GioiTinh = N'Nữ')
ALTER TABLE NHANVIEN ADD CONSTRAINT check_GioiTinhNV check(GioiTinh = N'Nam' or GioiTinh = N'Nữ')

 