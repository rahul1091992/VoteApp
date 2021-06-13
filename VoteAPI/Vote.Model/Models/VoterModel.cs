using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model.Models
{
   
    public class VoterModel
    {
        public VoterModel()
        {
            Data = new VotersListdata();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public VotersListdata Data { get; set; }
    }
    public class VoterList
    {
        public VoterList()
        {
            Data = new List<VotersListdata>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<VotersListdata> Data { get; set; }
    }
}
