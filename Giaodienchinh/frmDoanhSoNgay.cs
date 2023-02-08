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
using WindowsFormsApp1.ConnectDB;

namespace WindowsFormsApp1
{

    public partial class frmDoanhSoNgay : Form
    {
        bool Loaded = false;
        DataTable dt = new DataTable();
        DateTime dtBD;
        DateTime dtKT;
        public frmDoanhSoNgay()
        {
            InitializeComponent();
            dtpmonthReport.Format = dtpSau.Format = DateTimePickerFormat.Custom;
            label6.Hide();
            numericUpDown1.Hide();
        }

        private void frmDoanhSoNgay_Load(object sender, EventArgs e)
        {
            dtpmonthReport.Text = dtpSau.Text = DateTime.Now.ToString();
            comboBox1.Text = "Theo ngày";
            dtBD = DateTime.Now;
            dtKT = DateTime.Now;
            LoadAccountList();
            FillChart();
            this.dataGridView.Columns.Add("ChenhLech", "Chênh lệch (VND)");
            LoadChenhLech();
            dataGridView.Columns[2].DefaultCellStyle.Format = "#,##0.##";
            dataGridView.Columns[3].DefaultCellStyle.Format = "#,##0.##";
            dataGridView.Columns["ChenhLech"].DefaultCellStyle.Format = "#,##0.##";
            Loaded = true;
        }
        void LoadChenhLech()
        {
            ulong chenhlech = 0;
            double nhapvao = 0;
            double chira = 0;
            

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[3].Value.ToString() == "")
                {
                    nhapvao = 0;
                    dataGridView.Rows[i].Cells[3].Value = "0";
                }
                else
                {
                    nhapvao = double.Parse(dataGridView.Rows[i].Cells[3].Value.ToString());
                }
                if (dataGridView.Rows[i].Cells[4].Value.ToString() == "")
                {
                    chira = 0;
                    dataGridView.Rows[i].Cells[4].Value = "0";
                }
                else
                {
                    chira = double.Parse(dataGridView.Rows[i].Cells[4].Value.ToString());
                }
                if (nhapvao > chira)
                {
                    chenhlech = (ulong)(nhapvao - chira);
                }
                else
                {
                    chenhlech = (ulong)(chira - nhapvao);
                }
                
