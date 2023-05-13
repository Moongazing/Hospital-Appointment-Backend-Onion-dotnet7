using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Department.Rules;
using TAO.HAS.Application.Features.Profession.Commands.DeleteProfession;
using TAO.HAS.Application.Repositories;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommandRequest, DeleteDepartmentCommandResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DeleteDepartmentCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, ILogger<DeleteDepartmentCommandHandler> logger,IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
        {
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<DeleteDepartmentCommandResponse> Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _departmentBusinessRules.DepartmentShouldBeExistsWhenDeletedOrUpdated(request.Id);

            var department = await _departmentRepository.GetByIdAsync(request.Id);

            _departmentRepository.Delete(department);

            await _departmentRepository.SaveChangesAsync();
            _logger.LogInformation($"This {request.Id} owner department has been deleted.");

            DeleteDepartmentCommandResponse response = _mapper.Map<DeleteDepartmentCommandResponse>(department);

            return response;




        }
    }
}
