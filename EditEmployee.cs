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
    public partial class EditEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-M9RBD6L\\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        string query;
        public EditEmployee()
        {
            InitializeComponent();
            BindData();

            tbfname.Text = Form1.Emp_fName;
            tblname.Text = Form1.Emp_lName;
            tbsalary.Text = Form1.Emp_salary;
            tbemail.Text = Form1.Emp_email;

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
        private void EditEmployee_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton219_Click(object sender, EventArgs e)
        {
            query = "Edit_Employee";
            cmd = new SqlCommand(query,con);
            cmd.CommandType = CommandType.StoredProcedure;
            string index = comboBox1.SelectedIndex.ToString();
            int x = Int32.Parse(index);
            x++;
            cmd.Parameters.Add(new SqlParameter("@id_", SqlDbType.VarChar)).Value = Form1.Employee_ID;
            cmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.VarChar)).Value = tbfname.Text;
            cmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar)).Value = tblname.Text;
            cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar)).Value = tbpassword.Text;
            cmd.Parameters.Add(new SqlParameter("@jobid", SqlDbType.VarChar)).Value = x;
            cmd.Parameters.Add(new SqlParameter("@salary", SqlDbType.VarChar)).Value = tbsalary.Text;
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = tbemail.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("changed successfully");

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
