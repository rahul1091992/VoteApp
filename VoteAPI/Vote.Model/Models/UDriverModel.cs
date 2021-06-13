using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    
    public class UDriverModel
    {
        public UDriverModel()
        {
            Data = new UDrivers();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public UDrivers Data { get; set; }
    }
    public class UDriverList
    {
        public UDriverList()
        {
            Data = new List<UDrivers>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<UDrivers> Data { get; set; }
    }


    public class UProductList
    {
        public UProductList()
        {
            Data = new List<UProduct>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ProductName { get; set; }
        public int TotalProduct { get; set; }
        public List<UProduct> Data { get; set; }
    }


    public class UBProductList
    {
        public UBProductList()
        {
            Data = new List<UBProductData>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<UBProductData> Data { get; set; }
    }
}
