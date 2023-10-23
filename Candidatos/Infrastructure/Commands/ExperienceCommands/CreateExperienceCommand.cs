using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Commands.ExperienceCommands
{
    public record CreateExperienceCommand(CandidateExperienceDto CandidateExperienceDto) : IRequest<CandidateExperienceDto>;
    
}
