CREATE DATABASE QuanLyTuBep
USE QuanLyTuBep
CREATE TABLE [dbo].[tblCongViec]
(
	[MaCV] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenCV] NVARCHAR(50) NULL, 
    [MucLuong] FLOAT NULL
);


CREATE TABLE [dbo].[tblChatLieu] (
    [MaChatLieu]  NVARCHAR (10) NOT NULL,
    [TenChatLieu] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([MaChatLieu] ASC)
);

CREATE TABLE [dbo].[tblKichThuoc] (
    [MaKichThuoc]  NVARCHAR (10) NOT NULL,
    [TenKichThuoc] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([MaKichThuoc] ASC)
);

CREATE TABLE [dbo].[tblMauSac] (
    [MaMau]  NVARCHAR (10) NOT NULL,
    [TenMau] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([MaMau] ASC)
);

CREATE TABLE [dbo].[tblNuocSX] (
    [MaNuocSX]  NVARCHAR (10) NOT NULL,
    [TenNuocSX] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([MaNuocSX] ASC)
);

CREATE TABLE [dbo].[tblHangHoa]
(
	[MaHang] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenHangHoa] NVARCHAR(50) NULL, 
	[MaKichThuoc] NVARCHAR(10) NOT NULL,
	[MaChatLieu] NVARCHAR(10) NOT NULL,
	[MaNuocSX] NVARCHAR(10) NOT NULL,
	[MaMau] NVARCHAR(10) NOT NULL,
    [SoLuong] INT NULL, 
    [DonGiaNhap] FLOAT NULL, 
    [DonGiaBan] FLOAT NULL, 
    [ThoiGianBaoHanh] NVARCHAR(50) NULL, 
    [Anh] NVARCHAR(500) NULL, 
    [GhiChu] NVARCHAR(200) NULL
	CONSTRAINT FK_KichThuoc_HangHoa FOREIGN KEY (MaKichThuoc) REFERENCES [dbo].[tblKichThuoc](MaKichThuoc),
	CONSTRAINT FK_ChatLieu_HangHoa FOREIGN KEY (MaChatLieu) REFERENCES [dbo].[tblChatLieu](MaChatLieu),
	CONSTRAINT FK_NuocSX_HangHoa FOREIGN KEY (MaNuocSX) REFERENCES [dbo].[tblNuocSX](MaNuocSX),
	CONSTRAINT FK_MauSac_HangHoa FOREIGN KEY (MaMau) REFERENCES [dbo].[tblMauSac](MaMau),
)


CREATE TABLE [dbo].[tblNhaCungCap]
(
	[MaNCC] NVARCHAR(10) NOT NULL PRIMARY KEY,
	[TenNCC] NVARCHAR(50) NULL,
	[DC] NVARCHAR(50) NULL,
	[DienThoai] NVARCHAR(15) NULL,

);

CREATE TABLE [dbo].[tblNhanVien]
(
	[MaNV] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenNV] NVARCHAR(50) NULL, 
    [GioiTinh] NVARCHAR(10) NULL, 
    [NgaySinh] DATE NULL, 
    [DienThoai] NVARCHAR(15) NULL, 
    [DC] NVARCHAR(50) NULL, 
    [MaCV] NVARCHAR(10) NULL,
	CONSTRAINT FK_CongViec_NhanVien FOREIGN KEY (MaCV) REFERENCES [dbo].[tblCongViec](MaCV),
);

CREATE TABLE [dbo].[tblKhachHang]
(
	[MaKhach] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenKhach] NVARCHAR(50) NULL, 
    [DC] NVARCHAR(50) NULL, 
    [DienThoai] NVARCHAR(15) NULL,

);

CREATE TABLE [dbo].[tblHoaDonBan]
(
	[SoHDB] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [MaNV] NVARCHAR(10) NULL, 
    [NgayBan] DATE NULL, 
	[MaKhach] NVARCHAR(10) NULL,
    [TongTien] FLOAT NULL,
	CONSTRAINT FK_NhanVien_HoaDonBan FOREIGN KEY (MaNV) REFERENCES [dbo].[tblNhanVien](MaNV),
	CONSTRAINT FK_KhachHang_HoaDonBan FOREIGN KEY (MaKhach) REFERENCES [dbo].[tblKhachHang](MaKhach)


);

CREATE TABLE [dbo].[tblHoaDonNhap]
(
	[SoHDN] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [MaNV] NVARCHAR(10) NULL, 
    [NgayNhap] DATE NULL, 
	[MaNCC] NVARCHAR(10) NULL,
    [TongTien] FLOAT NULL,
	CONSTRAINT FK_NhanVien_HoaDonNhap FOREIGN KEY (MaNV) REFERENCES [dbo].[tblNhanVien](MaNV),
	CONSTRAINT FK_NhaCungCap_HoaDonNhap FOREIGN KEY (MaNCC) REFERENCES [dbo].[tblNhaCungCap](MaNCC),
	
);

