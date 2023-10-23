using Candidates.Domain;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        readonly IConfiguration _conf;
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
    }
}
