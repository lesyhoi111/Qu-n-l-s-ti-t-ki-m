using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thong_Tin_Khach_hang
{
    internal class Person
    {
        public string maKH { get; set; }
        public string cccd { get; set; }
        public string tenKH { get; set; }
        public DateTime ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string sdt { get; set; }
        public string email { get; set; }
        public string chiNhanh { get; set; }
        public string nhanVien { get; set; }
        public decimal soDu { get; set; }
        public DateTime ngayThamGia { get; set; }
        public bool tinhTrangHoatDong { get; set; }

        public Person() { }

        public Person(string maKH, string cccd, string tenKH, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email, string chiNhanh,decimal soDu, string nhanVien, DateTime ngayThamGia, bool tinhTrangHoatDong)
        {
            this.maKH = maKH;
            this.cccd = cccd;
            this.tenKH = tenKH;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.email = email;
            this.chiNhanh = chiNhanh;
            this.nhanVien = nhanVien;
            this.soDu = soDu;
            this.ngayThamGia = ngayThamGia;
            this.tinhTrangHoatDong = tinhTrangHoatDong;
        }
    }
}
