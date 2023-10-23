using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidates.Domain
{
    public class CandidateExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public string Company {get; set;}
        public string Job { get; set;}
        public string Description { get; set;}
        public double Salary { get; set;}
        public DateTime BeginDate { get; set;}
        public DateTime EndDate { get; set;}
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

        [ForeignKey("IdCandidate")]
        public virtual Candidate Candidate { get; set; }
    }
}
