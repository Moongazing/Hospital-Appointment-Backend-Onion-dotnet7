using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Department.Rules;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Department.Commands.UpdateDepatment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<UpdateDepartmentCommandHandler> _logger;
        private readonly DepartmentBusinessRules _departmentBusinessRules;
        private readonly IMapper _mapper;
        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, ILogger<UpdateDepartmentCommandHandler> logger, DepartmentBusinessRules departmentBusinessRules, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentShouldBeExistsWhenDeletedOrUpdated(request.Id);

            await _departmentBusinessRules.DepartmentNameCannotDuplicateWhenInsertedOrUpdated(request.Name);

            var department = await _departmentRepository.GetByIdAsync(request.Id);

            var mappedDepartment = _mapper.Map(request, department);

            _departmentRepository.Update(mappedDepartment);


            _logger.LogInformation($"This {request.Id} owner department has been updated, updated name:{request.Name} updated description:{request.Description}");

            return new UpdateDepartmentCommandResponse();





        }
    }
}
