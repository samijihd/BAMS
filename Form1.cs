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
        public float AccBalance;
        public float amount;
        public float ReciverBalance;

        string queryEmployee = " select ID_,Firstname,Lastname,Username,JobTitle,Activity,Salary,Email" +
                               " from tblEmployee" +
                               " INNER JOIN tblJobTitle" +
                               " ON tblEmployee.Job_ID = tblJobTitle.id";


        string queryAcc =  " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id";

        public static string Employee_ID ;
        public string Client_ID;
        public string Account_ID;
        public string Account_NO;
        public string First_Name;
        public string Last_Name;
        public string second="";
        public string type = "";
        string Amount;

        public static string Emp_fName;
        public static string Emp_lName;
        public static string Emp_password;
        public static string Emp_salary;
        public static string Emp_email;




        public Form1()
        {
            InitializeComponent();
            MoveSidePanel(btn2);
            MoveSidePanel(btn3);
            MoveSidePanel(btn4);
            MoveSidePanel(btn5);
            MoveSidePanel(btn6);
            MoveSidePanel(btnDashboard);
            label4.Text = DateTime.Now.ToString();
            label2.Text = Login.user;
            hidepanels();
            
        }
        private void hidepanels()
        {
            panel10.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;
        }

        public void AddProcess()
        {
            
            string query_P = "AddProcess";
            cmd = new SqlCommand(query_P,con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@first", SqlDbType.VarChar)).Value = First_Name+" "+Last_Name;
            cmd.Parameters.Add(new SqlParameter("@second", SqlDbType.VarChar)).Value = second;
            cmd.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar)).Value = type;
            cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = DateTime.Now.ToString();
            cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.VarChar)).Value = DateTime.Now.ToString();
            cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.VarChar)).Value = Amount;

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

        }

        public void DisplayProcess()
        {
            string query_p = "select * from tblProcesses";
            try
            {
                con.Open();
                adpt = new SqlDataAdapter(query_p, con);
                dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {
            //panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {
//panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
           // panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox4_OnValueChanged(object sender, EventArgs e)
        {
           // panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuMetroTextbox5_OnValueChanged(object sender, EventArgs e)
        {
           // panel1.AutoScrollPosition = new Point(0, 650);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           // panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
           // panel1.AutoScrollPosition = new Point(0, 650);
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btnDashboard);
            hidepanels();
           // panel10.Visible = true;
           // panel6.Visible = true;
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
            panel3.Visible = true;
            query = "select * from tblCustomer";
            showdata();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn3);
            hidepanels();
            panel10.Visible = true;
            showAccount();
            DisplayProcess();
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
            Account aaa = new Account();
            this.Hide();
            aaa.Show();
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
        private void btn6_Click(object sender, EventArgs e)
        {
            MoveSidePanel(btn6);
            hidepanels();
            panel6.Visible = true;
            BindData();
            DisplayEmployee();
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
            //panel1.AutoScrollPosition = new Point(0, 1100);
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
           // panel1.AutoScrollPosition = new Point(0, 1100);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            //panel1.AutoScrollPosition = new Point(0, 1100);
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

        public void checkBalance()
        {
            string strBalance = "";
            string stramt = tbamount.Text.Trim();
            Amount = tbamount.Text.Trim();
            string sql_Query = "select Balance from tblAccount where ID_ = '"+Account_ID+"' and AccountNo = '"+Account_NO+"'";
            cmd = new SqlCommand(sql_Query,con);

            if (string.IsNullOrEmpty(Account_ID) || string.IsNullOrEmpty(tbamount.Text))
            {
                MessageBox.Show("Please Select an Account to start checking");
                Account_ID = "";
            }
            else
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    strBalance = reader["Balance"].ToString();
                }

                amount = float.Parse(stramt);
                AccBalance = float.Parse(strBalance);

                if (amount > AccBalance)
                {
                    MessageBox.Show("sorry your balance is not enough");
                }
                else
                {
                    MessageBox.Show("Your Balance is enough... YOU CAN TRANSFER THIS AMOUNT");
                }
                con.Close();
            }
        }
        public void Send()
        {
            string query_Send = "UPDATE tblAccount set Balance = '"+(AccBalance - amount)+"' where AccountNo = '"+tbsaccountno.Text+"' and Iban = '"+tbsiban.Text+"'";
            //query_Send += "update tblAccount set Balance = '"+()+"'";
            cmd = new SqlCommand(query_Send,con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the Process is completed");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void getReceive_Balance()
        {
            string strBalance = "";

            string query_receive = "select Balance from tblAccount where AccountNo ='" + tbraccountno.Text + "' and Iban ='" + tbriban.Text + "'";
            cmd = new SqlCommand(query_receive,con);

            if(string.IsNullOrEmpty(tbraccountno.Text) || string.IsNullOrEmpty(tbriban.Text))
            {
                MessageBox.Show("please Enter the account Number ");
            }
            else
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    strBalance = reader["Balance"].ToString();
                }
                ReciverBalance = float.Parse(strBalance);
                con.Close();
            }
        }

        public void Receive()
        {
            string query_receive = "update tblaccount set Balance ='" + (ReciverBalance + amount) + "' where AccountNo = '" + tbraccountno.Text + "' and Iban = '" + tbriban.Text + "'";
            cmd = new SqlCommand(query_receive,con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the mission complete");
                Account_ID = "";
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            //submit
            checkBalance();
            if (amount < AccBalance)
            {
                Send();
                getReceive_Balance();
                Receive();
                showAccount();

                type = "Transfer money";
                second = tbraccountno.Text.Trim();

                AddProcess();
                DisplayProcess();
            }
        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            
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
            string SqlClient = "Delete from tblCustomer where ID ='"+Client_ID+"'";

            cmd = new SqlCommand(SqlClient,con);

            if (string.IsNullOrEmpty(Client_ID))
            {
                MessageBox.Show("Select a profile to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully");
                }
                catch(Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                showdata();
            }
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            panel10.AutoScrollPosition = new Point(0, 190);
        }

        float AccBalanceD;
        public void Deposite1()
        {

            string strBalance = "";
            string stramt = tbamount.Text.Trim();
            string sql_Query = "select Balance from tblAccount where ID_ = '" + Account_ID + "' and AccountNo ='" + Account_NO + "'";
            cmd = new SqlCommand(sql_Query, con);

            if (string.IsNullOrEmpty(Account_ID) || string.IsNullOrEmpty(tbamount.Text))
            {
                MessageBox.Show("Please Select an Account to start checking");
                
            }
            else
            {
                Amount = tbamount.Text.Trim();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    strBalance = reader["Balance"].ToString();
                }

                amount = float.Parse(stramt);
                AccBalanceD = float.Parse(strBalance);
                con.Close();
                Deposite2();
            }
        }
         
        public void Deposite2()
        {
            string query_receive = "update tblaccount set Balance ='" + (AccBalanceD + amount) + "' where ID_ = '"+Account_ID+"' and AccountNo ='"+Account_NO+"'";
            cmd = new SqlCommand(query_receive, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the mission complete");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            Account_ID = "";
            Account_NO = "";
            tbamount.Text = "";
            AccBalanceD = 0;
            
            amount = 0;

        }
        private void bunifuThinButton28_Click_1(object sender, EventArgs e)
        {
            //deposite
            if (string.IsNullOrEmpty(tbamount.Text))
            {
                MessageBox.Show("please enter a vailed amount value!");
            }
            else
            {
                Deposite1();
                showAccount();

                second = "-";
                type = "Deposite";
                AddProcess();
                DisplayProcess();
            }
            
        }

        float AccBalanceW;
        public void Withdraw1()
        {
            string strBalance = "";
            string stramt = tbamount.Text.Trim();
            string sql_Query = "select Balance from tblAccount where ID_ = '" + Account_ID + "' and AccountNo ='" + Account_NO + "'";
            cmd = new SqlCommand(sql_Query, con);

            if (string.IsNullOrEmpty(Account_ID) || string.IsNullOrEmpty(tbamount.Text))
            {
                MessageBox.Show("Please Select an Account to start checking");
                Account_ID = "";
            }
            else
            {
                Amount = tbamount.Text.Trim();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    strBalance = reader["Balance"].ToString();
                }

                amount = float.Parse(stramt);
                AccBalanceW = float.Parse(strBalance);
                con.Close();
                Withdraw2();
            }
        }
        public void Withdraw2()
        {
            string query_ = "update tblaccount set Balance ='" + (AccBalanceW - amount) + "' where ID_ = '" + Account_ID + "' and AccountNo ='" + Account_NO + "'";
            cmd = new SqlCommand(query_, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("the mission complete");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            Account_ID = "";
            Account_NO = "";
            AccBalanceW = 0;
            amount = 0;
            tbamount.Text = "";
        }
        private void bunifuThinButton26_Click_2(object sender, EventArgs e)
        {
            //withdraw

            if (string.IsNullOrEmpty(tbamount.Text))
            {
                MessageBox.Show("please enter a vailed amount value!");
            }
            else
            {
                Withdraw1();
                showAccount();

                type = "withdraw";
                second = " ";

                AddProcess();
                DisplayProcess();
            }
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        public void DisplayEmployee()
        {
             try
            { 
              con.Open();
              adpt = new SqlDataAdapter(queryEmployee, con);
              dt = new DataTable();
              adpt.Fill(dt);
              datagridEmployee.DataSource = dt;
              con.Close();
            }
            catch (Exception exew)
            {
                MessageBox.Show("failed to show data make sure that you are connected to the server, please try again !");
            }
        } 

        private void bunifuThinButton212_Click_1(object sender, EventArgs e)
        {
            //refresh
            queryEmployee = " select ID_,Firstname,Lastname,Username,JobTitle,Activity,Salary,Email" +
                               " from tblEmployee" +
                               " INNER JOIN tblJobTitle" +
                               " ON tblEmployee.Job_ID = tblJobTitle.id";
            DisplayEmployee();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            newEmployee ne = new newEmployee();
            ne.Show();
        }

        private void panel6_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addJobTitle aj = new addJobTitle();
            aj.Show();
        }

        private void bunifuThinButton221_Click(object sender, EventArgs e)
        {
            if (radioactive.Checked)
            {
                queryEmployee = " select ID_,Firstname,Lastname,Username,JobTitle,Activity,Salary,Email" +
                               " from tblEmployee" +
                               " INNER JOIN tblJobTitle" +
                               " ON tblEmployee.Job_ID = tblJobTitle.id" +
                               " Where Activity = 'active' ";
                DisplayEmployee();
            }
            else if (radiodeactvie.Checked)
            {
                queryEmployee = " select ID_,Firstname,Lastname,Username,JobTitle,Activity,Salary,Email" +
                               " from tblEmployee" +
                               " INNER JOIN tblJobTitle" +
                               " ON tblEmployee.Job_ID = tblJobTitle.id" +
                               " Where Activity = 'deactive' ";
                DisplayEmployee();
            }
            else
            {
                MessageBox.Show("please select one selection to start searching ");
            }
        }

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {
            //search textbox

            queryEmployee = " select ID_,Firstname,Lastname,Username,JobTitle,Activity,Salary,Email" +
                               " from tblEmployee" +
                               " INNER JOIN tblJobTitle" +
                               " ON tblEmployee.Job_ID = tblJobTitle.id"+
                               " WHERE ID_ like '"+tbsearchEmployee.Text+"%' or Firstname like '"+tbsearchEmployee.Text+"%'  or Lastname like '"+tbsearchEmployee.Text+"%' or Username like '"+tbsearchEmployee.Text+"'";
            DisplayEmployee();
        }

        private void bunifuThinButton222_Click(object sender, EventArgs e)
        {
            string index = comboBox1.SelectedIndex.ToString();
            int x = Int32.Parse(index);
            x++;
            queryEmployee = " select ID_,Firstname,Lastname,Username,JobTitle,Activity,Salary,Email" +
                               " from tblEmployee" +
                               " INNER JOIN tblJobTitle" +
                               " ON tblEmployee.Job_ID = tblJobTitle.id" +
                               " where tblJobTitle.id = '"+x+"'";
            DisplayEmployee();
        }

        private void bunifuThinButton218_Click(object sender, EventArgs e)
        {
            //delete from Employee
            string sqlEmployee = "Delete from tblEmployee where ID_ = '"+Employee_ID+"'";
            cmd = new SqlCommand(sqlEmployee,con);

            if (string.IsNullOrEmpty(Employee_ID))
            {
                MessageBox.Show("Select a profile to DELETE");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully");
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
                DisplayEmployee();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        /*
         * ********************************   ***********
         * *******************************   ************
         * *******************************   *************
         * ***************                   **************  
         * ***************                   ***************                
         * ***************                   ****************            *******
         * *******************************   *****************          **********
         * *******************************   *********  *******        ******* 
         * *******************************   *********   *******      *******
         * ***************                   *********    *******    *******
         * ***************                   *********     *******  *******
         * ***************                   *********      **************
         * *******************************   *********       ************
         * *******************************   *********        **********
         * *******************************   *********         ********
        
             */

        private void datagridEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = datagridEmployee.Rows[index];
                tbsearchEmployee.Text = selectedRow.Cells["ID_"].Value.ToString();
            }*/
    }

    private void datagridEmployee_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            if(index >= 0)
            {
                DataGridViewRow selectedRow = datagridEmployee.Rows[index];
                Employee_ID = selectedRow.Cells["ID_"].Value.ToString();
                Emp_fName = selectedRow.Cells["Firstname"].Value.ToString();
                Emp_lName = selectedRow.Cells["Lastname"].Value.ToString();
                Emp_salary = selectedRow.Cells["Salary"].Value.ToString();
                Emp_email = selectedRow.Cells["Email"].Value.ToString();
            }            
        }

        private void bunifuThinButton220_Click(object sender, EventArgs e)
        {
            string sql = "update tblEmployee set Activity = 'deactive' where ID_ = '"+Employee_ID+"'";
            cmd = new SqlCommand(sql,con);
            if (string.IsNullOrEmpty(Employee_ID))
            {
                MessageBox.Show("Select a profile to DEACTIVE");
            }
            else
            {

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Changed Successfully");
            }
            catch(Exception exee)
            {
                MessageBox.Show(exee.Message);
            }
            DisplayEmployee();

            }
            
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            query = "select * from tblCustomer where firstname like '" + tbsearch.Text + "%' or ID like '" + tbsearch.Text + "%' ";
            showdata();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = gridview.Rows[index];
                Client_ID = selectedRow.Cells["ID"].Value.ToString();
            }
        }
        public void showAccount()
        {
            try
            {
                con.Open();
                adpt = new SqlDataAdapter(queryAcc, con);
                dt = new DataTable();
                adpt.Fill(dt);
                dataAccount.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuThinButton213_Click_1(object sender, EventArgs e)
        {
            queryAcc = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id";

            showAccount();
        }

        private void bunifuThinButton211_Click_1(object sender, EventArgs e)
        {
            queryAcc = " SELECT ID_,AccountNo,Iban,CurrencyType,Balance,firstname,lastname" +
                       " FROM tblAccount " +
                       " INNER JOIN tblCurrency" +
                       " ON tblAccount.CurrencyID = tblCurrency.id" +
                       " where ID_ like '" + tbsearchAccount.Text + "%' or firstname like '" + tbsearchAccount.Text + "%' or AccountNo like '" + tbsearchAccount.Text + "%' or Iban like '" + tbsearchAccount.Text + "%' ";

            showAccount();
        }

        private void dataAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = dataAccount.Rows[index];
                Account_ID = selectedRow.Cells["ID_"].Value.ToString();
                Account_NO = selectedRow.Cells["AccountNo"].Value.ToString();
                First_Name = selectedRow.Cells["firstname"].Value.ToString();
                Last_Name = selectedRow.Cells["lastname"].Value.ToString();
                tbsaccountno.Text = selectedRow.Cells["AccountNo"].Value.ToString();
                tbsiban.Text = selectedRow.Cells["Iban"].Value.ToString();
            }
        }

        private void bunifuThinButton214_Click_1(object sender, EventArgs e)
        {
            checkBalance();
        }

        private void dataAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton219_Click(object sender, EventArgs e)
        {
            string sql = "update tblEmployee set Activity = 'active' where ID_ = '" + Employee_ID + "'";
            cmd = new SqlCommand(sql, con);
            if (string.IsNullOrEmpty(Employee_ID))
            {
                MessageBox.Show("Select a profile to ACTIVATION");
            }
            else
            {

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Changed Successfully");
                }
                catch (Exception exee)
                {
                    MessageBox.Show(exee.Message);
                }
                DisplayEmployee();

            }
        }

        private void bunifuThinButton217_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Employee_ID) && string.IsNullOrEmpty(Emp_fName))
            {
                MessageBox.Show("please select a row to edit");
            }
            else
            {
                EditEmployee ee = new EditEmployee();
                ee.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
