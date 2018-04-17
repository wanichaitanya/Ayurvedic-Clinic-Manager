using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    partial class BloodPressure
    {
        LinkedList1 ll1;
        Node Temp;
        public string PatientId;
        public string BPReportId;
        string[] BPArr = new string[3]; 
        public BloodPressure(LinkedList1 list,string PatId)
        {
            int iCnt = 0;
            ll1 = list;
            PatientId = PatId;
            Random r = new Random();
            BPReportId = "BP" + r.Next(1, 100000);
            for (iCnt = 0, Temp = ll1.Head; (iCnt < 3) && (Temp != null); iCnt++, Temp = Temp.next)
            {
                BPArr[iCnt] = Temp.Value;
            }
        }
        public void Insert()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into BloodPressure values('" + BPReportId + "','" + PatientId + "','" + BPArr[0] + "','" + BPArr[1] + "','" + BPArr[2] +  "')", con);
            cmd.ExecuteNonQuery();
        }
    }
    partial class OtherReport
    {
        LinkedList1 ll1;
        Node Temp;
        public string PatientId;
        public string OReportId;
        string[] ORArr = new string[3];
        public OtherReport(LinkedList1 list, string PatId)
        {
            int iCnt = 0;
            ll1 = list;
            PatientId = PatId;
            Random r = new Random();
            OReportId = "OR" + r.Next(1, 100000);
            for (iCnt = 0, Temp = ll1.Head; (iCnt < 3) && (Temp != null); iCnt++, Temp = Temp.next)
            {
                ORArr[iCnt] = Temp.Value;
            }
        }
        public void Insert()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into OtherReports values('" + OReportId + "','" + PatientId + "','" + ORArr[0] + "','" + ORArr[1] + "','" + ORArr[2] + "')", con);
            cmd.ExecuteNonQuery();
        }
    }
    partial class Surgery
    {
        LinkedList1 ll1;
        Node Temp;
        public string PatientId;
        public string SurgeryId;
        string[] SUArr = new string[3];
        public Surgery(LinkedList1 list, string PatId)
        {
            int iCnt = 0;
            ll1 = list;
            PatientId = PatId;
            for (iCnt = 0, Temp = ll1.Head; (iCnt < 3) && (Temp != null); iCnt++, Temp = Temp.next)
            {
                SUArr[iCnt] = Temp.Value;
            }
        }
        public string Type, Date, Descp;
        public Surgery(string type,string date,string descp,string pid)
        {
            PatientId = pid;
            Random r = new Random();
            SurgeryId = "SU" + r.Next(1, 100000);
            Type = type;
            Descp = descp;
            Date = date;
        }
        public void Insert()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("insert into Surgery values('" + SurgeryId + "','" + PatientId + "','" + Type + "','" + Date + "','" + Descp + "')", con);
            cmd.ExecuteNonQuery();
        }
    }

    partial class Sugar
    {
        LinkedList1 ll1;
        Node Temp;
        public string PatientId;
        public string SReportId;
        string[] SArr = new string[6];
        public Sugar(LinkedList1 list, string PatId)
        {
            int iCnt = 0;
            ll1 = list;
            PatientId = PatId;
            Random r = new Random();
            SReportId = "SR" + r.Next(1, 100000);
            for (iCnt = 0, Temp = ll1.Head; (iCnt < 6) && (Temp != null); iCnt++, Temp = Temp.next)
            {
                SArr[iCnt] = Temp.Value;
            }
        }
        public void Insert()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sugar values('" + SReportId + "','" + PatientId + "','" + SArr[0] + "','" + SArr[1] + "','" + SArr[2] + "','" + SArr[3] + "','" + SArr[4] + "','" + SArr[5] + "')", con);
            cmd.ExecuteNonQuery();
        }
    }
}
