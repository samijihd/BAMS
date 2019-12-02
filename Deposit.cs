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
    public partial class Deposit : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M9RBD6L\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string connString = "Data Source=DESKTOP-M9RBD6L\\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlDataAdapter adpt;
        SqlCommand cmd;
        public Deposit()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {
            string lname = tblname.Text.Trim();
            string no = tbaccountno.Text.Trim();
            string amont = tbamount.Text.Trim();

            int yourValue = 0;
            string query = "select Balance from tblAccount where lastname = '"+lname+"' and AccountNo = '"+no+"'";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                yourValue = (Int32)cmd.ExecuteScalar();
            }
        }
    }
}
