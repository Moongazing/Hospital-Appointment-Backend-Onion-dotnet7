using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Exceptions;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Department.Rules
{
    public class DepartmentBusinessRules
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentBusinessRules(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task DepartmentNameCannotDuplicateWhenInsertedOrUpdated(string departmentName)
        {
            var result = await _departmentRepository.FindAsync(d => d.Name.ToLower() == departmentName.ToLower());
            if (result.Any())
            {
                throw new BusinessException("Name already exists.");
            }
        }
        public async Task DepartmentShouldBeExistsWhenDeletedOrUpdated(Guid id)
        {
            var result = await _departmentRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new BusinessException("Department should be exists.");
            }
        }
    }
}
