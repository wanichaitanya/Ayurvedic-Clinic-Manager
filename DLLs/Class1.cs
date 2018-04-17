using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyuRakshaDll
{
    public class Class1
    {
        public static int CalculateAge(string InputDate)
        {
            /////////////////////////////////////////////////////////////////////
            //
            //  Name:-      CalculateAge
            //  Input:-     String
            //  Output:-    Integer
            //  
            /////////////////////////////////////////////////////////////////////
            int iTodayDay, iTodayMonth, iTodayYear, iBirthDay, iBirthMonth, iBirthYear, iAge = 0, iDiff = 0;
            //converting user entered date into string format
            string UserDate = Convert.ToDateTime(InputDate.ToString()).ToString();//ToShortDateString();

            //converting today's date into string format
            string Todaydate = Convert.ToDateTime(DateTime.Now.ToString()).ToString();//ToShortDateString();

            //converting today's date field of format (dd/mm/yyyy) into integer
            iTodayDay = Convert.ToInt32(Todaydate.Substring(0, 2));

            //converting today's month field of format (dd/mm/yyyy) into integer
            iTodayMonth = Convert.ToInt32(Todaydate.Substring(3, 2));

            //converting today's year field of format (dd/mm/yyyy) into integer
            iTodayYear = Convert.ToInt32(Todaydate.Substring(6, 4));

            //converting UserDate's date field of format (dd/mm/yyyy) into integer
            iBirthDay = Convert.ToInt32(UserDate.Substring(0, 2));

            //converting UserDate's month field of format (dd/mm/yyyy) into integer
            iBirthMonth = Convert.ToInt32(UserDate.Substring(3, 2));

            //converting UserDate's year field of format (dd/mm/yyyy) into integer
            iBirthYear = Convert.ToInt32(UserDate.Substring(6, 4));

            //Input Validation Filter
            if ((iBirthDay >= iTodayDay) && (iBirthMonth >= iTodayMonth) && (iBirthYear >= iTodayYear))
            {
                return -1;
            }
            iDiff = iTodayYear - iBirthYear;
            //Calculate Age by using today's system date and user entered birth date
            if ((iTodayMonth < iBirthMonth) || ((iTodayMonth == iBirthMonth) && (iTodayDay <= iBirthDay)))
            {
                iAge = iDiff - 1;
            }
            else if ((iTodayMonth > iBirthMonth) || ((iTodayMonth == iBirthMonth) && (iTodayDay > iBirthDay)))
            {
                iAge = iDiff;
            }

            return iAge;
        }
        public static string PrakrutiDharma(string InputDate)
        {
            /////////////////////////////////////////////////////////////////////
            //
            //  Name:-      PrakrutiDharma
            //  Input:-     String
            //  Output:-    String
            //  Description:- It takes birthdate as input and return the patient's 
            //                prakruti dharma as a output
            //  
            /////////////////////////////////////////////////////////////////////
            int newMonth=0,BirthMonth = 0;
            BirthMonth = Convert.ToInt32(InputDate.Substring(3, 2));
            newMonth = BirthMonth + 5;
            if(newMonth>12)
            {
                newMonth = newMonth % 12;
            }
            if((newMonth==7)||(newMonth==8)||(newMonth == 9))
            {
                return "AamlaQamaI-";
            }
            else if ((newMonth == 3) || (newMonth == 4) || (newMonth == 5))
            {
                return "xaarQamaI-";
            }
            else if ((newMonth == 11) || (newMonth == 12) || (newMonth == 1))
            {
                return "]BayaQamaI-";
            }
            else
            {
                return "?tusaMQaIkaL";
            }
        }

    }



    

}
