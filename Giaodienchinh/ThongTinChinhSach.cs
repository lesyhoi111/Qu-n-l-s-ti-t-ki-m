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

namespace Lần_1
{
    public partial class ThongTinChinhSach : Form
    {
        public ThongTinChinhSach()
        {
            InitializeComponent();
        }

        private void ThongTinChinhSach_Load(object sender, EventArgs e)
        {
            LoadDT();
        }
        void LoadDT()
        {
            string st = "SELECT * FROM THAMSO";
            DataTable dt = dataProvider.Instance.ExecuteQuery(st);
            DataRow dtr = dt.Rows[0];
            tbTTBanDau.Text = dtr[0].ToString();
            tbTTThem.Text = dtr[1].ToString();
            tbSNTTSauGoi.Text = dtr[2].ToString();
            tbTTBanDau.ReadOnly = true;
            tbTTThem.ReadOnly = true;
            tbSNTTSauGoi.ReadOnly = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Sửa")
            {
                button2.Text = "Xác Nhận";
                tbSNTTSauGoi.ReadOnly = false;
                tbTTBanDau.ReadOnly = false;
                tbTTThem.ReadOnly = false;
            }
            else
            {
                button2.Text = "Sửa";
                string st = "UPDATE THAMSO SET SoTienGoiToithieuBD= N'" + tbTTBanDau.Text + "',SoTienGoiThemToiThieu='" + tbTTThem.Text + "',SoNgayDuocRutSauGoi='" + tbSNTTSauGoi.Text + "' ";
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn sửa thông tin trên?", "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dataProvider.Instance.ExecuteNonQuery(st) == 0)
                    {
                        MessageBox.Show("Sửa không thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thành công!");
                    }
                    LoadDT();
                }
            }
        }

        private void tbTTBanDau_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbTTThem_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbSNTTSauGoi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbTTBanDau_TextChanged(object sender, EventArgs e)
        {
            if (tbTTBanDau.Text == "00")
            {
                tbTTBanDau.Text = "";
            }
            if (!string.IsNullOrEmpty(tbTTBanDau.Text))
            {
                tbTTBanDau.Text = string.Format("{0:0,0}", double.Parse(tbTTBanDau.Text));
                tbTTBanDau.SelectionStart = tbTTBanDau.Text.Length;
            }
        }

        private void tbTTThem_TextChanged(object sender, EventArgs e)
        {
            if (tbTTThem.Text == "00")
            {
                tbTTThem.Text = "";
            }
            if (!string.IsNullOrEmpty(tbTTThem.Text))
            {
                tbTTThem.Text = string.Format("{0:0,0}", double.Parse(tbTTThem.Text));
                tbTTThem.SelectionStart = tbTTThem.Text.Length;
            }
        }
    }
}
