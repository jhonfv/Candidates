using Candidates.Application.DTOs;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Commands.CandidateCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candidates.Application.Handlers.CandidateHandler
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, CandidateDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateCandidateHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateDTO> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FindAsync(
                new object[] {request.Candidate.IdCandidate});

            if (candidate == null)
            {
                return null;
            }

            candidate.Name = request.Candidate.Name;
            candidate.Surname = request.Candidate.Surname;
            candidate.BirtDate = request.Candidate.BirtDate;
            candidate.Email = request.Candidate.Email;
            candidate.ModifyDate = DateTime.Now;

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
