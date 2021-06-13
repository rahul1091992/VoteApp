using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    

    public class LuckydrawPrizeModel
    {
        public LuckydrawPrizeModel()
        {
            Data = new LuckydrawPrize();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public LuckydrawPrize Data { get; set; }
    }
    public class LuckydrawPrizeList
    {
        public LuckydrawPrizeList()
        {
            Data = new List<LuckydrawPrize>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<LuckydrawPrize> Data { get; set; }
    }



    public class LuckydrawPrizeListData
    {
        public LuckydrawPrizeListData()
        {
            Data = new List<LuckydrawPrizeData>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<LuckydrawPrizeData> Data { get; set; }
    }
    public class LuckydrawPrizeModelData
    {
        public LuckydrawPrizeModelData()
        {
            Data = new LuckydrawPrizeData();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public LuckydrawPrizeData Data { get; set; }
    }
}
