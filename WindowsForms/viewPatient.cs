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
    public partial class viewPatient : Form
    {
        public viewPatient()
        {
            InitializeComponent();
            this.dataGridView2.DefaultCellStyle.Font = new Font("Shivaji01", 18);
        }

        private void viewPatient_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            DataSet ds;
            SqlDataAdapter da;
            SqlCommandBuilder bldr;
            da = new SqlDataAdapter("select PId,PFirstName,PLastName,PGender,PAddr,PMob,PEmail,PDob from Patient", con);
            ds = new DataSet();
            da.Fill(ds, "Patient");
            bldr = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables["Patient"];

            DataSet ds1;
            SqlDataAdapter da1;
            SqlCommandBuilder bldr1;
            da1 = new SqlDataAdapter("select PPrakruti from Patient", con);
            ds1 = new DataSet();
            da1.Fill(ds1, "Patient");
            bldr1 = new SqlCommandBuilder(da1);
            dataGridView2.DataSource = ds1.Tables["Patient"];

            con.Close();
        }
    }
}