CREATE TABLE [dbo].[tblChiTietHDB]
(
	[SoHDB] NVARCHAR(10) NOT NULL ,
	[MaHang] NVARCHAR(10) NOT NULL ,
	[SoLuong] INT NULL,
	[GiamGia] NVARCHAR(50) NULL,
	[ThanhTien] FLOAT NULL,
	CONSTRAINT PK_ChiTietHDB PRIMARY KEY (SoHDB,MaHang),
	CONSTRAINT FK_HangHoa_ChiTietHDB FOREIGN KEY (MaHang) REFERENCES [dbo].[tblHangHoa](MaHang),
	CONSTRAINT FK_HoaDonBan_ChiTietHDB FOREIGN KEY (SoHDB) REFERENCES [dbo].[tblHoaDonBan](SoHDB),
);


CREATE TABLE [dbo].[tblChiTietHDN]
(
	[SoHDN] NVARCHAR(10) NOT NULL ,
	[MaHang] NVARCHAR(10) NOT NULL ,
	[SoLuong] INT NULL,
	[DonGia] FLOAT NULL,
	[GiamGia] NVARCHAR(50) NULL,
	[ThanhTien] FLOAT NULL,
	CONSTRAINT PK_ChiTietHDN PRIMARY KEY (SoHDN,MaHang),
	CONSTRAINT FK_HangHoa_ChiTietHDN FOREIGN KEY (MaHang) REFERENCES [dbo].[tblHangHoa](MaHang),
	CONSTRAINT FK_HoaDonNhap_ChiTietHDN FOREIGN KEY (SoHDN) REFERENCES [dbo].[tblHoaDonNhap](SoHDN),
);


insert into tblCongViec values(N'CV01',N'Công việc 1',5000000),
							  (N'CV02',N'Công việc 2',5000000),
							  (N'CV03',N'Công việc 3',5000000);

insert into tblNhaCungCap values(N'NCC01',N'Nhà cung cấp 1',N'Hà Nội',N'094739738'),
							  (N'NCC02',N'Nhà cung cấp 2',N'Cà Màu',N'058374387'),
							  (N'NCC03',N'Nhà cung cấp 3',N'Kiên Giang',N'027487431');

insert into tblNhanVien values(N'NV01',N'Hướng',N'Nam','2002-09-30',N'0364474747',N'Hà Nam',N'CV01'),
							  (N'NV02',N'Đạt',N'Nam','2002-09-09',N'08979774747',N'Quốc Oai',N'CV01'),
							  (N'NV03',N'Đức',N'Nữ','2002-02-22',N'0364475757',N'Phú Xuyên',N'CV01');

insert into tblHoaDonNhap values(N'HDN01',N'NV01','2022-09-12',N'NCC01',null),
								(N'HDN02',N'NV02','2022-03-19',N'NCC02',null),
								(N'HDN03',N'NV03','2022-10-24',N'NCC03',null);

insert into tblKichThuoc values(N'KT01',N'Kích thước 1'),
								(N'KT02',N'Kích thước 2'),
								(N'KT03',N'Kích thước 3');

insert into tblChatLieu values(N'CL01',N'Chất liệu 1'),
								(N'CL02',N'Chất liệu 1'),
								(N'CL03',N'Chất liệu 1');

insert into tblMauSac values(N'MS01',N'Đỏ'),
							(N'MS02',N'Tím'),
							(N'MS03',N'Vàng');
							
insert into tblNuocSX values(N'NSX01',N'Mỹ'),
							(N'NSX02',N'Nhật'),
							(N'NSX03',N'Việt Nam');
	
insert into tblHangHoa values(N'HH01',N'Tủ gỗ',N'KT01',N'CL01',N'NSX01',N'MS01',20,4000000,5000000,N'3 năm',null,null),
							(N'HH02',N'Tủ nhôm',N'KT02',N'CL02',N'NSX02',N'MS02',30,3000000,4000000,N'3 năm',null,null),
							(N'HH03',N'Tủ inox',N'KT03',N'CL03',N'NSX03',N'MS03',10,6000000,8000000,N'3 năm',null,null);

insert into tblChiTietHDN values(N'HDN01',N'HH01',4,5000000,N'0.5',null),
							(N'HDN01',N'HH02',5,4000000,N'0.2',null),
							(N'HDN01',N'HH03',2,8000000,N'1.5',null);



