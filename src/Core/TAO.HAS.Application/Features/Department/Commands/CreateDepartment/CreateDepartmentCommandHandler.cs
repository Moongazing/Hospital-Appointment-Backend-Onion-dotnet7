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
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<CreateDepartmentCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, ILogger<CreateDepartmentCommandHandler> logger,IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentBusinessRules = departmentBusinessRules;
            _logger = logger;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }
        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentNameCannotDuplicateWhenInsertedOrUpdated(request.Name);

            var department = _mapper.Map<Domain.Entities.Department>(request);

            _departmentRepository.Add(department);

            await _departmentRepository.SaveChangesAsync();

            _logger.LogInformation($"The department added, name:{request.Name}  description:{request.Description}");

            CreateDepartmentCommandResponse response = _mapper.Map<CreateDepartmentCommandResponse>(department);

            return response;


        }
    }
}
