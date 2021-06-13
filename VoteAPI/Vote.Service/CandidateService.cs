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
    
    public class CandidateService : ICandidateService
    {
        ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public CandidateModel Post(Candidates candidates)
        {
            return _candidateRepository.Post(candidates);
        }
        public CandidateModel Put(Candidates candidates, int id)
        {
            return _candidateRepository.Put(candidates, id);
        }
        public CandidateModel Get(int id)
        {
            return _candidateRepository.Get(id);
        }
        public CandidateModel Delete(int id)
        {
            return _candidateRepository.Delete(id);
        }
        public CandidateList GetAll(int electionId)
        {
            return _candidateRepository.GetAll(electionId);
        }
        public CandidateModel Status(int id)
        {
            return _candidateRepository.Status(id);
        }

    }
}
