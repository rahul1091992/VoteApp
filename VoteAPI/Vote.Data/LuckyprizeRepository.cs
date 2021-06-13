using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Data.Abstraction;
using Vote.Data.DB;
using Vote.Data.Helper;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data
{
    public class LuckyprizeRepository : ILuckyprizeRepository
    {
        private VoteDBContext voteContext;
        public LuckyprizeRepository(VoteDBContext db)
        {
            voteContext = db;
        }

        public LuckydrawPrizeModel Post(LuckydrawPrize luckydrawPrize)
        {


            LuckydrawPrizeModel statusResponse = new LuckydrawPrizeModel();
            //var name = voteContext.luckydrawPrize.Where(x => x.PrizeName == luckydrawPrize.PrizeName).FirstOrDefault();
            //if (name != null)
            //{
            //    statusResponse.Status = false; statusResponse.Message = "Name already exists";
            //}
            //if (name == null)
            //{
                luckydrawPrize.IsActive = true;
                luckydrawPrize.CreatedOn = DateTime.Now;
                voteContext.luckydrawPrize.Add(luckydrawPrize);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Prize saved";
            //}

            return statusResponse;
        }

        public LuckydrawPrizeListData GetAll()
        {
            LuckydrawPrizeListData statusResponse = new LuckydrawPrizeListData();
            var data = voteContext.luckydrawPrize.OrderBy(x => x.CreatedOn).ToList();
            if (data.Count > 0)
            {
                List<LuckydrawPrizeData> lst = new List<LuckydrawPrizeData>();
                foreach (var item in data)
                {
                    var img = voteContext.fileUpload.Where(x => x.Id == item.PrizeImageId).FirstOrDefault();
                    lst.Add(new LuckydrawPrizeData { PrizeEmotion=item.PrizeEmotion, PrizeType=item.PrizeType, CreatedOn = item.CreatedOn, Id = item.Id, IsActive = item.IsActive, PrizeAmount = item.PrizeAmount, PrizeImage = img != null ? img.ImageUrl : "", PrizeImageId = item.PrizeImageId, PrizePurpose = item.PrizePurpose, PrizeName = item.PrizeName  });
                }
                statusResponse.Status = true; statusResponse.Message = "Prize list"; statusResponse.Data = lst;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Prize not found";
            }

            return statusResponse;
        }
        public LuckydrawPrizeModel Delete(int id)
        {
            LuckydrawPrizeModel statusResponse = new LuckydrawPrizeModel();
            var data = voteContext.luckydrawPrize.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                voteContext.Remove(data);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Prize deleted"; statusResponse.Data = data;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Prize details not found";
            }

            return statusResponse;
        }

        public LuckydrawPrizeModelData Get(int id)
        {
            LuckydrawPrizeModelData statusResponse = new LuckydrawPrizeModelData();
            var data = voteContext.luckydrawPrize.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
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
                statusResponse.Status = false; statusResponse.Message = "Prize details not found";
            }

            return statusResponse;
        }




        public LuckydrawPrizeModel Put(int id, LuckydrawPrize luckydrawPrize)
        {
            LuckydrawPrizeModel statusResponse = new LuckydrawPrizeModel();

            var data = voteContext.luckydrawPrize.Where(x => x.Id == id).FirstOrDefault();


            if (data != null)
            {
                data.PrizeAmount = luckydrawPrize.PrizeAmount;
                data.PrizeImageId = luckydrawPrize.PrizeImageId;
                data.PrizeName = luckydrawPrize.PrizeName;
                data.PrizeType = luckydrawPrize.PrizeType;
                data.PrizeEmotion = luckydrawPrize.PrizeEmotion;
                data.PrizePurpose = luckydrawPrize.PrizePurpose;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Prize updated";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Prize not found";
            }
            return statusResponse;
        }

    }
}
