using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using Thong_Tin_Khach_hang;
using WindowsFormsApp1.ConnectDB;

namespace WindowsFormsApp1
{
    public partial class frmTopKhachHang : Form
    {
        string month = "";
        string year = "";
        bool Loaded = false;
        DateTime dtBD;
        DateTime dtKT;
        public frmTopKhachHang()
        {
            InitializeComponent();
        }
        private void ReportTopDeposit_Load(object sender, EventArgs e)
        {

            dtpmonthReport.Text = dtpSau.Text = DateTime.Now.ToString();
            comboBox1.Text = "Theo ngày";
            dtBD = DateTime.Now;
            dtKT = DateTime.Now;
            LoadAccountList();
            FillChart();
            LoadAccountList();
            Loaded = true;
            rdbAll.Checked = true;
        }


        private void FillChart()
        {

            string query = "SELECT TOP 5 KH.MaKH, KH.TenKH, KH.CCCD,KH.SDT,KH.DiaChi,SUM(PGT.SoTienGoi) as'TongTienGui' From KHACHHANG KH, PHIEUGOITIEN PGT WHERE KH.MaKH=PGT.MaKH" + tinhTrangHoatDong() + " AND (PGT.NgayGoi >= '" + dtBD + "' AND PGT.NgayGoi <= '" + dtKT + "') GROUP BY KH.MaKH, KH.TenKH, KH.CCCD,KH.SDT,KH.DiaChi ORDER BY SUM(PGT.SoTienGoi) DESC";
            chart1.DataSource = dataProvider.Instance.ExecuteQuery(query);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Khách hàng";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số tiền (VND)";
            chart1.Series["Số tiền gửi"].XValueMember = "TenKH";
            chart1.Series["Số tiền gửi"].YValueMembers = "TongTienGui";
        }

        void LoadAccountList()
        {
            string query = "SELECT TOP 5 KH.MaKH 'Mã Khách Hàng', KH.TenKH 'Tên Khách Hàng', KH.CCCD,KH.SDT,KH.DiaChi 'Địa Chỉ',SUM(PGT.SoTienGoi) as'Tổng tiền gửi (VND)' From KHACHHANG KH, PHIEUGOITIEN PGT WHERE KH.MaKH=PGT.MaKH" + tinhTrangHoatDong() + " AND (PGT.NgayGoi >= '" + dtBD + "' AND PGT.NgayGoi <= '" + dtKT + "') GROUP BY KH.MaKH, KH.TenKH, KH.CCCD,KH.SDT,KH.DiaChi ORDER BY SUM(PGT.SoTienGoi) DESC";
            DataProvider provider = new DataProvider();
            dataGridView_Top5.DataSource = provider.ExcuteQuery(query);
            dataGridView_Top5.Columns[5].DefaultCellStyle.Format = "#,##0.##";
        }

        void setDT()
        {
            if (comboBox1.Text == "Theo ngày")
            {
                dtpSau.CustomFormat = dtpmonthReport.CustomFormat = "dd/MM/yyyy";
                label6.Hide();
                numericUpDown1.Hide();
                dtpSau.Enabled = dtpmonthReport.Enabled = true;
                dtBD = dtpmonthReport.Value;
                dtKT = dtpSau.Value;
            }
            if (comboBox1.Text == "Theo tháng")
            {
                dtpSau.CustomFormat = dtpmonthReport.CustomFormat = "MM/yyyy";
                label6.Hide();
                numericUpDown1.Hide();
                dtpSau.Enabled = dtpmonthReport.Enabled = true;
                dtBD = new DateTime(dtpmonthReport.Value.Year, dtpmonthReport.Value.Month, 1);
                dtKT = new DateTime(dtpSau.Value.Year, dtpSau.Value.Month, DateTime.DaysInMonth(dtpSau.Value.Year, dtpSau.Value.Month));
            }
            if (comboBox1.Text == "Theo năm")
            {
                dtpSau.CustomFormat = dtpmonthReport.CustomFormat = "yyyy";
                label6.Hide();
                numericUpDown1.Hide();
                dtpSau.Enabled = dtpmonthReport.Enabled = true;
                dtBD = new DateTime(dtpmonthReport.Value.Year, 1, 1);
                dtKT = new DateTime(dtpSau.Value.Year, 12, 31);
            }
            if (comboBox1.Text == "Theo quý (3 tháng)")
            {
                dtpSau.CustomFormat = dtpmonthReport.CustomFormat = "yyyy";
                label6.Show();
                numericUpDown1.Show();
                dtpSau.Enabled = false;
                int monthbd = 1 + 3 * ((int)(numericUpDown1.Value) - 1);
                dtBD = new DateTime(dtpmonthReport.Value.Year, monthbd, 1);
                dtKT = new DateTime(dtpmonthReport.Value.Year, monthbd, 1).AddMonths(3).AddDays(-1);
                // MessageBox.Show((dtBD).ToString() + "-" + (dtKT).ToString());

            }
        }
        string tinhTrangHoatDong()
        {
            string active = "";
            if (rdbActive.Checked)
            {
                active = " and TinhTrangHoatDong='true'";
            }
            else if (rdbInactive.Checked)
            {
                active = " and TinhTrangHoatDong='false'";
            }
            else
            {
                active = "";
            }
            return active;
        }
        private void rjbtnXuatFile_Click(object sender, EventArgs e)
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tọa mới một excel WorkBook
            oExcel.Visible = true;
            oExcel.DisplayAlerts = true;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = "Tổng tiền gửi";

