using Candidates.Application.DTOs;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Commands.ExperienceCommands;
using MediatR;

namespace Candidates.Application.Handlers.ExperienceHandler
{
    public class UpdateExperienceHandler : IRequestHandler<UpdateExperienceCommand, CandidateExperienceDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateExperienceHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateExperienceDto> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = await _dbContext.CandidateExperiences.FindAsync(
                new object[] { request.CandidateExperienceDto.IdCandidateExperience });

            if (experience == null)
            {
                return null;
            }

            experience.Company = request.CandidateExperienceDto.Company;
            experience.Job = request.CandidateExperienceDto.Job;
            experience.Description = request.CandidateExperienceDto.Description;
            experience.Salary = request.CandidateExperienceDto.Salary;
            experience.BeginDate = request.CandidateExperienceDto.BeginDate;
            experience.EndDate = request.CandidateExperienceDto.EndDate;
            experience.ModifyDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

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
