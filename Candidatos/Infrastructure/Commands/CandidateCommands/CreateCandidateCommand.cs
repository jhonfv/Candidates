using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Commands.CandidateCommands
{
    public record CreateCandidateCommand(CandidateDTO Candidate) : IRequest<CandidateDTO>;
}
