using MediatR;

namespace Candidates.Infrastructure.Commands.ExperienceCommands
{
    public record DeleteExperienceCommand(int idExperience):IRequest<bool>;
}
