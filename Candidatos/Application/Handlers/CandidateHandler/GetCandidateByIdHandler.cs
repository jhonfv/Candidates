using Candidates.Application.DTOs;
using Candidates.Infrastructure;
using Candidates.Infrastructure.Queries.CandidateCommands;
using MediatR;

namespace Candidates.Application.Handlers.CandidateHandler
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDTO>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCandidateByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateDTO> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FindAsync(
                new object[] {request.idCandidate}, cancellationToken);
            if (candidate == null)
            {
                return null;
            }

            return new CandidateDTO
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirtDate = candidate.BirtDate,
                Email = candidate.Email,
            };
        }
    }
}
