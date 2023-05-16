using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Department.Queries.GetAllDepartments;
using TAO.HAS.Application.Features.Department.Rules;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Department.Queries.GetDepartmentByName
{
    public class GetDepartmentByNameQueryHandler : IRequestHandler<GetDepartmentByNameQueryRequest, GetDepartmentByNameQueryResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<GetAllDepartmentsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public GetDepartmentByNameQueryHandler(IDepartmentRepository departmentRepository, ILogger<GetAllDepartmentsQueryHandler> logger, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;

        }
        public async Task<GetDepartmentByNameQueryResponse> Handle(GetDepartmentByNameQueryRequest request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentNameShoulBeExists(request.Name);

            var departments = await _departmentRepository.FindAsync(d => d.Name.ToLower().Contains(request.Name.ToLower()));

            var departmentDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return new GetDepartmentByNameQueryResponse
            {
                Departments = departmentDto
            };




        }
    }
}
