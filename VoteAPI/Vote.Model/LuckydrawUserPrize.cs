using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
    public class LuckydrawUserPrize
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int GameId { get; set; }

        public int PrizeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
