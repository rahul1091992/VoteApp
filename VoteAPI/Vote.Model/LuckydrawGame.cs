using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
   public class LuckydrawGame
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ImgId { get; set; }
    }

    public class LuckydrawGameCls
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserCount { get; set; }
        public bool  IsExpire { get; set; }
        public int ImgId { get; set; }
        public string ImgUrl { get; set; }
    }
    public class LuckydrawGameData
    {
        public LuckydrawGameData()
        {
            PrizeId = new List<int>();
        }
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ImgId { get; set; }
        public List<int> PrizeId { get; set; }
    }
}
