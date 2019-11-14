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

namespace BAMS
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            MoveSidePanel(btn2);
            MoveSidePanel(btn3);
            MoveSidePanel(btn4);
            MoveSidePanel(btn5);
            MoveSidePanel(btn6);
            MoveSidePanel(btn7);
            MoveSidePanel(btnDashboard);
            
            label2.Text = Login.user;
            
            

        }
        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox4_OnValueChanged(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox5_OnValueChanged(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnDashboard);
            hidepanels();
            //flowLayoutPanel1.Visible = true;
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void hidepanels()
        {
            //flowLayoutPanel1.Visible = false;
        }
        private void MoveSidePanel(Control c)
        {
            sidePanel.Height = c.Height;
            sidePanel.Top = c.Top;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn2);
            hidepanels();
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn7);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = Login.user;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 1100);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void nColorButton1_ColorChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 1100);
        }
    }
}
