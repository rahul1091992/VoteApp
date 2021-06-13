using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Data.Helper
{
   
    public static class SendOtp
    {
        public static int SendOtpCode()
        {
            int result = 0;
            try
            {
                int code = GenerateRandomNo();
                return code;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
