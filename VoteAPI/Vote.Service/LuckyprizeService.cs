using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Model;
using Vote.Model.Models;
using Vote.Service.Abstraction;

namespace Vote.Service
{
    
    public class LuckyprizeService : ILuckyprizeService
    {
        ILuckyprizeRepository _luckyprizeRepository;
        public LuckyprizeService(ILuckyprizeRepository luckyprizeRepository)
        {
            _luckyprizeRepository = luckyprizeRepository;
        }
        
        public LuckydrawPrizeModel Post(LuckydrawPrize luckydrawPrize)
        {
            return _luckyprizeRepository.Post(luckydrawPrize);
        }
        public LuckydrawPrizeListData GetAll()
        {
            return _luckyprizeRepository.GetAll();
        }
        public LuckydrawPrizeModel Delete(int id)
        {
            return _luckyprizeRepository.Delete(id);
        }

        public LuckydrawPrizeModelData Get(int id)
        {
            return _luckyprizeRepository.Get(id);
        }
       

        public LuckydrawPrizeModel Put(int id, LuckydrawPrize luckydrawPrize)
        {
            return _luckyprizeRepository.Put(id, luckydrawPrize);
        }
    }
}
