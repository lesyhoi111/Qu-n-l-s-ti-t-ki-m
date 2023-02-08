using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace Thong_Tin_Khach_hang
{
    internal class editPerson
    {
        public bool Insert(Person kh)
        {
            var connection = dataProvider.Instance.getConnection();
            string querry = "INSERT INTO KHACHHANG (MaKH, CCCD, TenKH, NgaySinh, GioiTinh, DiaChi,SDT,Email,ChiNhanhNhapTT,NhanVienNhapTT,NgayThamGia,SoDu,TinhTrangHoatDong) VALUES (@MaKH, @CCCD, @TenKH, @NgaySinh, @GioiTinh, @DiaChi,@SDT, @Email, @ChiNhanhNhapTT, @NhanVienNhapTT, @NgayThamGia,@SoDu,@TinhTrangHoatDong)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = kh.maKH;
                command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = kh.cccd;
                command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = kh.tenKH;
                command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = kh.ngaySinh;
                command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = kh.gioiTinh;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.diaChi;
                command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = kh.sdt;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = kh.email;
                command.Parameters.Add("@ChiNhanhNhapTT", SqlDbType.NVarChar).Value = kh.chiNhanh;
                command.Parameters.Add("@NhanVienNhapTT", SqlDbType.NVarChar).Value = kh.nhanVien;
                command.Parameters.Add("@NgayThamGia", SqlDbType.DateTime).Value = kh.ngayThamGia;
                command.Parameters.Add("@SoDu", SqlDbType.Money).Value = kh.soDu;
                command.Parameters.Add("@TinhTrangHoatDong", SqlDbType.Bit).Value = kh.tinhTrangHoatDong;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool InsertPassBook(Passbook pb)
        {
            var connection = dataProvider.Instance.getConnection();
            string querry = "INSERT INTO SOTIETKIEM (MaSoTK, MaKH, MaLoaiTK, MaNV, MaChiNhanh, NgayMoSo, SoVon, HinhThucTraLai, SoLanGiaHan) VALUES (@MaSoTK, @MaKH, @MaLoaiTK, @MaNV, @MaChiNhanh,@NgayMoSo, @SoVon, @HinhThucTraLai, @SoLanGiaHan)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.Add("@MaSoTK", SqlDbType.NVarChar).Value = pb.maSoTK;
                command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = pb.maKH;
                command.Parameters.Add("@MaLoaiTK", SqlDbType.NVarChar).Value = pb.maLoaiTK;
                command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = pb.maNV;
                command.Parameters.Add("@MaChiNhanh", SqlDbType.NVarChar).Value = pb.maChiNhanh;
                command.Parameters.Add("@NgayMoSo", SqlDbType.DateTime).Value = pb.ngayMoSo;
                command.Parameters.Add("@SoVon", SqlDbType.Money).Value = pb.soDuSo;
                command.Parameters.Add("@HinhThucTraLai", SqlDbType.NVarChar).Value = pb.hinhThucTraLai;
                command.Parameters.Add("@SoLanGiaHan", SqlDbType.Int).Value = pb.soLanGiaHan;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

     

        public bool InsertphieuGuiTien(phieuGuiTien pg)
        {
            var connection = dataProvider.Instance.getConnection();
            string querry = "INSERT INTO PHIEUGOITIEN (MaPhieu, MaKH, MaNV, NgayGoi, SoTienGoi, MaCN, NoiDungGiaoDich) VALUES (@MaPhieu, @MaKH, @MaNV, @NgayGoi, @SoTienGoi, @MaCN, @NoiDungGiaoDich)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.Add("@MaPhieu", SqlDbType.NVarChar).Value = pg.maPhieu;
                command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = pg.maKH;
                command.Parameters.Add("@MaCN", SqlDbType.NVarChar).Value = pg.maCN;
                command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = pg.maNV;
                command.Parameters.Add("@NgayGoi", SqlDbType.DateTime).Value = pg.ngayGui;
                command.Parameters.Add("@SoTienGoi", SqlDbType.Money).Value = pg.soTienGui;
                command.Parameters.Add("@NoiDungGiaoDich", SqlDbType.NVarChar).Value = pg.noiDungGiaoDich;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool InsertphieuRutTien(phieuRutTien pr)
        {
            var connection = dataProvider.Instance.getConnection();
            string querry = "INSERT INTO PHIEURUTTIEN (MaPhieu, MaNV, NgayRut, SoTienRut, MaKH, MaCN, NoiDungGiaoDich) VALUES (@MaPhieu, @MaNV, @NgayRut, @SoTienRut, @MaKH, @MaCN, @NoiDungGiaoDich)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.Add("@MaPhieu", SqlDbType.NVarChar).Value = pr.maPhieu;
                command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = pr.maNV;
                command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = pr.maKH;
                command.Parameters.Add("@MaCN", SqlDbType.NVarChar).Value = pr.maCN;
                command.Parameters.Add("@NgayRut", SqlDbType.DateTime).Value = pr.ngayRut;
                command.Parameters.Add("@SoTienRut", SqlDbType.Money).Value = pr.soTienRut;
                command.Parameters.Add("@NoiDungGiaoDich", SqlDbType.NVarChar).Value = pr.noiDungGiaoDich;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool Update(Person kh)
        {
            var connection = dataProvider.Instance.getConnection();
            string querry = "UPDATE KHACHHANG SET CCCD=@CCCD, TenKH=@TenKH, NgaySinh=@NgaySinh,GioiTinh=@GioiTinh, DiaChi=@DiaChi,SDT=@SDT, Email=@Email, ChiNhanhNhapTT=@ChiNhanhNhapTT, NhanVienNhapTT=@NhanVienNhapTT, NgayThamGia=@NgayThamGia, SoDu=@SoDu WHERE maKH=@maKH";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = kh.maKH;
                command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = kh.cccd;
                command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = kh.tenKH;
                command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = kh.ngaySinh;
                command.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = kh.gioiTinh;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = kh.diaChi;
                command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = kh.sdt;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = kh.email;
                command.Parameters.Add("@ChiNhanhNhapTT", SqlDbType.NVarChar).Value = kh.chiNhanh;
                command.Parameters.Add("@NhanVienNhapTT", SqlDbType.NVarChar).Value = kh.nhanVien;
                command.Parameters.Add("@NgayThamGia", SqlDbType.DateTime).Value = kh.ngayThamGia;
                command.Parameters.Add("@SoDu", SqlDbType.Money).Value = kh.soDu;
                command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}

    
