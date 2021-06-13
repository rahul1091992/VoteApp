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

    public class LuckygameService : ILuckygameService
    {
        ILuckygameRepository _luckygameRepository;
        public LuckygameService(ILuckygameRepository luckygameRepository)
        {
            _luckygameRepository = luckygameRepository;
        }

        public LuckydrawGameModel Post(LuckydrawGameData luckydrawGameData)
        {
            return _luckygameRepository.Post(luckydrawGameData);
        }
        public LuckydrawGameList GetAll()
        {
            return _luckygameRepository.GetAll();
        }
        public LuckydrawGameModel Delete(int id)
        {
            return _luckygameRepository.Delete(id);
        }

        public LuckydrawGameModel Get(int id)
        {
            return _luckygameRepository.Get(id);
        }


        public LuckydrawGameModel Put(int id, LuckydrawGameData luckydrawGameData)
        {
            return _luckygameRepository.Put(id, luckydrawGameData);
        }
        public LuckydrawPrizeListData GetAllPrize(int gameId)
        {
            return _luckygameRepository.GetAllPrize(gameId);
        }
        public LuckyList GetAllUsers(int gameId)
        {
            return _luckygameRepository.GetAllUsers(gameId);
        }
        public LuckydrawPrizeListData GetPlayersPrize(int UserId, int GameId)
        {
            return _luckygameRepository.GetPlayersPrize(UserId, GameId);
        }
        public LuckydrawGameModel GiveChance(int UserId, int GameId)
        {
            return _luckygameRepository.GiveChance(UserId, GameId);
        }
        public LuckydrawPrizeModelData PlayGame(int UserId, int GameId)
        {
            return _luckygameRepository.PlayGame(UserId, GameId);
        }
        public LuckydrawPrizeModelData SaveWinPrize(int UserId, int GameId, int PrizeId)
        {
            return _luckygameRepository.SaveWinPrize(UserId, GameId, PrizeId);
        }
    }
}
