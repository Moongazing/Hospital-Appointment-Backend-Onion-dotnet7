using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TAO.HAS.Application.Features.Doctor.Commands.CreateDoctor;
using TAO.HAS.Application.Features.Doctor.Queries.GetAllDoctors;
using TAO.HAS.Application.Features.Profession.Commands.CreateProfession;
using TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        readonly IMediator _mediator;
        readonly ILogger<DoctorsController> _logger;
       

        public DoctorsController(IMediator mediator, ILogger<DoctorsController> logger )
        {
            _mediator = mediator;
            _logger = logger;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDoctorsQueryRequest getAllDoctorsQueryRequest)
        {
            GetAllDoctorsQueryResponse response = await _mediator.Send(getAllDoctorsQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommandRequest createDoctorCommandRequest)
        {
            CreateDoctorCommandResponse response = await _mediator.Send(createDoctorCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
