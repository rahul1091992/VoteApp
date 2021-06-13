using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Model
{
   public class Voters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Image { get; set; }
        public int Proof { get; set; }
        public string Address { get; set; }
        public string Adhar { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Password { get; set; }
    }
    public class VotersListdata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Image { get; set; }
        public int Proof { get; set; }
        public string Address { get; set; }
        public string Adhar { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ImageUrl { get; set; }
        public string ProofUrl { get; set; }
        public string Password { get; set; }
    }
}
