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
    public partial class AllocateMedicine : Form
    {
        public string PatientId;
        public string TreatmentId;
        public string Gender;
        public string MedType = "";
        public AllocateMedicine(string PatId,string TreatId,string Prakruti)
        {   /////////////////////////////////////
            //
            //on the constructor call prakruti dharma and medicine is selected
            //
            //
            //////////////////////////////////////
            InitializeComponent();
            textBox3.Text = Prakruti;
            PatientId = PatId;
            TreatmentId = TreatId;
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            if (Prakruti == "?tusaMQaIkaL")
            {
                label10.Visible = true;
            }
            else
            {
                string qry = "select MName from PrakrutiDharma where PrakrutiDharma = '" + Prakruti + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string str1 = dr.GetValue(0).ToString();
                    comboBox5.Items.Add(str1);
                }
                dr.Close();
            }
        }
        private void AllocateMedicine_Load(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////
            //
            //on page load function
            //font style for data greidview 1 is set to shivaji
            //other medicine types are loaded in combobox 3
            //
            //
            /////////////////////////////////////////////// for Other Medicine Type
            this.dataGridView1.DefaultCellStyle.Font = new Font("Shivaji01", 18);
            
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select MType from Medicine where MCategory='Others' group by MType";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string str = dr.GetValue(0).ToString();
                comboBox3.Items.Add(str);
            }
        }
        public LinkedList1 AddComboBox(string str)
        {
            ///////////////////////////////////
            //
            //on this function call mid and mname according to input ie mtype
            //are loaded into linkedlist and it returns the linked list
            //
            //
            /////////////////////////////////
            LinkedList1 ll1 = new LinkedList1();
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select MId,MName from Medicine where MType='" + str + "'";
            SqlCommand cmd = new SqlCommand(qry, con); 
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string str1 = dr.GetValue(0).ToString();
                string str2= dr.GetValue(1).ToString();
                ll1.Add(str1,str2);
            }
            return ll1;
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /////////////////////////////////////////
            //
            // on click of radio button 1 combobox1 loaded with med with radio button value
            //
            ////////////////////////////////////////////////////// for churna
            MedType = radioButton1.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox(radioButton1.Text);
            Node Temp = ll2.Head;
            while(Temp!=null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)
            //////////////////////////////////////////////////////// for Kadha
            MedType = radioButton2.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox(radioButton2.Text);
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ////////////////////////////////////////////////////// for Vati
            MedType = radioButton3.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("vaTI");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ///////////////////////////////////////////// for Tel
            MedType = radioButton4.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("tola");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ////////////////////////////////////////////////// for Lep
            MedType = radioButton5.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("laop");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ////////////////////////////////////////////////// for kalpa
            MedType = radioButton6.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("klp");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ///////////////////////////////////////////////// for iter ayurvedic Medicine
            MedType = radioButton7.Text;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("[-tr");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox1.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }
        
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ///////////////////////////////////////////////// For Tablet
            MedType = radioButton14.Text;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("Tablet");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox2.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ////////////////////////////////////////////// For  Capsule
            MedType = radioButton8.Text;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("Capsule");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox2.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            ////////////////////////////////////////////////// for  syrup
            MedType = radioButton9.Text;
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("Syrup");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox2.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            /////////////////////////////////////////////////  Granules
            MedType = radioButton10.Text;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("Granules");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox2.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            //////////////////////////////////////////////////// ointment
            MedType = radioButton11.Text;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            LinkedList1 ll2 = new LinkedList1();
            ll2 = AddComboBox("Ointment");
            Node Temp = ll2.Head;
            while (Temp != null)
            {
                
                comboBox2.Items.Add(Temp.Value);
                Temp = Temp.next;
            }
        }

        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // same work like radiobutton1.......(*)

            //////////////////////////////////////////////////// for  other Medicine Name
            MedType = comboBox3.Text;
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select MId,MName from Medicine where MType='"+comboBox3.Text+"'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string str = dr.GetValue(0).ToString();
                string str1 = dr.GetValue(1).ToString();
                comboBox4.Items.Add(str1);
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            comboBox1.Text = "";
            textBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton14.Checked = false;
            checkBox5.Checked = false;
            checkBox4.Checked = false;
            checkBox6.Checked = false;
            comboBox2.Text="";
            textBox2.Text = "";

        }

        public string dosage = "";
        public void Ayurvedic()
        {
            if (checkBox1.Checked == true)
            {
                dosage = dosage + "_" + checkBox1.Text;
            }
            if (checkBox2.Checked == true)
            {
                dosage = dosage + "_" + checkBox2.Text;
            }
            if (checkBox3.Checked == true)
            {
                dosage = dosage + "_" + checkBox3.Text;
            }
        }
        public string dosage1 = "";
        public void Alopathic()
        {
            if (checkBox4.Checked == true)
            {
                dosage1 = dosage1 + "_" + checkBox4.Text;
            }
            if (checkBox5.Checked == true)
            {
                dosage1 = dosage1 + "_" + checkBox5.Text;
            }
            if (checkBox6.Checked == true)
            {
                dosage1 = dosage1 + "_" + checkBox6.Text;
            }
        }
        public void Display1(string str1)
        { 
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            DataSet ds;
            SqlDataAdapter da;
            SqlCommandBuilder bldr;
            da = new SqlDataAdapter("select M.MName,MType from Medicine M,MED_TREAT MT where M.MId=MT.MId and M.MCategory='" + str1+"' and MT.TreatId='"+TreatmentId+"'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            if (str1 == "Ayurvedic")
            {
                
                dataGridView1.DataSource = ds.Tables["Medicine"];
            }
            else if(str1=="Alopathic")
            {
                
                dataGridView2.DataSource = ds.Tables["Medicine"];
            }
            else
            {
                
                dataGridView3.DataSource = ds.Tables["Medicine"];
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            dosage = "";
            Ayurvedic();
            TreatMed TM = new TreatMed(PatientId, TreatmentId, MedType,comboBox1.Text, textBox1.Text, dosage);
            str=TM.Insert();
            MessageBox.Show("Medicine is alloted for patient...!!!");
            Display1("Ayurvedic");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str;
            dosage1 = "";
            Alopathic();
            TreatMed TM = new TreatMed(PatientId, TreatmentId, MedType,comboBox2.Text, textBox2.Text, dosage);
            str=TM.Insert();
            MessageBox.Show("Medicine is alloted for patient...!!!");
            Display1("Alopathic");
        }

        public string dosage2;
        public void Others()
        {
            if (checkBox9.Checked == true)
            {
                dosage2 = dosage2 + "_" + checkBox9.Text;
            }
            if (checkBox8.Checked == true)
            {
                dosage2 = dosage2 + "_" + checkBox8.Text;
            }
            if (checkBox7.Checked == true)
            {
                dosage2 = dosage2 + "_" + checkBox7.Text;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string str;
            dosage2 = "";
            Others();
            TreatMed FTM = new TreatMed(PatientId, TreatmentId, MedType, comboBox4.Text,textBox4.Text,dosage2);
            str=FTM.Insert();
            MessageBox.Show("Medicine is alloted for patient...!!!");
            Display1("Others");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Payment PY = new Payment(PatientId, TreatmentId);
            PY.Show();
            this.Close();
        }

       
    }
}

