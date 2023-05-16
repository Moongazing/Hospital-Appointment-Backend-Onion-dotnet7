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
           var result =  await _departmentRepository.FindAsync(d => d.Name.ToLower() == departmentName.ToLower());

            if (result.Any())
            {
                throw new BusinessException($"{departmentName} already exists.");
            }
        }
        public async Task DepartmentShouldBeExistsWhenDeletedOrUpdated(Guid departmentId)
        {
            var result = await _departmentRepository.GetByIdAsync(departmentId);
            if (result == null)
            {
                throw new BusinessException($"{departmentId} not found. Department should be exists.");
            }

        }
        public async Task DepartmentNameShoulBeExists(string departmentName)
        {
            var result = await _departmentRepository.FindAsync(d => d.Name.ToLower().Contains(departmentName.ToLower()));
            if (result== null)
            {
                throw new BusinessException($"{departmentName} not found. Department name should be exists.");
            }
        }
        public void GetDepartmentByCreatedDateShouldSmallerThanTomorrow(DateTime date)
        {
            var today = DateTime.Today.AddDays(1);
            if (date >= today)
            {
                throw new BusinessException("Date should be smaller than tomorrow");
            }
        }
    }
}
