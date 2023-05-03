using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TAO.HAS.Application.Features.Profession.Commands.CreateProfession;
using TAO.HAS.Application.Features.Profession.Commands.DeleteProfession;
using TAO.HAS.Application.Features.Profession.Commands.UpdateProfession;
using TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions;
using TAO.HAS.Application.Features.Profession.Queries.GetProfessionById;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<ProfessionsController> _logger;
        readonly IProfessionRepository _professionRepository;

        public ProfessionsController(IMediator mediator, ILogger<ProfessionsController> logger, IProfessionRepository professionRepository)
        {
            _mediator = mediator;
            _logger = logger;
            _professionRepository = professionRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProfessionCommandRequest createProfessionCommandRequest)
        {
            CreateProfessionCommandResponse response = await _mediator.Send(createProfessionCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]DeleteProfessionCommandRequest deleteProfessionCommandRequest)
        {
            DeleteProfessionCommandResponse response = await _mediator.Send(deleteProfessionCommandRequest);
            return Ok("Profession deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProfessionCommandRequest updateProfessionCommandRequest)
        {
            UpdateProfessionCommandResponse response = await _mediator.Send(updateProfessionCommandRequest);
            return Ok("Profession updated.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllProfessionQueryRequest getAllProfessionQueryRequest)
        {
            GetAllProfessionQueryResponse response = await _mediator.Send(getAllProfessionQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProfessionByIdQueryRequest getProfessionByIdQueryRequest)
        {
            GetProfessionByIdQueryResponse response = await _mediator.Send(getProfessionByIdQueryRequest);
            return Ok(response);
        }

    }
}
