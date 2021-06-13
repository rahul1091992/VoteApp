using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
   public class LuckydrawPrize
    {
        public int Id { get; set; }
        public string PrizeName { get; set; }
        public string PrizePurpose { get; set; }
        public decimal PrizeAmount { get; set; }
        public int PrizeImageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public string PrizeType { get; set; }
        public string PrizeEmotion { get; set; }

    }
    public class LuckydrawPrizeData
    {
        public int Id { get; set; }
        public string PrizeName { get; set; }
        public string PrizePurpose { get; set; }
        public decimal PrizeAmount { get; set; }
        public int PrizeImageId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool? IsGame { get; set; }
        public string PrizeImage{ get; set; }
        public string PrizeType { get; set; }
        public string PrizeEmotion { get; set; }
    }

}
