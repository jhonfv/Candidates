using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidates.Domain
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirtDate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
