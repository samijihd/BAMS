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
    public partial class newClient : Form
    {

        public string gender;
        public string birth;
        public newClient()
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

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            string firstname = tbfname.Text.Trim();
            string lastname = tblname.Text.Trim();
            string email = tbemail.Text.Trim();
            string phone = tbphone.Text.Trim();
            string job = tbjob.Text.Trim();
            string address = tbaddress.Text.Trim();


            
            if (string.IsNullOrEmpty(tbfname.Text) && string.IsNullOrEmpty(tblname.Text))
            {
                MessageBox.Show("please fill all blanks");
            }
            else
            {
                if (maleradio.Checked)
                {
                    gender = "male";
                }
                else if (femaleradio.Checked)
                {
                    gender = "female";
                }
                else if (otherradio.Checked)
                {
                    gender = "other";
                }
                else
                {
                    MessageBox.Show("please select the client gender");
                }

                birth = birthpicher.Value.ToShortDateString();

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-M9RBD6L\\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                string query = @"INSERT INTO [dbo].[tblCustomer]
           ([firstName]
           ,[lastName]
           ,[Email]
           ,[Phone]
           ,[Job]
           ,[Address]
           ,[Gender]
           ,[Birth])
     VALUES
           ('" + firstname + "','" + lastname + "','" + email + "','" + phone + "','" + job + "','" + address + "','" + gender + "','" + birth + "')";

                SqlCommand cmd = new SqlCommand(query, con);


                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("The new client added successfully");
                }
                catch
                {
                    MessageBox.Show("error to add new client, please try again");
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
