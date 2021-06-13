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
    
    public class LuckyService : ILuckyService
    {
        ILuckyRepository _luckyRepository;
        public LuckyService(ILuckyRepository luckyRepository)
        {
            _luckyRepository = luckyRepository;
        }
        public LuckyModel ForgotPassword(string email)
        {
            return _luckyRepository.ForgotPassword(email);
        }
        public LuckyModel Login(LuckydrawUser luckydrawUser)
        {
            return _luckyRepository.Login(luckydrawUser);
        }
        public LuckyModel Post(LuckydrawUser luckydrawUser)
        {
            return _luckyRepository.Post(luckydrawUser);
        }
        public LuckyList GetAll()
        {
            return _luckyRepository.GetAll();
        }


        public LuckyModel Get(int id)
        {
            return _luckyRepository.Get(id);
        }
        public LuckyModel Status(int id)
        {
            return _luckyRepository.Status(id);
        }
        public LuckyModel ChangePassword(int id, string oldPassword, string newPassword)
        {
            return _luckyRepository.ChangePassword(id, oldPassword, newPassword);
        }

        public LuckyModel Put(int id, LuckydrawUser luckydrawUser)
        {
            return _luckyRepository.Put(id, luckydrawUser);
        }
        public LuckyModel AdminStatus(int id)
        {
            return _luckyRepository.AdminStatus(id);
        }
    }
}
