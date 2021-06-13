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

    public class VoterRepository : IVoterRepository
    {
        private VoteDBContext voteContext;
        public VoterRepository(VoteDBContext db)
        {
            voteContext = db;
        }
        public VoterModel ForgotPassword(string email)
        {
            VoterModel statusResponse = new VoterModel();
            var result = voteContext.voters.Where(x => x.Email == email).FirstOrDefault();
            if (result != null)
            {
                string newPass = SendEmail.GenerateRandomPassword();
                bool passCheck = SendEmail.SendForgotPasswordMail(result.Name, result.Email, newPass);
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
                statusResponse.Status = false; statusResponse.Message = "Invalid email";
            }

            return statusResponse;
        }
        public VoterModel Login(Voters voters)
        {
            VoterModel statusResponse = new VoterModel();
            voters.Password = EncryptPassword.EncodePasswordToBase64(voters.Password);
            var data = voteContext.voters.Where(x => x.Email == voters.Email && x.Password == voters.Password).FirstOrDefault();
            if (data != null)
            {
                if (data.IsActive)
                {
                    VotersListdata obj = new VotersListdata();
                    obj.Address = data.Address;
                    obj.Adhar = data.Adhar;
                    obj.CreatedOn = data.CreatedOn;
                    obj.Email = data.Email;
                    obj.FatherName = data.FatherName;
                    obj.Id = data.Id;
                    obj.Image = data.Image;
                    obj.ImageUrl = voteContext.fileUpload.Where(x => x.Id == data.Image).Select(x => x.ImageUrl).FirstOrDefault();
                    obj.IsActive = data.IsActive;
                    obj.Name = data.Name;
                    obj.Password = data.Password;
                    obj.Phone = data.Phone;
                    obj.Proof = data.Proof;
                    obj.ProofUrl = voteContext.fileUpload.Where(x => x.Id == data.Proof).Select(x => x.ImageUrl).FirstOrDefault();

                    statusResponse.Status = true; statusResponse.Message = "Login successful"; statusResponse.Data = obj;
                }

                else
                {
                    statusResponse.Status = false; statusResponse.Message = "User blocked by admin";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid credentials";
            }

            return statusResponse;
        }
        public VoterModel Post(Voters voters)
        {
            VoterModel statusResponse = new VoterModel();
            var email = voteContext.voters.Where(x => x.Email == voters.Email).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }


            string newPass = SendEmail.GenerateRandomPassword();
            bool passCheck = SendEmail.SendForgotPasswordMail(voters.Name, voters.Email, newPass);
            if (!passCheck)
            {
                statusResponse.Status = false; statusResponse.Message = "Invalid email";
            }

            if (email == null && passCheck)
            {
                voters.IsActive = true;
                voters.CreatedOn = DateTime.Now;
                voters.Password = EncryptPassword.EncodePasswordToBase64(newPass);
                voteContext.voters.Add(voters);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Password have been send on your register email";
            }

            return statusResponse;
        }

        public VoterList GetAll(int size, int skip, string filter)
        {
            VoterList statusResponse = new VoterList();
            var data = voteContext.voters.OrderByDescending(x => x.CreatedOn).Skip(skip).Take(size).ToList();
            var dataCount = voteContext.voters.Count();

            if (!string.IsNullOrEmpty(filter))
            {
                data = voteContext.voters.Where(x => x.Name.Contains(filter)).OrderByDescending(x => x.CreatedOn).ToList();
                dataCount = voteContext.voters.Where(x => x.Name.Contains(filter)).Count();
            }
            if (data.Count > 0)
            {
                List<VotersListdata> votersListdatas = new List<VotersListdata>();
                foreach (var item in data)
                {
                    var imageUrl = voteContext.fileUpload.Where(x => x.Id == item.Image).Select(x => x.ImageUrl).FirstOrDefault();
                    votersListdatas.Add(new VotersListdata { Address = item.Address, Image = item.Image, Adhar = item.Adhar, CreatedOn = item.CreatedOn, Email = item.Email, FatherName = item.FatherName, Id = item.Id, ImageUrl = imageUrl, IsActive = item.IsActive, Name = item.Name, Phone = item.Phone, Proof = item.Proof });
                }
                statusResponse.Status = true; statusResponse.Message = dataCount.ToString(); statusResponse.Data = votersListdatas;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Voter not found";
            }

            return statusResponse;
        }

        public VoterModel Status(int id)
        {
            VoterModel statusResponse = new VoterModel();
            var data = voteContext.voters.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                data.IsActive = data.IsActive == true ? false : true;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Voter ststus changed";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Voter details not found";
            }

            return statusResponse;
        }
        public VoterModel Get(int id)
        {
            VoterModel statusResponse = new VoterModel();
            var data = voteContext.voters.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                VotersListdata obj = new VotersListdata();
                obj.Address = data.Address;
                obj.Adhar = data.Adhar;
                obj.CreatedOn = data.CreatedOn;
                obj.Email = data.Email;
                obj.FatherName = data.FatherName;
                obj.Id = data.Id;
                obj.Image = data.Image;
                obj.ImageUrl = voteContext.fileUpload.Where(x => x.Id == data.Image).Select(x => x.ImageUrl).FirstOrDefault();
                obj.IsActive = data.IsActive;
                obj.Name = data.Name;
                obj.Password = data.Password;
                obj.Phone = data.Phone;
                obj.Proof = data.Proof;
                obj.ProofUrl = voteContext.fileUpload.Where(x => x.Id == data.Proof).Select(x => x.ImageUrl).FirstOrDefault();




                statusResponse.Status = true; statusResponse.Message = "Voter details"; statusResponse.Data = obj;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Voter details not found";
            }

            return statusResponse;
        }

        public VoterModel ChangePassword(int id, string oldPassword, string newPassword)
        {
            VoterModel statusResponse = new VoterModel();
            var data = voteContext.voters.Where(x => x.Id == id).FirstOrDefault();
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


        public VoterList Vote(int voterId, int candidateId, int electionId)
        {
            VoterList statusResponse = new VoterList();
            var data = voteContext.elections.Where(x => x.Id == electionId).FirstOrDefault();



            if (data != null)
            {
                if (data.IsActive)
                {

                    var voteData = voteContext.voteData.Where(x => x.ElectionId == electionId && x.VoterId == voterId).FirstOrDefault();
                    if (voteData == null)
                    {
                        VoteData obj = new VoteData();
                        obj.ElectionId = electionId;
                        obj.CandidateId = candidateId;
                        obj.VoterId = voterId;
                        obj.CreatedOn = DateTime.Now;
                        voteContext.voteData.Add(obj);
                        voteContext.SaveChanges();
                        statusResponse.Status = true; statusResponse.Message = "You have voted";

                    }
                    else
                    {
                        statusResponse.Status = false; statusResponse.Message = "You have already voted";
                    }

                }
                else
                {
                    statusResponse.Status = false; statusResponse.Message = "Election closed";
                }
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Election not found";
            }

            return statusResponse;
        }

        public VoterModel Put(int id, Voters voters)
        {
            VoterModel statusResponse = new VoterModel();

            var data = voteContext.voters.Where(x => x.Id == id).FirstOrDefault();


            if (data != null)
            {
                data.Name = voters.Name;
                data.Address = voters.Address;
                data.Adhar = voters.Adhar;
                data.FatherName = voters.FatherName;
                data.Image = voters.Image;
                data.Phone = voters.Phone;
                data.Proof = voters.Proof;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Profile updated";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Voter not found";
            }
            return statusResponse;
        }

    }
}
