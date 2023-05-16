using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Profession.Queries.GetAllProfessions;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, GetAllDepartmentsQueryResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<GetAllDepartmentsQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, ILogger<GetAllDepartmentsQueryHandler> logger, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<GetAllDepartmentsQueryResponse> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalDepartmentCount = _departmentRepository.GetAll().Count();

            var departments = _departmentRepository.GetAll()
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                .ToList();

            return await Task.FromResult(new GetAllDepartmentsQueryResponse
            {
                Departments = departments,
                TotalDepartmentsCount = totalDepartmentCount
            });
        }
    }
}
