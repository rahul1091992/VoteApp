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
   
    public class AdminAccountService : IAdminAccountService
    {
        IAdminAccountRepository _adminAccountRepository;
        public AdminAccountService(IAdminAccountRepository adminAccountRepository)
        {
            _adminAccountRepository = adminAccountRepository;
        }
        public AdminAccountModel ForgotPassword(string email)
        {
            return _adminAccountRepository.ForgotPassword(email);
        }
        public AdminAccountModel Register(AdminUsers adminUsers)
        {
            return _adminAccountRepository.Register(adminUsers);
        }
        public AdminAccountModel Login(AdminUsers adminUsers)
        {
            return _adminAccountRepository.Login(adminUsers);
        }
        public AdminAccountModel GetProfile(int userId)
        {
            return _adminAccountRepository.GetProfile(userId);
        }
        public AdminAccountModel UpdateProfile(AdminUsers adminUsers)
        {
            return _adminAccountRepository.UpdateProfile(adminUsers);
        }
        public AdminAccountModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            return _adminAccountRepository.ChangePassword(changePasswordModel);
        }
        public DashboardModel Dashboard()
        {
            return _adminAccountRepository.Dashboard();
        }
    }
}
