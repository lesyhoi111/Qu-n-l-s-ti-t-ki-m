using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thong_Tin_Khach_hang
{
    public class Passbook
    {
        public string maSoTK { get; set; }
        public string maKH { get; set; }
        public string maLoaiTK { get; set; }
        public string maNV { get; set; }
        public string maChiNhanh { get; set; }
        public DateTime ngayMoSo { get; set; }
        public decimal soDuSo { get; set; }
        public string hinhThucTraLai { get; set; }
        public int soLanGiaHan { get; set; }

        public Passbook() { }

        public Passbook(string maSoTK, string maKH, string maLoaiTK, string maNV, string maChiNhanh, DateTime ngayMoSo, decimal soDuSo, string hinhThucTraLai, int soLanGiaHan)
        {
            this.maSoTK = maSoTK;
            this.maKH = maKH;
            this.maLoaiTK = maLoaiTK;
            this.maNV = maNV;
            this.maChiNhanh = maChiNhanh;
            this.ngayMoSo = ngayMoSo;
            this.soDuSo = soDuSo;
            this.hinhThucTraLai = hinhThucTraLai;
            this.soLanGiaHan = soLanGiaHan;
        }
    }
}
