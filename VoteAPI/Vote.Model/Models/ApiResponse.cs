using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }



    public class ApiResponseData<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public int TotalProduct { get; set; }
        public string ProductName { get; set; }
        public T Data { get; set; }
    }
}
