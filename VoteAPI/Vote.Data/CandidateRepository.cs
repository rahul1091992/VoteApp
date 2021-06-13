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

    public class CandidateRepository : ICandidateRepository
    {
        private VoteDBContext voteContext;
        public CandidateRepository(VoteDBContext db)
        {
            voteContext = db;
        }
        public CandidateModel Post(Candidates candidates)
        {
            CandidateModel statusResponse = new CandidateModel();
            var email = voteContext.candidates.Where(x => x.Email == candidates.Email).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }
            var phone = voteContext.candidates.Where(x => x.Phone == candidates.Phone).FirstOrDefault();
            if (phone != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Phone already exists";
            }

            if (email == null && phone == null)
            {
                candidates.IsActive = true;
                candidates.CreatedOn = DateTime.Now;
                voteContext.candidates.Add(candidates);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Candidate Registered successful";
            }

            return statusResponse;
        }
        public CandidateModel Put(Candidates candidates, int id)
        {
            CandidateModel statusResponse = new CandidateModel();
            var email = voteContext.candidates.Where(x => x.Email == candidates.Email && x.Id != id).FirstOrDefault();
            if (email != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Email already exists";
            }
            var phone = voteContext.candidates.Where(x => x.Phone == candidates.Phone && x.Id != id).FirstOrDefault();
            if (phone != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Phone already exists";
            }
            var adhar = voteContext.candidates.Where(x => x.Adhar == candidates.Adhar && x.Id != id).FirstOrDefault();
            if (adhar != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Adhar already exists";
            }

            if (email == null && phone == null && adhar == null)
            {
                var result = voteContext.candidates.Where(x => x.Id == id).FirstOrDefault();
                result.Name = candidates.Name;
                result.ElectionId = candidates.ElectionId;
                result.Phone = candidates.Phone;
                result.Adhar = candidates.Adhar;
                result.Email = candidates.Email;
                result.Address = candidates.Address;
                result.Proof = candidates.Proof;
                result.Image = candidates.Image;
                result.FatherName = candidates.FatherName;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Candidate updated successful";
            }

            return statusResponse;
        }
        public CandidateModel Get(int id)
        {
            CandidateModel statusResponse = new CandidateModel();
            var data = voteContext.candidates.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                CandidatesData obj = new CandidatesData();
                obj.Address = data.Address;
                obj.Adhar = data.Adhar;
                obj.CreatedOn = data.CreatedOn;
                obj.ElectionId = data.ElectionId;
                obj.Email = data.Email;
                obj.FatherName = data.FatherName;
                obj.Id = data.Id;
                obj.Image = data.Image;
                obj.ImageName = voteContext.fileUpload.Where(x => x.Id == data.Image).Select(x => x.ImageUrl).FirstOrDefault();
                obj.IsActive = data.IsActive;
                obj.Name = data.Name;
                obj.Phone = data.Phone;
                obj.Proof = data.Proof;
                obj.ProofName = voteContext.fileUpload.Where(x => x.Id == data.Proof).Select(x => x.ImageUrl).FirstOrDefault(); ;


                statusResponse.Status = true; statusResponse.Message = "Candidate details"; statusResponse.Data = obj;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Candidate details not found";
            }

            return statusResponse;
        }
        public CandidateModel Delete(int id)
        {
            CandidateModel statusResponse = new CandidateModel();
            var data = voteContext.candidates.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                var votes = voteContext.voteData.Where(x => x.CandidateId == data.Id).ToList();
                foreach (var item in votes)
                {
                    voteContext.voteData.Remove(item);
                    voteContext.SaveChanges();
                }

                voteContext.candidates.Remove(data);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Candidate deleted";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Candidate details not found";
            }

            return statusResponse;
        }
        public CandidateList GetAll(int electionId)
        {
            CandidateList statusResponse = new CandidateList();
            var data = voteContext.candidates.Where(x => x.ElectionId == electionId).OrderByDescending(x => x.CreatedOn).ToList();
            if (data.Count > 0)
            {
                List<CandidatesData> lst = new List<CandidatesData>();
                foreach (var item in data)
                {
                    string imageName = voteContext.fileUpload.Where(x => x.Id == item.Image).Select(x => x.ImageUrl).FirstOrDefault();
                    string proofName = voteContext.fileUpload.Where(x => x.Id == item.Proof).Select(x => x.ImageUrl).FirstOrDefault(); ;

                    int totalVote = voteContext.voteData.Where(x => x.CandidateId == item.Id).Count();
                    lst.Add(new CandidatesData { TotalVote = totalVote, Address = item.Address, Adhar = item.Adhar, CreatedOn = item.CreatedOn, ElectionId = item.ElectionId, Email = item.Email, FatherName = item.FatherName, Id = item.Id, Image = item.Image, ImageName = imageName, IsActive = item.IsActive, Name = item.Name, Phone = item.Phone, Proof = item.Proof, ProofName = proofName });
                }
                statusResponse.Status = true; statusResponse.Message = "Candidate list"; statusResponse.Data = lst.OrderByDescending(x => x.TotalVote).ToList();
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Candidate not found";
            }

            return statusResponse;
        }

        public CandidateModel Status(int id)
        {
            CandidateModel statusResponse = new CandidateModel();
            var data = voteContext.candidates.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                data.IsActive = data.IsActive == true ? false : true;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Candidate ststus changed";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Candidate details not found";
            }

            return statusResponse;
        }

    }
}
