using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
     
    public class LuckydrawGameModel
    {
        public LuckydrawGameModel()
        {
            Data = new LuckydrawGameCls();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public LuckydrawGameCls Data { get; set; }
    }
    public class LuckydrawGameList
    {
        public LuckydrawGameList()
        {
            Data = new List<LuckydrawGameCls>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<LuckydrawGameCls> Data { get; set; }
    }
}
