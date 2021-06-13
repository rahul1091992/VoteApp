using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Data.Abstraction
{
    public interface IAdminAccountRepository
    {
        AdminAccountModel ForgotPassword(string email);
        AdminAccountModel Register(AdminUsers adminUsers);
        AdminAccountModel Login(AdminUsers adminUsers);

        AdminAccountModel GetProfile(int userId);
        AdminAccountModel UpdateProfile(AdminUsers adminUsers);
        AdminAccountModel ChangePassword(ChangePasswordModel changePasswordModel);
        DashboardModel Dashboard();
    }
}
