using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Queries.ExperienceQueries
{
    public record GetExperiencesByIdQuery(int experienceId):IRequest<CandidateExperienceDto>;
}
