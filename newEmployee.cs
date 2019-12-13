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
    public partial class newEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-M9RBD6L\\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        string query;
        string activity = "";
        public newEmployee()
        {
            InitializeComponent();
            BindData();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void BindData()
        {
            con.Open();
            query = "select id,JobTitle from tblJobTitle";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("JobTitle", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "JobTitle";
            comboBox1.DataSource = dt;
            con.Close();
        }
        public void Clear()
        {
            tbfname.Text = "";
            tblname.Text = "";
            tbuser.Text = "";
            tbpass.Text = "";
            tbsalary.Text = "";
            tbemail.Text = "";
        }
        
        public void addNewEmployee()
        {
            query = "addEmployee";
            cmd = new SqlCommand(query,con);
            cmd.CommandType = CommandType.StoredProcedure;
            string index = comboBox1.SelectedIndex.ToString();
            int x = Int32.Parse(index);
            x++;
            cmd.Parameters.Add(new SqlParameter("@fname", SqlDbType.VarChar)).Value = tbfname.Text;
            cmd.Parameters.Add(new SqlParameter("@lname", SqlDbType.VarChar)).Value = tblname.Text;
            cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.VarChar)).Value = tbuser.Text;
            cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar)).Value = tbpass.Text;
            cmd.Parameters.Add(new SqlParameter("@jobid", SqlDbType.VarChar)).Value = x;
            cmd.Parameters.Add(new SqlParameter("@activity", SqlDbType.VarChar)).Value = activity;
            cmd.Parameters.Add(new SqlParameter("@salary", SqlDbType.VarChar)).Value = tbsalary.Text;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = tbemail.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Added Successfully");
                Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (radioactive.Checked)
            {
                activity = "active";
            }
            else if (radiodeactive.Checked)
            {
                activity = "deactive";
            }
            else
            {
                activity = "deactive";
            }
            if (string.IsNullOrEmpty(tbfname.Text))
            {
                MessageBox.Show("please fill all the blanks");
            }
            else if (string.IsNullOrEmpty(tblname.Text))
            {
                MessageBox.Show("please fill all the blanks");
            }
            else if (string.IsNullOrEmpty(tbuser.Text))
            {
                MessageBox.Show("please fill all the blanks");
            }
            else if (string.IsNullOrEmpty(tbpass.Text))
            {
                MessageBox.Show("please fill all the blanks");
            }
            else if (string.IsNullOrEmpty(tbemail.Text))
            {
                MessageBox.Show("please fill all the blanks");
            }
            else if (string.IsNullOrEmpty(tbsalary.Text))
            {
                MessageBox.Show("please fill all the blanks");
            }
            else
            {
                addNewEmployee();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addJobTitle aj = new addJobTitle();
            aj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
