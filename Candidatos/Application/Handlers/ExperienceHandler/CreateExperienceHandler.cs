using Candidates.Application.DTOs;
using Candidates.Domain;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Commands.CandidateCommands;
using Candidates.Infrastructure.Commands.ExperienceCommands;
using MediatR;

namespace Candidates.Application.Handlers.ExperienceHandler
{
    public class CreateExperienceHandler : IRequestHandler<CreateExperienceCommand, CandidateExperienceDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateExperienceHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateExperienceDto> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = new CandidateExperience
            { 
                IdCandidate = request.CandidateExperienceDto.IdCandidate,
                Company = request.CandidateExperienceDto.Company,
                Job = request.CandidateExperienceDto.Job,
                Description = request.CandidateExperienceDto.Description,
                Salary = request.CandidateExperienceDto.Salary,
                BeginDate = request.CandidateExperienceDto.BeginDate,
                EndDate = request.CandidateExperienceDto.EndDate,
                InsertDate = DateTime.Now,
                ModifyDate = DateTime.Now,

            };
            _dbContext.Add(experience);
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
