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

namespace TAO.HAS.Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQueryRequest, GetDepartmentByIdQueryResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<GetDepartmentByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository, ILogger<GetDepartmentByIdQueryHandler> logger, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetDepartmentByIdQueryResponse> Handle(GetDepartmentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentShouldBeExistsWhenDeletedOrUpdated(request.Id);

            Domain.Entities.Department department = await _departmentRepository.GetByIdAsync(request.Id);

            var mappedDepartment = _mapper.Map<GetDepartmentByIdQueryResponse>(department);

            return mappedDepartment;

        }
    }
}
