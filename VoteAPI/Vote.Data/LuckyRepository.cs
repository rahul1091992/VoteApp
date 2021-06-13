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

    public class LuckyRepository : ILuckyRepository
    {
        private VoteDBContext voteContext;
        public LuckyRepository(VoteDBContext db)
        {
            voteContext = db;
        }
        public LuckyModel ForgotPassword(string email)
        {
            LuckyModel statusResponse = new LuckyModel();
            var result = voteContext.luckydrawUser.Where(x => x.Email == email).FirstOrDefault();
            if (result != null)
            {
                string newPass = SendEmail.GenerateRandomPassword();
                bool passCheck = SendEmail.SendForgotPasswordMail(result.FullName, result.Email, newPass);
                if (passCheck)
                {
                    result.Password = EncryptPassword.EncodePasswordToBase64(newPass);
                    voteContext.SaveChanges();
                    statusResponse.Status = true; statusResponse.Message = "Password have been send on your email";
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "There are some problem in email please try again";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Allow email sending permission  on server";
            }

            return statusResponse;
        }
        public LuckyModel Login(LuckydrawUser luckydrawUser)
        {
            LuckyModel statusResponse = new LuckyModel();
            luckydrawUser.Password = EncryptPassword.EncodePasswordToBase64(luckydrawUser.Password);
            var data = voteContext.luckydrawUser.Where(x => x.Email == luckydrawUser.Email && x.Password == luckydrawUser.Password).FirstOrDefault();
            if (data != null)
            {
                if (data.IsActive)
                {
                    LuckydrawUser luckydraw = new LuckydrawUser();
                    luckydraw.CreatedOn = data.CreatedOn;
                    luckydraw.Department = data.Department;
                    luckydraw.Designation = data.Designation;
                    luckydraw.Email = data.Email;
                    luckydraw.FatherName = data.FatherName;
                    luckydraw.FullName = data.FullName;
                    luckydraw.Id = data.Id;
                    luckydraw.Img = data.Img;
                    luckydraw.IsActive = data.IsActive;
                    luckydraw.IsAdmin = data.IsAdmin;
                    luckydraw.Password = data.Password;
                    luckydraw.Phone = data.Phone;

                    var photo = voteContext.fileUpload.Where(x => x.Id == data.Img).FirstOrDefault();
                    luckydraw.Gender = photo != null ? photo.ImageUrl : "";
                    statusResponse.Status = true; statusResponse.Message = "Login successful"; statusResponse.Data = luckydraw;
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "User deactivated by admin";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid credentials";
            }

            return statusResponse;
        }
        public LuckyModel Post(LuckydrawUser luckydrawUser)
        {


            LuckyModel statusResponse = new LuckyModel();
            var email = voteContext.luckydrawUser.Where(x => x.Email == luckydrawUser.Email).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }


            string newPass = SendEmail.GenerateRandomPassword();
            bool passCheck = SendEmail.SendForgotPasswordMail(luckydrawUser.FullName, luckydrawUser.Email, newPass);
            if (!passCheck)
            {
                statusResponse.Status = false; statusResponse.Message = "Allow email sending permission  on server";
            }

            if (email == null && passCheck)
            {
                luckydrawUser.IsActive = true;
                luckydrawUser.IsAdmin = false;
                luckydrawUser.CreatedOn = DateTime.Now;
                luckydrawUser.Password = EncryptPassword.EncodePasswordToBase64(newPass);
                voteContext.luckydrawUser.Add(luckydrawUser);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Password have been send on your register email";
            }

            return statusResponse;
        }

        public LuckyList GetAll()
        {
            LuckyList statusResponse = new LuckyList();
            var data = voteContext.luckydrawUser.OrderBy(x => x.FullName).ToList();


            if (data.Count > 0)
            {
                List<LuckydrawUser> lst = new List<LuckydrawUser>();
                foreach (var item in data)
                {
                    var photo = voteContext.fileUpload.Where(x => x.Id == item.Img).FirstOrDefault();
                    lst.Add(new LuckydrawUser { Img=item.Img,CreatedOn=item.CreatedOn,Department=item.Department,Designation=item.Designation,Email=item.Email,FatherName=item.FatherName,FullName=item.FullName,Gender = photo != null ? photo.ImageUrl : "", Id=item.Id,IsActive=item.IsActive,IsAdmin=item.IsAdmin,Password=item.Password,Phone=item.Phone});
                }
                statusResponse.Status = true; statusResponse.Message = "User list"; statusResponse.Data = lst;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User not found";
            }

            return statusResponse;
        }


        public LuckyModel Get(int id)
        {
            LuckyModel statusResponse = new LuckyModel();
            var data = voteContext.luckydrawUser.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                LuckydrawUser luckydrawUser = new LuckydrawUser();
                luckydrawUser.CreatedOn = data.CreatedOn;
                luckydrawUser.Department = data.Department;
                luckydrawUser.Designation = data.Designation;
                luckydrawUser.Email = data.Email;
                luckydrawUser.FatherName = data.FatherName;
                luckydrawUser.FullName = data.FullName;
                luckydrawUser.Id = data.Id;
                luckydrawUser.Img = data.Img;
                luckydrawUser.IsActive = data.IsActive;
                luckydrawUser.IsAdmin = data.IsAdmin;
                luckydrawUser.Password = data.Password;
                luckydrawUser.Phone = data.Phone;
                
                var photo = voteContext.fileUpload.Where(x => x.Id == data.Img).FirstOrDefault();
                luckydrawUser.Gender = photo != null ? photo.ImageUrl : "";

                statusResponse.Status = true; statusResponse.Message = "User details"; statusResponse.Data = luckydrawUser;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User details not found";
            }

            return statusResponse;
        }
        public LuckyModel Status(int id)
        {
            LuckyModel statusResponse = new LuckyModel();
            var data = voteContext.luckydrawUser.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                data.IsActive = data.IsActive == true ? false : true;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Status changed"; statusResponse.Data = data;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User details not found";
            }

            return statusResponse;
        }
        public LuckyModel AdminStatus(int id)
        {
            LuckyModel statusResponse = new LuckyModel();
            var data = voteContext.luckydrawUser.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                data.IsAdmin = data.IsAdmin == true ? false : true;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Admin Status changed"; statusResponse.Data = data;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User details not found";
            }

            return statusResponse;
        }

        public LuckyModel ChangePassword(int id, string oldPassword, string newPassword)
        {
            LuckyModel statusResponse = new LuckyModel();
            var data = voteContext.luckydrawUser.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                string oldPass = EncryptPassword.EncodePasswordToBase64(oldPassword);
                if (oldPass == data.Password)
                {
                    data.Password = EncryptPassword.EncodePasswordToBase64(newPassword);
                    voteContext.SaveChanges();
                    statusResponse.Status = true; statusResponse.Message = "Password changed";
                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "Old password not valid";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Voter details not found";
            }

            return statusResponse;
        }



        public LuckyModel Put(int id, LuckydrawUser luckydrawUser)
        {
            LuckyModel statusResponse = new LuckyModel();

            var result = voteContext.luckydrawUser.Where(x => x.Id == id).FirstOrDefault();


            if (result != null)
            {
                result.FullName = luckydrawUser.FullName;
                result.FatherName = luckydrawUser.FatherName;
                result.Phone = luckydrawUser.Phone;
                result.Gender = luckydrawUser.Gender;
                result.Department = luckydrawUser.Department;
                result.Designation = luckydrawUser.Designation;
                result.Img = luckydrawUser.Img;
                voteContext.SaveChanges();

                var data = voteContext.luckydrawUser.Where(x => x.Id == id).FirstOrDefault();
                LuckydrawUser luckydraw = new LuckydrawUser();
                luckydraw.CreatedOn = data.CreatedOn;
                luckydraw.Department = data.Department;
                luckydraw.Designation = data.Designation;
                luckydraw.Email = data.Email;
                luckydraw.FatherName = data.FatherName;
                luckydraw.FullName = data.FullName;
                luckydraw.Id = data.Id;
                luckydraw.Img = data.Img;
                luckydraw.IsActive = data.IsActive;
                luckydraw.IsAdmin = data.IsAdmin;
                luckydraw.Password = data.Password;
                luckydraw.Phone = data.Phone;

                var photo = voteContext.fileUpload.Where(x => x.Id == data.Img).FirstOrDefault();
                luckydraw.Gender = photo != null ? photo.ImageUrl : "";

                statusResponse.Status = true; statusResponse.Message = "Profile updated"; statusResponse.Data = luckydraw;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "User not found";
            }
            return statusResponse;
        }

    }
}
