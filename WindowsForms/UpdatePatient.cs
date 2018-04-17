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
    public partial class UpdatePatient : Form
    {
        public string Spid;
        public string str1, str2, str3;
        public UpdatePatient()
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
                Spid = dr.GetValue(0).ToString();
            }
            if ((Spid == "") || (Spid == null))
            {
                MessageBox.Show("Patient Record Not Found.....", "Error", MessageBoxButtons.OK);
                button10.Enabled = false;
            }
            else
            {
                MessageBox.Show("Patient Record found press START Updation to proceed furthur.", "Success", MessageBoxButtons.OK);
                button10.Enabled = true;
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            radioButton1.Text = "Male";
            radioButton2.Text = "Female";
            panel1.Visible = true;
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select * from Patient where PId='"+ Spid + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                textBox4.Text = dr.GetValue(0).ToString();//PID
                textBox5.Text= dr.GetValue(1).ToString();//FNAME
                textBox6.Text = dr.GetValue(2).ToString();//LNAME
                if(dr.GetValue(3).ToString()=="Male")
                {
                    radioButton1.Checked = true;//GENDER
                }
                else
                {
                    radioButton2.Checked = true;//GENDER
                }
                richTextBox1.Text = str3 = dr.GetValue(4).ToString();//ADDR
                textBox9.Text = str1=dr.GetValue(5).ToString();//Mob
                textBox10.Text = str2=dr.GetValue(6).ToString();//Email
                textBox7.Text = dr.GetValue(7).ToString();//DOB
                textBox8.Text = dr.GetValue(8).ToString();//Prakruti dharma
            }
            if(radioButton1.Checked==true)
            {
                textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = radioButton1.Enabled = radioButton2.Enabled = textBox7.Enabled = textBox8.Enabled = false;
            }
            if(radioButton2.Checked==true)
            {
                textBox4.Enabled = radioButton1.Enabled = radioButton2.Enabled = textBox7.Enabled = textBox8.Enabled = false;
            }
            con.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to change previous values", "Alert", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                textBox9.Text = "";
                textBox10.Text = "";
                richTextBox1.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if((str1!=textBox9.Text)||(str2!=textBox10.Text)||(str3!=richTextBox1.Text))
            {
                DialogResult res = MessageBox.Show("Do you really want to change previous values", "Alert", MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes)
                {
                    Patient P = new Patient(Spid,textBox5.Text,textBox6.Text,"","",richTextBox1.Text, Convert.ToUInt64(textBox9.Text),textBox10.Text,"");
                    P.update();
                }
            }
        }
    }
}
