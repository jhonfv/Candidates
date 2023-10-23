using Candidates.Infrastructure.Queries.CandidateCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candidates.Controllers
{
    public class HomeController : Controller
    {
        #region CTOR
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var candidate = await _mediator.Send(new GetAllCandidateQuery());
            return View(candidate);
        }

    }
}