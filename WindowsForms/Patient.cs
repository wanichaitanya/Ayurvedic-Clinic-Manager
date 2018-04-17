using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using AyuRakshaDll;
namespace WindowsFormsApp1
{
    partial class Patient
    {
        private string FName = null;
        private string LName = null;
        private string Dob = null;
        private string Gender = null;
        private string Addr = null;
        private UInt64 Mob = 0;
        private string Email = null;
        private string PatientId = null;
        private string PrakrutiDharma = null;
        public Patient(string PatID, string fname, string lname, string dob, string gender, string addr, UInt64 mob, string email,string Prakruti)
        {
            PatientId = PatID;
            FName = fname;
            LName = lname;
            Dob = dob;
            Gender = gender;
            Addr = addr;
            Mob = mob;
            Email = email;
            PrakrutiDharma = Prakruti;
        }
        public void Insert()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Patient values('" + PatientId + "','" + FName + "','" + LName + "','" + Gender + "','" + Addr + "','" + Mob + "','" + Email + "','" + Dob + "','"+PrakrutiDharma+"')", con);
            cmd.ExecuteNonQuery();
        }
        public void update()
        {
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Patient set PAddr='" + Addr + "', PMob='" + Mob + "',PEmail='" + Email + "' where PId='"+PatientId+"'", con);
            cmd.ExecuteNonQuery();
            
        }
    }
}
