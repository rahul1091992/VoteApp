using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Service.Abstraction
{
    public interface IElectionService
    {
        ElectionModel Post(Elections elections);
        ElectionModel Put(Elections elections, int id);
        ElectionModel Get(int id);
        ElectionModel Delete(int id);
        ElectionList GetAll();
        ElectionModel Status(int id);
        VoterList GetAllVoters(int electionId, int candidateId, int size, int skip);
    }
}
