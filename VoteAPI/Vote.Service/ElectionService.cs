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
    
    public class ElectionService : IElectionService
    {
        IElectionRepository _electionRepository;
        public ElectionService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }
        public ElectionModel Post(Elections elections)
        {
            return _electionRepository.Post(elections);
        }
        public ElectionModel Put(Elections elections, int id)
        {
            return _electionRepository.Put(elections, id);
        }
        public ElectionModel Get(int id)
        {
            return _electionRepository.Get(id);
        }
        public ElectionModel Delete(int id)
        {
            return _electionRepository.Delete(id);
        }
        public ElectionList GetAll()
        {
            return _electionRepository.GetAll();
        }
        public ElectionModel Status(int id)
        {
            return _electionRepository.Status(id);
        }
        public VoterList GetAllVoters(int electionId, int candidateId, int size, int skip)
        {
            return _electionRepository.GetAllVoters( electionId,  candidateId, size, skip);
        }
    }
}
