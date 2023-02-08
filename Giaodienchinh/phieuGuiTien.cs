using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thong_Tin_Khach_hang
{
    internal class phieuGuiTien
    {
        public string maPhieu { get; set; }
        public string maKH { get; set; }
        public string maNV { get; set; }
        public string maCN { get; set; }
        public DateTime ngayGui { get; set; }
        public Decimal soTienGui { get; set; }
        public string noiDungGiaoDich { get; set; }
        public phieuGuiTien() { }

        public phieuGuiTien(string maPhieu, string maKH, string maNV, string maCN, DateTime ngayGui, decimal soTienGui, string noiDungGiaoDich)
        {
            this.maPhieu = maPhieu;
            this.maKH = maKH;
            this.maNV = maNV;
            this.maCN = maCN;
            this.ngayGui = ngayGui;
            this.soTienGui = soTienGui;
            this.noiDungGiaoDich = noiDungGiaoDich;
        }
    }
}
