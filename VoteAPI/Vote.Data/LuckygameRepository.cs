using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Data.DB;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data
{

    public class LuckygameRepository : ILuckygameRepository
    {
        private VoteDBContext voteContext;
        public LuckygameRepository(VoteDBContext db)
        {
            voteContext = db;
        }

        public LuckydrawGameModel Post(LuckydrawGameData luckydrawGameData)
        {


            LuckydrawGameModel statusResponse = new LuckydrawGameModel();
            var name = voteContext.luckydrawGame.Where(x => x.GameName == luckydrawGameData.GameName).FirstOrDefault();
            if (name != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Name already exists";
            }
            if (name == null)
            {
                LuckydrawGame luckydrawGame = new LuckydrawGame();
                luckydrawGame.CreatedOn = DateTime.Now;
                luckydrawGame.FromDate = luckydrawGameData.FromDate;
                luckydrawGame.GameDescription = luckydrawGameData.GameDescription;
                luckydrawGame.GameName = luckydrawGameData.GameName;
                luckydrawGame.ToDate = luckydrawGameData.ToDate;
                luckydrawGame.ImgId = luckydrawGameData.ImgId;
                voteContext.luckydrawGame.Add(luckydrawGame);
                voteContext.SaveChanges();

                foreach (var item in luckydrawGameData.PrizeId)
                {
                    LuckydrawGamePrize luckydrawGamePrize = new LuckydrawGamePrize();
                    luckydrawGamePrize.CreatedOn = DateTime.Now;
                    luckydrawGamePrize.GameId = luckydrawGame.Id;
                    luckydrawGamePrize.PrizeId = item;
                    voteContext.luckydrawGamePrize.Add(luckydrawGamePrize);
                    voteContext.SaveChanges();
                }

                statusResponse.Status = true; statusResponse.Message = "Game saved";
            }

            return statusResponse;
        }

        public LuckydrawGameList GetAll()
        {
            LuckydrawGameList statusResponse = new LuckydrawGameList();
            var data = voteContext.luckydrawGame.OrderByDescending(x => x.Id).ToList();
            if (data.Count > 0)
            {
                List<LuckydrawGameCls> luckydrawGameCls = new List<LuckydrawGameCls>();
                foreach (var item in data)
                {
                    bool isExpire = false;
                    if (item.ToDate.Date < DateTime.Now.Date)
                    {
                        isExpire = true;
                    }
                    var img = voteContext.fileUpload.Where(x => x.Id == item.ImgId).FirstOrDefault();
                    var userCount = voteContext.luckydrawUserPrize.Where(x => x.GameId == item.Id).Count();


                    luckydrawGameCls.Add(new LuckydrawGameCls { ImgUrl = img != null ? img.ImageUrl : "", ImgId = item.ImgId, IsExpire = isExpire, UserCount = userCount, CreatedOn = item.CreatedOn, FromDate = item.FromDate, GameDescription = item.GameDescription, GameName = item.GameName, Id = item.Id, ToDate = item.ToDate, });
                }
                statusResponse.Status = true; statusResponse.Message = "Game list"; statusResponse.Data = luckydrawGameCls;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Game not found";
            }

            return statusResponse;
        }
        public LuckydrawGameModel Delete(int id)
        {
            LuckydrawGameModel statusResponse = new LuckydrawGameModel();
            var data = voteContext.luckydrawGame.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                voteContext.Remove(data);
                voteContext.SaveChanges();
                var result = voteContext.luckydrawGamePrize.Where(x => x.GameId == id).ToList();
                foreach (var item in result)
                {
                    voteContext.Remove(item);
                    voteContext.SaveChanges();
                }
                statusResponse.Status = true; statusResponse.Message = "Game deleted";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Game details not found";
            }

            return statusResponse;
        }

        public LuckydrawGameModel Get(int id)
        {
            LuckydrawGameModel statusResponse = new LuckydrawGameModel();
            var data = voteContext.luckydrawGame.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                LuckydrawGameCls luckydrawGameCls = new LuckydrawGameCls();
                luckydrawGameCls.CreatedOn = data.CreatedOn;
                luckydrawGameCls.FromDate = data.FromDate;
                luckydrawGameCls.GameDescription = data.GameDescription;
                luckydrawGameCls.GameName = data.GameName;
                luckydrawGameCls.Id = data.Id;
                luckydrawGameCls.ImgId = data.ImgId;
                var img = voteContext.fileUpload.Where(x => x.Id == data.ImgId).FirstOrDefault();
                luckydrawGameCls.ImgUrl = img != null ? img.ImageUrl : "";
                luckydrawGameCls.IsExpire = false;
                luckydrawGameCls.ToDate = data.ToDate;
                luckydrawGameCls.UserCount = 0;
                statusResponse.Status = true; statusResponse.Message = "Game details"; statusResponse.Data = luckydrawGameCls;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Game details not found";
            }

            return statusResponse;
        }




        public LuckydrawGameModel Put(int id, LuckydrawGameData luckydrawGameData)
        {
            LuckydrawGameModel statusResponse = new LuckydrawGameModel();

            var data = voteContext.luckydrawGame.Where(x => x.Id == id).FirstOrDefault();


            if (data != null)
            {
                data.FromDate = luckydrawGameData.FromDate;
                data.ToDate = luckydrawGameData.ToDate;
                data.GameName = luckydrawGameData.GameName;
                data.ImgId = luckydrawGameData.ImgId;
                data.GameDescription = luckydrawGameData.GameDescription;
                voteContext.SaveChanges();
                //remove
                var result = voteContext.luckydrawGamePrize.Where(x => x.GameId == id).ToList();
                foreach (var item in result)
                {
                    voteContext.Remove(item);
                    voteContext.SaveChanges();
                }

                foreach (var item in luckydrawGameData.PrizeId)
                {
                    LuckydrawGamePrize luckydrawGamePrize = new LuckydrawGamePrize();
                    luckydrawGamePrize.CreatedOn = DateTime.Now;
                    luckydrawGamePrize.GameId = id;
                    luckydrawGamePrize.PrizeId = item;
                    voteContext.luckydrawGamePrize.Add(luckydrawGamePrize);
                    voteContext.SaveChanges();
                }
                statusResponse.Status = true; statusResponse.Message = "Game updated";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Game not found";
            }
            return statusResponse;
        }
        public LuckydrawPrizeListData GetAllPrize(int gameId)
        {
            LuckydrawPrizeListData statusResponse = new LuckydrawPrizeListData();
            var data = voteContext.luckydrawPrize.ToList();
            if (data.Count > 0)
            {
                List<LuckydrawPrizeData> lst = new List<LuckydrawPrizeData>();
                foreach (var result in data)
                {
                    var item = voteContext.luckydrawGamePrize.Where(x => x.PrizeId == result.Id && x.GameId == gameId).FirstOrDefault();
                    var img = voteContext.fileUpload.Where(x => x.Id == result.PrizeImageId).FirstOrDefault();
                    if (item != null)
                    {
                        lst.Add(new LuckydrawPrizeData { PrizeImage = img != null ? img.ImageUrl : "", IsGame = true, CreatedOn = result.CreatedOn, Id = result.Id, IsActive = result.IsActive, PrizeAmount = result.PrizeAmount, PrizeImageId = result.PrizeImageId, PrizeName = result.PrizeName, PrizePurpose = result.PrizePurpose, PrizeType = result.PrizeType, PrizeEmotion = result.PrizeEmotion });
                    }
                    else
                    {
                        lst.Add(new LuckydrawPrizeData { PrizeImage = img != null ? img.ImageUrl : "", IsGame = false, CreatedOn = result.CreatedOn, Id = result.Id, IsActive = result.IsActive, PrizeAmount = result.PrizeAmount, PrizeImageId = result.PrizeImageId, PrizeName = result.PrizeName, PrizePurpose = result.PrizePurpose, PrizeType = result.PrizeType, PrizeEmotion = result.PrizeEmotion });
                    }
                }
                statusResponse.Status = true; statusResponse.Message = "Prize list"; statusResponse.Data = lst;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Prize not found";
            }

            return statusResponse;
        }


        public LuckyList GetAllUsers(int gameId)
        {
            LuckyList statusResponse = new LuckyList();
            var data = voteContext.luckydrawUser.OrderBy(x => x.FullName).ToList();


            if (data.Count > 0)
            {
                List<LuckydrawUser> lst = new List<LuckydrawUser>();
                foreach (var item in data)
                {
                    var check = voteContext.luckydrawUserPrize.Where(x => x.GameId == gameId && x.UserId == item.Id).FirstOrDefault();
                    if (check != null)
                    {
                        var photo = voteContext.fileUpload.Where(x => x.Id == item.Img).FirstOrDefault();
                        lst.Add(new LuckydrawUser { Img = item.Img, CreatedOn = item.CreatedOn, Department = item.Department, Designation = item.Designation, Email = item.Email, FatherName = item.FatherName, FullName = item.FullName, Gender = photo != null ? photo.ImageUrl : "", Id = item.Id, IsActive = item.IsActive, IsAdmin = item.IsAdmin, Password = item.Password, Phone = item.Phone });

                    }
                }
                statusResponse.Status = true; statusResponse.Message = "User list"; statusResponse.Data = lst;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User not found";
            }

            return statusResponse;
        }


        public LuckydrawPrizeListData GetPlayersPrize(int UserId, int GameId)
        {
            LuckydrawPrizeListData statusResponse = new LuckydrawPrizeListData();
            var data = voteContext.luckydrawUserPrize.Where(x => x.UserId == UserId && x.GameId == GameId).ToList();
            if (data.Count > 0)
            {
                string msg = "0";
                var result = voteContext.luckydrawUserPrize.Where(x => x.UserId == UserId && x.GameId == GameId && x.IsActive == true).ToList();
                if (result.Count > 0)
                {
                    msg = "1";
                }
                List<LuckydrawPrizeData> lst = new List<LuckydrawPrizeData>();
                foreach (var cn in data)
                {
                    var item = voteContext.luckydrawPrize.Where(x => x.Id == cn.PrizeId).FirstOrDefault();
                    var img = voteContext.fileUpload.Where(x => x.Id == item.PrizeImageId).FirstOrDefault();
                    lst.Add(new LuckydrawPrizeData { CreatedOn = item.CreatedOn, Id = item.Id, IsActive = item.IsActive, PrizeAmount = item.PrizeAmount, PrizeImage = img != null ? img.ImageUrl : "", PrizeImageId = item.PrizeImageId, PrizePurpose = item.PrizePurpose, PrizeName = item.PrizeName, PrizeType = item.PrizeType, PrizeEmotion = item.PrizeEmotion });
                }
                statusResponse.Status = true; statusResponse.Message = msg; statusResponse.Data = lst;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Prize not found";
            }

            return statusResponse;
        }
        public LuckydrawGameModel GiveChance(int UserId, int GameId)
        {
            LuckydrawGameModel statusResponse = new LuckydrawGameModel();
            var data = voteContext.luckydrawUserPrize.Where(x => x.UserId == UserId && x.GameId == GameId).ToList();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    voteContext.Remove(item);
                    // item.IsActive = item.IsActive == true ? false : true;
                    voteContext.SaveChanges();
                }
                statusResponse.Status = true; statusResponse.Message = "Chance";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Game details not found";
            }

            return statusResponse;
        }

        public LuckydrawPrizeModelData PlayGame(int UserId, int GameId)
        {
            LuckydrawPrizeModelData statusResponse = new LuckydrawPrizeModelData();


            var gameData = voteContext.luckydrawGame.Where(x => x.Id == GameId).FirstOrDefault();
            DateTime dt = DateTime.Now;
            if (gameData.FromDate > dt)
            {
                statusResponse.Status = false; statusResponse.Message = "Game not started";
            }
            else if (gameData.ToDate < dt)
            {
                statusResponse.Status = false; statusResponse.Message = "Game expired";
            }
            else
            {
                var data = voteContext.luckydrawPrize.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                if (data != null)
                {


                    var cn = voteContext.luckydrawUserPrize.Where(x => x.GameId == GameId && x.UserId == UserId).FirstOrDefault();
                    if (cn == null)
                    {
                        LuckydrawPrizeData luckydrawPrizeData = new LuckydrawPrizeData();
                        luckydrawPrizeData.CreatedOn = data.CreatedOn;
                        luckydrawPrizeData.Id = data.Id;
                        luckydrawPrizeData.IsActive = data.IsActive;
                        luckydrawPrizeData.PrizeAmount = data.PrizeAmount;
                        luckydrawPrizeData.PrizeImageId = data.PrizeImageId;
                        luckydrawPrizeData.PrizeName = data.PrizeName;
                        luckydrawPrizeData.PrizePurpose = data.PrizePurpose;
                        luckydrawPrizeData.PrizeType = data.PrizeType;
                        luckydrawPrizeData.PrizeEmotion = data.PrizeEmotion;
                        var img = voteContext.fileUpload.Where(x => x.Id == data.PrizeImageId).FirstOrDefault();
                        luckydrawPrizeData.PrizeImage = img != null ? img.ImageUrl : "";
                        statusResponse.Status = true; statusResponse.Message = "Prize details"; statusResponse.Data = luckydrawPrizeData;
                    }
                    else
                    {
                        statusResponse.Status = false; statusResponse.Message = "You have played before";
                    }
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "Prize details not found";
                }
            }
            return statusResponse;
        }


        public LuckydrawPrizeModelData SaveWinPrize(int UserId, int GameId, int PrizeId)
        {
            LuckydrawPrizeModelData statusResponse = new LuckydrawPrizeModelData();



            var data = voteContext.luckydrawPrize.Where(x => x.Id == PrizeId).FirstOrDefault();

            if (data != null)
            {
                var check = voteContext.luckydrawUserPrize.Where(x => x.GameId == GameId && x.UserId == UserId).FirstOrDefault();
                if (check == null)
                {
                    LuckydrawUserPrize luckydrawUserPrize = new LuckydrawUserPrize();
                    luckydrawUserPrize.GameId = GameId;
                    luckydrawUserPrize.IsActive = false;
                    luckydrawUserPrize.PrizeId = data.Id;
                    luckydrawUserPrize.UserId = UserId;
                    luckydrawUserPrize.CreatedOn = DateTime.Now;
                    voteContext.luckydrawUserPrize.Add(luckydrawUserPrize);
                    voteContext.SaveChanges();

                    var cn = voteContext.luckydrawUserPrize.Where(x => x.GameId == GameId && x.UserId == UserId).ToList();
                    foreach (var item in cn)
                    {
                        item.IsActive = false;
                        voteContext.SaveChanges();
                    }
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "You have played before";
                }

                statusResponse.Status = true; statusResponse.Message = "Prize details";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Prize details not found";
            }

            return statusResponse;
        }

    }
}
