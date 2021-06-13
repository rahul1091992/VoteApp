using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
    
    public class CandidateModel
    {
        public CandidateModel()
        {
            Data = new CandidatesData();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public CandidatesData Data { get; set; }
    }
    public class CandidateList
    {
        public CandidateList()
        {
            Data = new List<CandidatesData>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<CandidatesData> Data { get; set; }
    }
}
