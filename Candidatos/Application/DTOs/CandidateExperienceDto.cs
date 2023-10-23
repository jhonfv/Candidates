namespace Candidates.Application.DTOs
{
    public class CandidateExperienceDto
    {
        public int IdCandidateExperience { get; set; }
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
