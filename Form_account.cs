﻿using System;
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
    public partial class Form_account : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-M9RBD6L\\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        string query;
        string id;
        string fname;
        string lname;
        public Form_account()
        {
            InitializeComponent();
            BindData();

            tbid.Text = Form1.Account_ID_;
            tbfname.Text = Form1.First_Name_;
            tblname.Text = Form1.Last_Name_;
        }
        public void BindData()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-M9RBD6L\SSQL;Initial Catalog=BAM_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            query = "select id,CurrencyType from tblCurrency";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("CurrencyType", typeof(string));
            dt.Load(reader);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "CurrencyType";
            comboBox1.DataSource = dt;
            con.Close();
        }
        public int accountNo()
        {
            Random rnd = new Random();
            int accountno = rnd.Next(15000, 500000);
            return accountno;
        }
        public int Iban()
        {
            Random rnd = new Random();
            int iban = rnd.Next(25000, 5005000);
            return iban;
        }

        public void checkid()
        {
            id = tbid.Text.Trim();
            lname = tblname.Text.Trim();
            fname = tbfname.Text.Trim();
            string balance = tbbalance.Text.Trim();
            string index = comboBox1.SelectedIndex.ToString();
            int x = Int32.Parse(index);
            x++;
            query = "select * from tblCustomer where ID ='" + id + "' and firstname ='" + fname + "' and lastname = '" + lname + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count > 0)
            {

                string sql_query = "AddAccount";
                /*query = @"insert into[dbo].[tblAccount]
                ([ID_], [AccountNo], [Iban], [CurrencyID]
                     , [Balance],[firstname],[lastname])
                     values('" + id + "','" + accountNo() + "','" + Iban() + "','" + x + "','" + balance + "','" + tbfname.Text + "','" + lname + "')";*/
                cmd = new SqlCommand(sql_query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = id;
                cmd.Parameters.Add(new SqlParameter("@accountno", SqlDbType.VarChar)).Value = accountNo();
                cmd.Parameters.Add(new SqlParameter("@iban", SqlDbType.VarChar)).Value = Iban();
                cmd.Parameters.Add(new SqlParameter("@currencyid", SqlDbType.VarChar)).Value = x;
                cmd.Parameters.Add(new SqlParameter("@balance", SqlDbType.VarChar)).Value = balance;
                cmd.Parameters.Add(new SqlParameter("@firstname", SqlDbType.VarChar)).Value = fname;
                cmd.Parameters.Add(new SqlParameter("@lastname", SqlDbType.VarChar)).Value = lname;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("the new account added succesfully");
                }
                catch (Exception ex5)
                {
                    MessageBox.Show(ex5.Message);
                }
            }
            else
            {
                MessageBox.Show("the ID or lastname is noncorrect");
            }
        }

        private void Form_account_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCurrency curr = new addCurrency();
            curr.Show();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            checkid();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
