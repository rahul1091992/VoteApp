using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
 public   class VoteData
    {
        public int Id { get; set; }
        public int ElectionId { get; set; }
        public int CandidateId { get; set; }
        public int VoterId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
