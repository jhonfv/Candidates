using Candidates.Application.DTOs;
using Candidates.Domain;
using Candidates.Infrastructure.Commands.CandidateCommands;
using Candidates.Infrastructure.Commands.ExperienceCommands;
using Candidates.Infrastructure.Queries.CandidateCommands;
using Candidates.Infrastructure.Queries.ExperienceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candidates.Controllers
{
    public class ExperiencesController : Controller
    {
        #region CTOR
        private readonly IMediator _mediator;

        public ExperiencesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Details
        [HttpGet("Experiences/Details/{idCandidate}")]
        public async Task<ActionResult> DetailsAsync(int idCandidate)
        {
            ViewData["IdCandidate"] = idCandidate;
            var experiences = await _mediator.Send(new GetExperienceByCandidateQuery(idCandidate));
            return View(experiences);
        }
        #endregion

        #region Create
        [HttpGet("Experiences/Create/{idCandidate}")]
        public async Task<ActionResult> Create(int idCandidate)
        {
            ViewData["IdCandidate"] = idCandidate;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SubmitNewExperience(CandidateExperienceDto candidateExperienceDto)
        {
            var newCandidate = await _mediator.Send(new CreateExperienceCommand(candidateExperienceDto));
            if (newCandidate != null)
            {
                return RedirectToAction("Details", "Experiences", new { idCandidate = candidateExperienceDto.IdCandidate });
            }
            else
            {
                return RedirectToAction("Create", "Experiences", new { idCandidate = candidateExperienceDto.IdCandidate });
            }
        }
        #endregion

        #region Update
        [HttpGet("Experiences/Update/{IdExperience}")]
        public async Task<ActionResult> Update(int IdExperience)
        {
            var experience = await _mediator.Send(new GetExperiencesByIdQuery(IdExperience));
            if (experience == null)
            {
                return NotFound($"Experience #{IdExperience} not found.");
            }
            return View(experience);
        }

        [HttpPost]
        public async Task<ActionResult> SubmitUpdateExperience(CandidateExperienceDto candidateExperienceDto)
        {
            var experience = await _mediator.Send(new UpdateExperienceCommand(candidateExperienceDto));

            return RedirectToAction("Details", "Experiences", new { idCandidate = candidateExperienceDto.IdCandidate });
        }
        #endregion

        #region Delete
        public async Task<ActionResult> Delete(int IdCandidate, int IdCandidateExperience)
        {
            var experience = await _mediator.Send(new DeleteExperienceCommand(IdCandidateExperience));
            if (!experience)
            {
                return BadRequest($"Experience #{IdCandidateExperience} not deleted");
            }
            return RedirectToAction("Details", "Experiences", new { idCandidate = IdCandidate});
        }
        #endregion
    }
}
