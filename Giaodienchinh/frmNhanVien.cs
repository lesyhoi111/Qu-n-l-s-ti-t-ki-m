using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;
using Thong_Tin_Khach_hang;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Net.Mail;
using System.Drawing.Printing;

namespace Lần_1
{
    public partial class FrmNhanVien : Form
    {
       DataTable dt=new DataTable();
        DataTable dt1,dt2 = new DataTable();
        bool loaded = false;
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        void LoadData()
        {

            string st = "SELECT MaNV, CCCD, TenNV ,NgaySinh ,GioiTinh,NV.DiaChi,SDT,Email,CN.TenCN,ChucVu FROM NHANVIEN NV, CHINHANH CN WHERE NV.ChiNhanhLV=CN.MaCN ";
            dgvNhanVien.DataSource = dataProvider.Instance.ExecuteQuery(st);
            rbNam.Checked = false;
            rbNu.Checked = false;
        }
        void LoadChiNhanh()
        { 
            string st = "SELECT MaCN,TenCN FROM CHINHANH";
            
            cbChiNhanh.DisplayMember = "TenCN";
            cbChiNhanh.ValueMember = "MaCN";
            cbCN.DisplayMember = "TenCN";
            cbCN.ValueMember = "MaCN";
            dt1 =dataProvider.Instance.ExecuteQuery(st);
            dt2 = dataProvider.Instance.ExecuteQuery(st);
            cbChiNhanh.DataSource = dt1;
            cbCN.DataSource = dt2;
            cbChiNhanh.Text = cbCN.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cbChucVu.Text =cbChucVu1.Text= "";
            cbChiNhanh.Text = cbCN.Text = "";
            LoadChiNhanh();
            LoadData();
            loaded = true;
            
            //connection.Close();
            
        }

        

       bool CheckMa( string st)
        {
            DataTable dtb = new DataTable();
            dt = dataProvider.Instance.ExecuteQuery(st);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }
        int Random()
        {
            Random rd = new Random();
            return rd.Next(100000, 999999);
        }
        
