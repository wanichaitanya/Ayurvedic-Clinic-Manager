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
    public partial class Medicines : Form
    {
        public string Category = null;
        public string MedicinID = null;
        public Medicines()
        {
            InitializeComponent();
        }

        private void Medicines_Load(object sender, EventArgs e)
        {
            //Ayurvedic Medicines Type 
            comboBox1.Items.Clear();
            comboBox1.Items.Add("caUNa-");
            comboBox1.Items.Add("kaZa");
            comboBox1.Items.Add("vaTI");
            comboBox1.Items.Add("tola");
            comboBox1.Items.Add("laop");
            comboBox1.Items.Add("klp");
            comboBox1.Items.Add("[-tr");
            //Alopathic Medicines Type
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Tablet");
            comboBox2.Items.Add("Capsule");
            comboBox2.Items.Add("Granules");
            comboBox2.Items.Add("Syrup");
            comboBox2.Items.Add("Ointment");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            comboBox1.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            comboBox2.Text = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while((textBox1.Text == "")&&(comboBox1.Text==""))
            {
                MessageBox.Show(" * fields are mandetory...!!!");
                return;
            }
            Category = "Ayurvedic";
            Random r = new Random();
            MedicinID = "Med" + r.Next(1, 15000);
            MedicineInfo MInfo = new MedicineInfo(MedicinID, textBox1.Text,comboBox1.Text,Category);
            MInfo.Insert();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while ((textBox2.Text == "") && (comboBox2.Text == ""))
            {
                MessageBox.Show(" * fields are mandetory...!!!");
                return;
            }
            Category = "Alopathic";
            Random r = new Random();
            MedicinID = "Med" + r.Next(1, 15000);
            MedicineInfo MInfo = new MedicineInfo(MedicinID, textBox2.Text, comboBox2.Text, Category);
            MInfo.Insert();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            while ((textBox3.Text == "") && (textBox4.Text == ""))
            {
                MessageBox.Show(" * fields are mandetory...!!!");
                return;
            }
            Category = "Others";
            Random r = new Random();
            MedicinID = "Med" + r.Next(1, 15000);
            MedicineInfo MInfo = new MedicineInfo(MedicinID, textBox3.Text, textBox4.Text, Category);
            MInfo.Insert();
        
        }
        
    }
    public partial class MedicineInfo
    {
        public string MedId = null;
        public string MedName = null;
        public string MedType = null;
        public string MedCate = null;
        public MedicineInfo(string mid, string mname, string mtype, string mcate)
        {
            MedId = mid;
            MedName = mname;
            MedType = mtype;
            MedCate = mcate;
            
        }
        public void Insert()
        {
            ////////////////////////////////////////////////////////////////
            //  Name:        Insert
            //  Input:       N/A
            //  Output:      N/A
            //  Description: It is used to insert records
            //               of medicines into Medicine table of ClientDB 
            ////////////////////////////////////////////////////////////////
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Medicine values('" + MedId + "','" + MedName + "','" + MedCate + "','" + MedType + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medicines are inserted");
        }
        

    }

}
