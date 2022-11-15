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

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string strcon = @"Data Source=LESYHOI;Initial Catalog=QLSTK;Integrated Security=True";
        SqlDataReader reader ;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            rjTaiKhoan.Focus();
        }

        

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
            {
                rjMatKhau.PasswordChar = false;
            }
            else
            {
                rjMatKhau.PasswordChar = true;
            }
        }

        private void rjBtDangNhap_Click(object sender, EventArgs e)
        {
            if (rjTaiKhoan.Texts=="")
            {
                MessageBox.Show("Mời nhập thông tin tài khoản !", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                rjTaiKhoan.Focus();
                return;
            }
            if (rjMatKhau.Texts == "")
            {
                MessageBox.Show("Mời nhập thông tin mật khẩu !", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                rjMatKhau.Focus();
                return;
            }
            connection = new SqlConnection(strcon);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM NHANVIEN WHERE Email='" + rjTaiKhoan.Texts + "' AND MatKhau='" + rjMatKhau.Texts + "'";
            reader=command.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Tài khoản, mật khẩu không đúng, mời nhập lại!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                rjTaiKhoan.Focus();
            }
            else
            {
                MessageBox.Show(rjTaiKhoan.Texts + " " + rjMatKhau.Texts);
                MessageBox.Show("Đăng nhập thành công!", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }
    }
}