                dataGridView.Rows[i].Cells["ChenhLech"].Value = chenhlech;
            }

        }
        void LoadAccountList()
        {
            //MessageBox.Show((dtBD).ToString() + "-" + (dtKT).ToString());
            string query = $"  SELECT CN.MaCN,CN.TenCN, SUM(T1.TongTienThu) as TongTienThu, SUM(T2.TongTienChi) as TongTienChi FROM (SELECT MaCN, SUM(SoTienGoi) as TongTienThu FROM PHIEUGOITIEN WHERE NgayGoi >= '"+dtBD+"' AND NgayGoi <= '"+dtKT+"' AND NoiDungGiaoDich = N'Nộp tiền vào tài khoản' GROUP BY MaCN) T1 FULL JOIN(SELECT MaCN, SUM(SoTienRut) as TongTienChi FROM PHIEURUTTIEN WHERE NgayRut >= '"+dtBD+"' AND NgayRut <= '"+dtKT+"' AND NoiDungGiaoDich = N'Rút tiền trong tài khoản' GROUP BY MaCN) T2 ON T1.MaCN = T2.MaCN, CHINHANH CN WHERE CN.MaCN = T1.MaCN OR CN.MaCN = T2.MaCN GROUP BY CN.MaCN,CN.TenCN";
            //MessageBox.Show(query);
            dataGridView.DataSource = dataProvider.Instance.ExecuteQuery(query);
            
        }
        private void FillChart()
        {

            //DataProvider provider = new DataProvider();
            string query = $"SELECT CN.MaCN,CN.TenCN, SUM(T1.TongTienThu) as TongTienThu, SUM(T2.TongTienChi) as TongTienChi FROM (SELECT MaCN, SUM(SoTienGoi) as TongTienThu FROM PHIEUGOITIEN WHERE NgayGoi >= '" + dtBD + "' AND NgayGoi <= '" + dtKT + "' AND NoiDungGiaoDich = N'Nộp tiền vào tài khoản' GROUP BY MaCN) T1 FULL JOIN(SELECT MaCN, SUM(SoTienRut) as TongTienChi FROM PHIEURUTTIEN WHERE NgayRut >= '" + dtBD + "' AND NgayRut <= '" + dtKT + "' AND NoiDungGiaoDich = N'Rút tiền trong tài khoản' GROUP BY MaCN) T2 ON T1.MaCN = T2.MaCN, CHINHANH CN WHERE CN.MaCN = T1.MaCN OR CN.MaCN = T2.MaCN GROUP BY CN.MaCN,CN.TenCN";
            dt.Clear();
            dt = dataProvider.Instance.ExecuteQuery(query);
            chart1.DataSource = dt;

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Tổng tiền thu, chi";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số tiền (VND)";
            chart1.Series["TongThu"].XValueMember = "TenCN";
            chart1.Series["TongThu"].YValueMembers = "TongTienThu";
            chart1.Series["TongChi"].YValueMembers = "TongTienChi";

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
            oSheet.Name = "Tổng tiền gửi, rút";
            //Tạo 
            Microsoft.Office.Interop.Excel.Range headleft1 = oSheet.get_Range("A1", "B1");
            headleft1.MergeCells = true;
            headleft1.Value2 = "NGÂN HÀNG TƯ NHÂN META BANK";
            headleft1.Font.Bold = true;
            headleft1.Font.Name = "Tahoma";
            headleft1.Font.Size = "15";
            headleft1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range headright1 = oSheet.get_Range("C1", "E1");
            headright1.MergeCells = true;
            headright1.Value2 = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            headright1.Font.Bold = true;
            headright1.Font.Name = "Tahoma";
            headright1.Font.Size = "15";
            headright1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range headright2 = oSheet.get_Range("C2", "E2");
            headright2.MergeCells = true;
            headright2.Value2 = "Độc lập-Tự do-Hạnh phúc";
            headright2.Font.Bold = true;
            headright2.Font.Underline = true;
            headright2.Font.Name = "Tahoma";
            headright2.Font.Size = "14";
            headright2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range headright3 = oSheet.get_Range("C4", "E4");
            headright3.MergeCells = true;
            headright3.Value2 = MainFormManager.Instance.tenCN().ToString()+", ngày " + DateTime.Now.Date.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            headright3.Font.Italic = true;
            headright3.Font.Name = "Tahoma";
            headright3.Font.Size = "12";
            headright3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //Tạo tiêu đề 
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A5", "E5");
            head.MergeCells = true;
            head.Value2 = "Báo Cáo Doanh Số Hoạt Động";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "15";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range r1 = oSheet.get_Range("A6", "E6");
            r1.MergeCells = true;
            r1.Value2 = "Từ ngày: " + dtBD.ToString("dd/MM/yyyy") + " đến ngày: " + dtKT.ToString("dd/MM/yyyy");
            r1.ColumnWidth = 13.5;
            r1.Font.Italic = true;
            //Tạo tiêu đề cột
            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A7", "A7");
            cl1.Value2 = "Mã Chi Nhánh";
            cl1.ColumnWidth = 18.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B7", "B7");
            cl2.Value2 = "Tên Chi Nhánh";
            cl2.ColumnWidth = 30.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C7", "C7");
            cl3.Value2 = "Tổng Thu (VND)";
            cl3.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D7", "D7");
            cl4.Value2 = "Tổng Chi (VND)";
            cl4.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E7", "E7");
            cl5.Value2 = "Chênh Lệch (VND)";
            cl5.ColumnWidth = 25.0;
            /*Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Tổng tiền gửi";
            cl6.ColumnWidth = 25.0;*/
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A7", "E7");
            rowHead.Font.Bold = true;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //Tạo mảng Datatable
            object[,] arr = new object[dataGridView.Rows.Count, dataGridView.Columns.Count];
            //Chuyển dữ liệu từ Datatable vào mảng đối tượng 
            for (int r = 0; r < dataGridView.Rows.Count; r++)
            {
                DataGridViewRow dt = dataGridView.Rows[r];

                for (int c = 0; c < dataGridView.Columns.Count; c++)
                {
                    if (c == 0)
                    {
                        arr[r, 4] = dt.Cells[c].Value;
                    }
                    else
                    {
                        arr[r, c - 1] = dt.Cells[c].Value;
                    }
                   
                }
                arr[r, 4] = dt.Cells[0].Value.ToString();
            }
            //Thiết lập vùng điền dữ liệu 
            int rowStart = 8;
            int columnStart = 1;
            int rowEnd = rowStart + dataGridView.Rows.Count - 1;
            int columnEnd = dataGridView.Columns.Count;
            /*Microsoft.Office.Interop.Excel.Range bd = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[4, 3];
            Microsoft.Office.Interop.Excel.Range kt = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[4 + dataGridView.Rows.Count - 1, 3];
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(bd, kt);
            range.NumberFormat = "dd/MM/yyyy";*/

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range1 = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range1.Value2 = arr;
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //Kí xác nhận
            string colunderS = "D" + (rowEnd + 2);
            string colunderE = "E" + (rowEnd + 2);
            Microsoft.Office.Interop.Excel.Range under1 = oSheet.get_Range(colunderS, colunderE);
            under1.MergeCells = true;
            under1.Value2 = "Giám đốc";
            under1.Font.Bold = true;
            under1.Font.Name = "Tahoma";
            under1.Font.Size = "12";
            under1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            colunderS = "D" + (rowEnd + 3);
            colunderE = "E" + (rowEnd + 3);
            Microsoft.Office.Interop.Excel.Range under2 = oSheet.get_Range(colunderS, colunderE);
            under2.MergeCells = true;
            under2.Value2 = "(Kí và ghi rõ họ tên)";
            under2.Font.Name = "Tahoma";
            under2.Font.Size = "9";
            under2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void dtpmonthReport_ValueChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();

                LoadChenhLech();
                //MessageBox.Show((dtBD).ToString() + "-" + (dtKT).ToString());
            }
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
                LoadChenhLech();
            }
            /*Tùy chọn
Một tháng
Một quý (3 tháng)
Một năm*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int monthbd = 1 + 3 * ((int)(numericUpDown1.Value) - 1);
            int monthkt = monthbd + 3;
            dtBD = new DateTime(dtpmonthReport.Value.Year, monthbd, 1);
            dtKT = new DateTime(dtpmonthReport.Value.Year, monthkt, 1).AddDays(-1);
            //MessageBox.Show((dtBD).ToString()+"-"+(dtKT).ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                setDT();
                LoadAccountList();
                FillChart();
                LoadChenhLech();
                //MessageBox.Show((dtBD).ToString() + "-" + (dtKT).ToString());
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView.Rows.Count.ToString() + "-" + dataGridView.Columns.Count.ToString());
            for (int r = 0; r < dataGridView.Rows.Count; r++)
            {
                DataGridViewRow dt = dataGridView.Rows[r];

                for (int c = 0; c < dataGridView.Columns.Count ; c++)
                {
                    MessageBox.Show(dt.Cells[c].Value.ToString());
                    //arr[r, c - 1] = dt.Cells[c].Value;
                }
            }
        }
    }
}
