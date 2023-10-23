using Candidates.Application.DTOs;
using Candidates.Domain;
using Candidates.Infrastructure.Commands.CandidateCommands;
using Candidates.Infrastructure.Queries.CandidateCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candidates.Controllers
{
    public class CandidateController : Controller
    {
        #region ctor
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SubmitNewCandidate(CandidateDTO candidateDTO)
        {
            var newCandidate = await _mediator.Send(new CreateCandidateCommand(candidateDTO));
            if (newCandidate != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Candidate", "Create");
            }
        }
        #endregion

        #region Update
        [HttpGet("Candidate/Update/{IdCandidate}")]
        public async Task<ActionResult> Update(int IdCandidate)
        {
            var candidate = await _mediator.Send(new GetCandidateByIdQuery(IdCandidate));
            if (candidate == null)
            {
                return NotFound($"Candidate #{IdCandidate} not found.");
            }
            return View(candidate);
        }

        [HttpPost]
        public async Task<ActionResult> SubmitUpdateCandidate(CandidateDTO candidateDTO)
        {
            var candidate = await _mediator.Send(new UpdateCandidateCommand(candidateDTO));
            
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Delete
        [HttpGet("Candidate/Delete/{idCandidate}")]
        public async Task<ActionResult> Delete(int idCandidate)
        {
            var candidate = await _mediator.Send(new DeleteCandidateCommand(idCandidate));
            if (!candidate)
            {
                return BadRequest($"Candidate #{idCandidate} not deleted");
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
