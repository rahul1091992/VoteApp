using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    
    public class LuckyModel
    {
        public LuckyModel()
        {
            Data = new LuckydrawUser();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public LuckydrawUser Data { get; set; }
    }
    public class LuckyList
    {
        public LuckyList()
        {
            Data = new List<LuckydrawUser>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<LuckydrawUser> Data { get; set; }
    }
}
