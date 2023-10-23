using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Commands.ExperienceCommands
{
    public record UpdateExperienceCommand(CandidateExperienceDto CandidateExperienceDto):IRequest<CandidateExperienceDto>;
}
