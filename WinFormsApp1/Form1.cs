using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insertRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Employee_profitSum;Integrated Security=True");

        private void Insert_Click(object sender, EventArgs e)
        {
           
                
                string empname = cmbName.Text;
                string empyear = cmbYear.Text;
                int empprofit = int.Parse(txtProfit.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("exec Insert_Emp '" + empname + "','" + empyear + "','" + empprofit + "'", con);
                cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully inserted.....!");
            con.Close();
            }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GetProfit();
        }

       
        void GetProfit()
        {
            SqlCommand cmd = new SqlCommand("exec Sum_Emp_Profit ", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataDisplay.DataSource = dt;
        }
    }
    }
