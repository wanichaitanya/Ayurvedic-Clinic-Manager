using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace WindowsFormsApp1
{
    class Checkup
    {
        private LinkedList1 ll1;
        private string PatId = "";
        Random r = new Random();
        private string TreateId = "";
        private string[] Sarr = new string[12];
        private string TreateDate = "";
        public Checkup(LinkedList1 List, string PatientId, string Date,string TreatId)
        {
            ll1 = List;
            PatId = PatientId;
            TreateId = TreatId;
            TreateDate = Date;
        }
        public string Show()
        {
            return (ll1.Traverse());
        }
        public void SetData()
        {
            int iCnt = 0;

            Node temp = ll1.Head;
            for (iCnt = 0, temp = ll1.Head; (iCnt < 12) && (temp != null); temp = temp.next, iCnt++)
            {
                Sarr[iCnt] = temp.Value;
            }
        }
        public void Insert()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into TREATMENT values('" + TreateId + "','" + PatId + "','" + Sarr[0] + "','" + Sarr[1] + "','" + Sarr[2] + "','" + Sarr[3] + "','" + Sarr[4] + "','" + Sarr[5] + "','" + Sarr[6] + "','"+ Sarr[7] + "','" + Sarr[8] + "','" + Sarr[9] + "','" + Sarr[10] + "','" + Sarr[11] + "','" + TreateDate + "')", con);
            cmd.ExecuteNonQuery();
        }
    }
}

