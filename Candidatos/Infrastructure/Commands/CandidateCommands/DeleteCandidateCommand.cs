using MediatR;

namespace Candidates.Infrastructure.Commands.CandidateCommands
{
    public record DeleteCandidateCommand(int IdCandidate) : IRequest<bool>;
}
