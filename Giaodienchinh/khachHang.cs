using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using WindowsFormsApp1;
using System.Net.Mail;

namespace Thong_Tin_Khach_hang
{
    public partial class frmthongTinKhachHang : Form
    {
        DataTable dt = new DataTable();
        editPerson edit = new editPerson();
        DateTime date = DateTime.Now;
        public string maSoTK = "";
        public string maPhieuGui = "";
        bool a = false;
        bool b = false;
        public frmthongTinKhachHang()
        {
            InitializeComponent();
            ShowData();
            danhSachKyHan();

        }
        //Danh sách khách hàng
        void ShowData()
        {
            string query0 = "update KHACHHANG set TinhTrangHoatDong ='false' where MaKH in (select distinct kh.MaKH from KHACHHANG kh left join SOTIETKIEM stk on kh.MaKH=stk.MaKH where kh.MaKH not in (select distinct MaKH from SOTIETKIEM where SoVon<>0)) and SoDu=0";
            dataProvider.Instance.ExecuteNonQuery(query0);
            string query1 = "update KHACHHANG set TinhTrangHoatDong ='true' where MaKH in (select distinct kh.MaKH from KHACHHANG kh left join SOTIETKIEM stk on kh.MaKH=stk.MaKH where kh.MaKH in (select distinct MaKH from SOTIETKIEM where SoVon<>0)) or SoDu<>0";
            dataProvider.Instance.ExecuteQuery(query1);
            string query = "SELECT MaKH, kh.CCCD , tenKH , kh.NgaySinh ,kh.GioiTinh , kh.DiaChi , kh.SDT , kh.Email , cn.TenCN , nv.TenNV , NgayThamGia , SoDu ,TinhTrangHoatDong FROM KHACHHANG kh, CHINHANH cn, NHANVIEN nv WHERE kh.ChiNhanhNhapTT=MaCN and nv.MaNV=kh.NhanVienNhapTT order by TinhTrangHoatDong desc";
            dataGridView1.DataSource = dataProvider.Instance.ExecuteQuery(query);
            dataGridView1.Columns[10].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[11].DefaultCellStyle.Format = "#,##0.##";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            b = false;
            a = false;
        }
        //danh sách chi nhánh

