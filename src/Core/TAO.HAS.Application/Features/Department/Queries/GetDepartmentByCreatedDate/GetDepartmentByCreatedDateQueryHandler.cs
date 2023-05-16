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
using TAO.HAS.Application.Features.Profession.Queries.GetProfessionByCreatedDate;
using TAO.HAS.Application.Features.Profession.Rules;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Department.Queries.GetDepartmentByCreatedDate
{
    public class GetDepartmentByCreatedDateQueryHandler : IRequestHandler<GetDepartmentByCreatedDateQueryRequest, GetDepartmentByCreatedDateQueryResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<GetAllDepartmentsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;
        public GetDepartmentByCreatedDateQueryHandler(IDepartmentRepository departmentRepository, ILogger<GetAllDepartmentsQueryHandler> logger, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
            _mapper = mapper;
            _departmentBusinessRules = departmentBusinessRules;
        }
        public async Task<GetDepartmentByCreatedDateQueryResponse> Handle(GetDepartmentByCreatedDateQueryRequest request, CancellationToken cancellationToken)
        {
            _departmentBusinessRules.GetDepartmentByCreatedDateShouldSmallerThanTomorrow(request.CreatedDate);
            var formattedDate = request.CreatedDate.ToString("yyyy-MM-dd");

            var professions = await _departmentRepository.FindAsync(d=> d.CreatedDate.ToString().Contains(formattedDate));
            var response = new GetDepartmentByCreatedDateQueryResponse();
            response.Departments = _mapper.Map<List<DepartmentDto>>(professions);
            return response;
        }
    }
}
