using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
   
    public class UCustomerModel
    {
        public UCustomerModel()
        {
            Data = new UCustomers();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public UCustomers Data { get; set; }
    }
}
