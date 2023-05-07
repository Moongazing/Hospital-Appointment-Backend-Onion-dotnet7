using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Exceptions;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Profession.Rules
{
    public class ProfessionBusinessRules
    {
        private readonly IProfessionRepository _professionRepository;
        public ProfessionBusinessRules(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }
        public async Task ProfessionNameCanNotBeDuplicatedWhenInsertedOrUpdated(string professionName)
        {
            var result = await _professionRepository.FindAsync(p => p.Name.ToLower() == professionName.ToLower());
            if (result.Any())
            {
                throw new BusinessException("Profession name already exists.");
            }
        }
        public async Task ProfessionShouldBeExistsWhenDeletedOrUpdated(Guid id)
        {
            var result = await _professionRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new BusinessException("Profession should be exists.");
            }
        }
        public async Task ProfessionNameShouldBeExists(string name)
        {
            var profession = await _professionRepository.FindAsync(p => p.Name.ToLower().Contains(name.ToLower()));
            if (profession == null)
            {
                throw new BusinessException("Profession returns null.");
            }
        }
        public void GetProfessionByCreatedDateShouldSmallerThanTomorrow(DateTime date)
        {
            var today = DateTime.Today.AddDays(1);
            if (date >= today)
            {
                throw new BusinessException("Date should be smaller than tomorrow");
            }
        }

       
    }
}
