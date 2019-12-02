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
    public partial class addCurrency : Form
    {
        public addCurrency()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbname.Text.Trim();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M9RBD6L\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "INSERT INTO [dbo].[tblCurrency] ([CurrencyType]) VALUES ('"+name+"')";

            SqlCommand cmd = new SqlCommand(query,con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("added succesfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
