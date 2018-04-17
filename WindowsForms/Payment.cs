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
    public partial class Payment : Form
    {
        public string PatientId;
        public string TreatId;
        public string TransId;
        public void TreatDate()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();

            string qry = "select MTreatDate from TREATMENT where TreatID='" + TreatId + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string str1 = dr.GetValue(0).ToString();
                label13.Text = str1;

            }
        }
         public void Display1()
         {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            DataSet ds;
            SqlDataAdapter da;
            SqlCommandBuilder bldr;
            da = new SqlDataAdapter("select M.MId from Medicine M,MED_TREAT MT where M.MId=MT.MId and M.MCategory='Ayurvedic' and MT.TreatId='" + TreatId + "'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Medicine"];

            DataSet ds1;
            SqlDataAdapter da1;
            SqlCommandBuilder bldr1;
            da1 = new SqlDataAdapter("select M.MName,M.MType from Medicine M,MED_TREAT MT where M.MId=MT.MId and M.MCategory='Ayurvedic' and MT.TreatId='" + TreatId + "'", con);
            ds1 = new DataSet();
            da1.Fill(ds1, "Medicine");
            bldr1 = new SqlCommandBuilder(da1);

            dataGridView2.DataSource = ds1.Tables["Medicine"];

            con.Close();
        }
        public void Display2()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            DataSet ds;
            SqlDataAdapter da;
            SqlCommandBuilder bldr;
            da = new SqlDataAdapter("select M.MId,M.MName,M.MType from Medicine M,MED_TREAT MT where M.MId=MT.MId and M.MCategory='Alopathic' and MT.TreatId='" + TreatId + "'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            dataGridView3.DataSource = ds.Tables["Medicine"];
            con.Close();

        }
        public string str1;
        public void Balance()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();

            string qry = "select Balance from PAYMENT where PId='" + PatientId + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 str1 = dr.GetValue(0).ToString();
                if ((str1 == null)||(str1==""))
                {
                    str1 = "0";
                    textBox1.Text = "0";
                }
                textBox1.Text = str1;

            }

            con.Close();
        }
        public void Display3()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            DataSet ds;
            SqlDataAdapter da;
            SqlCommandBuilder bldr;
            da = new SqlDataAdapter("select M.MId,M.MName,M.MType from Medicine M,MED_TREAT MT where M.MId=MT.MId and M.MCategory='Others' and MT.TreatId='" + TreatId + "'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            dataGridView4.DataSource = ds.Tables["Medicine"];
            con.Close();
        }
        public Payment(string patid,string treatid)
        {
            InitializeComponent();
            this.dataGridView2.DefaultCellStyle.Font = new Font("Shivaji01", 18);
            PatientId = patid;
            TreatId = treatid;
            Random r = new Random();
            TransId = "Trans" + r.Next(1, 99999999);
            label10.Text = PatientId;
            label11.Text = TreatId;
            label12.Text = TransId;
            Display1();
            Display2();
            Display3();
            TreatDate();
            Balance();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            int Amount=Convert.ToInt32(textBox2.Text);
            int NowPay= Convert.ToInt32(textBox3.Text); ;
            int Balance=Amount-NowPay+Convert.ToInt32(str1);
            string Date = Convert.ToDateTime(DateTime.Now.ToString()).ToShortDateString(); 
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PAYMENT values('" + TransId + "','" + PatientId + "','" + TreatId + "','" + Amount + "','"+NowPay+"','"+Balance+"','"+Date+"','"+richTextBox1.Text+"')", con);
            MessageBox.Show("Payment Details are updated....");
            button1.Enabled = false;
            cmd.ExecuteNonQuery();
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            int Amount = Convert.ToInt32(textBox2.Text);
            int NowPay = Convert.ToInt32(textBox3.Text); ;
            int Balance = Amount - NowPay + Convert.ToInt32(str1);
            
            textBox4.Text = Convert.ToString(Balance);
        }
        
    }
}
