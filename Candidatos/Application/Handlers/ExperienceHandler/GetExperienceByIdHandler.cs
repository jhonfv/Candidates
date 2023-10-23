using Candidates.Application.DTOs;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Queries.ExperienceQueries;
using MediatR;

namespace Candidates.Application.Handlers.ExperienceHandler
{
    public class GetExperienceByIdHandler : IRequestHandler<GetExperiencesByIdQuery, CandidateExperienceDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetExperienceByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateExperienceDto> Handle(GetExperiencesByIdQuery request, CancellationToken cancellationToken)
        {
            var experience = await _dbContext.CandidateExperiences.FindAsync(
                new object[] { request.experienceId }, cancellationToken);
            if (experience == null)
            {
                return null;
            }

            return new CandidateExperienceDto
            {
               IdCandidateExperience = experience.IdCandidateExperience,
               IdCandidate = experience.IdCandidate,
               Company = experience.Company,
               Job = experience.Job,
               Description = experience.Description,
               Salary = experience.Salary,
               BeginDate = experience.BeginDate,
               EndDate = experience.EndDate,
            };
        }
    }
}