            Microsoft.Office.Interop.Excel.Range headleft1 = oSheet.get_Range("A1", "B1");
            headleft1.MergeCells = true;
            headleft1.Value2 = "NGÂN HÀNG TƯ NHÂN META BANK";
            headleft1.Font.Bold = true;
            headleft1.Font.Name = "Tahoma";
            headleft1.Font.Size = "15";
            headleft1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range headright1 = oSheet.get_Range("D1", "F1");
            headright1.MergeCells = true;
            headright1.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            headright1.Font.Bold = true;
            headright1.Font.Name = "Tahoma";
            headright1.Font.Size = "15";
            headright1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range headright2 = oSheet.get_Range("D2", "F2");
            headright2.MergeCells = true;
            headright2.Value2 = "Độc lập-Tự do-Hạnh phúc";
            headright2.Font.Bold = true;
            headright2.Font.Underline = true;
            headright2.Font.Name = "Tahoma";
            headright2.Font.Size = "14";
            headright2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range headright3 = oSheet.get_Range("C4", "F4");
            headright3.MergeCells = true;
            headright3.Value2 = MainFormManager.Instance.tenCN().ToString() + ", ngày " + DateTime.Now.Date.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            headright3.Font.Italic = true;
            headright3.Font.Name = "Tahoma";
            headright3.Font.Size = "12";
            headright3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //Tạo tiêu đề 
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A5", "F5");
            head.MergeCells = true;
            head.Value2 = "Thống kê top 5 khách hàng gửi tiền nhiều nhất ";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range r1 = oSheet.get_Range("A6", "F6");
            r1.MergeCells = true;
            r1.Value2 = "Từ ngày: " + dtBD.ToString("dd/MM/yyyy") + " đến ngày: " + dtKT.ToString("dd/MM/yyyy");
            r1.ColumnWidth = 13.5;
            r1.Font.Italic = true;

            //Tạo tiêu đề cột
            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A7", "A7");
            cl1.Value2 = "Mã khách hàng";
            cl1.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B7", "B7");
            cl2.Value2 = "Tên khách hàng";
            cl2.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C7", "C7");
            cl3.Value2 = "CCCD";
            cl3.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D7", "D7");
            cl4.Value2 = "SDT";
            cl4.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E7", "E7");
            cl5.Value2 = "Điạ chỉ";
            cl5.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F7", "F7");
            cl6.Value2 = "Tổng tiền gửi";
            cl6.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A7", "F7");
            rowHead.Font.Bold = true;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //Tạo mảng Datatable
            object[,] arr = new object[dataGridView_Top5.Rows.Count, dataGridView_Top5.Columns.Count];
            //Chuyển dữ liệu từ Datatable vào mảng đối tượng 
            for (int r = 0; r < dataGridView_Top5.Rows.Count; r++)
            {
                DataGridViewRow dt = dataGridView_Top5.Rows[r];

                for (int c = 0; c < dataGridView_Top5.Columns.Count; c++)
                {
                    arr[r, c] = dt.Cells[c].Value;
                }
            }
            //Thiết lập vùng điền dữ liệu 
            int rowStart = 8;
            int columnStart = 1;
            int rowEnd = rowStart + dataGridView_Top5.Rows.Count - 1;
            int columnEnd = dataGridView_Top5.Columns.Count;
            Microsoft.Office.Interop.Excel.Range bd = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[8, 3];
            Microsoft.Office.Interop.Excel.Range kt = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[8 + dataGridView_Top5.Rows.Count - 1, 3];
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(bd, kt);
            range.NumberFormat = "000000000000";
            Microsoft.Office.Interop.Excel.Range bd1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[8, 4];
            Microsoft.Office.Interop.Excel.Range kt1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[8 + dataGridView_Top5.Rows.Count - 1, 4];
            Microsoft.Office.Interop.Excel.Range range2 = oSheet.get_Range(bd1, kt1);
            range2.NumberFormat = "0000000000";
            Microsoft.Office.Interop.Excel.Range bd2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[8, 6];
            Microsoft.Office.Interop.Excel.Range kt2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[8 + dataGridView_Top5.Rows.Count - 1, 6];
            Microsoft.Office.Interop.Excel.Range range3 = oSheet.get_Range(bd2, kt2);
            range3.NumberFormat = "#,##0.##";
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range1 = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range1.Value2 = arr;
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            //Kí xác nhận
            string colunderS = "E" + (rowEnd + 2);
            string colunderE = "F" + (rowEnd + 2);
            Microsoft.Office.Interop.Excel.Range under1 = oSheet.get_Range(colunderS, colunderE);
            under1.MergeCells = true;
            under1.Value2 = "Giám đốc";
            under1.Font.Bold = true;
            under1.Font.Name = "Tahoma";
            under1.Font.Size = "12";
            under1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            colunderS = "E" + (rowEnd + 3);
            colunderE = "F" + (rowEnd + 3);
            Microsoft.Office.Interop.Excel.Range under2 = oSheet.get_Range(colunderS, colunderE);
            under2.MergeCells = true;
            under2.Value2 = "(Kí và ghi rõ họ tên)";
            under2.Font.Name = "Tahoma";
            under2.Font.Size = "9";
            under2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void dtpmonthReport_ValueChanged(object sender, EventArgs e)
        {
            month = dtpmonthReport.Value.Month.ToString();
            year = dtpmonthReport.Value.Year.ToString();
            FillChart();
            LoadAccountList();
        }

        private void dtpmonthReport_ValueChanged_1(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
                //MessageBox.Show((dtBD).ToString() + "-" + (dtKT).ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
                //MessageBox.Show((dtBD).ToString() + "-" + (dtKT).ToString());
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
            }
        }

        private void rdbActive_CheckedChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
            }
        }

        private void rdbInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
            }
        }
    }
}
