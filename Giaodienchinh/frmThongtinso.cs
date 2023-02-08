using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thong_Tin_Khach_hang;
using System.Drawing.Printing;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class frmThongtinso : Form
    {
        DataTable dt = new DataTable();
        bool loaded = false;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        editPerson editPerson = new editPerson();
        DateTime date = DateTime.Now;
        ulong lai = 0;
        ulong lai1 = 0;
        ulong goclai = 0;
        bool loadedLTk = false;
        bool a = false;
        int soKH = 0;
        ulong goc = 0;
        public frmThongtinso()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            MainFormManager.Instance.openChildForm(new frmthongTinKhachHang());
        }
        void LoadChiNhanh()
        {
            string st = "SELECT MaCN,TenCN FROM CHINHANH";
            cbCN.DisplayMember = "TenCN";
            cbCN.ValueMember = "MaCN";
            dt1 = dataProvider.Instance.ExecuteQuery(st);
            cbCN.DataSource = dt1;
            cbCN.Text = "";
        }
        void LoadThoiHan()
        {
            string st = "SELECT MaLoaiTK,ThoiHan FROM LOAITIETKIEM";
            cbTH.DisplayMember = "ThoiHan";
            cbTH.ValueMember = "MaLoaiTK";
            dt2 = dataProvider.Instance.ExecuteQuery(st);
            DataView dv = dt2.DefaultView;
            dv.Sort = "ThoiHan asc";
            DataTable sortedtable1 = dv.ToTable();
            cbTH.DataSource = sortedtable1;
            cbTH.Text = "";
        }
        private void frmThongtinso_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            LoadChiNhanh();
            LoadThoiHan();
            LoadData();
            loaded = true;
            
            //dtNgayMS1.CustomFormat = "dd-MM-yyyy";
            string query = "select TenNV,TenCN from NHANVIEN,CHINHANH where NHANVIEN.ChiNhanhLV=CHINHANH.MaCN AND SDT='" + Login.sdt + "'";
            dt = dataProvider.Instance.ExecuteQuery(query);
            cboNhanVien1.Text=cbNV1.Text =txtnhanVien3.Text= dt.Rows[0]["TenNV"].ToString();
            cboChiNhanh1.Text=cbCN1.Text =txtchiNhanh3.Text= dt.Rows[0]["TenCN"].ToString();
        }
        private string maCN(string text)
        {
            string query = "SELECT MaCN from CHINHANH where TenCN=N'" + text + "'";
            dt = dataProvider.Instance.ExecuteQuery(query);
            string macn = dt.Rows[0]["MaCN"].ToString();
            return macn;
        }
        private string maNV(string text)
        {
            string query = "SELECT MaNV from NHANVIEN where TenNV=N'" + text + "'";
            dt = dataProvider.Instance.ExecuteQuery(query);
            string maNV = dt.Rows[0]["MaNV"].ToString();
            return maNV;
        }
        /* private void iconButton3_Click(object sender, EventArgs e)
         {
             a = false;
             if (!string.IsNullOrEmpty(txtMaSo.Text) || !string.IsNullOrEmpty(txtTenKH.Text) || !string.IsNullOrEmpty(txtMaKH.Text) || !string.IsNullOrEmpty(txtNhanVien.Text) || !string.IsNullOrEmpty(txtMaNhanVien.Text) || !string.IsNullOrEmpty(txtChiNhanh.Text) || !string.IsNullOrEmpty(txtNgayMoSo.Text) || !string.IsNullOrEmpty(txtSoDu.Text))
             {

                 System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                 string query = "select CCCD,DiaChi from khachhang where maKh='" + txtMaKH.Text + "'";
                 string query1 = "select TenLoaiTK, LaiXuat from LOAITIETKIEM where ThoiHan='" + txtThoiHan.Text + "'";
                 dt = dataProvider.Instance.ExecuteQuery(query);
                 tabControl1.TabPages.Remove(tabPage1);
                 tabControl1.TabPages.Remove(tabPage3);
                 tabControl1.TabPages.Remove(tabPage4);
                 tabControl1.TabPages.Remove(tabPage5);
                 tabControl1.TabPages.Remove(tabPage6);
                 tabControl1.TabPages.Remove(tabPage7);
                 tabControl1.TabPages.Remove(tabPage8);
                 tabControl1.TabPages.Add(tabPage2);
                 txtMaKH2.Text = txtMaKH.Text;
                 txtTenKH2.Text = txtTenKH.Text;
                 txtCCCD2.Text = dt.Rows[0]["CCCD"].ToString();
                 txtDiaChi2.Text = dt.Rows[0]["DiaChi"].ToString();
                 txtMaSoTK1.Text = txtMaSo.Text;
                 dt = dataProvider.Instance.ExecuteQuery(query1);
                 txtLoaiTK.Text = dt.Rows[0]["TenLoaiTK"].ToString();
                 txtLaiSuat1.Text = dt.Rows[0]["LaiXuat"].ToString();
                 txtTienGuiVao.Text = txtSoDu.Text;
                 txtngayRut.Text = date.Date.ToString("dd/MM/yyyy");
                 ulong x = (ulong)float.Parse(txtTienGuiVao.Text);
                 float y = float.Parse(txtLaiSuat1.Text);
                 TimeSpan time = DateTime.Now - Convert.ToDateTime(txtNgayMoSo.Text).AddMonths(Int32.Parse(txtThoiHan.Text));
                 int soNgayQuaDaoHan = time.Days;
                 TimeSpan time2 = DateTime.Now - Convert.ToDateTime(txtNgayMoSo.Text);
                 int soNgayGuiTietKiem = time.Days;
                 if (chkDaoHan.Checked == true)
                 {
                     txtTienL.Text = String.Format("{0:0,0}", (x * (y / 100)));
                     string query2 = "select LaiXuat from LOAITIETKIEM where ThoiHan=0";
                     dt = dataProvider.Instance.ExecuteQuery(query2);
                     float laiKhongThoiHan = float.Parse(dt.Rows[0]["LaiXuat"].ToString());
                     float tienGuiVao = float.Parse(txtTienGuiVao.Text);
                     float tienLai = float.Parse(txtTienL.Text);
                     ulong tienLaiCongGoc = (ulong)(tienGuiVao + tienLai);
                     double tienLaiKhongThoiHan = (tienLaiCongGoc) *Math.Pow((1 + (laiKhongThoiHan / 100)), (soNgayQuaDaoHan / 30))- tienLaiCongGoc;
                     txtLaiKhongKyHan.Text = String.Format("{0:0,0}", tienLaiKhongThoiHan);
                 }
                 else if (chkTuGiaHan.Checked)
                 {
                     goclai = (ulong)(float.Parse(txtSoDu.Text));
                     string query3 = "SELECT * FROM PHIEURUTTIEN WHERE MaSoTK='" + txtMaSoTK1.Text + "'";
                     DataTable dtb = new DataTable();
                     dtb = dataProvider.Instance.ExecuteQuery(query3);
                     if (dtb.Rows.Count == 0)
                     {
                         string st = "SELECT TOP(1) PGT.NgayGoi FROM PHIEUGOITIEN PGT WHERE PGT.MaSoTK='" + txtMaSoTK1.Text + "' ORDER BY PGT.NgayGoi ASC";
                         DateTime ngaygoi = DateTime.Parse(dataProvider.Instance.ExecuteScalar(st).ToString());
                         TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                         int intI = interval.Days;
                         int thangGoi = (int)(intI / 30);
                         int thangKH = int.Parse(txtThoiHan.Text);
                         int soKH = (int)(thangGoi / thangKH);
                         ulong goc = (ulong)(goclai / (Math.Pow((1 + y / 100), soKH)));
                         lai = goclai - goc;
                         txtTienL.Text = String.Format("{0:0,0}", lai);
                         txtTienGuiVao.Text = String.Format("{0:0,0}", goc);
                         txtLaiKhongKyHan.Text = "0";
                     }
                     else
                     {
                         string st = "SELECT TOP(1) PRT.NgayRut FROM PHIEURUTTIEN PRT WHERE PRT.MaSoTK='" + txtMaSoTK1.Text + "' ORDER BY PRT.NgayRut DESC";
                         DateTime ngaygoi = DateTime.Parse(dataProvider.Instance.ExecuteScalar(st).ToString());
                         TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                         int intI = interval.Days;
                         int thangGoi = (int)(intI / 30);
                         int thangKH = int.Parse(txtThoiHan.Text);
                         int soKH = (int)(thangGoi / thangKH);
                         ulong goc = (ulong)(goclai / (Math.Pow((1 + y / 100), soKH)));
                         lai = goclai - goc;
                         txtTienL.Text = String.Format("{0:0,0}", lai);
                         txtTienGuiVao.Text = String.Format("{0:0,0}", goc);
                         txtLaiKhongKyHan.Text = "0";
                     }


                 }
                 else
                 {
                     txtTienL.Text = "0";
                     txtLaiKhongKyHan.Text = "0";
                 }


             }
             else
             {
                 MessageBox.Show("Vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

         }

         private void iconButton5_Click(object sender, EventArgs e)
         {

             int i = dataGridView1.CurrentRow.Index;
             if (i == -1)
             {
                 MessageBox.Show("Mời chọn sổ muốn gia hạn!");
             }
             else
             {
                 if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "True" || dataGridView1.Rows[i].Cells[8].Value.ToString() == "True")
                 {

                     tabControl1.TabPages.Remove(tabPage1);
                     tabControl1.TabPages.Remove(tabPage2);
                     tabControl1.TabPages.Remove(tabPage4);
                     tabControl1.TabPages.Remove(tabPage5);
                     tabControl1.TabPages.Remove(tabPage6);
                     tabControl1.TabPages.Remove(tabPage7);
                     tabControl1.TabPages.Remove(tabPage8);
                     tabControl1.TabPages.Add(tabPage3);


                     string st = "SELECT MaSoTK,stk.MaKH,TenKH,kh.DiaChi,kh.CCCD,kh.GioiTinh,kh.SDT,kh.Email,TenNV,TenCN,stk.SoVon,TuDongGiaHan,ltk.ThoiHan,TenLoaiTK,LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.MaSoTK='" +txtMaSo.Text + "'";
                     dgv1.DataSource = dataProvider.Instance.ExecuteQuery(st);
                     LoadTab3();
                     loadedLTk = true;

                 }
                 else
                 {
                     MessageBox.Show("Sổ chưa đáo hạn nên không thể đáo hạn!");
                 }
             }
         }

         private void btnGuiThemVon_Click(object sender, EventArgs e)
         {

             tabControl1.TabPages.Remove(tabPage1);
             tabControl1.TabPages.Remove(tabPage3);
             tabControl1.TabPages.Remove(tabPage2);
             tabControl1.TabPages.Remove(tabPage5);
             tabControl1.TabPages.Remove(tabPage6);
             tabControl1.TabPages.Remove(tabPage7);
             tabControl1.TabPages.Remove(tabPage4);
             tabControl1.TabPages.Add(tabPage8);
             string query = "select CCCD,DiaChi from khachhang where maKh='" + txtMaKH.Text + "'";
             string query1 = "select TenLoaiTK, LaiXuat from LOAITIETKIEM where ThoiHan='" + txtThoiHan.Text + "'";
             dt = dataProvider.Instance.ExecuteQuery(query);
             txtmaKH3.Text = txtMaKH.Text;
             txttenKH3.Text = txtTenKH.Text;
             txtcccd3.Text = dt.Rows[0]["CCCD"].ToString();
             txtdiaChi3.Text = dt.Rows[0]["DiaChi"].ToString();
             txtmaSoTK3.Text = txtMaSo.Text;
             dt = dataProvider.Instance.ExecuteQuery(query1);
             txtloaiTK3.Text = dt.Rows[0]["TenLoaiTK"].ToString();
             txtlaiXuat3.Text = dt.Rows[0]["LaiXuat"].ToString();
             txtsoDuSo3.Text = txtSoDu.Text;
             txtngayGui.Text = date.Date.ToString("dd/MM/yyyy");
             txttongTien3.Text = TinhTongTien1();

         }

         String TinhTongTien1()
         {
             ulong tongtien = 0;
             float goithem = 0;
             bool a = float.TryParse(txtsoTienGuiThem3.Text, out goithem);
             tongtien = (ulong)float.Parse(txtsoDuSo3.Text) + (ulong)(goithem);
             return tongtien.ToString();
         }

         private void panel4_Paint(object sender, PaintEventArgs e)
         {

         }

         private void iconButton1_Click(object sender, EventArgs e)
         {
             btnphieuGuiTien.Hide();
             string query = "select SoNgayDuocRutSauGoi from thamso";
             dt = dataProvider.Instance.ExecuteQuery(query);
             string st = "SELECT TOP(1) PGT.NgayGoi FROM PHIEUGOITIEN PGT WHERE PGT.MaSoTK='"+txtMaSoTK1.Text + "' ORDER BY PGT.NgayGoi ASC";

             if (DateTime.Parse(dataProvider.Instance.ExecuteScalar(st).ToString()).AddDays(value: Int32.Parse(dt.Rows[0]["SoNgayDuocRutSauGoi"].ToString())) <= DateTime.Now)
             {
                 string query1 = "select MaLoaiTK from LOAITIETKIEM where ThoiHan=" + txtThoiHan.Text + "";
                 phieuRutTien pr = new phieuRutTien();
                 maPhieuRut = Random().ToString();
                 dt = dataProvider.Instance.ExecuteQuery(query1);
                // pr.maLoaiTK = dt.Rows[0]["MaLoaiTK"].ToString();
                 pr.maPhieu = maPhieuRut;
                 //pr.maSoTK = txtMaSoTK1.Text;
                 pr.maNV = maNV(cboNhanVien1.Text);
                 pr.ngayRut = date.Date;
                 pr.soTienRut = decimal.Parse(txtTienL.Text) + decimal.Parse(txtLaiKhongKyHan.Text) + decimal.Parse(txtTienGuiVao.Text);
                 string query2 = "Update SOTIETKIEM set SoVon =0, NgayMoSo ='"+date.Date+"' where MaSoTK ='" + txtMaSoTK1.Text + "'";
                 if (editPerson.InsertphieuRutTien(pr) && dataProvider.Instance.ExecuteNonQuery(query2) != 0)
                 {
                     MessageBox.Show("Tất toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     tabControl1.TabPages.Remove(tabPage1);
                     tabControl1.TabPages.Remove(tabPage3);
                     tabControl1.TabPages.Remove(tabPage2);
                     tabControl1.TabPages.Remove(tabPage5);
                     tabControl1.TabPages.Remove(tabPage6);
                     tabControl1.TabPages.Remove(tabPage7);
                     tabControl1.TabPages.Remove(tabPage8);
                     tabControl1.TabPages.Add(tabPage4);
                     inPhieuRut();
                 }
             }
             else
             {
                 MessageBox.Show("Sổ tiết kiệm chỉ được phép tất toán sau "+ dt.Rows[0]["SoNgayDuocRutSauGoi"].ToString()+" ngày kể từ ngày mở sổ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

         }*/

        void LoadData()
        {
            
            string st = "SELECT MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.SoVon<>'0'";
            dataGridView1.DataSource = dataProvider.Instance.ExecuteQuery(st);
            dataGridView1.Columns[6].DefaultCellStyle.Format = "#,##0.##";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            DateTime dtn = DateTime.Now;

           
        }
        void KhoiTao()
        {
            txtMaSo.Text = txtTenKH.Text = txtMaKH.Text = txtChiNhanh.Text = txtNhanVien.Text = txtHinhThucTL.Text = txtSoDu.Text = txtNgayMoSo.Text = txtThoiHan.Text = "";


            LoadData();
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = radioButton5.Checked = false;
            tbTimKiem.Text = "";
            cboChiNhanh1.Text = "";
            cboNhanVien1.Text = "";
            cbCN.Text = cbTH.Text = "";

        }



        private void dtgDSSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat
            int i;
            i = e.RowIndex;
            if (i == -1)
            {
                return;
            }
            dataGridView1.Rows[i].Selected = true;
            txtMaSo.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtMaKH.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtNhanVien.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtChiNhanh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtThoiHan.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            DateTime ngaymo = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            txtNgayMoSo.Text = ngaymo.ToString("dd/MM/yyyy");
            txtHinhThucTL.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtLaiXuat.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            txtSoDu.Text = String.Format("{0:0,0}", float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()));
            TinhLai(i);
            txtTienLai.Text = String.Format("{0:0,0}", float.Parse(lai.ToString()));
            txttienlaimoi.Text = String.Format("{0:0,0}", float.Parse(lai1.ToString()));
        }


        private void bthoiTao_Click(object sender, EventArgs e)
        {
            DateTime dtn = DateTime.Now;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int Result;
                bool a = int.TryParse(dataGridView1.Rows[i].Cells[9].Value.ToString(), out Result);
                DateTime dt = DateTime.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()).AddDays(30 * Result);
                MessageBox.Show(dt.ToString() + "--" + dataGridView1.Rows[i].Cells[9].Value.ToString());
                if (DateTime.Compare(dtn, dt) >= 0)
                {
                    dataGridView1.Rows[i].Cells[10].Value = true;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[10].Value = false;
                }
            }
        }
        void TimKiem()
        {
            string st = "";
            try
            {
                if (!string.IsNullOrEmpty(tbTimKiem.Text) || cbCN.Text != "" || cbTH.Text != "")
                {
                    if (radioButton1.Checked)
                    {
                        st = "SELECT MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.SoVon<>'0' AND stk.MaSoTK like '%" + tbTimKiem.Text.ToString() + "%' ";
                        
                    }
                    else if (radioButton2.Checked)
                    {
                        st = "SELECT MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.SoVon<>'0' AND kh.TenKH like N'%" + tbTimKiem.Text.ToString() + "%' ";
                    }
                    else if (radioButton3.Checked)
                    {
                        st = "SELECT MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.SoVon<>'0' AND stk.MaKH like '%" + tbTimKiem.Text.ToString() + "%' ";
                    }
                    else if (radioButton4.Checked)
                    {
                        st = "SELECT MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.SoVon<>'0' AND nv.TenNV like N'%" + tbTimKiem.Text.ToString() + "%' ";
                    }
                    else
                    {
                        st = "SELECT MaSoTK,stk.MaKH,TenKH,TenNV,TenCN,NgayMoSo,stk.SoVon,HinhThucTraLai,ltk.ThoiHan,ltk.LaiXuat FROM SOTIETKIEM stk,KHACHHANG kh, NHANVIEN nv,CHINHANH cn, LOAITIETKIEM ltk WHERE stk.MaKH = kh.MaKH AND stk.MaChiNhanh = cn.MaCN AND stk.MaLoaiTK = ltk.MaLoaiTK AND stk.MaNV = nv.MaNV AND stk.SoVon<>'0' AND stk.MaNV like '%" + tbTimKiem.Text.ToString() + "%' ";
                        
                    }
                    if (cbCN.Text != "")
                    {
                        st += " AND cn.TenCN = N'" + cbCN.Text.ToString() + "'";
                    }
                    if (cbTH.Text != "")
                    {
                        st += " AND ltk.ThoiHan = N'" + cbTH.Text.ToString() + "'";
                    }
                    dataGridView1.DataSource = dataProvider.Instance.ExecuteQuery(st);

                }
                else
                {
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void cbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                TimKiem();
            }
        }

        private void cbTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                TimKiem();
            }
        }
        /* void TK_CheckBox()
         {
             if (checkBox1.Checked && checkBox2.Checked)
             {
                 (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TuDongGiaHan=True";
                 (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TaiKhoan=True";
             }
             else
             {
                 if (checkBox1.Checked && !checkBox2.Checked)
                 {
                     (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TuDongGiaHan=True";
                     (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TaiKhoan=False";
                 }
                 else
                 {
                     if (!checkBox1.Checked && checkBox2.Checked)
                     {
                         (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TuDongGiaHan=False";
                         (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TaiKhoan=True";
                     }
                     else
                     {
                         (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TuDongGiaHan=False";
                         (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "TaiKhoan=False";
                     }
                 }

             }
         }
        */
        private void checkBox1_Click(object sender, EventArgs e)
        {
            //TK_CheckBox();
            TimKiem();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            //TK_CheckBox();
            TimKiem();
        }

        private void btKhoiTao_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage1);
        }
        private bool checkThongTinSoIn()
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtCCCD2.Text) || string.IsNullOrEmpty(txtDiaChi2.Text) || string.IsNullOrEmpty(cboChiNhanh1.Text) || string.IsNullOrEmpty(cboNhanVien1.Text) || string.IsNullOrEmpty(txtMaSoTK1.Text) || string.IsNullOrEmpty(txtLoaiTK.Text) || string.IsNullOrEmpty(txtSoDu.Text) || string.IsNullOrEmpty(txtLaiSuat1.Text) || string.IsNullOrEmpty(txtTienL.Text))
            {
                return false;
            }
            return true;
        }
        public int Random()
        {
            Random rd = new Random();
            return rd.Next(100000, 999999);
        }
        public string maPhieuRut;
        public string maPhieuGui;
        /*private void iconButton2_Click_1(object sender, EventArgs e)
        {
            if (txtTienL.Text != "0")
            {
                btnquaylai1.Hide();
                btnphieuGuiTien.Hide();
                if (checkThongTinSoIn())
                {
                    if (!chkDaoHan.Checked && !chkTuGiaHan.Checked || txtTienL.Text == "00")
                    {
                        MessageBox.Show("Sổ tiết kiệm của bạn chưa đến ngày đáo hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string query = "select MaLoaiTK from LOAITIETKIEM where ThoiHan=" + txtThoiHan.Text + "";
                        phieuRutTien pr = new phieuRutTien();
                        maPhieuRut = Random().ToString();
                        dt = dataProvider.Instance.ExecuteQuery(query);
                       // pr.maLoaiTK = dt.Rows[0]["MaLoaiTK"].ToString();
                        pr.maPhieu = maPhieuRut;
                        //.maSoTK = txtMaSoTK1.Text;
                        pr.maNV = maNV(cboNhanVien1.Text);
                        pr.ngayRut = DateTime.Now;
                        pr.soTienRut = decimal.Parse(txtTienL.Text) + decimal.Parse(txtLaiKhongKyHan.Text);
                        string query1 = "Update SOTIETKIEM set NgayMoSo ='" + DateTime.Now + "',SoVon='" + decimal.Parse(txtTienGuiVao.Text) + "' where MaSoTK ='" + txtMaSoTK1.Text + "'";
                        if (editPerson.InsertphieuRutTien(pr) && dataProvider.Instance.ExecuteNonQuery(query1) != 0)
                        {
                            MessageBox.Show("Rút tiền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tabControl1.TabPages.Remove(tabPage1);
                            tabControl1.TabPages.Remove(tabPage3);
                            tabControl1.TabPages.Remove(tabPage2);
                            tabControl1.TabPages.Remove(tabPage5);
                            tabControl1.TabPages.Remove(tabPage6);
                            tabControl1.TabPages.Remove(tabPage7);
                            tabControl1.TabPages.Remove(tabPage8);
                            tabControl1.TabPages.Add(tabPage4);
                            inPhieuRut();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("rút thất bại");
                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Sổ chưa đến ngày đáo hạn!");
            }
           
        }*/

        private Bitmap MemoryImage;
        private void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            GetPrintArea(pnl);

            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, 0, this.pnlPrint.Location.Y);
        }

        public void inPhieuRut()
        {
            dgvRutTien.Columns.Clear();
            string query = "SELECT NgayRut 'Ngày Rút', SoTienRut 'Số Tiền Rút', SoVon 'Số Dư Sổ' FROM PHIEURUTTIEN,SOTIETKIEM WHERE PHIEURUTTIEN.MaSoTK=SOTIETKIEM.MaSoTK and MaPhieu='" + maPhieuRut + "'";
            dgvRutTien.DataSource = dataProvider.Instance.ExecuteQuery(query);

            dgvRutTien.Columns.Add("Column", "Nhân Viên");
            dgvRutTien.Columns.Add("Column", "Khách Hàng");
            DataGridViewRow row = dgvRutTien.Rows[0];
            dgvRutTien.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRutTien.Columns[1].DefaultCellStyle.Format = "#,##0.##";
            dgvRutTien.Columns[2].DefaultCellStyle.Format = "#,##0.##";
            row.Height = 100;
        }
        public void inPhieuGui()
        {
            dgvPhieuGuiTIen.Columns.Clear();
            string query = "SELECT Ngaygoi 'Ngày gửi', SoTienGoi 'Số Tiền Gửi', SoVon 'Số Dư Sổ' FROM PHIEUGOITIEN,SOTIETKIEM WHERE PHIEUGOITIEN.MaSoTK=SOTIETKIEM.MaSoTK and MaPhieu='" + maPhieuGui + "'";
            dgvPhieuGuiTIen.DataSource = dataProvider.Instance.ExecuteQuery(query);

            dgvPhieuGuiTIen.Columns.Add("Column", "Nhân Viên");
            dgvPhieuGuiTIen.Columns.Add("Column", "Khách Hàng");
            DataGridViewRow row = dgvPhieuGuiTIen.Rows[0];
            row.Height = 100;
            dgvPhieuGuiTIen.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPhieuGuiTIen.Columns[1].DefaultCellStyle.Format = "#,##0.##";
            dgvPhieuGuiTIen.Columns[2].DefaultCellStyle.Format = "#,##0.##";
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage2);
        }

        /*private void btninPhieuRut_Click(object sender, EventArgs e)
        {
            maPhieuGui = Random().ToString();
            Print(panel6);
            if (a)
            {
                if (!KTGiaHanSo())
                {
                    if (cbLXKT1.Text == "Gộp lãi vào vốn")
                    {
                        if (tbGT1.Text != "")
                        {
                            string st1 = "SELECT stk.MaLoaiTK FROM SOTIETKIEM stk WHERE stk.MaSoTK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
                            string st = " INSERT INTO PHIEUGOITIEN (MaPhieu,MaSoTK,MaNV,NgayGoi,SoTienGoi,MaLoaiTK) VALUES('" + maPhieuGui + "','" + tbMS1.Text + "','" + maNV(cbNV1.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + tbGT1.Text + "','" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                            if (dataProvider.Instance.ExecuteNonQuery(st) != 0)
                            {
                                tabControl1.TabPages.Remove(tabPage1);
                                tabControl1.TabPages.Remove(tabPage3);
                                tabControl1.TabPages.Remove(tabPage2);
                                tabControl1.TabPages.Remove(tabPage5);
                                tabControl1.TabPages.Remove(tabPage6);
                                tabControl1.TabPages.Remove(tabPage4);
                                tabControl1.TabPages.Remove(tabPage8);
                                tabControl1.TabPages.Add(tabPage7);
                                inPhieuGui();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi");
                            }

                        }
                        else
                        {
                            string query3 = "UPDATE SOTIETKIEM SET NgayMoSo='" + DateTime.Now.ToString("yyyy/MM/dd") + "',SoVon='" + tbTongTien.Text + "' WHERE MaSoTK='" + tbMS1.Text + "' ";
                            if (dataProvider.Instance.ExecuteNonQuery(query3) != 0)
                            {
                                MessageBox.Show("Gia hạn thành công");
                            }
                            else
                            {
                                MessageBox.Show("Gia hạn thất bại");
                            }

                        }
                    }
                    else //rút lãi
                    {
                        string st1 = "SELECT stk.MaLoaiTK FROM SOTIETKIEM stk WHERE stk.MaSoTK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
                        string st = " INSERT INTO PHIEUGOITIEN (MaPhieu,MaSoTK,MaNV,NgayGoi,SoTienGoi,MaLoaiTK) VALUES('" + maPhieuGui + "','" + tbMS1.Text + "','" + maNV(cbNV1.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + tbGT1.Text + "','" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                        if (dataProvider.Instance.ExecuteNonQuery(st) != 0)
                        {
                            tabControl1.TabPages.Remove(tabPage1);
                            tabControl1.TabPages.Remove(tabPage3);
                            tabControl1.TabPages.Remove(tabPage2);
                            tabControl1.TabPages.Remove(tabPage5);
                            tabControl1.TabPages.Remove(tabPage6);
                            tabControl1.TabPages.Remove(tabPage4);
                            tabControl1.TabPages.Remove(tabPage8);
                            tabControl1.TabPages.Add(tabPage7);
                            inPhieuGui();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi");
                        }

                    }
                }
                else
                {
                    btnphieuGuiTien.Show();
                }
            }


        }*/

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        /*bool KTGiaHanSo()
        {
            {
                if (cbLoaiTK1.Text != dgv1.Rows[0].Cells[13].Value.ToString())
                    return true;
            }
            if ((dgv1.Rows[0].Cells[11].Value.ToString() == "True" && rdbKhong.Checked == true) || (dgv1.Rows[0].Cells[11].Value.ToString() == "False" && rdbCo.Checked == true))
            {
                return true;
            }
            return false;

        }*/
        /*private void bntGiaHanSo_Click(object sender, EventArgs e)
        {
            a = true;
            btnphieuGuiTien.Hide();
            maPhieuRut = Random().ToString();
            maPhieuGui = Random().ToString();
            if (tbGT1.Text != "" || tbGT1.Text != "0")
            {

                string query = "SELECT SoTienGoiThemToiThieu FROM THAMSO";
                dt = dataProvider.Instance.ExecuteQuery(query);
                decimal soTienQD;
                decimal goiThem;
                Decimal.TryParse(dt.Rows[0]["SoTienGoiThemToiThieu"].ToString(), out soTienQD);
                Decimal.TryParse(tbGT1.Text, out goiThem);
                if (goiThem < soTienQD)
                {
                    MessageBox.Show("Số tiền gởi thêm tối thiều " + String.Format("{0:0,0 VNĐ}", soTienQD), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            btnquaylai1.Hide();
            if (KTGiaHanSo())
            {
                btnphieuGuiTien.Show();
                DialogResult = MessageBox.Show("Bạn có chắc muốn gia hạn sổ bằng cách tạo sổ mới!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    string query = "select MaLoaiTK from LOAITIETKIEM where ThoiHan=" + txtThoiHan.Text + "";
                    phieuRutTien pr = new phieuRutTien();
                    maPhieuRut = Random().ToString();
                    dt = dataProvider.Instance.ExecuteQuery(query);
                    //pr.maLoaiTK = dt.Rows[0]["MaLoaiTK"].ToString();
                    pr.maPhieu = maPhieuRut;
                    // pr.maSoTK = tbMS1.Text;
                    //pr.maNV = maNV(cboNhanVien1.Text);
                    pr.ngayRut = date.Date;
                    pr.soTienRut = decimal.Parse(tbLai1.Text) + decimal.Parse(tbST1.Text);
                    string query1 = "Update SOTIETKIEM set SoVon=0 where MaSoTK ='" + tbMS1.Text + "'";
                    if (editPerson.InsertphieuRutTien(pr) && dataProvider.Instance.ExecuteNonQuery(query1) != 0)
                    {
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage3);
                        tabControl1.TabPages.Remove(tabPage2);
                        tabControl1.TabPages.Remove(tabPage5);
                        tabControl1.TabPages.Remove(tabPage6);
                        tabControl1.TabPages.Remove(tabPage7);
                        tabControl1.TabPages.Remove(tabPage8);
                        tabControl1.TabPages.Add(tabPage4);
                        inPhieuRut();
                        lblten.Text = txtten1.Text;
                        lblcc.Text = txtcccd1.Text;
                        lblchinhanh1.Text = cbCN1.Text;
                        lbldiachi1.Text = txtdiaChi1.Text;
                        lblkyhan1.Text = cbLoaiTK1.Text;
                        lblmakh1.Text = txtmaKH1.Text;
                        lblmaso1.Text = tbMS1.Text;
                        lblngay1.Text = date.Date.ToString("dd/MM/yyyy");
                        lbllaisuat1.Text = tbLX1.Text;
                        if (cbLXKT1.Text == "Gộp lãi vào vốn")
                        {
                            lblsotien1.Text = String.Format("{0:0,0 VNĐ}", double.Parse(tbTongTien.Text));
                        }
                        else
                        {
                            lblsotien1.Text = String.Format("{0:0,0 VNĐ}", double.Parse(tbTongTien.Text) - double.Parse(tbLai1.Text));
                        }

                    }
                    else
                    {
                        MessageBox.Show("rút tiền thất bại");
                    }
                }
            }
            else//thay đổi thông tin sổ
            {
                DialogResult = MessageBox.Show("Bạn có chắc muốn gia hạn sổ!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    if (cbLXKT1.Text == "Gộp lãi vào vốn")
                    {

                        //MessageBox.Show("Sổ sẽ tự động gia hạn, không cần thực hiện thủ công!");
                        //sử lý gởi thêm vốn
                        if (tbGT1.Text == "")
                        {
                            MessageBox.Show("Sổ sẽ tự động gia hạn, không cần thực hiện thủ công!");
                        }
                        else
                        {

                            string st1 = "SELECT stk.MaLoaiTK FROM SOTIETKIEM stk WHERE stk.MaSoTK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
                            string st = " INSERT INTO PHIEUGOITIEN (MaPhieu,MaSoTK,MaNV,NgayGoi,SoTienGoi,MaLoaiTK) VALUES('" + maPhieuGui + "','" + tbMS1.Text + "','" + maNV(cbNV1.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "'," + decimal.Parse(tbGT1.Text) + ",'" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                            if (dataProvider.Instance.ExecuteNonQuery(st) != 0)
                            {
                                tabControl1.TabPages.Remove(tabPage1);
                                tabControl1.TabPages.Remove(tabPage3);
                                tabControl1.TabPages.Remove(tabPage2);
                                tabControl1.TabPages.Remove(tabPage5);
                                tabControl1.TabPages.Remove(tabPage6);
                                tabControl1.TabPages.Remove(tabPage4);
                                tabControl1.TabPages.Remove(tabPage8);
                                tabControl1.TabPages.Add(tabPage7);
                                inPhieuGui();
                            }
                            else
                            {
                                MessageBox.Show("Gia hạn thất bại, vui lòng thử lại sau!!");
                            }
                        }
                    }




                    //in phiếu gởi nếu có gởi thêm
                    //cập nhập lãi sổ sovon=tong tiền

                    else //rút lãi
                    {
                        string st1 = "SELECT stk.MaLoaiTK FROM SOTIETKIEM stk WHERE stk.MaSoTK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";

                        if (tbLai1.Text == "0")
                        {
                            DialogResult dialog = MessageBox.Show("Sổ của bạn chưa đáo hạn, Bạn có muốn tiếp tục gia hạn cho sổ không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialog == DialogResult.Yes)
                            {

                                string st = " INSERT INTO PHIEUGOITIEN (MaPhieu,MaSoTK,MaNV,NgayGoi,SoTienGoi,MaLoaiTK) VALUES('" + maPhieuGui + "','" + tbMS1.Text + "','" + maNV(cbNV1.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "'," + decimal.Parse(tbGT1.Text) + ",'" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                                if (dataProvider.Instance.ExecuteNonQuery(st) != 0)
                                {
                                    tabControl1.TabPages.Remove(tabPage1);
                                    tabControl1.TabPages.Remove(tabPage3);
                                    tabControl1.TabPages.Remove(tabPage2);
                                    tabControl1.TabPages.Remove(tabPage5);
                                    tabControl1.TabPages.Remove(tabPage6);
                                    tabControl1.TabPages.Remove(tabPage4);
                                    tabControl1.TabPages.Remove(tabPage8);
                                    tabControl1.TabPages.Add(tabPage7);
                                    inPhieuGui();
                                    string st2 = " INSERT INTO PHIEURUTTIEN (MaPhieu,MaSoTK,MaNV,NgayRut,SoTienRut,MaLoaiTK) VALUES('" + maPhieuRut + "','" + tbMS1.Text + "','" + maNV(cbNV1.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + tbLai1.Text + "','" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                                    dataProvider.Instance.ExecuteNonQuery(st2);
                                }

                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            string st = " INSERT INTO PHIEURUTTIEN (MaPhieu,MaSoTK,MaNV,NgayRut,SoTienRut,MaLoaiTK) VALUES('" + maPhieuRut + "','" + tbMS1.Text + "','" + maNV(cbNV1.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + tbLai1.Text + "','" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                            dataProvider.Instance.ExecuteNonQuery(st);
                            tabControl1.TabPages.Remove(tabPage1);
                            tabControl1.TabPages.Remove(tabPage3);
                            tabControl1.TabPages.Remove(tabPage2);
                            tabControl1.TabPages.Remove(tabPage5);
                            tabControl1.TabPages.Remove(tabPage6);
                            tabControl1.TabPages.Remove(tabPage7);
                            tabControl1.TabPages.Remove(tabPage8);
                            tabControl1.TabPages.Add(tabPage4);
                            inPhieuRut();

                        }
                        //in phiếu rút

                        //sử lý gởi thêm vốn

                    }
                }
            }

        
        }*/
        string checkPhieuGR(string tenphieu)
        {
            string maPhieu = "";
            if (tenphieu == "goi")
            {
                maPhieu = Random().ToString();
                string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                while (!CheckMa(st))
                {
                    maPhieu = Random().ToString();
                }
            }
            else
            {
                maPhieu = Random().ToString();
                string st = "SELECT * FROM PHIEURUTTIEN WHERE MaPhieu='" + maPhieu + "' ";
                while (!CheckMa(st))
                {
                    maPhieu = Random().ToString();
                }
            }
            return maPhieu;
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

        void LoadTab3()
        {
            string query = "select CCCD,DiaChi,GioiTinh,SDT,Email from khachhang where maKh='" + txtMaKH.Text + "'";
            string query1 = "select TenLoaiTK, LaiXuat from LOAITIETKIEM where ThoiHan='" + txtThoiHan.Text + "'";
            dt = dataProvider.Instance.ExecuteQuery(query);           
            //khách hàng
            txtmaKH1.Text = txtMaKH.Text;
            txtten1.Text = txtTenKH.Text;
            txtdiaChi1.Text = dt.Rows[0]["DiaChi"].ToString();
            txtcccd1.Text = dt.Rows[0]["CCCD"].ToString();
            txtSDT1.Text = dt.Rows[0]["SDT"].ToString();
            txtGmail1.Text = dt.Rows[0]["Email"].ToString();

            //sổ

            tbMS1.Text = txtMaSo.Text;
            cbCN1.Text = txtHinhThucTL.Text;
            cbNV1.Text = txtNhanVien.Text;
            tbST1.Text = txtSoDu.Text;
            tbNgayMS.Text = txtNgayMoSo.Text;
            tbTH1.Text = txtThoiHan.Text;
            dt = dataProvider.Instance.ExecuteQuery(query1);
            tbLoaiTK1.Text = dt.Rows[0]["TenLoaiTK"].ToString();
            tbLX1.Text = dt.Rows[0]["LaiXuat"].ToString();
            tbHinhTTL.Text = txtHinhThucTL.Text;
            if(tbHinhTTL.Text== "Tất toán sổ ")
            {
                rdbKhong.Checked = true;
                rdbCo.Checked = false;
                lbGH1.Hide();
                tbGH1.Hide();
                lbGhiChu1.Text = "Sổ sẽ tự động tất toán khi đáo hạn,";
                lbGhiChu2.Text= "cả gốc và lãi được chuyển vào số dư của khách hàng";
            }
            else
            {
                rdbKhong.Checked = false;
                rdbCo.Checked = true;
                lbGH1.Show();
                tbGH1.Show();
                tbGH1.Text = soKH.ToString();
                if(tbHinhTTL.Text == "Lãi trả vào tài khoản khách hàng ")
                {
                    lbGhiChu1.Text = "Sổ sẽ tự động gia hạn khi đáo hạn với số tiền gốc ban ";
                    lbGhiChu2.Text = "đầu, còn lãi được chuyển vào số dư của khách hàng";
                
                }
                if (tbHinhTTL.Text == "Lãi nhập gốc")
                {
                    lbGhiChu1.Text = "Sổ sẽ tự động gia hạn khi đáo hạn và";
                    lbGhiChu2.Text = " số tiền vốn bằng sô tiền ban đầu và lãi";
                }
            }
            tbNgayDH.Text = txtngayDH.Text;
            tbLai1.Text = txtTienLai.Text;
            tblaimoi.Text = txttienlaimoi.Text;
            tbTongTien.Text = String.Format("{0:0,0}", (goc + lai));
        }

      
       /* void LoadLTK()
        {
            string st = "SELECT MaLoaiTK,TenLoaiTk FROM LOAITIETKIEM";
            cbLoaiTK1.DisplayMember = "TenLoaiTk";
            cbLoaiTK1.ValueMember = "MaLoaiTK";
            DataTable dt3 = dataProvider.Instance.ExecuteQuery(st);
            cbLoaiTK1.DataSource = dt3;
        }*/
        void TinhLai(int i)
        {
            if (txtHinhThucTL.Text == "Tất toán sổ")
            {
                goc = (ulong)(float.Parse(txtSoDu.Text));
                float laixuat = float.Parse(txtLaiXuat.Text);             
                DateTime ngaygoi = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                int thangTH;
                bool a = int.TryParse(txtThoiHan.Text, out thangTH);
                DateTime ngaydh = ngaygoi.AddDays(30 * thangTH);
                txtngayDH.Text = ngaydh.ToString("dd/MM/yyyy");
                lai =0;
                lai1 = (ulong)(goc * laixuat/100);
            }
            else
            {
                if (txtHinhThucTL.Text == "Lãi nhập gốc")
                {
                    goc = (ulong)(float.Parse(txtSoDu.Text));
                    float laixuat = float.Parse(txtLaiXuat.Text);
                    DateTime ngaygoi = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                    TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                    int intI = interval.Days;
                    int thangGoi = (int)(intI / 30);
                    int thangKH = int.Parse(txtThoiHan.Text);
                    soKH = (int)(thangGoi / thangKH);
                    DateTime ngayDHSaptToi = ngaygoi.AddDays(30 * thangKH * (soKH + 1));
                    txtngayDH.Text = ngayDHSaptToi.ToString("dd/MM/yyyy");
                    goclai = (ulong)(goc * (Math.Pow((1 + laixuat / 100), soKH)));
                    ulong goclai1 = (ulong)(goc * (Math.Pow((1 + laixuat / 100), (soKH + 1))));
                    lai = goclai - goc;
                    lai1 = goclai1 - goc;
                }
                else
                {
                    goc = (ulong)(float.Parse(txtSoDu.Text));
                    float laixuat = float.Parse(txtLaiXuat.Text);
                    DateTime ngaygoi = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()).Date;
                    TimeSpan interval = DateTime.Now.Subtract(ngaygoi);
                    int intI = interval.Days;
                    int thangGoi = (int)(intI / 30);
                    int thangKH = int.Parse(txtThoiHan.Text);
                    soKH = (int)(thangGoi / thangKH);
                    DateTime ngayDHSaptToi = ngaygoi.AddDays(30 * thangKH * (soKH + 1));
                    txtngayDH.Text = ngayDHSaptToi.ToString("dd/MM/yyyy");                
                    lai = 0;
                    lai1 = (ulong)(goc*laixuat/100);
                }
            }
        }

        /*private void cbLoaiTK1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadedLTk)
            {
                string st = "SELECT LaiXuat FROM LOAITIETKIEM WHERE MaLoaiTK='" + cbLoaiTK1.SelectedValue.ToString() + "'";
                tbLX1.Text = dataProvider.Instance.ExecuteScalar(st).ToString();
                st = "SELECT ThoiHan FROM LOAITIETKIEM WHERE MaLoaiTK='" + cbLoaiTK1.SelectedValue.ToString() + "'";
                tbTH1.Text = dataProvider.Instance.ExecuteScalar(st).ToString();
            }
        }*/

       
        private void tbGT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       /* private void iconButton5_Click_1(object sender, EventArgs e)
        {
            btnquayLai.Show();
            Print(pnlPrint);
            bool giahan = false;
            if (rdbGH1.Checked)
            {
                giahan = true;
            }
            string query = "select MaLoaiTK from LOAITIETKIEM where TenLoaiTK=N'" + cbLoaiTK1.Text + "'";

            phieuGuiTien pg = new phieuGuiTien();
            dt = dataProvider.Instance.ExecuteQuery(query);
            //pg.maLoaiTK = dt.Rows[0]["MaLoaiTK"].ToString();
            pg.maPhieu = Random().ToString();
            pg.maNV = maNV(cbNV1.Text);
            //pg.maSoTK = tbMS1.Text;
            pg.ngayGui = date.Date;
            string tienMoi;
            if (cbLXKT1.Text == "Gộp lãi vào vốn")
            {
                tienMoi = String.Format("{0:0,0}", double.Parse(tbTongTien.Text));
            }
            else
            {
                tienMoi = String.Format("{0:0,0}", double.Parse(tbTongTien.Text) - double.Parse(tbLai1.Text));
            }
            pg.soTienGui = decimal.Parse(tienMoi);

            string st = "UPDATE SOTIETKIEM SET MaLoaiTK='" + maLoaiTK(cbLoaiTK1.Text) + "',MaNV='" + maNV(cbNV1.Text) + "',MaChiNhanh='" + maCN(cbCN1.Text) + "',NgayMoSo='" + dtNgayMS1.Value.ToString() + "',SoVon='" + tbTongTien.Text + "',TuDongGiaHan='" + giahan.ToString() + "' WHERE MaSoTK='" + tbMS1.Text + "'";
            if (dataProvider.Instance.ExecuteNonQuery(st) == 0 || !editPerson.InsertphieuGuiTien(pg))
            {
                MessageBox.Show("Gia hạn không thành công, mời thực hiện lại!");
                btnquayLai.Show();
            }
            else
            {
                MessageBox.Show("Gia hạn thành công!");
                LoadData();
            }
        }*/
        public string maLoaiTK(string x)
        {
            string query = "select MaLoaiTK from LOAITIETKIEM where TenLoaiTK=N'" + x + "'";
            dt = dataProvider.Instance.ExecuteQuery(query);
            return dt.Rows[0]["MaLoaiTK"].ToString();
        }
        /*private void btninPhieuGui_Click(object sender, EventArgs e)
        {
            if (KTGiaHanSo())
            {
                btnInSo.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage7);
                tabControl1.TabPages.Remove(tabPage8);
                tabControl1.TabPages.Add(tabPage5);
            }
            else
            {
                btnInSo.Hide();
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage8);
                tabControl1.TabPages.Add(tabPage7);
            }

        }*/

        private void iconButton7_Click(object sender, EventArgs e)
        {
            Print(panel11);
            btnInSo.Show();
        }

       /* private void btnInSo_Click(object sender, EventArgs e)
        {
            btnquayLai.Hide();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage6);
            lblmaso.Text = tbMS1.Text;
            lblmakh2.Text = txtmaKH1.Text;
            lblchinhanh2.Text = cbCN1.Text;
            lblkyhan2.Text = cbLoaiTK1.Text;
            lbltenkh.Text = txtten1.Text;
            lblcccd2.Text = txtcccd1.Text;
            lbldiachi2.Text = txtdiaChi1.Text;
            lblngayphathanh.Text = date.Date.ToString("dd/MM/yyyy");
        }/*

        private void btnquayLai_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage1);
            LoadData();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void btnquayLai2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage1);
            LoadData();
        }

        private void txtsoTienGuiThem3_TextChanged(object sender, EventArgs e)
        {
            //txttongTien3.Text =  TinhTongTien1();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            maPhieuGui = Random().ToString();
            string query3 = "UPDATE SOTIETKIEM SET NgayMoSo='" + date.Date + "',SoVon='" + txttongTien3.Text + "'where MaSoTK='" + txtMaSo.Text + "'";

            if (dataProvider.Instance.ExecuteNonQuery(query3) != 0)
            {
                string st1 = "SELECT stk.MaLoaiTK FROM SOTIETKIEM stk WHERE stk.MaSoTK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
                string st = " INSERT INTO PHIEUGOITIEN (MaPhieu,MaSoTK,MaNV,NgayGoi,SoTienGoi,MaLoaiTK) VALUES('" + maPhieuGui + "','" + txtmaSoTK3.Text + "','" + maNV(txtnhanVien3.Text) + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + txtsoTienGuiThem3.Text + "','" + dataProvider.Instance.ExecuteScalar(st1).ToString() + "')";
                if (dataProvider.Instance.ExecuteNonQuery(st1) != 0)
                {
                    MessageBox.Show("Gửi thành công");

                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage6);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage8);
                    tabControl1.TabPages.Add(tabPage7);
                    inPhieuGui();

                }

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            string query = "select MaLoaiTK from LOAITIETKIEM where TenLoaiTK=N'" + txtloaiTK3.Text + "'";
            phieuGuiTien pg = new phieuGuiTien();
            dt = dataProvider.Instance.ExecuteQuery(query);
            // pg.maLoaiTK = dt.Rows[0]["MaLoaiTK"].ToString();
            pg.maPhieu = Random().ToString();
            pg.maNV = maNV(txtnhanVien3.Text);
            // pg.maSoTK = txtmaSoTK3.Text;
            pg.ngayGui = date.Date;
            if (editPerson.InsertphieuGuiTien(pg))
            {
                Print(panel14);
            }
            else
            {
                MessageBox.Show("Lỗi không gửi được vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /* private void iconButton9_Click_1(object sender, EventArgs e)
        {
            Print(panel14);
            if (!KTGiaHanSo())
            {
                if (cbLXKT1.Text == "Gộp lãi vào vốn")
                {
                    string query3 = "UPDATE SOTIETKIEM SET NgayMoSo='" + DateTime.Now.ToString("yyyy/MM/dd") + "',SoVon='" + tbTongTien.Text + "',TuDongGiaHan='" + rdbGH1.Checked + "' WHERE MaSoTK='" + tbMS1.Text + "' ";
                    if (dataProvider.Instance.ExecuteNonQuery(query3) != 0)
                    {
                        MessageBox.Show("Gia hạn thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Gia hạn không thành công!");
                    }
                }
                else //rút lãi
                {
                    if (tbGT1.Text != "")
                    {
                        string query3 = "UPDATE SOTIETKIEM SET NgayMoSo='" + DateTime.Now.ToString("yyyy/MM/dd") + "',SoVon='" + tbTongTien.Text + "',TuDongGiaHan='" + rdbGH1.Checked + "' WHERE MaSoTK='" + tbMS1.Text + "' ";
                        if (dataProvider.Instance.ExecuteNonQuery(query3) != 0)
                        {
                            MessageBox.Show("Gia hạn thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Gia hạn không thành công!");
                        }
                    }

                }
            }
        }*/

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void txtTienLai_TextChanged(object sender, EventArgs e)
        {
            if (txtTienL.Text == "00")
            {
                txtTienL.Text = "0";
            }
        }

        private void txtSoDu_TextChanged(object sender, EventArgs e)
        {
            if (txtTienLai.Text == "00")
            {
                txtTienLai.Text = "0";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }       

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                MessageBox.Show(dataGridView1.Rows[0].Cells[i].Value.ToString() + "++i");
            }
        }

        private void btnTatToan_Click(object sender, EventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            if (txtMaSo.Text == "") 
            {
                MessageBox.Show("Mời chọn sổ muốn tất toán!", "Thông báo!");
                return;
            }
            DateTime ngaymo = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            string st = "SELECT * FROM THAMSO";
            DataTable dt = dataProvider.Instance.ExecuteQuery(st);
            DataRow dtr = dt.Rows[0];
            double SoNgayDuocRutSauGoi = double.Parse(dtr[2].ToString());
            DateTime sau15ngay = ngaymo.AddDays(SoNgayDuocRutSauGoi);
            if (sau15ngay > DateTime.Now)
            {
                MessageBox.Show("Sổ chỉ được tất toán sau " + SoNgayDuocRutSauGoi + " ngày kể từ ngày mở sổ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage7);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage8);
                tabControl1.TabPages.Add(tabPage3);
                LoadTab3();
                btTatToan.Show();
            }
        }

        private void btTatToan_Click(object sender, EventArgs e)
        {
            if (tbHinhTTL.Text == "Tất toán sổ ")
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn tất toán sổ trước kì hạn?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {

                    string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + txtmaKH1.Text + "'").ToString();
                    decimal sodu = decimal.Parse(sodubd) + decimal.Parse(tbTongTien.Text);
                    string query= "UPDATE SOTIETKIEM SET SoVon='0' WHERE MaSoTK='"+tbMS1.Text.ToString()+"'";
                    string query1 = "update KHACHHANG set SoDu='" + sodu + "'where MaKH='" + txtmaKH1.Text + "'";
                    string maPhieu = Random().ToString();
                    string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                    while (!CheckMa(st))
                    {
                        maPhieu = Random().ToString();
                    }
                    string query2 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + txtmaKH1.Text + "','" + MainFormManager.Instance.maNV().ToString() + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + decimal.Parse(tbTongTien.Text) + "','" + MainFormManager.Instance.maCN().ToString() + "',N'Tất toán sổ tiết kiệm')";
                    if (dataProvider.Instance.ExecuteNonQuery(query) > 0 && dataProvider.Instance.ExecuteNonQuery(query1)>0 && dataProvider.Instance.ExecuteNonQuery(query2)>0)
                    {
                        MessageBox.Show("Tất toán thành công, tiền gốc đã được chuyển vào tài khoản khách hàng!");
                    }
                    else
                    {
                        MessageBox.Show("Tất toán không thành công, mời thử lại!");
                    }
                }
            }
            if (tbHinhTTL.Text == "Lãi trả vào tài khoản khách hàng ")
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn tất toán sổ trước kì hạn?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + txtmaKH1.Text + "'").ToString();
                    decimal sodu = decimal.Parse(sodubd) + decimal.Parse(tbTongTien.Text);
                    string query = "UPDATE SOTIETKIEM SET SoVon='0' WHERE MaSoTK='" + tbMS1.Text.ToString() + "'";
                    string query1 = "update KHACHHANG set SoDu='" + sodu + "'where MaKH='" + txtmaKH1.Text + "'";
                    string maPhieu = Random().ToString();
                    string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                    while (!CheckMa(st))
                    {
                        maPhieu = Random().ToString();
                    }
                    string query2 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + txtmaKH1.Text + "','" + MainFormManager.Instance.maNV().ToString() + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + decimal.Parse(tbTongTien.Text) + "','" + MainFormManager.Instance.maCN().ToString() + "',N'Tất toán sổ tiết kiệm')";
                    if (dataProvider.Instance.ExecuteNonQuery(query) > 0 && dataProvider.Instance.ExecuteNonQuery(query1) > 0 && dataProvider.Instance.ExecuteNonQuery(query2) > 0)
                    {
                        MessageBox.Show("Tất toàn thành công, tiền gốc đã được chuyển vào tài khoản khách hàng");
                    }
                    else
                    {
                        MessageBox.Show("Tất toán không thành công, mời thử lại!");
                    }
                }
            }
            if (tbHinhTTL.Text == "Lãi nhập gốc")
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn tất toán sổ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    string sodubd = dataProvider.Instance.ExecuteScalar("SELECT SoDu From KHACHHANG where MaKH='" + txtmaKH1.Text + "'").ToString();
                    decimal sodu = decimal.Parse(sodubd) + decimal.Parse(tbTongTien.Text);
                    string query = "UPDATE SOTIETKIEM SET SoVon='0' WHERE MaSoTK='" + tbMS1.Text.ToString() + "'";
                    string query1 = "update KHACHHANG set SoDu='" + sodu + "'where MaKH='" + txtmaKH1.Text + "'";
                    string maPhieu = Random().ToString();
                    string st = "SELECT * FROM PHIEUGOITIEN WHERE MaPhieu='" + maPhieu + "' ";
                    while (!CheckMa(st))
                    {
                        maPhieu = Random().ToString();
                    }
                    string query2 = "INSERT INTO PHIEUGOITIEN (MaPhieu,MaKH,MaNV,NgayGoi,SoTienGoi,MaCN,NoiDungGiaoDich) VALUES('" + maPhieu + "','" + txtmaKH1.Text + "','" + MainFormManager.Instance.maNV().ToString() + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + decimal.Parse(tbTongTien.Text) + "','" + MainFormManager.Instance.maCN().ToString() + "',N'Tất toán sổ tiết kiệm')";
                    if (dataProvider.Instance.ExecuteNonQuery(query) > 0 && dataProvider.Instance.ExecuteNonQuery(query1) > 0 && dataProvider.Instance.ExecuteNonQuery(query2) > 0)
                    {
                        MessageBox.Show("Tất toàn thành công, tiền gốc và lãi đã được chuyển vào tài khoản khách hàng");
                    }
                    else
                    {
                        MessageBox.Show("Tất toán không thành công, mời thử lại!");
                    }
                }
            }
        }

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Add(tabPage1);
            LoadData();
            KhoiTao();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
//thứ 4 ngày 28/12 báo cáo cnpm chuyên sâu