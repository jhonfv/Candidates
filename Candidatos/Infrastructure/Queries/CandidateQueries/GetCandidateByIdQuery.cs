using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Queries.CandidateCommands
{
    public record GetCandidateByIdQuery(int idCandidate) : IRequest<CandidateDTO>;
}
