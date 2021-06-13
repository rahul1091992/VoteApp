using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data.Abstraction
{
    
    public interface ILuckyprizeRepository
    {
        LuckydrawPrizeModel Post(LuckydrawPrize luckydrawPrize);
        LuckydrawPrizeListData GetAll();
        LuckydrawPrizeModelData Get(int id);
        LuckydrawPrizeModel Put(int id, LuckydrawPrize luckydrawPrize);
        LuckydrawPrizeModel Delete(int id);
    }
}