--Cập nhật số lượng()
create trigger CNSLHH_CTHDB on tblChiTietHDB
for delete,update,insert
as
begin
	update tblHangHoa  
	set SoLuong= delete_hh.SL
	from tblHangHoa hh join
		(select d.MaHang,(isnull(hh.SoLuong,0) + isnull(d.SoLuong,0)) as SL
			from deleted d join tblHangHoa hh on d.MaHang=hh.MaHang
		) delete_hh on delete_hh.MaHang= hh.MaHang

	update tblHangHoa  
	set SoLuong= insert_hh.SL
	from tblHangHoa hh join
		(select i.MaHang,(isnull(hh.SoLuong,0) - isnull(i.SoLuong,0)) as SL
			from inserted i join tblHangHoa hh on i.MaHang=hh.MaHang
		) insert_hh on insert_hh.MaHang= hh.MaHang
end

create trigger CNSLHH_CTHDN on tblChiTietHDN
for delete,update,insert
as
begin
	update tblHangHoa  
	set SoLuong= delete_hh.SL
	from tblHangHoa hh join
		(select d.MaHang,(isnull(hh.SoLuong,0) - isnull(d.SoLuong,0)) as SL
			from deleted d join tblHangHoa hh on d.MaHang=hh.MaHang
		) delete_hh on delete_hh.MaHang= hh.MaHang

	update tblHangHoa  
	set SoLuong= insert_hh.SL
	from tblHangHoa hh join
		(select i.MaHang,(isnull(hh.SoLuong,0) + isnull(i.SoLuong,0)) as SL
			from inserted i join tblHangHoa hh on i.MaHang=hh.MaHang
		) insert_hh on insert_hh.MaHang= hh.MaHang
end


-- trigger tinh Thanh Tien

create trigger tri_ThanhTienHDB on tblChiTietHDB for insert,update,delete as
begin
	declare @mahang nvarchar(10) , @sohdb nvarchar(10) , @giamgia float , @dongia float ,@sl int
	declare @mahang1 nvarchar(10), @sohdb1 nvarchar(10), @giamgia1 float, @dongia1 float,@sl1 int
	select  @mahang  = MaHang , @giamgia =cast(GiamGia as float) , @sohdb= SoHDB , @sl = SoLuong from inserted
	select  @mahang1 = MaHang , @giamgia1=cast(GiamGia as float),  @sohdb1 = SoHDB,@sl1 =SoLuong from deleted
	select  @dongia =DonGiaBan from tblHangHoa where tblHangHoa.MaHang = @mahang
	select  @dongia1 = DonGiaBan from tblHangHoa where MaHang = @mahang1
	update tblChiTietHDB set ThanhTien = isnull(ThanhTien,0) + (@sl*@dongia*(1-@giamgia)) where SoHDB = @sohdb and MaHang = @mahang
	update tblChiTietHDB set ThanhTien = isnull(ThanhTien,0) - (@sl1*@dongia1*(1-@giamgia1)) where SoHDB = @sohdb1 and MaHang = @mahang1
end


create trigger tri_ThanhTienHDN on tblChiTietHDN for insert , update ,delete as
begin
	declare @mahang nvarchar(10) , @sohdn nvarchar(10) , @giamgia float , @dongia float , @sl int 
	declare @mahang1 nvarchar(10), @sohdn1 nvarchar(10), @giamgia1 float, @dongia1 float, @sl1 int
	select  @mahang =MaHang ,  @giamgia=cast(GiamGia as float) , @sohdn= SoHDN ,@dongia = DonGia , @sl = SoLuong from inserted
	select  @mahang1 =MaHang , @giamgia1=cast(GiamGia as float) , @sohdn1= SoHDN ,@dongia1 = DonGia , @sl1= SoLuong from deleted
	update tblChiTietHDN set ThanhTien = isnull(ThanhTien,0) + (@sl*@dongia*(1-@giamgia))   where MaHang = @mahang and SoHDN = @sohdn
	update tblChiTietHDN set ThanhTien = isnull(ThanhTien,0) - (@sl1*@dongia1*(1-@giamgia1)) where MaHang = @mahang1 and SoHDN = @sohdn1
end
--trigger cap nhat don gia 


create trigger tri_CapNhatDonGia on tblChiTietHDN for insert , update
as
begin
	declare @mahang nvarchar(10), @dongia float ,@mahang1 nvarchar(10)
	select @mahang = inserted.MaHang , @dongia = inserted.DonGia from inserted
	update tblHangHoa SET DonGiaNhap = isnull(@dongia,0) where MaHang = @mahang
	update tblHangHoa SET DonGiaBan  = isnull(cast(@dongia*1.1 as int ),0) where MaHang = @mahang
end



