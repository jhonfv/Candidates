using Candidates.Infrastructure;
using Candidates.Infrastructure.Commands.ExperienceCommands;
using MediatR;

namespace Candidates.Application.Handlers.ExperienceHandler
{
    public class DeleteExperienceHandler : IRequestHandler<DeleteExperienceCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteExperienceHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            var experience = await _dbContext.CandidateExperiences.FindAsync(
               new object[] { request.idExperience });

            if (experience == null)
            {
                return false;
            }

            _dbContext.CandidateExperiences.Remove(experience);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
