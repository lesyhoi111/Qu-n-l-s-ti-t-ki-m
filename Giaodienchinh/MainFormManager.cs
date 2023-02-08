using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Lần_1;
using Thong_Tin_Khach_hang;

namespace WindowsFormsApp1
{
    public partial class MainFormManager : Form
    {
        DataTable dt = new DataTable();
        private Form curentChildForm;
        public static MainFormManager Instance;
        bool formShow = false;
        public MainFormManager()
        {
            InitializeComponent();
            customizeDesign();
            Instance = this;
            this.WindowState = FormWindowState.Maximized;
        }
        private void customizeDesign()
        {
            panelThongTinKhachHang.Visible = false;
            panelThongTinSo.Visible = false;
            panelNhanVien.Visible = false;
            panelBCTK.Visible = false;
            pnChinhSach.Visible = false;
        }

        private void hidenSubMenu()
        {
            if (panelThongTinKhachHang.Visible == true)
            {
                panelThongTinKhachHang.Visible = false;
            }
            if (panelThongTinSo.Visible == true)
            {
                panelThongTinSo.Visible = false;
            }
            if (panelNhanVien.Visible == true)
            {
                panelNhanVien.Visible = false;
            }
            if (panelBCTK.Visible == true)
            {
                panelBCTK.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hidenSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void iconKhachHang_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongTinKhachHang);
            //hidenSubMenu();
        }

        private void iconThongTinSo_Click(object sender, EventArgs e)
        {
            showSubMenu(panelThongTinSo);
            // hidenSubMenu();
        }

        private void iconNhanVien_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhanVien);
            //hidenSubMenu();
        }

        private void iconBCTK_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBCTK);
            //hidenSubMenu();
        }
        void SetDFColor()
        {
            btnThongTinChung.BackColor = btnQuanLyNV.BackColor = btnSoTienGiaoDich.BackColor = btnTopKhachHang.BackColor  = btCSLX.BackColor = btCSNH.BackColor = Color.FromArgb(63, 110, 95);
            formShow = true;
        }
        private void btnThongTinChung_Click(object sender, EventArgs e)
        {
            openChildForm(new frmthongTinKhachHang());
            SetDFColor();
            btnThongTinChung.BackColor = Color.FromArgb(93, 166, 143);
        }


        public void openChildForm(Form childForm)
        {
            if (curentChildForm != null)
            {
                curentChildForm.Close();
            }
            curentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(curentChildForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnThongTinSo_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongtinso());
            SetDFColor();
            btnThongTinSo.BackColor = Color.FromArgb(93, 166, 143);
        }

        private void btnRutSo_Click(object sender, EventArgs e)
        {


        }

        private void btnQuanLyNV_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmNhanVien());
            SetDFColor();
            btnQuanLyNV.BackColor = Color.FromArgb(93, 166, 143);
        }

        private void btnSoTienGiaoDich_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDoanhSoNgay());
            SetDFColor();
            btnSoTienGiaoDich.BackColor = Color.FromArgb(93, 166, 143);
        }

        private void btnTopKhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTopKhachHang());
            SetDFColor();
            btnTopKhachHang.BackColor = Color.FromArgb(93, 166, 143);
        }

        private void iconChinhSach_Click(object sender, EventArgs e)
        {
            showSubMenu(pnChinhSach);
        }

        private void btCSLX_Click(object sender, EventArgs e)
        {
            openChildForm(new ChinhSuaLoaiTK());
            SetDFColor();
            btCSLX.BackColor = Color.FromArgb(93, 166, 143);
        }

        private void btCSNH_Click(object sender, EventArgs e)
        {
            openChildForm(new ThongTinChinhSach());
            SetDFColor();
            btCSNH.BackColor = Color.FromArgb(93, 166, 143);
        }

        private void pictureLogo_Click(object sender, EventArgs e)
        {
            hidenSubMenu();
            if (formShow)
            {
                curentChildForm.Close();
                formShow = false;
            }

        }

        private void iconUser_Click(object sender, EventArgs e)
        {
            
        }
        private void MainFormManager_Load_1(object sender, EventArgs e)
        {
            this.Text ="Ngân hàng Meta - Chi nhánh "+tenCN();
            openChildForm(new frmAccount());
            btnTK.Text = tenNV();
            string query="SELECT ChucVu from NHANVIEN where SDT='" + Login.sdt + "'";
            if (dataProvider.Instance.ExecuteScalar(query).ToString()=="Nhân viên quầy")
            {
                iconChinhSach.Hide();
                iconNhanVien.Hide();
            }
        }
        public string tenNV()
        {
            string query = "SELECT TenNV from NHANVIEN where SDT='" + Login.sdt + "'";
            string nv = dataProvider.Instance.ExecuteScalar(query).ToString();
            return nv;
        }
        public string maNV()
        {
            string query = "SELECT MaNV from NHANVIEN where SDT='" + Login.sdt + "'";
            string nv = dataProvider.Instance.ExecuteScalar(query).ToString();
            return nv;
        }
        public string tenCN()
        {
            string query = "SELECT ChiNhanhLV from NHANVIEN where SDT='" + Login.sdt + "'";
            string query1 = "select TenCN,MaCN from CHINHANH where MaCN='" + dataProvider.Instance.ExecuteScalar(query).ToString() + "'";
            string cn = dataProvider.Instance.ExecuteScalar(query1).ToString();
            return cn;

        }
        public string maCN()
        {
            string query = "SELECT ChiNhanhLV from NHANVIEN where SDT='" + Login.sdt + "'";
            string cn = dataProvider.Instance.ExecuteScalar(query).ToString();
            return cn;

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAccount());
        }
    }


}
