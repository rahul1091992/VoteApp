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

    public class ElectionRepository : IElectionRepository
    {
        private VoteDBContext voteContext;
        public ElectionRepository(VoteDBContext db)
        {
            voteContext = db;
        }
        public ElectionModel Post(Elections elections)
        {
            ElectionModel statusResponse = new ElectionModel();
            var data = voteContext.elections.Where(x => x.Name == elections.Name).FirstOrDefault();
            if (data != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Election name already exists";
            }

            if (data == null)
            {
                elections.IsActive = true;
                elections.CreatedOn = DateTime.Now;
                voteContext.elections.Add(elections);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Election Registered successful";
            }

            return statusResponse;
        }
        public ElectionModel Put(Elections elections, int id)
        {
            ElectionModel statusResponse = new ElectionModel();
            var data = voteContext.elections.Where(x => x.Name == elections.Name && x.Id != id).FirstOrDefault();
            if (data != null)
            {
                statusResponse.Status = false; statusResponse.Message = "Election name already exists";
            }

            if (data == null)
            {
                var result = voteContext.elections.Where(x => x.Id == id).FirstOrDefault();
                result.Name = elections.Name;
                result.Description = elections.Description;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Election updated successful";
            }

            return statusResponse;
        }
        public ElectionModel Get(int id)
        {
            ElectionModel statusResponse = new ElectionModel();
            var data = voteContext.elections.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                ElectionsData electionsData = new ElectionsData();
                electionsData.CreatedOn = data.CreatedOn;
                electionsData.Description = data.Description;
                electionsData.Id = data.Id;
                electionsData.IsActive = data.IsActive;
                electionsData.Name = data.Name;
                electionsData.TotalVote = voteContext.voteData.Where(x => x.ElectionId == data.Id).Count();

                statusResponse.Status = true; statusResponse.Message = "Election details"; statusResponse.Data = electionsData;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Election details not found";
            }

            return statusResponse;
        }
        public ElectionModel Delete(int id)
        {
            ElectionModel statusResponse = new ElectionModel();
            var data = voteContext.elections.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                var candidates = voteContext.candidates.Where(x => x.ElectionId == data.Id).ToList();
                foreach (var item in candidates)
                {
                    var votes = voteContext.voteData.Where(x => x.CandidateId == item.Id).ToList();
                    foreach (var cn in votes)
                    {
                        voteContext.voteData.Remove(cn);
                        voteContext.SaveChanges();
                    }
                    voteContext.candidates.Remove(item);
                    voteContext.SaveChanges();
                }

                voteContext.elections.Remove(data);
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Election deleted";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Election details not found";
            }

            return statusResponse;
        }
        public ElectionList GetAll()
        {
            ElectionList statusResponse = new ElectionList();
            var data = voteContext.elections.OrderByDescending(x => x.CreatedOn).ToList();
            if (data.Count > 0)
            {
                statusResponse.Status = true; statusResponse.Message = "Election list"; statusResponse.Data = data;
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Election not found";
            }

            return statusResponse;
        }

        public ElectionModel Status(int id)
        {
            ElectionModel statusResponse = new ElectionModel();
            var data = voteContext.elections.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                data.IsActive = data.IsActive == true ? false : true;
                voteContext.SaveChanges();
                statusResponse.Status = true; statusResponse.Message = "Election ststus changed";
            }
            else
            {
                statusResponse.Status = false; statusResponse.Message = "Election details not found";
            }

            return statusResponse;
        }

        public VoterList GetAllVoters(int electionId, int candidateId, int size, int skip)
        {
            VoterList statusResponse = new VoterList();
            var data = voteContext.voteData.Where(x => x.CandidateId == candidateId && x.ElectionId == electionId).Skip(skip).Take(size).ToList();
            var dataCount = voteContext.voteData.Where(x => x.CandidateId == candidateId && x.ElectionId == electionId).Count();

            //if (!string.IsNullOrEmpty(filter))
            //{
            //    data = voteContext.voters.Where(x => x.Name.Contains(filter)).OrderByDescending(x => x.CreatedOn).ToList();
            //    dataCount = voteContext.voters.Where(x => x.Name.Contains(filter)).Count();
            //}
            if (data.Count > 0)
            {
                List<VotersListdata> votersListdatas = new List<VotersListdata>();
                foreach (var cn in data)
                {
                    var item = voteContext.voters.Where(x => x.Id == cn.VoterId).FirstOrDefault();

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
    }
}
