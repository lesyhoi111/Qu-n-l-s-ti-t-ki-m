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

namespace WindowsFormsApp1
{
    public partial class frmAccount : Form
    {
        bool display = true;
        public frmAccount()
        {
            InitializeComponent();
        }
        

        private void frmAccount_Load(object sender, EventArgs e)
        {
            string query = "select TenNV,MaNV,NgaySinh,DiaChi,CCCD,GioiTinh,SDT,Email,ChiNhanhLV from nhanvien where SDT='" + Login.sdt + "'";
            DataTable dt = new DataTable();
            dt = dataProvider.Instance.ExecuteQuery(query);
            txtTen.Text = dt.Rows[0]["TenNV"].ToString();
            txtMaNV.Text = dt.Rows[0]["MaNV"].ToString();
            DateTime date = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            txtngaySinh.Text = date.Date.ToString("dd/MM/yyyy");
            txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            txtCCCD.Text = dt.Rows[0]["CCCD"].ToString();
            txtGioiTinh.Text = dt.Rows[0]["GioiTinh"].ToString();
            txtSDT.Text = dt.Rows[0]["SDT"].ToString();
            txtGmail.Text = dt.Rows[0]["Email"].ToString();
            txtChiNhanh.Text = MainFormManager.Instance.tenCN();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            MainFormManager.Instance.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            MainFormManager.Instance.openChildForm(new ForgotPass());
        }
    }
}
