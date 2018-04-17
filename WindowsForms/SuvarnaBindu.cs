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
using AyuRakshaDll;
namespace WindowsFormsApp1
{
    public partial class SuvarnaBindu : Form
    {
        public string SBTransId;
        public SuvarnaBindu()
        {
            InitializeComponent();
        }
        public string str;
        public string str1;
        public void ChkSuvarna()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select SBID from SuvarnaBindu where PId='" + str + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                str1 = dr.GetValue(0).ToString();
            }
            con.Close();
        }
        public void Insert()
        {
            Random r = new Random();
            str1 = "SBID" + r.Next(1, 10000000);
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SuvarnaBindu values('"+str1+"','"+str+"')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Records are inserted for Suvarna BinduPrashan Press Search Once again");
            con.Close();
        }
        public bool Validate1()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter First Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Last Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((textBox3.Text.Length < 10) || (textBox3.Text.Length > 10))
            {
                MessageBox.Show("Length of mobile number should be 10 digits", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (Validate1() != false)
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
                    MessageBox.Show("Patient not Found....", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    button10.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Patient Found....", "Success", MessageBoxButtons.OK);
                    ChkSuvarna();
                    if ((str1 == "") || (str1 == null))
                    {
                        DialogResult res = MessageBox.Show("Patient not Found in Suvarna Bindu Prashan. Do you want to add it","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            Insert();
                        }
                        button10.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Patient record Found in SuvarnaPrashan Click on Next To Proceed","Success");
                        button10.Enabled = true;
                    }
                }
            }
        }
        public string ReturnDob()
        {
            SqlConnection con;
            string dob="";
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select PDob from Patient where PId='" + str + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dob = dr.GetValue(0).ToString();
            }
            return dob;
        }
        public void InsertSBTreat(string sbtreatId,int age)
        {

            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SBTreat values('" + sbtreatId + "','" + str1 + "','"+textBox4.Text+"','"+age+"')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Records are inserted for Suvarna Bindu Prashan Treatment");
            con.Close();
        }
        public void InsertSBPayment(string sbtransId,string sbid,string sbtratid,int amt,string date)
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SBPayment values('"+sbtransId+"','" +sbid+ "','" +sbtratid+ "','" + amt + "','" + date + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Records are inserted for Suvarna Bindu Prashan Treatment");
            con.Close();
        }
        public int Age;
        private void button10_Click(object sender, EventArgs e)
        {
            Age = Class1.CalculateAge(ReturnDob());
            label10.Text = str1;
            label12.Text = str;
            string SBTransId;
            string SBTreatId;
            Random r = new Random();
            Random r1 = new Random();
            SBTransId = "SBTrans" + r.Next(1, 999999999);
            SBTreatId = "SBTreat" + r1.Next(1, 99999999);
            label16.Text = SBTreatId;
            label14.Text= SBTransId;
            textBox5.Text = Convert.ToString(Age);
            panel1.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Date = Convert.ToDateTime(dateTimePicker1.Text.ToString()).ToShortDateString();
            InsertSBTreat(label16.Text, Age);
            InsertSBPayment(SBTransId, str1, label16.Text, Convert.ToInt32(textBox6.Text), Date);
        }
    }
}
