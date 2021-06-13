using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
   public class UDrivers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string DeviceToken { get; set; }
        public int DeviceType { get; set; }
    }
}