        //danh sách kỳ hạn
        void danhSachKyHan()
        {
            string query = "SELECT TenLoaiTK from LOAITIETKIEM";
            dt = dataProvider.Instance.ExecuteQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboloaiTietKiem.Items.Add(dt.Rows[i]["TenLoaiTK"].ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtmNgayThamGia.Format = DateTimePickerFormat.Custom;
            dtmngayMoSo.Format = DateTimePickerFormat.Custom;
            dtmNgaySinh.Format = DateTimePickerFormat.Custom;
            dtmNgayThamGia.CustomFormat = "dd-MM-yyyy";
            dtmngayMoSo.CustomFormat = "dd-MM-yyyy";
            dtmNgaySinh.CustomFormat = "dd-MM-yyyy";
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            dtmNgayThamGia.Value = date.Date;
            dtmngayMoSo.Value = date.Date;
            dtmNgaySinh.Value = new DateTime(2002, 01, 13);
            dtmngayMoSo.Enabled = true;
            txtNapTien.ReadOnly = true;
            cboTraCuu.Text = "Tên khách hàng";
            btnXacNhan.Hide();
            btnHuyBo.Hide();
            

        }
        //Chọn khách hàng mở sổ
        private void iconButton7_Click(object sender, EventArgs e)
        {

            if (txtmaKH.Text != "" && txtmaKH != null)
            {
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                txtten1.Text = txthoTen.Text;
                txtmaKH1.Text = txtmaKH.Text;
                txtdiaChi1.Text = txtdiaChi.Text;
                txtcccd1.Text = txtcccd.Text;
                txtSoDu1.Text = txtSoDu.Text;
                txtSDT1.Text = txtsdt.Text;
                txtEmail1.Text = txtgmail.Text;
            }
            else
            {
                MessageBox.Show("Mời bạn chọn khách hàng cần mở sổ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool checkTienGuiVao()
        {
            string query = "select SoTienGoiToithieuBD from THAMSO";
            dt = dataProvider.Instance.ExecuteQuery(query);
            decimal soTien;
            decimal soTienGuiVao;
            Decimal.TryParse(dt.Rows[0]["SoTienGoiToithieuBD"].ToString(), out soTien);
            Decimal.TryParse(txtTienMoSo.Text, out soTienGuiVao);
            if (soTien > soTienGuiVao)
            {
                MessageBox.Show("số tiền gửi tiết kiệm tối thiểu là: " + String.Format("{0:0,0 VNĐ}", soTien), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public string maSo;
        // mở sổ tiết kiệm 
        private void iconbtnAdd_Click(object sender, EventArgs e)
        {

            if (cboHinhThucTraLai.Text == "" || cboloaiTietKiem.Text == "" || txtTienMoSo.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkTienGuiVao())
                {
                    if (decimal.Parse(txtTienMoSo.Text) > decimal.Parse(txtSoDu1.Text))
                    {
                        MessageBox.Show("Số dư không đủ để thực hiện giao dịch", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        maSo = Random().ToString();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage2);
                        tabControl1.TabPages.Remove(tabPage5);
                        tabControl1.TabPages.Remove(tabPage3);
                        tabControl1.TabPages.Add(tabPage4);
                        lbltenkh2.Text = txtten1.Text;
                        lblmakh2.Text = txtmaKH1.Text;
                        lblkyhan2.Text = cboloaiTietKiem.Text;
                        lblhinhThucTraLai2.Text = cboHinhThucTraLai.Text;
                        lblmaso2.Text = maSo;
                        lblngayphathanh2.Text = dtmngayMoSo.Value.ToString("dd/MM/yyyy");
                        string query = "select ThoiHan from LOAITIETKIEM where TenLoaiTK= N'" + cboloaiTietKiem.Text + "'";
                        if (cboloaiTietKiem.Text == "Không kỳ hạn")
                        {
                            lblngayDenHan2.Text = "Không kỳ hạn";
                        }
                        else
                        {
                            lblngayDenHan2.Text = dtmngayMoSo.Value.AddMonths(Int32.Parse(dataProvider.Instance.ExecuteScalar(query).ToString())).ToString("dd/MM/yyyy");
                        }
                        lblchinhanh2.Text = MainFormManager.Instance.tenCN();
                        lblcccd2.Text = txtcccd1.Text;
                        lbldiachi2.Text = txtdiaChi1.Text;
                        lviSoTK.Items.Clear();
                        ListViewItem lvi = new ListViewItem(dtmngayMoSo.Value.ToString("dd/MM/yyyy"));
                        lvi.SubItems.Add(string.Format("{0:0,0}", double.Parse(txtTienMoSo.Text)));
                        lvi.SubItems.Add(string.Format("{0:0,0}", double.Parse(txtTienMoSo.Text)));
                        lvi.SubItems.Add(txtLaiSuat.Text);
                        lviSoTK.Items.Add(lvi);
                    }


                }
            }
        }


        private void iconButton5_Click(object sender, EventArgs e)
        {
            
            reload1();
            txtTienMoSo.Enabled = true;
            cboloaiTietKiem.Enabled = true;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
            
        }
        bool CheckMa(string st)
        {
            DataTable dtb = new DataTable();
            dtb = dataProvider.Instance.ExecuteQuery(st);
            if (dtb.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }


        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txthoTen.Text))
            {
                MessageBox.Show("bạn chưa nhập tên Khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txthoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtcccd.Text))
            {
                MessageBox.Show("bạn chưa nhập số CCCD", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcccd.Focus();
                return false;
            }
            else if (txtcccd.Text.Length != 12 && txtcccd.Text.Length!=9)
            {
                MessageBox.Show("CCCD không hợp lệ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtdiaChi.Text))
            {
                MessageBox.Show("bạn chưa nhập địa chỉ khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtdiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtgmail.Text))
            {
                MessageBox.Show("bạn chưa nhập Gmail khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtgmail.Focus();
                return false;
            }
            else
            {
                string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                Regex regex = new Regex(strRegex);
                if (regex.IsMatch(txtgmail.Text) == false)
                {
                    MessageBox.Show("email không hợp lệ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtsdt.Text))
            {
                MessageBox.Show("bạn chưa nhập số điện thoại khách hàng", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsdt.Focus();
                return false;
            }
            else if (txtsdt.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại bao không hợp lệ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cboGioiTinh.Text))
            {
                MessageBox.Show("bạn chưa nhập Giới tính", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGioiTinh.Focus();
                return false;
            }
            return true;
        }
        int Random()
        {
            Random rd = new Random();
            return rd.Next(100000, 999999);
        }
        private string tien = "0";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                dataGridView1.Rows[index].Selected = true;
                txtmaKH.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtcccd.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txthoTen.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                dtmNgaySinh.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                cboGioiTinh.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                txtdiaChi.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                txtsdt.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                txtgmail.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
                chkKichHoat.Checked = Convert.ToBoolean(dataGridView1.Rows[index].Cells[12].Value.ToString());
                dtmNgayThamGia.Text = dataGridView1.Rows[index].Cells[10].Value.ToString();
                txtSoDu.Text = dataGridView1.Rows[index].Cells[11].Value.ToString();
                tien = dataGridView1.Rows[index].Cells[11].Value.ToString();
                txtNapTien.ReadOnly = true;
                active();
                btnHuyBo.Hide();
                btnXacNhan.Hide();
                txtNapTien.Text = "";
                btnRutTien.Enabled = true;
                btnNapTien.Enabled = true;
            }
        }

        // Thêm xóa sửa khách hàng
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (CheckData())
            {
                string maKH = Random().ToString();
                string st = "SELECT * FROM KHACHHANG WHERE MaKH='" + maKH.ToString() + "' OR CCCD='" + txtcccd.Text + "'";
                while (CheckMa(st))
                {
                    Person per = new Person();
                    per.maKH = maKH;
                    per.cccd = txtcccd.Text;
                    per.tenKH = txthoTen.Text;
                    per.ngaySinh = dtmNgaySinh.Value;
                    per.gioiTinh = cboGioiTinh.Text;
                    per.diaChi = txtdiaChi.Text;
                    per.sdt = txtsdt.Text;
                    per.email = txtgmail.Text;
                    per.chiNhanh = MainFormManager.Instance.maCN();
                    per.nhanVien = MainFormManager.Instance.maNV();
                    per.tenKH = txthoTen.Text;
                    per.ngayThamGia = dtmNgayThamGia.Value;
                    per.soDu = 0;
                    per.tinhTrangHoatDong = false;
                    if (edit.Insert(per))
                    {
                        reload();
                        ShowData();
                        MessageBox.Show("Thêm mới khách hàng thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi không thêm được, vui lòng thử lại sau!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {

                Person per = new Person();
                per.maKH = txtmaKH.Text;
                per.cccd = txtcccd.Text;
                per.tenKH = txthoTen.Text;
                per.ngaySinh = dtmNgaySinh.Value;
                per.gioiTinh = cboGioiTinh.Text;
                per.diaChi = txtdiaChi.Text;
                per.sdt = txtsdt.Text;
                per.email = txtgmail.Text;
                per.chiNhanh = MainFormManager.Instance.maCN();
                per.nhanVien = MainFormManager.Instance.maNV();
                per.tenKH = txthoTen.Text;
                per.ngayThamGia = dtmNgayThamGia.Value;
                per.soDu = decimal.Parse(txtSoDu.Text);
                if (edit.Update(per))
                {
                    ShowData();
                    MessageBox.Show("Thông tin đã được thay đổi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi không sửa được, vui lòng thử lại sau!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        //ràng buộc nhập số cho cccd
        private void txtcccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //ràng buộc nhập số cho sdt
        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txthoTen_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        //nhập lại sổ tiết kiệm
        void reload()
        {
            chkKichHoat.Checked = false;
            a = false;
            txtmaKH.Text = "";
            txtcccd.Text = "";
            txtsdt.Text = "";
            cboGioiTinh.Text = "";
            txtdiaChi.Text = "";
            txtgmail.Text = "";
            txthoTen.Text = "";
            txtsdt.Text = "";
            txtSoDu.Text = "";
            txtNapTien.Text = "";
            dtmNgaySinh.Value = new DateTime(2002, 01, 13);
            dtmNgayThamGia.Value = date.Date;
            txtNapTien.ReadOnly = true;

        }

        void reload1()
        {
            txtTienMoSo.Text = "";
            cboloaiTietKiem.Text = null;
            txtLaiSuat.Text = "";
            cboHinhThucTraLai.Text = null;
            dtmngayMoSo.Value = date.Date;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            reload();
            tien = "0";
        }

        private void txtmaKH_TextChanged(object sender, EventArgs e)
        {
            if (txtmaKH.Text == "" || txtmaKH == null)
            {
                btnAdd.Enabled = true;
                btnSua.Enabled = false;
                btnopenPassBook.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnSua.Enabled = true;
                btnopenPassBook.Enabled = true;
            }
        }

        private void cboloaiTietKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboloaiTietKiem.Text))
            {
                string query = "SELECT LaiXuat from LOAITIETKIEM where TenLoaiTK=N'" + cboloaiTietKiem.Text + "'";
                dt = dataProvider.Instance.ExecuteQuery(query);
                txtLaiSuat.Text = dt.Rows[0]["LaiXuat"].ToString();
            }
        }

        private void iconbtninSo_Click(object sender, EventArgs e)
        {
            iconButton1.Show();
            iconButton2.Hide();
            lblmaso2.Text = maSo;
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Add(tabPage4);
            lblmakh2.Text = txtmaKH1.Text;
            lblkyhan2.Text = cboloaiTietKiem.Text;
            lbltenkh2.Text = txtten1.Text;
            lblcccd2.Text = txtcccd1.Text;
            lbldiachi2.Text = txtdiaChi1.Text;
            lblngayphathanh2.Text = date.Date.ToString("dd/MM/yyyy");
        }
        //In sổ
        private void btnInSo_Click(object sender, EventArgs e)
        {
            Print(this.pnlPrint);
        }

        Bitmap MemoryImage;

        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, rect);
        }
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, 0, 0);
        }
        public void Print(Panel pnl)
        {
            PaperSize paperSize = new PaperSize("A5", 639, 887);
            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_1);
            GetPrintArea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }


        private void txtsoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Add(tabPage2);
        }
        private void checkedrdb()
        {
            try
            {
                if (!string.IsNullOrEmpty(txttimKiem.Text))
                {
                    string query;
                    if (cboTraCuu.Text == "Số điện thoại")
                    {
                        query = "SELECT MaKH 'Mã Khách Hàng', kh.CCCD 'CCCD', tenKH 'Tên Khách Hàng', kh.NgaySinh 'Ngày Sinh', kh.GioiTinh 'Giới Tính', kh.DiaChi 'Địa Chỉ', kh.SDT 'Số Điện Thoại', kh.Email 'Email', cn.TenCN 'Chi Nhánh', nv.TenNV 'Nhân Viên', NgayThamGia 'Ngày Tham Gia', SoDu 'Số dư', TinhTrangHoatDong 'Hoạt động' FROM KHACHHANG kh, CHINHANH cn, NHANVIEN nv WHERE kh.ChiNhanhNhapTT=MaCN and nv.MaNV=kh.NhanVienNhapTT and kh.SDT like '%" + txttimKiem.Text + "%'";
                    }
                    else if (cboTraCuu.Text == "CCCD")
                    {
                        query = "SELECT MaKH 'Mã Khách Hàng', kh.CCCD 'CCCD', tenKH 'Tên Khách Hàng', kh.NgaySinh 'Ngày Sinh', kh.GioiTinh 'Giới Tính', kh.DiaChi 'Địa Chỉ', kh.SDT 'Số Điện Thoại', kh.Email 'Email', cn.TenCN 'Chi Nhánh', nv.TenNV 'Nhân Viên', NgayThamGia 'Ngày Tham Gia', SoDu 'Số dư', TinhTrangHoatDong 'Hoạt động'  FROM KHACHHANG kh, CHINHANH cn, NHANVIEN nv WHERE kh.ChiNhanhNhapTT=MaCN and nv.MaNV=kh.NhanVienNhapTT and kh.CCCD like'%" + txttimKiem.Text + "%'";
                    }
                    else if (cboTraCuu.Text == "Tên khách hàng")
                    {
                        query = "SELECT MaKH 'Mã Khách Hàng', kh.CCCD 'CCCD', tenKH 'Tên Khách Hàng', kh.NgaySinh 'Ngày Sinh', kh.GioiTinh 'Giới Tính', kh.DiaChi 'Địa Chỉ', kh.SDT 'Số Điện Thoại', kh.Email 'Email', cn.TenCN 'Chi Nhánh', nv.TenNV 'Nhân Viên', NgayThamGia 'Ngày Tham Gia', SoDu 'Số dư', TinhTrangHoatDong 'Hoạt động'  FROM KHACHHANG kh, CHINHANH cn, NHANVIEN nv WHERE kh.ChiNhanhNhapTT=MaCN and nv.MaNV=kh.NhanVienNhapTT and TenKH like N'%" + txttimKiem.Text + "%'";
                    }
                    else
                    {
                        query = "SELECT MaKH 'Mã Khách Hàng', kh.CCCD 'CCCD', tenKH 'Tên Khách Hàng', kh.NgaySinh 'Ngày Sinh', kh.GioiTinh 'Giới Tính', kh.DiaChi 'Địa Chỉ', kh.SDT 'Số Điện Thoại', kh.Email 'Email', cn.TenCN 'Chi Nhánh', nv.TenNV 'Nhân Viên', NgayThamGia 'Ngày Tham Gia', SoDu 'Số dư', TinhTrangHoatDong 'Hoạt động'  FROM KHACHHANG kh, CHINHANH cn, NHANVIEN nv WHERE kh.ChiNhanhNhapTT=MaCN and nv.MaNV=kh.NhanVienNhapTT and MaKH like N'%" + txttimKiem.Text + "%'";
                    }
                    dataGridView1.DataSource = dataProvider.Instance.ExecuteQuery(query);

                    dataGridView1.Columns[11].DefaultCellStyle.Format = "#,##0.##";
                    dataGridView1.Columns[10].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                else
                {
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void txttimKiem_TextChanged(object sender, EventArgs e)
        {
            checkedrdb();
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Ivory, ButtonBorderStyle.Solid);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (!b)
            {
                decimal sodu = decimal.Parse(txtNapTien.Text) + decimal.Parse(txtSoDu.Text);
                string query = "update KHACHHANG set SoDu=" + sodu + "where MaKH='" + txtmaKH.Text + "'";
                phieuGuiTien pg = new phieuGuiTien();
                pg.maPhieu = lblMaPhieuGui.Text;
                pg.maKH = txtmaKH.Text;
                pg.maCN = MainFormManager.Instance.maCN();
                pg.ngayGui = date;
                pg.soTienGui = decimal.Parse(txtNapTien.Text);
                pg.maNV = MainFormManager.Instance.maNV();
                pg.noiDungGiaoDich = "Nộp tiền vào tài khoản";
                if (edit.InsertphieuGuiTien(pg) && dataProvider.Instance.ExecuteNonQuery(query) != 0)
                {
                    Print(panel11);
                    MessageBox.Show("Giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b = true;
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Print(panel11);
            }

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private void readOnLy()
        {
            txthoTen.ReadOnly = txtcccd.ReadOnly = txtgmail.ReadOnly = txtSoDu.ReadOnly = txtdiaChi.ReadOnly = txtsdt.ReadOnly = true;
            dtmNgaySinh.Enabled = dtmNgayThamGia.Enabled = cboGioiTinh.Enabled = txtNapTien.ReadOnly = false;
            btnSua.Enabled = false;
            btnNhapLai.Enabled = false;
            btnopenPassBook.Enabled = false;
            label43.BackColor = Color.White;

        }
        private void active()
        {
            txthoTen.ReadOnly = txtcccd.ReadOnly = txtgmail.ReadOnly = txtdiaChi.ReadOnly = txtsdt.ReadOnly = false;
            dtmNgaySinh.Enabled = dtmNgayThamGia.Enabled = cboGioiTinh.Enabled = txtNapTien.ReadOnly = true;
            btnSua.Enabled = true;
            btnNhapLai.Enabled = true;
            btnopenPassBook.Enabled = true;
            btnNapTien.Enabled = true;
            btnRutTien.Enabled = true;
            label43.BackColor = Color.WhiteSmoke;
        }
        private void btnNapTien_Click(object sender, EventArgs e)
        {

            a = false;
            if (string.IsNullOrEmpty(txtmaKH.Text))
            {
                MessageBox.Show("Mời chọn khách hàng cần nạp tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtNapTien.Enabled = true;
                txtNapTien.Focus();
                txtNapTien.Text = "";
                btnXacNhan.Show();
                btnHuyBo.Show();
                readOnLy();
                btnRutTien.Enabled = false;
            }
        }

        private void txtNapTien_TextChanged(object sender, EventArgs e)
        {
            if (txtNapTien.Text == "00")
            {
                txtNapTien.Text = "";
            }
            if (!string.IsNullOrEmpty(txtNapTien.Text))
            {
                txtNapTien.Text = string.Format("{0:0,0}", double.Parse(txtNapTien.Text));
                txtNapTien.SelectionStart = txtNapTien.Text.Length;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNapTien.Text))
            {
                maPhieuGui = Random().ToString();
                if (!a)
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage5);
                    lblchinhanh1.Text = MainFormManager.Instance.tenCN();
                    lblngay1.Text = date.ToString("dd/MM/yyyy");
                    lbltenKH1.Text = txthoTen.Text;
                    lblSDT1.Text = txtsdt.Text;
                    lblmakh1.Text = txtmaKH.Text;
                    lblcccd1.Text = txtcccd.Text;
                    lbldiachi1.Text = txtdiaChi.Text;
                    lblsoTienSo1.Text = String.Format("{0:0,0 VNĐ}", double.Parse(txtNapTien.Text));
                    lblSoTienChu1.Text = NumberToText(double.Parse(txtNapTien.Text));
                    lblMaPhieuGui.Text = maPhieuGui;
                }
                else
                {
                    if (decimal.Parse(txtSoDu.Text) < decimal.Parse(txtNapTien.Text))
                    {
                        MessageBox.Show("Số dư không đủ để thực hiện giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage4);
                        tabControl1.TabPages.Remove(tabPage2);
                        tabControl1.TabPages.Remove(tabPage5);
                        tabControl1.TabPages.Add(tabPage3);
                        lblchinhanh3.Text = MainFormManager.Instance.tenCN();
                        lblngay3.Text = date.ToString("dd/MM/yyyy");
                        lbltenKH3.Text = txthoTen.Text;
                        lblSDT3.Text = txtsdt.Text;
                        lblmakh3.Text = txtmaKH.Text;
                        lblcccd3.Text = txtcccd.Text;
                        lbldiachi3.Text = txtdiaChi.Text;
                        lblsoTienSo3.Text = String.Format("{0:0,0 VNĐ}", double.Parse(txtNapTien.Text));
                        lblSoTienChu3.Text = NumberToText(double.Parse(txtNapTien.Text));
                        lblMaPhieuRut3.Text = maPhieuGui;
                    }
                }


            }
            else
            {
                MessageBox.Show("Nhập số tiền cần nộp / rút", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtNapTien.Focus();
            }



        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            active();
            btnHuyBo.Hide();
            btnXacNhan.Hide();
            txtNapTien.Text = "";
        }

        private void txtSoDu_TextChanged(object sender, EventArgs e)
        {
            if (txtSoDu.Text == "00")
            {
                txtSoDu.Text = "0";
            }
            if (!string.IsNullOrEmpty(txtSoDu.Text) && txtSoDu.Text != "0")
            {
                txtSoDu.Text = string.Format("{0:0,0}", decimal.Parse(txtSoDu.Text));
                txtSoDu.SelectionStart = txtSoDu.Text.Length;
            }

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage1);
            reload();
            tien = "0";
            txtSoDu.Text = "";
            btnHuyBo.Hide();
            btnXacNhan.Hide();
            active();
            ShowData();

        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần tra cứu","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query0 = "SELECT MaSoTK,NgayMoSo,ThoiHan,LaiXuat,SoVon,HinhThucTraLai,MaKH,SoLanGiaHan From SOTIETKIEM STK, LOAITIETKIEM LTK where SoVon<>'0' AND STK.MaLoaiTK=LTK.MaLoaiTK AND MaKH='" + txtmaKH.Text + "'";
                dgv1.DataSource = dataProvider.Instance.ExecuteQuery(query0);
               
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    
                    
                    
                       
                        if (dgv1.Rows[i].Cells[5].Value.ToString() == "Tất toán sổ ")
                        {
                            
                            DateTime ngaygoi = DateTime.Parse(dgv1.Rows[i].Cells[1].Value.ToString());
                            int thangTH;
                            bool a = int.TryParse(dgv1.Rows[i].Cells[2].Value.ToString(), out thangTH);
                            DateTime ngaydh = ngaygoi.AddDays(30 * thangTH);
                           
                            if (DateTime.Today >= ngaydh)
                            {
                                ulong tiengoc = (ulong)(float.Parse(dgv1.Rows[i].Cells[4].Value.ToString()));
                                float laisuatKH = float.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                                ulong laisuat = (ulong)(tiengoc * (laisuatKH / 100));
                                string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'").ToString();
                                decimal sodusau = decimal.Parse(sodubd) + (decimal)tiengoc + (decimal)laisuat;
                                string st1 = "UPDATE SOTIETKIEM SET SoVon='0' WHERE MaSoTK='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                                string query2 = "update KHACHHANG set SoDu='" + sodusau + "'where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'";
                                string maPhieu = Random().ToString();
                                string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                                while (!CheckMa(st))
                                {
                                    maPhieu = Random().ToString();
                                }
                                string query3 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + dgv1.Rows[i].Cells[6].Value.ToString() + "','" + MainFormManager.Instance.maNV().ToString() + "','" + ngaydh.ToString("yyyy/MM/dd") + "','" + ((decimal)tiengoc + (decimal)laisuat) + "','" + MainFormManager.Instance.maCN().ToString() + "',N'Tất toán sổ tiết kiệm')";
                                dataProvider.Instance.ExecuteNonQuery(st1);
                                dataProvider.Instance.ExecuteNonQuery(query2);
                                dataProvider.Instance.ExecuteNonQuery(query3);
                            }
                        }
                    if (dgv1.Rows[i].Cells[5].Value.ToString() == "Lãi trả vào tài khoản khách hàng ")
                    {

                        DateTime ngaygoi = DateTime.Parse(dgv1.Rows[i].Cells[1].Value.ToString());
                        TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                        int intI = interval.Days;
                        int thangGoi = (int)(intI / 30);
                        int thangTH;
                        bool a = int.TryParse(dgv1.Rows[i].Cells[2].Value.ToString(), out thangTH);
                        int soKH1 = (int)(thangGoi / thangTH);
                        DateTime ngaydh = ngaygoi.AddDays(30 * thangTH * soKH1);
                        int solangiahan;
                        a = int.TryParse(dgv1.Rows[i].Cells[7].Value.ToString(), out solangiahan);
                        while (solangiahan < soKH1)
                        {
                            ngaydh = ngaygoi.AddDays(30 * thangTH * (solangiahan + 1));
                            ulong tiengoc = (ulong)(float.Parse(dgv1.Rows[i].Cells[4].Value.ToString()));
                            float laisuatKH = float.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                            ulong laisuat = (ulong)(tiengoc * (laisuatKH / 100));
                            string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'").ToString();
                            decimal sodusau = decimal.Parse(sodubd) + (decimal)laisuat;
                            string st1 = "UPDATE SOTIETKIEM SET SoLanGiaHan='" + (solangiahan + 1).ToString() + "' WHERE MaSoTK='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                            string query2 = "update KHACHHANG set SoDu='" + sodusau + "'where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'";
                            string maPhieu = Random().ToString();
                            string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                            while (!CheckMa(st))
                            {
                                maPhieu = Random().ToString();
                            }
                            string query3 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + dgv1.Rows[i].Cells[6].Value.ToString() + "','" + MainFormManager.Instance.maNV().ToString() + "','" + ngaydh.ToString("yyyy/MM/dd") + "','" + ((decimal)laisuat) + "','" + MainFormManager.Instance.maCN().ToString() + "',N'Trả lãi từ sổ tiết kiệm')";
                            dataProvider.Instance.ExecuteNonQuery(st1);
                            dataProvider.Instance.ExecuteNonQuery(query2);
                            dataProvider.Instance.ExecuteNonQuery(query3);

                            solangiahan++;
                        }
                    }
                   
                }

                //TuDongGiaHan(txtmaKH.Text);
                string query = "select NgayGoi as 'NgayGui',SoTienGoi as 'SoTienGui',NoiDungGiaoDich as 'NoiDungGiaoDichGui' from PHIEUGOITIEN where MaKH='" + txtmaKH.Text + "' order by NgayGoi DESC";
                string query1 = "select NgayRut as 'NgayRut',SoTienRut as 'SoTienRut',NoiDungGiaoDich as 'NoiDungGiaoDichRut' from PHIEURUTTIEN where MaKH='" + txtmaKH.Text + "' order by NgayRut DESC";
                dvgLichSuNop.DataSource = dataProvider.Instance.ExecuteQuery(query);
                dvgLichSuRut.DataSource = dataProvider.Instance.ExecuteQuery(query1);
                dvgLichSuNop.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
                dvgLichSuNop.Columns[1].DefaultCellStyle.Format = "+#,##0.##";
                dvgLichSuRut.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
                dvgLichSuRut.Columns[1].DefaultCellStyle.Format = "-#,##0.##";
                lblMaKHGD.Text = txtmaKH.Text;
                lblTenKHGD.Text = txthoTen.Text;
                lblSoDu.Text = txtSoDu.Text;
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage6);
                //lịch sử GD
                
            }
        }

        void TuDongGiaHan( string maKH) // thêm  chia 100 hàm tính lãi của cái đầu và cái cuối
        {
            

            MessageBox.Show(dgv1.Rows.Count.ToString());

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                MessageBox.Show("dòng " + i);
                MessageBox.Show(dgv1.Rows[i].Cells[2].Value.ToString());
                if (dgv1.Rows[i].Cells[2].Value.ToString() != "100")
                {
                    if (dgv1.Rows[i].Cells[5].Value.ToString() == "Tất toán sổ")
                    {
                        DateTime ngaygoi = DateTime.Parse(dgv1.Rows[i].Cells[1].Value.ToString());
                        int thangTH;
                        bool a = int.TryParse(dgv1.Rows[i].Cells[2].Value.ToString(), out thangTH);
                        DateTime ngaydh = ngaygoi.AddDays(30 * thangTH);
                        if (DateTime.Today >= ngaydh.Date)
                        {
                            ulong tiengoc = (ulong)(float.Parse(dgv1.Rows[i].Cells[4].Value.ToString()));
                            float laisuatKH = float.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                            ulong laisuat = (ulong)(tiengoc * (laisuatKH / 100));
                            string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'").ToString();
                            decimal sodusau = decimal.Parse(sodubd) + (decimal)tiengoc + (decimal)laisuat;
                            string query1 = "UPDATE SOTIETKIEM SET SoVon='0' WHERE MaSoTK='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                            string query2 = "update KHACHHANG set SoDu='" + sodusau + "'where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'";
                            dataProvider.Instance.ExecuteNonQuery(query1);
                            dataProvider.Instance.ExecuteNonQuery(query2);
                        }
                    }
                    if (dgv1.Rows[i].Cells[5].Value.ToString() == "Lãi trả vào tài khoản khách hàng")
                    {
                        DateTime ngaygoi = DateTime.Parse(dgv1.Rows[i].Cells[1].Value.ToString());
                        TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                        int intI = interval.Days;
                        int thangGoi = (int)(intI / 30);
                        int thangTH;
                        bool a = int.TryParse(dgv1.Rows[i].Cells[2].Value.ToString(), out thangTH);
                        int soKH1 = (int)(thangGoi / thangTH);
                        DateTime ngaydh = ngaygoi.AddDays(30 * thangTH * soKH1);
                        int solangiahan;
                        a = int.TryParse(dgv1.Rows[i].Cells[7].Value.ToString(), out solangiahan);
                        if (DateTime.Today >= ngaydh.Date && solangiahan < soKH1)
                        {
                            ulong tiengoc = (ulong)(float.Parse(dgv1.Rows[i].Cells[4].Value.ToString()));
                            float laisuatKH = float.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                            ulong laisuat = (ulong)(tiengoc * (laisuatKH / 100));
                            string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'").ToString();
                            decimal sodusau = decimal.Parse(sodubd) + (decimal)laisuat;
                            string query1 = "UPDATE SOTIETKIEM SET SoLanGiaHan='" + (solangiahan + 1).ToString() + "' WHERE MaSoTK='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                            string query2 = "update KHACHHANG set SoDu='" + sodusau + "'where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'";
                            dataProvider.Instance.ExecuteNonQuery(query1);
                            dataProvider.Instance.ExecuteNonQuery(query2);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("thời hạn 5s");
                    if (dgv1.Rows[i].Cells[5].Value.ToString() == "Tất toán sổ")
                    {
                        MessageBox.Show("tất toán sổ");
                        DateTime ngaygoi = DateTime.Parse(dgv1.Rows[i].Cells[1].Value.ToString());                      
                        DateTime ngaydh = ngaygoi.AddSeconds(5);
                        MessageBox.Show(ngaydh.ToString());
                        if (DateTime.Now>= ngaydh)
                        {
                            MessageBox.Show("đã đáo hạn");
                            ulong tiengoc = (ulong)(float.Parse(dgv1.Rows[i].Cells[4].Value.ToString()));
                            float laisuatKH = float.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                            ulong laisuat = (ulong)(tiengoc * (laisuatKH / 100));
                            string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'").ToString();
                            decimal sodusau = decimal.Parse(sodubd) + (decimal)tiengoc + (decimal)laisuat;
                            string query1 = "UPDATE SOTIETKIEM SET SoVon='0' WHERE MaSoTK='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                            string query2 = "update KHACHHANG set SoDu='" + sodusau + "'where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'";
                            string maPhieu = Random().ToString();
                            string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                            while (!CheckMa(st))
                            {
                                maPhieu = Random().ToString();
                            }
                            string query3 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + dgv1.Rows[i].Cells[6].Value.ToString() + "','" + MainFormManager.Instance.maNV().ToString() + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + ((decimal)tiengoc + (decimal)laisuat) + "','" + MainFormManager.Instance.maCN().ToString() + "','Tất toán sổ tiết kiệm')";
                            dataProvider.Instance.ExecuteNonQuery(query1);
                            dataProvider.Instance.ExecuteNonQuery(query2);
                            dataProvider.Instance.ExecuteNonQuery(query3);
                        }
                    }
                    if (dgv1.Rows[i].Cells[5].Value.ToString() == "Lãi trả vào tài khoản khách hàng")
                    {
                        DateTime ngaygoi = DateTime.Parse(dgv1.Rows[i].Cells[1].Value.ToString());
                        TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                        int thangGoi = (int)(interval.Seconds);
                        int thangTH=5;                       
                        int soKH1 = (int)(thangGoi / thangTH);
                        DateTime ngaydh = ngaygoi.AddSeconds( thangTH * soKH1);
                        int solangiahan;
                        a = int.TryParse(dgv1.Rows[i].Cells[7].Value.ToString(), out solangiahan);
                        while (DateTime.Now >= ngaydh && solangiahan < soKH1)
                        {
                            ulong tiengoc = (ulong)(float.Parse(dgv1.Rows[i].Cells[4].Value.ToString()));
                            float laisuatKH = float.Parse(dgv1.Rows[i].Cells[3].Value.ToString());
                            ulong laisuat = (ulong)(tiengoc * (laisuatKH / 100));
                            string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'").ToString();
                            decimal sodusau = decimal.Parse(sodubd) + (decimal)laisuat;
                            string query1 = "UPDATE SOTIETKIEM SET SoLanGiaHan='" + (solangiahan + 1).ToString() + "' WHERE MaSoTK='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                            string query2 = "update KHACHHANG set SoDu='" + sodusau + "'where MaKH='" + dgv1.Rows[i].Cells[6].Value.ToString() + "'";
                            string maPhieu = Random().ToString();
                            string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                            while (!CheckMa(st))
                            {
                                maPhieu = Random().ToString();
                            }
                            string query3 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + dgv1.Rows[i].Cells[6].Value.ToString() + "','" + MainFormManager.Instance.maNV().ToString() + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + ((decimal)laisuat) + "','" + MainFormManager.Instance.maCN().ToString() + "','Trả lãi từ sổ tiết kiệm')";
                            dataProvider.Instance.ExecuteNonQuery(query1);
                            dataProvider.Instance.ExecuteNonQuery(query2);
                            dataProvider.Instance.ExecuteNonQuery(query3);
                            string query = "SELECT MaSoTK,NgayMoSo,ThoiHan,LaiXuat,SoVon,HinhThucTraLai,MaKH,SoLanGiaHan From SOTIETKIEM STK, LOAITIETKIEM LTK where SoVon<>'0' AND STK.MaLoaiTK=LTK.MaLoaiTK AND MaKH='" + txtmaKH.Text + "'";
                            dgv.DataSource = dataProvider.Instance.ExecuteQuery(query);
                            a = int.TryParse(dgv1.Rows[i].Cells[7].Value.ToString(), out solangiahan);
                        }
                    }
                }
            }
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            string query = "SELECT MaLoaiTK from LOAITIETKIEM where TenLoaiTK=N'" + cboloaiTietKiem.Text + "'";
            string st = "SELECT * FROM  SOTIETKIEM WHERE MaSoTK ='" + lblmaso2.Text + "' ";
            if (!b)
            {
                while (CheckMa(st))
                {
                   
                        Passbook pb = new Passbook();
                        pb.maSoTK = lblmaso2.Text;
                        pb.maKH = txtmaKH1.Text;
                        pb.maLoaiTK = dataProvider.Instance.ExecuteScalar(query).ToString();
                        pb.maNV = MainFormManager.Instance.maNV();
                        pb.maChiNhanh = MainFormManager.Instance.maCN();
                        pb.ngayMoSo = dtmngayMoSo.Value;
                        pb.soDuSo = decimal.Parse(txtTienMoSo.Text);
                        pb.hinhThucTraLai = cboHinhThucTraLai.Text;
                        pb.soLanGiaHan = 0;
                        decimal sodu = decimal.Parse(txtSoDu1.Text) - decimal.Parse(txtTienMoSo.Text);
                        string query2 = "update KHACHHANG set SoDu=" + sodu + "where MaKH='" + lblmakh2.Text + "'";

                        phieuRutTien pr = new phieuRutTien();
                        pr.maPhieu = Random().ToString();
                        pr.maKH = txtmaKH.Text;
                        pr.maCN = MainFormManager.Instance.maCN();
                        pr.ngayRut = dtmngayMoSo.Value;
                        pr.soTienRut = decimal.Parse(txtTienMoSo.Text);
                        pr.maNV = MainFormManager.Instance.maNV();
                        pr.noiDungGiaoDich = "Nộp tiền vào sổ tiết kiệm";
                        if (edit.InsertPassBook(pb) && dataProvider.Instance.ExecuteNonQuery(query2) != 0 && edit.InsertphieuRutTien(pr))
                        {
                            b = true;
                            Print(pnlPrint);
                            TuDongGoiMail();
                            MessageBox.Show("mở sổ thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reload();
                            reload1();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng kiểm tra lại thông tin!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                   
                }
            }
            else
            {
                Print(pnlPrint);
            }
        }
        void TuDongGoiMail()// thêm thông tin tk bên sendmail mở tk
        {
            string query0 = "SELECT MaSoTK,TenKH,NgayMoSo,ThoiHan,LaiXuat,HinhThucTraLai,Email From SOTIETKIEM STK, LOAITIETKIEM LTK, KHACHHANG KH where SoVon<>'0' AND STK.MaLoaiTK=LTK.MaLoaiTK AND KH.MaKH=STK.MaKH";
            dgv2.DataSource = dataProvider.Instance.ExecuteQuery(query0);
            //MessageBox.Show(dgv2.Rows.Count.ToString());
            for (int i = 0; i < dgv2.Rows.Count-1; i++)
            {
               
                DateTime ngaygoi;
                int thangTH;
                DateTime ngaydh;
                if (dgv2.Rows[i].Cells[5].Value.ToString() == "Tất toán sổ ")                 
                {
                    //MessageBox.Show("tất toán sổ");
                    ngaygoi = DateTime.Parse(dgv2.Rows[i].Cells[2].Value.ToString());
                    bool a = int.TryParse(dgv2.Rows[i].Cells[3].Value.ToString(), out thangTH);
                    ngaydh = ngaygoi.AddDays(30 * thangTH);
                    string content = "<h2 >Thông báo!</h2> <h4> Xin chào " + dgv2.Rows[i].Cells[1].Value.ToString() + "! </h4> <p>Sổ tiết kiệm <b>" + dgv2.Rows[i].Cells[0].Value.ToString() + "</b> của bạn sẽ tự động tất toán vào ngày <b>" + ngaydh.ToString("dd/MM/yyyy") + "</b> </p><p> Số tiền gốc và lãi sẽ được chuyển vào tài khoản của bạn</p><p>**<i>Hãy đến chi nhánh gần nhất để kiểm tra và thực hiện giao dịch bạn mong muốn</i>**</p> ";
                    CheckSendMail(ngaydh, content, dgv2.Rows[i].Cells[6].Value.ToString());
                    //MessageBox.Show(ngaydh.AddDays(-5).ToString());
                }
                if (dgv2.Rows[i].Cells[5].Value.ToString() == "Lãi nhập gốc ")
                {
                    ngaygoi = DateTime.Parse(dgv2.Rows[i].Cells[2].Value.ToString());
                    TimeSpan interval = DateTime.Today.Subtract(ngaygoi);
                    int intI = interval.Days;
                    int thangGoi = (int)(intI / 30);
                    bool a = int.TryParse(dgv2.Rows[i].Cells[3].Value.ToString(), out thangTH);
                    int soKH = (int)(thangGoi / thangTH);
                    ngaydh = ngaygoi.AddDays(30 * thangTH * (soKH + 1));
                    string content = "<h2 >Thông báo!</h2> <h4> Xin chào " + dgv2.Rows[i].Cells[1].Value.ToString() + "! </h4> <p>Sổ tiết kiệm <b>" + dgv2.Rows[i].Cells[0].Value.ToString() + "</b> của bạn sẽ tự động gia hạn vào ngày <b>" + ngaydh.ToString("dd/MM/yyyy") + "</b> </p><p> Số tiền lãi sẽ được gộp vào số tiền gốc để tính lãi lần tiếp theo</p><p>**<i>Hãy đến chi nhánh gần nhất để kiểm tra và thực hiện giao dịch bạn mong muốn</i>**</p> ";
                    CheckSendMail(ngaydh, content, dgv2.Rows[i].Cells[6].Value.ToString());
                }
                if (dgv2.Rows[i].Cells[5].Value.ToString() == "Lãi trả vào tài khoản khách hàng ")
                {
                    ngaygoi = DateTime.Parse(dgv2.Rows[i].Cells[2].Value.ToString());
                    TimeSpan interval = DateTime.Today.Subtract(ngaygoi);
                    int intI = interval.Days;
                    int thangGoi = (int)(intI / 30);
                    bool a = int.TryParse(dgv2.Rows[i].Cells[3].Value.ToString(), out thangTH);
                    int soKH = (int)(thangGoi / thangTH);
                    ngaydh = ngaygoi.AddDays(30 * thangTH * (soKH + 1));
                    string content = "<h2 >Thông báo!</h2> <h4> Xin chào " + dgv2.Rows[i].Cells[1].Value.ToString() + "! </h4> <p>Sổ tiết kiệm <b>" + dgv2.Rows[i].Cells[0].Value.ToString() + "</b> của bạn sẽ tự động gia hạn vào ngày <b>" + ngaydh.ToString("dd/MM/yyyy") + "</b> </p><p> Số tiền lãi sẽ được trả vào tài khoản của bạn</p><p>**<i>Hãy đến chi nhánh gần nhất để kiểm tra và thực hiện giao dịch bạn mong muốn</i>**</p> ";
                    CheckSendMail(ngaydh, content, dgv2.Rows[i].Cells[6].Value.ToString());
                }

            }
        }
        void CheckSendMail(DateTime ngaydh, string content, string mailto)
        {
            if (ngaydh.AddDays(-5) == DateTime.Today)
            {
                string subject = "Thông báo sổ sắp đáo hạn!";
                SendMail("bankingmeta@gmail.com", mailto, subject, content);
            }
        }
        void SendMail(string mailfrom, string mailto, string subject, string content)
        {
            MailMessage mail = new MailMessage(mailfrom, mailto, subject, content); //
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("bankingmeta@gmail.com", "gxokcndrtxerjuwy"); /// Sử dụng tài khoản gmail người gửi
            client.EnableSsl = true;
            client.Send(mail);
        }
        private void btnRutTien_Click(object sender, EventArgs e)
        {

            a = true;
            if (string.IsNullOrEmpty(txtmaKH.Text))
            {
                MessageBox.Show("Mời chọn khách hàng cần nạp tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtNapTien.Enabled = true;
                txtNapTien.Focus();
                txtNapTien.Text = "";
                btnXacNhan.Show();
                btnHuyBo.Show();
                readOnLy();
                btnNapTien.Enabled = false;
            }
        }

        private void iconButton10_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage1);
            reload();
            tien = "0";
            txtSoDu.Text = "";
            btnHuyBo.Hide();
            btnXacNhan.Hide();
            active();
            ShowData();
        }

        private void iconButton11_Click_1(object sender, EventArgs e)
        {
            if (!b)
            {
                decimal sodu = decimal.Parse(txtSoDu.Text) - decimal.Parse(txtNapTien.Text);
                string query = "update KHACHHANG set SoDu='" + sodu + "'where MaKH='" + txtmaKH.Text + "'";
                phieuRutTien pr = new phieuRutTien();
                pr.maPhieu = lblMaPhieuRut3.Text;
                pr.maKH = txtmaKH.Text;
                pr.maCN = MainFormManager.Instance.maCN();
                pr.ngayRut = date;
                pr.soTienRut = decimal.Parse(txtNapTien.Text);
                pr.maNV = MainFormManager.Instance.maNV();
                pr.noiDungGiaoDich = "Rút tiền trong tài khoản";
                if (edit.InsertphieuRutTien(pr) && dataProvider.Instance.ExecuteNonQuery(query) != 0)
                {
                    Print(panel7);
                    MessageBox.Show("Giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b = true;
                }
                else
                {
                    MessageBox.Show("Giao dịch thất bại, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Print(panel7);
            }

        }

        private void txtTienMoSo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTienMoSo.Text))
            {
                txtTienMoSo.Text = string.Format("{0:0,0}", double.Parse(txtTienMoSo.Text));
                txtTienMoSo.SelectionStart = txtTienMoSo.Text.Length;
            }
        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            if (b)
            {
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage1);
                tien = "0";
                btnHuyBo.Hide();
                btnXacNhan.Hide();
                active();
                ShowData();
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage2);
                tien = "0";
                btnHuyBo.Hide();
                btnXacNhan.Hide();
                active();
                ShowData();
            }

        }

        private void txtNapTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Add(tabPage1);
        }
    }
}
