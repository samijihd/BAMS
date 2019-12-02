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
using Bunifu;
using BunifuAnimatorNS;


namespace BAMS
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M9RBD6L\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        DataSet ds = new DataSet();
        public string query;
        

        public Form1()
        {
            InitializeComponent();
            MoveSidePanel(btn2);
            MoveSidePanel(btn3);
            MoveSidePanel(btn4);
            MoveSidePanel(btn5);
            MoveSidePanel(btn6);
            MoveSidePanel(btnDashboard);
            
            label2.Text = Login.user;
            hidepanels();
            

        }
        private void hidepanels()
        {
            panel10.Visible = false;
            panel1.Visible = false;
            panel6.Visible = false;
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
           // panel10.Visible = true;
            panel6.Visible = true;
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
            hidepanels();
            panel1.Visible = true;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn3);
            hidepanels();
            panel10.Visible = true;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn4);
            hidepanels();
            Cards cd = new Cards();
            cd.Show();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn5);
            hidepanels();
            Account a = new Account();
            a.Show();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn6);
            hidepanels();
            Employee emp = new Employee();
            emp.Show();
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

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            panel1.AutoScrollPosition = new Point(0, 1100);
        }

        private void bunifuMetroTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox10_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox9_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox8_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            Deposit d = new Deposit();
            d.Show();
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            panel10.AutoScrollPosition = new Point(0,190);
        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            panel10.AutoScrollPosition = new Point(0,801);
        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {
            Transfer t = new Transfer();
            t.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void clearControls()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = string.Empty;
            }
        }

        private void bunifuThinButton26_Click_1(object sender, EventArgs e)
        {
            clearControls();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            newClient nc1 = new newClient();
            nc1.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public void showdata()
        {
            try
            {
                con.Open();
                //cmd = new SqlCommand();
                adpt = new SqlDataAdapter(query, con);
                dt = new DataTable();
                adpt.Fill(dt);
                gridview.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("failed to show data make sure that you are connected to the server, please try again !");
            }
        }
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            query = "select * from tblCustomer";
            showdata();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            query = "select * from tblCustomer";
            showdata();
        }

        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
        {
            if (maleradio.Checked)
            {
                query = "select * from tblCustomer where Gender='male'";
                showdata();
            }
            else if (femaleradio.Checked)
            {
                query = "select * from tblCustomer where Gender='female'";
                showdata();
            }
            else if (otherradio.Checked)
            {
                query = "select * from tblCustomer where Gender='other'";
                showdata();
            }
            else
            {
                MessageBox.Show("please select type");
            }
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            query = "select * from tblCustomer where firstname like '"+tbsearch.Text+"%' or ID like '"+tbsearch.Text+"%' ";
            showdata();
        }

     
        private void bunifuThinButton27_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            panel10.AutoScrollPosition = new Point(0, 190);
        }

        private void bunifuThinButton28_Click_1(object sender, EventArgs e)
        {
            Deposit d = new Deposit();
            d.Show();
        }

        private void bunifuThinButton26_Click_2(object sender, EventArgs e)
        {
            Transfer t = new Transfer();
            t.Show();
        }
    }
}
