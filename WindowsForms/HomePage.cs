using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class HomePage : Form
    {
        NewPatient NP;
        Medicines Med;
        public HomePage()
        {
            InitializeComponent();
        }

         private void HomePage_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;
            foreach(Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch(InvalidCastException exc)
                {

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(NP==null)
            {
                if (Med != null)
                {
                    Med.Close();
                }
                NP = new NewPatient();
                NP.MdiParent = this;
                NP.FormClosed += new FormClosedEventHandler(NP_FormClosed);
                NP.Show();
            }
            else
            {
                NP.Activate();
            }
        }

        private void NP_FormClosed(object sender, FormClosedEventArgs e)
        {
            NP = null;
            //throw new NotImplementedException();
        }

       
        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Med == null)
            {
                if(NP!=null) NP.Close();
                Med = new Medicines();
                Med.MdiParent = this;
                Med.FormClosed += new FormClosedEventHandler(TR_FormClosed);
                Med.Show();
            }
            else
            {
                Med.Activate();
            }
        }

        private void TR_FormClosed(object sender, FormClosedEventArgs e)
        {
            Med = null;
           // throw new NotImplementedException();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            NewPatient NP = new NewPatient();
            NP.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(panel5.Visible == true)
            {
                panel5.Visible = false;
            }
            else if(panel5.Visible ==false)
            {
                panel5.Visible = true;
            }
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
                string qry = "select PId,PDob,PGender,PPrakruti from Patient where PFirstName='" + textBox1.Text + "' and PLastName='" + textBox2.Text + "' and PMob='" + Convert.ToUInt64(textBox3.Text) + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string str = dr.GetValue(0).ToString();
                    string str1 = dr.GetValue(1).ToString();
                    string str2 = dr.GetValue(2).ToString();
                    string str3 = dr.GetValue(3).ToString();
                    textBox4.Text = str;
                    textBox5.Text = str1;
                    textBox6.Text = str2;
                    textBox7.Text = str3;

                }
                if ((textBox4.Text == "") || (textBox4.Text == null))
                {
                    MessageBox.Show("Patient Record Not Found.....", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    button10.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Patient Record found press START TREATMENT to proceed furthur.", "Success", MessageBoxButtons.OK);
                    button10.Enabled = true;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Treatement TR = new Treatement(textBox4.Text, textBox1.Text + " " + textBox2.Text,textBox7.Text,textBox6.Text);
            TR.Show();
            panel5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Medicines M = new Medicines();
            M.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewMedicine vm = new viewMedicine();
            vm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            viewPatient vp = new viewPatient();
            vp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdatePatient UP = new UpdatePatient();
            UP.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PaymentDetails PD = new PaymentDetails();
            PD.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SuvarnaBindu SB = new SuvarnaBindu();
            SB.Show();
        }
    }
}
