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
    }
}