--trigger TongTien
create trigger tri_TongTienHDN on tblChiTietHDN for insert , update , delete as
begin
	declare @thanhtien float , @sohdn nvarchar(10),@thanhtien1 float , @sohdn1 nvarchar(10)
	select @thanhtien =ThanhTien , @sohdn = SoHDN from inserted 
	select @thanhtien1 =ThanhTien , @sohdn1 =SoHDN from deleted
	update tblHoaDonNhap SET TongTien = isnull(TongTien,0) + isnull(@thanhtien,0) where SoHDN =@sohdn
	update tblHoaDonNhap SET TongTien = TongTien- isnull(@thanhtien1,0) where SoHDN = @sohdn1
end


create trigger tri_TongTienHDB on tblChiTietHDB for insert , update , delete as
begin
	declare @thanhtien float , @sohdb nvarchar(10) , @thanhtien1 float , @sohdb1 nvarchar(10)
	select @thanhtien = ThanhTien , @sohdb = SoHDB from inserted
	select @thanhtien1 =ThanhTien, @sohdb1 = SoHDB from deleted
	update tblHoaDonBan SET TongTien = isnull(TongTien,0) + isnull(@thanhtien,0) where SoHDB = @sohdb
	update tblHoaDonBan SET TongTien = TongTien - isnull(@thanhtien1,0) where SoHDB = @sohdb1
end

--4. Tìm kiếm sản phẩm theo: chất liệu, nước sx, thời gian bảo hành							
create function F1_cau4(@TenCL nvarchar(20))
returns table 
	as return(
		select tblHangHoa.*
		from tblHangHoa,tblChatLieu
		where tblHangHoa.MaChatLieu = tblChatLieu.MaChatLieu and tblChatLieu.TenChatLieu = @TenCL
	)

create function F2_cau4(@TenNSX nvarchar(20))
returns table as return(
select tblHangHoa.*
from tblHangHoa,tblNuocSX
where tblHangHoa.MaNuocSX = tblNuocSX.MaNuocSX and tblNuocSX.TenNuocSX = @TenNSX
)



--5. Tìm kiếm các HĐ bán theo: mã hàng, ngày bán, tổng tiền							
create function F1_cau5(@MaHang nvarchar(10))
returns table as return(
select tblHoaDonBan.*
from tblHoaDonBan, tblChiTietHDB
where tblChiTietHDB.SoHDB = tblHoaDonBan.SoHDB and tblChiTietHDB.MaHang = @MaHang

)



--6
create function F_cau6(@quy int,@nam int)
returns table
as
return
(
	select hh.MaHang, hh.TenHangHoa, hh.SoLuong, hh.DonGiaNhap, hh.DonGiaBan, hh.ThoiGianBaoHanh 
	from tblHangHoa hh join
	(select top 3 hh.MaHang,sum(ctb.SoLuong) as SL from tblHangHoa hh 
	join tblChiTietHDB ctb on ctb.MaHang =hh.MaHang
	join tblHoaDonBan hdb on hdb.SoHDB= ctb.SoHDB
	where month(hdb.NgayBan) between(case 
									when @quy=1 then 1
									when @quy=2 then 4
									when @quy=3 then 7
									when @quy=4 then 10
									end)
									and(case 
									when @quy=1 then 3
									when @quy=2 then 6
									when @quy=3 then 9
									when @quy=4 then 12
									end) 
	and year(hdb.NgayBan)=@nam 
	group by hh.MaHang
	order by SL desc) t3 on t3.MaHang=hh.MaHang
)



--7
create function F_cau7(@manv nvarchar(20))
returns table
as return
(
	select tblHoaDonNhap.* 
	from tblHoaDonNhap, tblNhanVien
	where tblNhanVien.MaNV = @manv and tblHoaDonNhap.MaNV = tblNhanVien.MaNV
)


--8
create function F_cau8(@quy int,@nam int)
returns table
as return
(
	select top 5 hdb.* from tblHoaDonBan hdb
	where month(hdb.NgayBan) between(case 
									when @quy=1 then 1
									when @quy=2 then 4
									when @quy=3 then 7
									when @quy=4 then 10
									end)
									and(case 
									when @quy=1 then 3
									when @quy=2 then 6
									when @quy=3 then 9
									when @quy=4 then 12
									end) 
	and year(hdb.NgayBan)=@nam 
	order by hdb.TongTien asc
)

--9. Báo cáo ds các khách hàng mua hàng theo tháng chọn trước							
create function F_cau9(@Thang int, @Nam int)
returns table as return(
select DISTINCT tblKhachHang.*
from tblKhachHang, tblHoaDonBan
where tblKhachHang.MaKhach = tblHoaDonBan.MaKhach and MONTH(NgayBan) = @Thang and YEAR(NgayBan) = @Nam
)
