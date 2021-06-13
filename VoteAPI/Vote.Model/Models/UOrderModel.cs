using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    
    public class UOrderModel
    {
        public UOrderModel()
        {
            Data = new UOrdersCustomer();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public UOrdersCustomer Data { get; set; }
    }
    public class UOrdersList
    {
        public UOrdersList()
        {
            Data = new List<UOrdersCustomer>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<UOrdersCustomer> Data { get; set; }
    }
}
