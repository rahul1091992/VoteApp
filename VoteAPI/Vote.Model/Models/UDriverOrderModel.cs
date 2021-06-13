using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    
    public class UDriverOrderModel
    {
        public UDriverOrderModel()
        {
            Data = new UOrdersDriver();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public UOrdersDriver Data { get; set; }
    }
    public class UDriverOrdersList
    {
        public UDriverOrdersList()
        {
            Data = new List<UOrdersDriver>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<UOrdersDriver> Data { get; set; }
    }
}
