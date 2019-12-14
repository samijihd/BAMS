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
    public partial class Account : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M9RBD6L\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        string query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id";

        public static string Account_ID_;
        public static string First_Name_;
        public static string Last_Name_;
        public Account()
        {
            InitializeComponent();
            showAccount();
        }

        public void showAccount()
        {
            try
            {
                con.Open();
                adpt = new SqlDataAdapter(query, con);
                dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Account_ID_) && string.IsNullOrEmpty(First_Name_)  && string.IsNullOrEmpty(Last_Name_))
            {
                MessageBox.Show("Please Select a client to add");
            }
            else
            {
                addAccount adc = new addAccount();
                adc.Show();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {
                
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id";

            showAccount();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            query = "select * from tblAccount where ID_ like '"+tbsearch.Text+"%' or firstname like '"+tbsearch.Text+"%' or AccountNo like '"+tbsearch.Text+"%' or Iban like '"+tbsearch.Text+"%' ";
            showAccount();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (usdradio.Checked)
            {
                query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where CurrencyType = 'USD'";
                showAccount();
            }
            else if (eurradio.Checked)
            {
                query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where CurrencyType = 'EUR'";
                showAccount();
            }
            else if (gbpradio.Checked)
            {
                query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where CurrencyType = 'BGP'";
                showAccount();
            }
            else if (chpradio.Checked)
            {
                query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where CurrencyType = 'CHP'";
                showAccount();
            }
            else
            {
                MessageBox.Show("please select the correct item");
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            string from = tbfrom.Text.Trim();
            string to = tbto.Text.Trim();
            query = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where Balance between "+from+" and "+to+"";
            showAccount(); 
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCurrency curr = new addCurrency();
            curr.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                Account_ID_ = selectedRow.Cells["ID_"].Value.ToString();
                First_Name_ = selectedRow.Cells["firstname"].Value.ToString();
                Last_Name_ = selectedRow.Cells["lastname"].Value.ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
