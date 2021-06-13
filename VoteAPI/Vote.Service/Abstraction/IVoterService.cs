using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Service.Abstraction
{
    public interface IVoterService
    {
        VoterModel ForgotPassword(string email);
        VoterModel Login(Voters voters);
        VoterModel Post(Voters voters);
        VoterList GetAll(int size,int skip,string filter);
        VoterModel Status(int id);
        VoterModel Get(int id);
        VoterModel ChangePassword(int id,string oldPassword, string newPassword);
        VoterList Vote(int voterId, int candidateId, int electionId);
        VoterModel Put(int id,Voters voters);
    }
}
