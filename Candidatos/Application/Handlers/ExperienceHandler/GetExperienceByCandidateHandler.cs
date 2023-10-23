using Candidates.Application.DTOs;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Queries.ExperienceQueries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Application.Handlers.ExperienceHandler
{
    public class GetExperienceByCandidateHandler : IRequestHandler<GetExperienceByCandidateQuery, IEnumerable<CandidateExperienceDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetExperienceByCandidateHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CandidateExperienceDto>> Handle(GetExperienceByCandidateQuery request, CancellationToken cancellationToken)
        {
            var experiences = await _dbContext.CandidateExperiences
                .Where(ex=>ex.IdCandidate==request.candidateId)
                .ToListAsync(cancellationToken);

            return experiences.Select(ex=>new CandidateExperienceDto
            {
                IdCandidateExperience=ex.IdCandidateExperience,
                IdCandidate = ex.IdCandidate,
                Company = ex.Company,
                Job = ex.Job,
                Description = ex.Description,
                Salary = ex.Salary,
                EndDate = ex.EndDate,
                BeginDate = ex.BeginDate,
            });
        }
    }
}
