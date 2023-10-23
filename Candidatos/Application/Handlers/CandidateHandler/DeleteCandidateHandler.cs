using Candidates.Infrastructure;
using Candidates.Infrastructure.Commands.CandidateCommands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Candidates.Application.Handlers.CandidateHandler
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteCandidateHandler(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FindAsync(
                new object[] { request.IdCandidate});

            if (candidate == null)
            {
                return false ;
            }

            _dbContext.Candidates.Remove(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
