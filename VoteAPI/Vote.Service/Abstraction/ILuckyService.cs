using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Service.Abstraction
{
    

    public interface ILuckyService
    {
        LuckyModel ForgotPassword(string email);
        LuckyModel Login(LuckydrawUser luckydrawUser);
        LuckyModel Post(LuckydrawUser luckydrawUser);
        LuckyList GetAll();
        LuckyModel Get(int id);
        LuckyModel ChangePassword(int id, string oldPassword, string newPassword);
        LuckyModel Put(int id, LuckydrawUser luckydrawUser);
        LuckyModel Status(int id);
        LuckyModel AdminStatus(int id);
    }
}