        private void btThem_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                return;
            }
            string maNV = Random().ToString();
            string st = "SELECT * FROM NHANVIEN WHERE MaNV='" + maNV + "' ";
            while (!CheckMa(st))
            {
                maNV = Random().ToString();
            }
            tbMNV.Text = maNV;
            st = "SELECT * FROM NHANVIEN WHERE  CCCD='" + tbCCCD.Text + "'";
            if (!CheckMa(st))
            {
                MessageBox.Show("CMND/CCCD đã tồn tại, mời nhập lại!", "Thông báo!", MessageBoxButtons.OK);
                tbCCCD.Focus();
                return;
            }
            string gioitinh="";
            if (rbNam.Checked)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
            string pass = Random().ToString();
            st = "INSERT INTO NHANVIEN VALUES ('" + tbMNV.Text + "','" + tbCCCD.Text + "',N'"+tbTen.Text+"','"+dtNgaySinh.Text+"',N'"+tbDiaChi.Text+"','"+tbSDT.Text+"','"+tbGmail.Text+"',N'"+ (string)cbChiNhanh.SelectedValue + "',N'"+cbChucVu.Text+ "','"+pass+"',N'"+gioitinh+"')";
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thêm Nhân viên trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataProvider.Instance.ExecuteNonQuery(st) == 0)
                {
                    MessageBox.Show("Thêm không thành công!");
                    
                }
                else
                {
                    MessageBox.Show("Thêm thành công!");
                    string subject = "Bảo mật";
                    string content = "<h2 > Xin chào bạn, bạn vừa được tạo tài khoản để đăng nhập vào phần mềm quản lý của ngân hàng META BANK chúng tôi!</h2> <h4> Mật khẩu dưới đây được sử dụng để đăng nhập vào hệ thống! </h4> <p><b> Tài khoản: </b><i> " + tbSDT.Text + " </i></p> <p><b> Mật khẩu: </b><i> " + pass + " </i></p><p> !!!Chú ý: Nên đổi mật khẩu trong lần đầu đăng nhập!!! </p> ";
                    SendMail("bankingmeta@gmail.com", tbGmail.Text, subject, content);
                    //MessageBox.Show(content);
                    MessageBox.Show("Thông tin tài khoản đã được gởi tới email " + tbGmail.Text + ", hãy kiểm tra và đăng nhập vào hệ thống!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);

                    label15.Text = tbTen.Text;
                    label18.Text = tbSDT.Text;
                    label19.Text = pass;
                    KhoiTao();
                }
            }
            
        }
        
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                return;
            }

            string st = "UPDATE NHANVIEN SET MatKhau = '' WHERE MaNV = '" + tbMNV.Text + "'";
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa mật khẩu của Nhân viên trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataProvider.Instance.ExecuteNonQuery(st) == 0)
                {
                    MessageBox.Show("Xóa không thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa thành công!");
                    KhoiTao();
                }
            }

        }

        private void btKhoiTao_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
        void KhoiTao() {
            tbMNV.ReadOnly = false;
            tbMNV.Text = "";
            tbTen.Text = "";
            tbDiaChi.Text = "";
            tbCCCD.Text = "";
            dtNgaySinh.Text = "12/31/2002";
            tbSDT.Text = "";
            cbChiNhanh.SelectedIndex = 1;
            tbGmail.Text = "";
            cbChucVu.Text = "";
            rbNam.Checked = false;
            rbNu.Checked = false;
         
            LoadData();
            string rowFilter = string.Format("{0} like '{1}'", "GioiTinh", "*" + "N" + "*");
            (dgvNhanVien.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
       
            tbTimKiem.Text = "";
            cbChucVu.Text = cbChucVu1.Text = "";
            cbChiNhanh.Text = cbCN.Text = "";
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (!Check()) 
            {
                return;
            }
            int index = dgvNhanVien.CurrentRow.Index;
            string st = "SELECT * FROM NHANVIEN WHERE  CCCD='" + tbCCCD.Text + "'";
            if (dgvNhanVien.Rows[index].Cells[1].Value.ToString() != tbCCCD.Text)
            {

                if (!CheckMa(st))
                {
                    MessageBox.Show("CMND/CCCD đã tồn tại, mời nhập lại!", "Thông báo!", MessageBoxButtons.OK);
                    tbMNV.Focus();
                }
            }
            string gioitinh = "";
            if (rbNam.Checked)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }
           
            st = "UPDATE NHANVIEN SET CCCD='"+tbCCCD.Text+"',TenNV=N'"+tbTen.Text+"',NgaySinh='"+dtNgaySinh.Text+"',GioiTinh=N'"+gioitinh+"',DiaChi=N'"+tbDiaChi.Text+"',SDT='"+tbSDT.Text+"',Email='"+tbGmail.Text+"',ChiNhanhLV='"+ cbChiNhanh.SelectedValue.ToString() + "',ChucVu=N'"+cbChucVu.Text+ "' WHERE  MaNV='" + tbMNV.Text+"'";
            
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn sửa thông tin Nhân viên trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataProvider.Instance.ExecuteNonQuery(st) == 0)
                {
                    MessageBox.Show("Sửa không thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa thành công!");
                    KhoiTao();
                }
            }
           
        }
        bool Check()
        {
            if( tbTen.Text=="" || tbDiaChi.Text=="" || tbCCCD.Text=="" || tbSDT.Text=="" || dtNgaySinh.Text=="" || cbChiNhanh.Text=="" || cbChucVu.Text=="" || tbGmail.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ các thông tin!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            if((rbNam.Checked==true && rbNu.Checked==true) || (rbNam.Checked == false && rbNu.Checked == false))
            {
                MessageBox.Show("Mời chọn giới tính!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            if(tbCCCD.Text.Length!=9 && tbCCCD.Text.Length != 12)
            {
                MessageBox.Show("CCCD/CMND là một dãy 9 hoặc 12 số!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            if (tbSDT.Text.Length != 10 )
            {
                MessageBox.Show("Số điện thoại phải có 10 số!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(strRegex);
            if (regex.IsMatch(tbGmail.Text) == false)
            {
                MessageBox.Show("email không hợp lệ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //SEND mail
        private void btTaoTK_Click(object sender, EventArgs e)
        {
            int i = dgvNhanVien.CurrentRow.Index;
            if (i == -1)
            {
                MessageBox.Show("Mời chọn nhân viên!");
            }
            else
            {
                if (dgvNhanVien.Rows[i].Cells[10].Value.ToString() == "True")
                {
                    MessageBox.Show("Nhân viên đã có tài khoản!");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn tạo tài khoản cho nhân viên " + tbTen.Text + " không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string pass = Membership.GeneratePassword(6, 1);
                        //MessageBox.Show(dgvNhanVien.Rows[i].Cells[7].Value.ToString());
                        string subject = "Bảo mật";
                        string content = "<h2 > Xin chào bạn, bạn vừa được tạo tài khoản để đăng nhập vào phần mềm quản lý của ngân hàng META BANK chúng tôi!</h2> <h4> Hãy sử dụng thông tin tài khoản, mật khẩu dưới đây để đăng nhập vào hệ thống! </h4><p><b> Tài Khoản: </b> <i> bankingmeta@gmail.com </i> </p> <p><b> Mật khẩu: </b><i> " + pass + " </i></p><p> !!!Chú ý: Nên đổi mật khẩu trong lần đầu đăng nhập!!! </p> ";
                        SendMail("bankingmeta@gmail.com", dgvNhanVien.Rows[i].Cells[7].Value.ToString(), subject, content);
                        //MessageBox.Show(content);
                        MessageBox.Show("Thông tin tài khoản đã được gởi tới email " + dgvNhanVien.Rows[i].Cells[7].Value.ToString() + ", hãy kiểm tra và đăng nhập vào hệ thống!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string query = "UPDATE NHANVIEN SET MatKhau='" + pass + "',TaiKhoan='True' WHERE MaNV='" + dgvNhanVien.Rows[i].Cells[0].Value.ToString() + "'";
                        if (dataProvider.Instance.ExecuteNonQuery(query) == 0)
                        {
                            MessageBox.Show("Cập nhập dữ liệu không thành công, mời thực hiện lại!");
                        }
                        KhoiTao();
                    }
                }
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMNV.ReadOnly = true;
            int i;
            i = e.RowIndex;
            if(i== -1)
            {
                return;
            }
            //MessageBox.Show(  dgvNhanVien.Rows[i].Cells[8].Value.ToString());
           
                tbMNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                tbTen.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
                tbDiaChi.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
                tbCCCD.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
                dtNgaySinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
                tbSDT.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
                tbGmail.Text = dgvNhanVien.Rows[i].Cells[7].Value.ToString();
                cbChucVu.Text = dgvNhanVien.Rows[i].Cells[9].Value.ToString();
                cbChiNhanh.Text = dgvNhanVien.Rows[i].Cells[8].Value.ToString();

                if (dgvNhanVien.Rows[i].Cells[4].Value.ToString() == "Nam")
                {
                    rbNam.Checked = true;
                    rbNu.Checked = false;
                }
                else
                {
                    rbNam.Checked = false;
                    rbNu.Checked = true;
                }


               
            
        }

        private void LoadTK()
        {
            string st = "";
            try
            {
                if (!string.IsNullOrEmpty(tbTimKiem.Text) || cbCN.Text!=""  || cbChucVu1.Text!="")
                {
                    if (radioButton1.Checked)
                    {
                        
                            st = "SELECT MaNV, CCCD, TenNV ,NgaySinh ,GioiTinh,NV.DiaChi,SDT,Email,CN.TenCN,ChucVu FROM NHANVIEN NV, CHINHANH CN WHERE NV.ChiNhanhLV=CN.MaCN AND MaNV like '%" + tbTimKiem.Text.ToString() + "%' ";
                       
                    }
                    else if (radioButton2.Checked)
                    {
                        st = "SELECT MaNV, CCCD, TenNV ,NgaySinh ,GioiTinh,NV.DiaChi,SDT,Email,CN.TenCN,ChucVu FROM NHANVIEN NV, CHINHANH CN WHERE NV.ChiNhanhLV=CN.MaCN AND TenNV like N'%" + tbTimKiem.Text.ToString() + "%' ";

                    }
                    else if (radioButton3.Checked)
                    {
                        st = "SELECT MaNV, CCCD, TenNV ,NgaySinh ,GioiTinh,NV.DiaChi,SDT,Email,CN.TenCN,ChucVu FROM NHANVIEN NV, CHINHANH CN WHERE NV.ChiNhanhLV=CN.MaCN AND CCCD like '%" + tbTimKiem.Text.ToString() + "%' ";

                    }
                    else
                    {
                        st = "SELECT MaNV, CCCD, TenNV ,NgaySinh ,GioiTinh,NV.DiaChi,SDT,Email,CN.TenCN,ChucVu FROM NHANVIEN NV, CHINHANH CN WHERE NV.ChiNhanhLV=CN.MaCN AND SDT like '%" + tbTimKiem.Text.ToString() + "%' ";

                    }
                    if (cbCN.Text != "")
                    {
                        st += " AND TenCN = N'" + cbCN.Text.ToString() + "'";
                    }
                    if (cbChucVu1.Text != "") 
                    {
                        st += " AND ChucVu = N'" + cbChucVu1.Text.ToString() + "'";
                    }
                    dgvNhanVien.DataSource = dataProvider.Instance.ExecuteQuery(st);
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
            LoadTK();
        }

        
        
       

        private void cbChiNhanh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                LoadTK();
                
            }
        }

       

        private void cbCN_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void cbChucVu1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void cbCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            /*if ((e.KeyChar == '.') && ((sender as System.Windows.Controls.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void tbCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            /*if ((e.KeyChar == '.') && ((sender as System.Windows.Controls.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(panel1);
        }
        private void Print(Panel pnl)
        {
            PaperSize paperSize = new PaperSize("A5", 270, 600);
            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            GetPrintArea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        private Bitmap MemoryImage;
        private void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, rect);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, 0, 0);
        }

        private void cbChucVu1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
            LoadTK();
        }

       
    }
}
