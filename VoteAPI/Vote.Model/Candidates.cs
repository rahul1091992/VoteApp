using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
    public class Candidates
    {
        public int Id { get; set; }
        public int ElectionId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adhar { get; set; }
        public int Image { get; set; }
        public int Proof { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class CandidatesData
    {
        public int Id { get; set; }
        public int ElectionId { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adhar { get; set; }
        public int Image { get; set; }
        public int Proof { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ImageName { get; set; }
        public string ProofName { get; set; }
        public int TotalVote { get; set; }
    }
}
