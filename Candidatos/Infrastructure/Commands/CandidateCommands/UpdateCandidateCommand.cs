using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Commands.CandidateCommands
{
    public record UpdateCandidateCommand(CandidateDTO Candidate) : IRequest<CandidateDTO>;
}
