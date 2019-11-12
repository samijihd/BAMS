using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnDashboard);
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MoveSidePanel(Control c)
        {
            sidePanel.Height = c.Height;
            sidePanel.Top = c.Top;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn2);
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

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }
    }
}
