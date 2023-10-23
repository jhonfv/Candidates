using Candidates.Application.DTOs;
using Candidates.Domain;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Commands.CandidateCommands;
using MediatR;

namespace Candidates.Application.Handlers.CandidateHandler
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, CandidateDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateCandidateHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateDTO> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                Name = request.Candidate.Name,
                Surname = request.Candidate.Surname,
                BirtDate = request.Candidate.BirtDate,
                Email = request.Candidate.Email,
                InsertDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };
            _dbContext.Candidates.Add(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CandidateDTO
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirtDate = candidate.BirtDate,
                Email = candidate.Email
            };
        }
    }
}
