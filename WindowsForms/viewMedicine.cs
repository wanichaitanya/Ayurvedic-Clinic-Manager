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
    public partial class viewMedicine : Form
    {
        public viewMedicine()
        {
            InitializeComponent();
            
            this.dataGridView2.DefaultCellStyle.Font = new Font("Shivaji01", 18);
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
            da = new SqlDataAdapter("select M.MId from Medicine M where M.MCategory='Ayurvedic'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Medicine"];

            DataSet ds1;
            SqlDataAdapter da1;
            SqlCommandBuilder bldr1;
            da1 = new SqlDataAdapter("select M.MName,M.MType from Medicine M where M.MCategory='Ayurvedic'", con);
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
            da = new SqlDataAdapter("select M.MId,M.MName,M.MType from Medicine M where M.MCategory='Alopathic'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            dataGridView3.DataSource = ds.Tables["Medicine"];
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
            da = new SqlDataAdapter("select M.MId,M.MName,M.MType from Medicine M where M.MCategory='Others'", con);
            ds = new DataSet();
            da.Fill(ds, "Medicine");
            bldr = new SqlCommandBuilder(da);
            dataGridView4.DataSource = ds.Tables["Medicine"];
            con.Close();
        }

        private void viewMedicine_Load(object sender, EventArgs e)
        {
            Display1();
            Display2();
            Display3();
        }
    }
}
