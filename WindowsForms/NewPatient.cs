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
using AyuRakshaDll;
namespace WindowsFormsApp1
{
    
    public partial class NewPatient : Form
    {

        public string Gender = "";
        public string Date;
        public UInt64 Mob;
        public NewPatient()
        {
            InitializeComponent();

        }
        public void ClearRecords()
        {
            textBox1.Text = "";//first Name
            textBox2.Text = "";//Last Name
            if (textBox3.Text != null) textBox3.Text = "";//Age
            textBox5.Text = "";//Mobile
            textBox7.Text = "";//Email
            dateTimePicker1.Value = DateTime.Now;//todays date
            radioButton1.Checked = false;//male
            radioButton2.Checked = false;//female
            richTextBox1.Text = "";//Address
            Gender = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.ClearRecords();
        }
        private void NewPatient_Load(object sender, EventArgs e)
        {

        }
        public bool Validate1()
        {
            int Age = Class1.CalculateAge(dateTimePicker1.Text);//Age

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter First Name","Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Last Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Age", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Age == -1)
            {
                MessageBox.Show("Please Select Correct BirthDate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Gender.Equals("")/*(radioButton1.Checked == false) || (radioButton2.Checked == false)*/)
            {
                MessageBox.Show("Select Gender", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((textBox5.Text.Length < 10) || (textBox5.Text.Length > 10))
            {
                MessageBox.Show("Length of mobile number should be 10 digits", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Validate1() != false)
            {
                Random r = new Random();
                string PID = "Pat" + r.Next(1, 25000);//Patient ID
                Date = Convert.ToDateTime(dateTimePicker1.Text.ToString()).ToShortDateString();//Dob 
                string Prakruti = Class1.PrakrutiDharma(Date);//Prakruti Dharma
                Mob = Convert.ToUInt64(textBox5.Text);
                if ((Gender == "Male") || (Gender == "Female"))
                {
                    Patient PObj = new Patient(PID, textBox1.Text, textBox2.Text, Date, Gender, richTextBox1.Text, Mob, textBox7.Text, Prakruti);
                    Treatement TR = new Treatement(PID, textBox1.Text + " " + textBox2.Text, Prakruti, Gender);
                    PObj.Insert();
                    MessageBox.Show("Records are inserted");
                    TR.Show();
                    this.Close();
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }
        private void button3_Click(object sender, EventArgs e)//Add New Patient
        {
            if (Validate1() != false)
            {
                Random r = new Random();
                string PID = "Pat" + r.Next(1, 25000);//PatientId
                Date = Convert.ToDateTime(dateTimePicker1.Text.ToString()).ToShortDateString();//DOB
                string Prakruti = Class1.PrakrutiDharma(Date);//Prakruti Dharma
                Patient PObj = new Patient(PID, textBox1.Text, textBox2.Text, Date, Gender, richTextBox1.Text, Convert.ToUInt64(textBox5.Text), textBox7.Text, Prakruti);
                PObj.Insert();
                MessageBox.Show("Records are inserted");
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)//Calculate age nd set it into Age text feild
        {
            int Age=Class1.CalculateAge(dateTimePicker1.Text);
            if (Age == -1)
            {
                MessageBox.Show("Please Select Correct BirthDate.");
                textBox3.Text = "";
            }
            else
                textBox3.Text = Convert.ToString(Age);
        }
    }
}
