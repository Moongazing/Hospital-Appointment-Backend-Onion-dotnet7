using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TAO.HAS.Application.Features.Department.Commands.CreateDepartment;
using TAO.HAS.Application.Features.Doctor.Commands.CreateDoctor;

namespace TAO.HAS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<DepartmentsController> _logger;


        public DepartmentsController(IMediator mediator, ILogger<DepartmentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommandRequest createDepartmentCommandRequest)
        {
            CreateDepartmentCommandResponse response = await _mediator.Send(createDepartmentCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
