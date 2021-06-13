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

    public class AdminAccountRepository : IAdminAccountRepository
    {
        private VoteDBContext voteDBContext;
        public AdminAccountRepository(VoteDBContext db)
        {
            voteDBContext = db;
        }
        public AdminAccountModel ForgotPassword(string email)
        {
            AdminAccountModel statusResponse = new AdminAccountModel();
            var result = voteDBContext.adminUsers.Where(x => x.Email == email).FirstOrDefault();
            if (result != null)
            {
                string newPass = SendEmail.GenerateRandomPassword();
                bool passCheck = SendEmail.SendForgotPasswordMail(result.Name, result.Email, newPass);
                if (passCheck)
                {
                    result.Password = EncryptPassword.EncodePasswordToBase64(newPass);
                    voteDBContext.SaveChanges();
                    statusResponse.Status = true; statusResponse.Message = "Password have been send on your email";
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "There are some problem in email please try again";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid email";
            }

            return statusResponse;
        }
        public AdminAccountModel Register(AdminUsers adminUsers)
        {
            AdminAccountModel statusResponse = new AdminAccountModel();

            var email = voteDBContext.adminUsers.Where(x => x.Email == adminUsers.Email).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }
            if (email == null)
            {
                adminUsers.IsActive = true;
                adminUsers.CreatedOn = DateTime.Now;
                adminUsers.Password = EncryptPassword.EncodePasswordToBase64(adminUsers.Password);
                voteDBContext.adminUsers.Add(adminUsers);
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Registration successful"; statusResponse.Data = adminUsers;
            }

            return statusResponse;
        }

        public AdminAccountModel Login(AdminUsers adminUsers)
        {
            AdminAccountModel statusResponse = new AdminAccountModel();
            adminUsers.Password = EncryptPassword.EncodePasswordToBase64(adminUsers.Password);
            var result = voteDBContext.adminUsers.Where(x => x.Email == adminUsers.Email && x.Password == adminUsers.Password).FirstOrDefault();
            if (result != null)
            {
                statusResponse.Status = true; statusResponse.Message = "Login successful"; statusResponse.Data = result;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid credentials";
            }

            return statusResponse;
        }

        public AdminAccountModel GetProfile(int userId)
        {
            AdminAccountModel statusResponse = new AdminAccountModel();
            var result = voteDBContext.adminUsers.Where(x => x.Id == userId).FirstOrDefault();
            if (result != null)
            {
                statusResponse.Status = true; statusResponse.Message = "User data"; statusResponse.Data = result;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid user";
            }

            return statusResponse;
        }
        public AdminAccountModel UpdateProfile(AdminUsers adminUsers)
        {
            AdminAccountModel statusResponse = new AdminAccountModel();

            var email = voteDBContext.adminUsers.Where(x => x.Email == adminUsers.Email && x.Id != adminUsers.Id).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }
            if (email == null)
            {
                var data = voteDBContext.adminUsers.Where(x => x.Id == adminUsers.Id).FirstOrDefault();
                data.Name = adminUsers.Name;
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Profile updated successful"; statusResponse.Data = data;
            }

            return statusResponse;
        }
        public AdminAccountModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            AdminAccountModel statusResponse = new AdminAccountModel();
            string pass = EncryptPassword.EncodePasswordToBase64(changePasswordModel.OldPassword);
            var dataOldPassword = voteDBContext.adminUsers.Where(x => x.Id == changePasswordModel.UserId && x.Password == pass).FirstOrDefault();

            if (dataOldPassword != null)
            {
                var data = voteDBContext.adminUsers.Where(x => x.Id == changePasswordModel.UserId).FirstOrDefault();
                data.Password = EncryptPassword.EncodePasswordToBase64(changePasswordModel.NewPassword);
                voteDBContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Password updated successful"; statusResponse.Data = data;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid old password";
            }

            return statusResponse;
        }

        public DashboardModel Dashboard()
        {
            DashboardModel statusResponse = new DashboardModel();

            DashboardData dashboardData = new DashboardData();
            dashboardData.Candidate = voteDBContext.candidates.Count();
            dashboardData.Election = voteDBContext.elections.Count();
            dashboardData.Voter = voteDBContext.voters.Count();
            statusResponse.Status = true; statusResponse.Message = "Dashboard Data"; statusResponse.Data = dashboardData;

            return statusResponse;
        }
    }
}
