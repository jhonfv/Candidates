using Candidates.Application.DTOs;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Queries.CandidateCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Application.Handlers.CandidateHandler
{
    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidateQuery, IEnumerable<CandidateDTO>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllCandidatesHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CandidateDTO>> Handle(GetAllCandidateQuery request, CancellationToken cancellationToken)
        {
            var canidates = await _dbContext.Candidates.ToListAsync(cancellationToken);
            return canidates.Select(c => new CandidateDTO {
                IdCandidate = c.IdCandidate,
                Name = c.Name,
                Surname = c.Surname,
                BirtDate = c.BirtDate,
                Email  = c.Email,
            });
        }
    }
}
