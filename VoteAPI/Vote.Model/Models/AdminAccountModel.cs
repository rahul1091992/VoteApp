using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
   
    public class AdminAccountModel
    {
        public AdminAccountModel()
        {
            Data = new AdminUsers();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public AdminUsers Data { get; set; }
    }
}
