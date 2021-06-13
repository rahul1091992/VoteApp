using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    
    public class ElectionModel
    {
        public ElectionModel()
        {

            Data = new ElectionsData();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public ElectionsData Data { get; set; }
    }
    public class ElectionList
    {
        public ElectionList()
        {
            Data = new List<Elections>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Elections> Data { get; set; }
    }
}
