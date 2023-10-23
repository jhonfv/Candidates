using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Queries.CandidateCommands
{
    public record GetAllCandidateQuery : IRequest<IEnumerable<CandidateDTO>>;
}
