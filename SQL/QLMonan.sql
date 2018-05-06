<<<<<<< HEAD:QLMonan.sql
use master
Drop Database QLMonan
----------
create database QLMonan
GO
use QLMonan
GO
CREATE TABLE KHACHHANG
(
	MaKH INT IDENTITY(1,1),
	HoTen nVarchar(50) NOT NULL,
	Taikhoan Varchar(50) UNIQUE,
	Matkhau Varchar(50) NOT NULL,
	Email Varchar(100) UNIQUE,
	DiachiKH nVarchar(200),
	DienthoaiKH Varchar(50),	
	Ngaysinh DATETIME
	CONSTRAINT PK_Khachhang PRIMARY KEY(MaKH)
)
GO
Create Table LOAI
(
	Maloai int Identity(1,1),
	Tenloai nvarchar(50) NOT NULL,
	CONSTRAINT PK_ChuDe PRIMARY KEY(Maloai)
)
GO
Go
CREATE TABLE MONAN
(
	Mamon INT IDENTITY(1,1),
	Tenmon NVARCHAR(100) NOT NULL,
	Giaban Decimal(18,0) CHECK (Giaban>=0),
	Soluong int,
	Anh VARCHAR(50),
	Trangthai nvarchar(10),
	Thucuong nvarchar(10),
	Maloai INT,
	CONSTRAINT PK_Monan PRIMARY KEY(Mamon),
	CONSTRAINT FK_Loai FOREIGN KEY(Maloai) REFERENCES LOAI(Maloai),
)
GO
CREATE TABLE DONDATHANG
(
	MaDonHang INT IDENTITY(1,1),
	Dathanhtoan bit,
	Tinhtranggiaohang  bit,
	Ngaydat Datetime,
	Ngaygiao Datetime,	
	MaKH INT,
	CONSTRAINT FK_Khachhang FOREIGN KEY(MaKH) REFERENCES Khachhang(MaKH),
	CONSTRAINT PK_DonDatHang PRIMARY KEY(MaDonHang)
)
GO
CREATE TABLE CHITIETDONTHANG
(
	MaDonHang INT,
	Mamon INT,
	Soluong Int Check(Soluong>0),
	Dongia Decimal(18,0) Check(Dongia>=0),	
	CONSTRAINT PK_CTDatHang PRIMARY KEY(MaDonHang,Mamon),
)

=======
use master
Drop Database QLMonan
----------
create database QLMonan
GO
use QLMonan
GO
CREATE TABLE KHACHHANG
(
	MaKH INT IDENTITY(1,1),
	HoTen nVarchar(50) NOT NULL,
	Taikhoan Varchar(50) UNIQUE,
	Matkhau Varchar(50) NOT NULL,
	Email Varchar(100) UNIQUE,
	DiachiKH nVarchar(200),
	DienthoaiKH Varchar(50),	
	Ngaysinh DATETIME
	CONSTRAINT PK_Khachhang PRIMARY KEY(MaKH)
)
GO
Create Table LOAI
(
	Maloai int Identity(1,1),
	Tenloai nvarchar(50) NOT NULL,
	CONSTRAINT PK_ChuDe PRIMARY KEY(Maloai)
)
GO
Go
CREATE TABLE MONAN
(
	Mamon INT IDENTITY(1,1),
	Tenmon NVARCHAR(100) NOT NULL,
	Giaban Decimal(18,0) CHECK (Giaban>=0),
	Soluong int,
	Anh VARCHAR(50),
	Trangthai nvarchar(10),
	Thucuong nvarchar(10),
	Maloai INT,
	CONSTRAINT PK_Monan PRIMARY KEY(Mamon),
	CONSTRAINT FK_Loai FOREIGN KEY(Maloai) REFERENCES LOAI(Maloai),
)
GO
CREATE TABLE DONDATHANG
(
	MaDonHang INT IDENTITY(1,1),
	Dathanhtoan bit,
	Tinhtranggiaohang  bit,
	Ngaydat Datetime,
	Ngaygiao Datetime,	
	MaKH INT,
	CONSTRAINT FK_Khachhang FOREIGN KEY(MaKH) REFERENCES Khachhang(MaKH),
	CONSTRAINT PK_DonDatHang PRIMARY KEY(MaDonHang)
)
GO
CREATE TABLE CHITIETDONTHANG
(
	MaDonHang INT,
	Masach INT,
	Soluong Int Check(Soluong>0),
	Dongia Decimal(18,0) Check(Dongia>=0),	
	CONSTRAINT PK_CTDatHang PRIMARY KEY(MaDonHang,Masach),
)

>>>>>>> ae7ccd005e8ed59d9a8ccfe261f97ee7e47f360e:SQL/QLMonan.sql
