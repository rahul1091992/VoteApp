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

    public class VoterService : IVoterService
    {
        IVoterRepository _voterRepository;
        public VoterService(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }
        public VoterModel ForgotPassword(string email)
        {
            return _voterRepository.ForgotPassword(email);
        }
        public VoterModel Login(Voters voters)
        {
            return _voterRepository.Login(voters);
        }
        public VoterModel Post(Voters voters)
        {
            return _voterRepository.Post(voters);
        }
        public VoterList GetAll(int size,int skip,string filter)
        {
            return _voterRepository.GetAll(size,skip, filter );
        }

        public VoterModel Status(int id)
        {
            return _voterRepository.Status(id);
        }
        public VoterModel Get(int id)
        {
            return _voterRepository.Get(id);
        }
        public VoterModel ChangePassword(int id,string oldPassword, string newPassword)
        {
            return _voterRepository.ChangePassword(id, oldPassword, newPassword);
        }
        public VoterList Vote(int voterId, int candidateId, int electionId)
        {
            return _voterRepository.Vote(voterId, candidateId, electionId);
        }
        public VoterModel Put(int id,Voters voters)
        {
            return _voterRepository.Put(id,voters);
        }
    }
}
