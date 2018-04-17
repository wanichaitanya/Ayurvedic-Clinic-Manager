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
using System.Configuration;
namespace WindowsFormsApp1
{
    public partial class PaymentDetails : Form
    {
        public string str;
        public PaymentDetails()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select PId from Patient where PFirstName='" + textBox1.Text + "' and PLastName='" + textBox2.Text + "' and PMob='" + Convert.ToUInt64(textBox3.Text) + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                str = dr.GetValue(0).ToString();
            }
            if ((str == "") || (str == null))
            {
                MessageBox.Show("Patient Record Not Found.....", "Error", MessageBoxButtons.OK);
                button10.Enabled = false;
            }
            else
            {
                MessageBox.Show("Patient Record found click on Check Payment Details to proceed furthur.", "Success", MessageBoxButtons.OK);
                button10.Enabled = true;
            }
        }

        public void setData()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select PId,PFirstName,PLastName,PEmail,PMob from Patient where PId='" + str + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label10.Text = dr.GetValue(0).ToString();
                label9.Text = dr.GetValue(1).ToString()+" "+ dr.GetValue(2).ToString();
                label11.Text = dr.GetValue(3).ToString();
                label12.Text = dr.GetValue(4).ToString();
            }

        }
        private void button10_Click(object sender, EventArgs e)
        {
            setData();
            panel1.Visible = true;
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            DataSet ds;
            SqlDataAdapter da;
            SqlCommandBuilder bldr;
            da = new SqlDataAdapter("select TransID as TransactionID,TratID as TreatmentID,Amount,NowPay as Paid_Amount,Balance,DateOfPayment as Date,PayDescp as Description from PAYMENT where PId='"+str+"'", con);
            ds = new DataSet();
            da.Fill(ds, "PAYMENT");
            bldr = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["PAYMENT"];
            con.Close();
        }
    }
}
