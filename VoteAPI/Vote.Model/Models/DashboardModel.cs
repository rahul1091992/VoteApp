using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
   public class DashboardData
    {
        public int Election { get; set; }
        public int Voter { get; set; }
        public int Candidate { get; set; }
    }
    public class DashboardModel
    {
        public DashboardModel()
        {
            Data = new DashboardData();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public DashboardData Data { get; set; }
    }
}
