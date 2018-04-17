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
    public partial class Treatement : Form
    {
        public string PatID = null;
        public string PatName = null;
        public string Prakruti = null;
        public string TodayDate = "";
        public string PainString = "";
        public string NaadString = "";
        public string TreatId = "";
        public string Gender = "";
        public Treatement(string PatientId,string PatientName,string PrakrutiDharma,string gender)
        {
            
            InitializeComponent();
            Random r = new Random();
            TreatId = "Treat" + r.Next(1, 90000000);
            PatID = PatientId;
            PatName = PatientName;
            Prakruti = PrakrutiDharma;
            label29.Text = PatientName;
            label42.Text = PrakrutiDharma;
            TodayDate= Convert.ToDateTime(DateTime.Now.ToString()).ToShortDateString();
            label37.Text = TodayDate;
            Gender = gender;
            FetchInfo();
        }
        public void FetchInfo()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select Balance, DateOfPayment from PAYMENT where PId='" + PatID + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label38.Text = dr.GetValue(0).ToString();
                label39.Text = dr.GetValue(1).ToString();
            }
        }
        private void Treatement_Load(object sender,EventArgs e)
        {
            if(Gender=="Male")
            {
                textBox20.Text = "NOT APLLICABLE";
                richTextBox4.Text= "NOT APLLICABLE";
                comboBox9.Text = "NOT APLLICABLE";
                panel8.Visible = false;
            }
            button11.Enabled = false;

            comboBox2.Items.Add("Loose Motions");//
            comboBox2.Items.Add("Frequent");//      Mala
            comboBox2.Items.Add("Tight");//


            comboBox3.Items.Add("Frequent");//      Mutra
            comboBox3.Items.Add("Regular");//


            comboBox4.Items.Add("Pa`akRt");//       
            comboBox4.Items.Add("APa`akRt");//         Nidra
            comboBox4.Items.Add("Ait");//


            comboBox5.Items.Add("saama");//     Jiva
            comboBox5.Items.Add("inara");//


            comboBox7.Items.Add("maMd");//
            comboBox7.Items.Add("tIxNa");//     Agni
            comboBox7.Items.Add("sama");//


            comboBox6.Items.Add("vaat ip%t");//
            comboBox6.Items.Add("ip%t vaat");
            comboBox6.Items.Add("ip%t kf");
            comboBox6.Items.Add("kf ip%t");//      Nadi Parikshan
            comboBox6.Items.Add("vaat kf");
            comboBox6.Items.Add("kf vaat");
            comboBox6.Items.Add("sama");//

            comboBox9.Items.Add("inayaimat");  //Masik Pali
            comboBox9.Items.Add("Ainayaimat");//
            label29.Text = PatName;//Patient
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Clear Tratement Deatails
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox9.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            textBox20.Text = "";
            richTextBox4.Text = "";
            richTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // clear Blood Pressure Records
            textBox9.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            richTextBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear sugar records
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            dateTimePicker3.Value = DateTime.Now;
            richTextBox5.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker4.Value = DateTime.Now;
            richTextBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            richTextBox2.Text = "";
        }
        private void PainCheckBox()
        {
            if (checkBox3.Checked == true)
            {
                PainString = PainString + "yakRt/";
            }
            if (checkBox4.Checked == true)
            {
                PainString = PainString + "iPlaha/";
            }
            if (checkBox5.Checked == true)
            {
                PainString = PainString + "Left Kidney/";
            }
            if (checkBox6.Checked == true)
            {
                PainString = PainString + "Right Kidney/";
            }
            if (checkBox7.Checked == true)
            {
                PainString = PainString + "Apat/";
            }
            if (checkBox8.Checked == true)
            {
                PainString = PainString + "Umbilical Region/";
            }

        }
        private void NaadCheckBox()
        {
            if (checkBox1.Checked == true)
            {
                NaadString = NaadString + "yakRt/";
            }
            if (checkBox2.Checked == true)
            {
                NaadString = NaadString + "iPlaha/";
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            ////////////////////////////////
            //
            //  Add Treatement details in database
            //
            /////////////////////////////////
            NaadString = "";
            PainString = "";
            PainCheckBox();
            NaadCheckBox();
            LinkedList1 ll = new LinkedList1();
            ll.Add("Mala", comboBox2.Text);
            ll.Add("Mutra", comboBox3.Text);
            ll.Add("Nidra", comboBox4.Text);
            ll.Add("Jivha", comboBox5.Text);
            ll.Add("Nadi Parikshan", comboBox6.Text);
            ll.Add("Naad", NaadString);
            ll.Add("Pain", PainString);
            ll.Add("Agni", comboBox7.Text);
            ll.Add("Other_Complaints", richTextBox1.Text);
            ll.Add("Masik_Pali_Diwas", textBox20.Text);
            ll.Add("Andamochan", comboBox9.Text);
            ll.Add("Masik_Pali_Other_Complaints", richTextBox4.Text);
            
            Checkup FC = new Checkup(ll, PatID, TodayDate,TreatId);
            FC.SetData();
            FC.Insert();
            MessageBox.Show("Treatement Record stored successfully...!!!");
            button5.Enabled = false;
            button11.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LinkedList1 ll = new LinkedList1();
            string TestDate = Convert.ToDateTime(dateTimePicker2.Text.ToString()).ToShortDateString();
            ll.Add("TopBottomNumber", textBox9.Text);
            ll.Add("TestDate", TestDate);
            ll.Add("Description", richTextBox6.Text);
            BloodPressure BP = new BloodPressure(ll,PatID);
            BP.Insert();
            MessageBox.Show("Blood Pressure Report Updated...!!!");
            
        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            LinkedList1 ll = new LinkedList1();
            string TestDate = Convert.ToDateTime(dateTimePicker4.Text.ToString()).ToShortDateString();
            ll.Add("Type", textBox1.Text);
            ll.Add("TestDate", TestDate);
            ll.Add("Description", richTextBox3.Text);
                OtherReport OR = new OtherReport(ll, PatID);
                OR.Insert();
                MessageBox.Show("Other Report details Updated...!!!");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LinkedList1 ll = new LinkedList1();
            string TestDate = Convert.ToDateTime(dateTimePicker3.Text.ToString()).ToShortDateString();
            ll.Add("BloodFasting", textBox11.Text);
            ll.Add("BloodPP", textBox13.Text);
            ll.Add("BloodR", textBox12.Text);
            ll.Add("UrineR", textBox14.Text);
            ll.Add("TestDate", TestDate);
            ll.Add("Description", richTextBox5.Text);
            Sugar OR = new Sugar(ll, PatID);
            OR.Insert();
            MessageBox.Show("Diabetes Report details inserted...!!!");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string TestDate = Convert.ToDateTime(dateTimePicker1.Text.ToString()).ToShortDateString();
            Surgery SU = new Surgery(textBox15.Text,TestDate,richTextBox2.Text,PatID);
            SU.Insert();
            MessageBox.Show("Surgery details Inserted...!!!");
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AllocateMedicine AM = new AllocateMedicine(PatID, TreatId,Prakruti);
            this.Close();
            AM.Show();
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }
    }
}
