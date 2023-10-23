using Candidates.Application.DTOs;
using MediatR;

namespace Candidates.Infrastructure.Queries.ExperienceQueries
{
    public record GetExperienceByCandidateQuery(int candidateId):IRequest<IEnumerable<CandidateExperienceDto>>;
}
