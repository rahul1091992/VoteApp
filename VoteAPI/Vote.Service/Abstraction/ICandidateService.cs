using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;
using Vote.Model.Models;

namespace Vote.Service.Abstraction
{
    
    public interface ICandidateService
    {
        CandidateModel Post(Candidates candidates);
        CandidateModel Put(Candidates candidates, int id);
        CandidateModel Get(int id);
        CandidateModel Delete(int id);
        CandidateList GetAll(int electionId);
        CandidateModel Status(int id);
    }
}
