using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class phieuRutTien
    {
        public string maPhieu { get; set; }

        public string maNV { get; set; }
        public string maKH { get; set; }
        public string maCN { get; set; }
        public DateTime ngayRut { get; set; }
        public Decimal soTienRut { get; set; }
        public string noiDungGiaoDich { get; set; }
        public phieuRutTien() { }

        public phieuRutTien(string maNV, string maKH, string maCN, DateTime ngayRut, decimal soTienRut, string noiDungGiaoDich)
        {
            this.maNV = maNV;
            this.maKH = maKH;
            this.maCN = maCN;
            this.ngayRut = ngayRut;
            this.soTienRut = soTienRut;
            this.noiDungGiaoDich = noiDungGiaoDich;
        }
    }
}
