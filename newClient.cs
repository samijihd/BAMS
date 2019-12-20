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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-M9RBD6L\\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        string query;

        public string gender;
        public string birth;
        public int branch;
        public int job;
        public newClient()
        {
            InitializeComponent();
            BindData_Branch();
            BindData_Jobs();
        }
        public void BindData_Jobs()
        {
            con.Open();
            query = "select id,Job from tblCustomerJobs";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("Job", typeof(string));
            dt.Load(reader);
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "Job";
            comboBox2.DataSource = dt;
            con.Close();
        }
        public void BindData_Branch()
        {
            con.Open();
            query = "select id_,Branch from tblBranch";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id_", typeof(string));
            dt.Columns.Add("Branch", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "id_";
            comboBox1.DisplayMember = "Branch";
            comboBox1.DataSource = dt;
            con.Close();
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
            string address = tbaddress.Text.Trim();
            birth = birthpicher.Value.ToShortDateString();

            string index1 = comboBox2.SelectedIndex.ToString();
            int job = Int32.Parse(index1);
            job++;
            string index = comboBox1.SelectedIndex.ToString();
            int branch = Int32.Parse(index);
            branch++;

            if (string.IsNullOrEmpty(tbfname.Text) && string.IsNullOrEmpty(tblname.Text))
            {
                MessageBox.Show("please fill all blanks");
            }
            else 
            {
                               

                if (maleradio.Checked)
                {
                    gender = "1";
                }
                else if (femaleradio.Checked)
                {
                    gender = "2";
                }
                else if (otherradio.Checked)
                {
                    gender = "3";
                }
                else
                {
                    MessageBox.Show("please select the client gender");
                }

                
                query = "addCustomer";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
    
                cmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.VarChar)).Value = firstname;
                cmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar)).Value = lastname;
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;
                cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar)).Value = phone;
                cmd.Parameters.Add(new SqlParameter("@jobID", SqlDbType.VarChar)).Value = job;
                cmd.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar)).Value = address;
                cmd.Parameters.Add(new SqlParameter("@genderID", SqlDbType.VarChar)).Value = gender;
                cmd.Parameters.Add(new SqlParameter("@birth", SqlDbType.VarChar)).Value = birth;
                cmd.Parameters.Add(new SqlParameter("@branchID", SqlDbType.VarChar)).Value = branch;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Added Successfully");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                /*string query = @"Insert INTO tblCustomer values"
                               +"('" + firstname + "','" + lastname + "','" + email + "','" 
                               + phone + "','" + job + "','" + address + "','" + gender + "','"
                               + birth + "','" + branch + "')";*/

                /* string query = @"INSERT INTO [dbo].[tblCustomer]
            ([firstName]
            ,[lastName]
            ,[Email]
            ,[Phone]
            ,[Job_id]
            ,[Address]
            ,[Gender_id]
            ,[Birth]
            ,[Barnch_id])
      VALUES
            ('" + firstname + "','" + lastname + "','" + email + "','" + phone + "','" + job + "','" + address + "','" + gender + "','" + birth + "','"+branch+"')";*/

                /*SqlCommand cmd = new SqlCommand(query, con);*/


             
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tbphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newBranch nb = new newBranch();
            nb.Show();
        }
    }
}
