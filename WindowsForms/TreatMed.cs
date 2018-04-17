using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    class TreatMed
    {
        public string PatientId;
        public string TreatId;
        public string MName;
        public string NoOfDays;
        public string Dosage;
        
        public string MType;
        public string str1;
        public TreatMed(string PatId, string FTreatId, string MedType,string MedicineName, string Days, string Dose)
        {
            PatientId = PatId;
            TreatId = FTreatId;
            MName = MedicineName;
            MType = MedType;
            NoOfDays = Days;
            Dosage = Dose;
            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            string qry = "select MId from Medicine where MName = '" + MName + "' and MType='"+MType+"'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                str1 = dr.GetValue(0).ToString();
            }
            dr.Close();
            
        }
        public string Insert()
        {

            SqlConnection con;
            string connectionstring = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.ClientDBConnectionString"].ConnectionString;
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into MED_TREAT values('" + TreatId + "','" + str1 + "','" + NoOfDays + "','" + Dosage + "')", con);
            cmd.ExecuteNonQuery();
            return str1;
        }

    }
}