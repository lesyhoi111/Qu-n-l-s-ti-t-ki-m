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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IconButton currenBtn;
        private Panel leftBoderBtn;
        private Form childFormCurrent;
        public Form1()
        {
            InitializeComponent();
            leftBoderBtn = new Panel();
            leftBoderBtn.Size = new Size(7, 60);
            panelBar.Controls.Add(leftBoderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            HideFullBtn();
        }
       
        private void HideFullBtn()
        {
            panelGiaoDich.Visible = false;
            panelLapPhieu.Visible=false;
            panelThongTin.Visible=false;
            panelBCTK.Visible=false;
        }
        private void HideSubBtn()
        {
            if (panelGiaoDich.Visible)
            {
                panelGiaoDich.Visible=false;
            }
            if (panelLapPhieu.Visible)
            {
                panelLapPhieu.Visible = false;
            }
            if (panelThongTin.Visible)
            {
                panelThongTin.Visible= false;
            }
            if (panelBCTK.Visible)
            {
                panelBCTK.Visible= false;
            }
        }
        private void ShowSubBtn(Panel panelClicked)
        {
            if (panelClicked.Visible)
            {
                panelClicked.Visible=false;
            }
            else {
                HideSubBtn();
                panelClicked.Visible=true;}
        }
        private void ActivateButton(Object senderBtn,int locationYBoder)
        {
            if(senderBtn!= null)
            {
                DisableButton();
                currenBtn=(IconButton)senderBtn;
                currenBtn.BackColor = Color.FromArgb(89, 158, 136);
                currenBtn.ForeColor = Color.Aqua;
                currenBtn.TextAlign=ContentAlignment.MiddleCenter;
                currenBtn.IconColor = Color.Aqua;
                currenBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currenBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBoderBtn.BackColor = Color.Aqua;
                leftBoderBtn.Location=new Point(0,locationYBoder);
                leftBoderBtn.Visible = true;
                leftBoderBtn.BringToFront();

                iconChildForm.IconChar = currenBtn.IconChar;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (childFormCurrent != null)
            {
                childFormCurrent.Close();   
            }
            childFormCurrent = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle=FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelChildForm.Text = childForm.Text;
        }
        private void DisableButton()
        {
            if (currenBtn != null)
            {
                currenBtn.BackColor = Color.FromArgb(57, 102, 88);
                currenBtn.ForeColor = Color.White;
                currenBtn.TextAlign = ContentAlignment.MiddleLeft;
                currenBtn.IconColor = Color.White;
                currenBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currenBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void iconThongTin_Click(object sender, EventArgs e)
        {
            ActivateButton(sender,125);
            //OpenChildForm(new Form2());
            ShowSubBtn(panelThongTin);
        }

        private void iconGiaoDich_Click(object sender, EventArgs e)
        {
            ActivateButton(sender,185);
            ShowSubBtn(panelGiaoDich);
        }

        private void iconLapPhieu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender,245);
            ShowSubBtn(panelLapPhieu);
        }

        private void iconBCTK_Click(object sender, EventArgs e)
        {
            ActivateButton(sender,305);
            ShowSubBtn(panelBCTK);
        }

        private void iconGiupDo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender,365);
            HideSubBtn();
        }

        private void pictureLogo_Click(object sender, EventArgs e)
        {
            if(childFormCurrent != null)
            {
                childFormCurrent.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBoderBtn.Visible = false;
            iconChildForm.IconChar = IconChar.Home;
            iconChildForm.IconColor = Color.Yellow;
            labelChildForm.Text = "Home";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
