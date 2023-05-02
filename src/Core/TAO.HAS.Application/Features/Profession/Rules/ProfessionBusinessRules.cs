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
        public async Task ProfessionNameCanNotBeDuplicatedWhenInserted(string professionName)
        {
            var result = await _professionRepository.FindAsync(p => p.Name.ToLower() == professionName.ToLower());
            if (result.Any())
            {
                throw new BusinessException("Profession name already exists.");
            }
        }
        public async Task ProfessionShouldBeExistsWhenDeleted(Guid id)
        {
            var result = await _professionRepository.GetByIdAsync(id);
            if (result == null)
            {
                throw new BusinessException("Profession should be exists.");
            }
        }
    }
}
