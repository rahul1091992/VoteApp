using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data.Abstraction
{
     
    public interface ILuckygameRepository
    {

        LuckydrawGameModel Post(LuckydrawGameData luckydrawGameData);
        LuckydrawGameList GetAll();
        LuckydrawGameModel Get(int id);
        LuckydrawGameModel Put(int id, LuckydrawGameData luckydrawGameData);
        LuckydrawGameModel Delete(int id);
        LuckydrawPrizeListData GetAllPrize(int gameId);
        LuckyList GetAllUsers(int gameId);
        LuckydrawPrizeListData GetPlayersPrize(int UserId, int GameId);
        LuckydrawGameModel GiveChance(int UserId, int GameId);
        LuckydrawPrizeModelData PlayGame(int UserId, int GameId);
        LuckydrawPrizeModelData SaveWinPrize(int UserId, int GameId, int PrizeId);

    }
}
