using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Exceptions;
using TAO.HAS.Application.Repositories;

namespace TAO.HAS.Application.Features.Doctor.Rules
{
    public class DoctorBusinessRules
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorBusinessRules(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public bool IsNationalIdentityCorrectFormat(string nationalIdentity)
        {
            /*This rule for the Turkey Identity Algorithm*/

            int oddNumbersTotal = 0;
            int evenNumbersTotal = 0;
            int total10 = 0;

            if (nationalIdentity.Length != 11 || nationalIdentity.Substring(0, 1) == "0" || nationalIdentity.All(char.IsDigit) == false)
            {
                return false;
            }
            for (int i = 0; i < nationalIdentity.Length; i++)
            {
                Convert.ToInt32(nationalIdentity[i].ToString());
                if (nationalIdentity[i] != 10)
                {
                    total10 += nationalIdentity[i];
                }
                if (nationalIdentity[i] % 2 != 0)
                {
                    oddNumbersTotal += nationalIdentity[i];
                }
                else
                {
                    evenNumbersTotal += nationalIdentity[i];
                }
            }

            if ((7 * oddNumbersTotal - evenNumbersTotal) % 10 != nationalIdentity[10])
            {
                return false;
            }
            if (total10 % 10 != nationalIdentity[10])
            {
                return false;
            }

            return true;
        }

        public async Task NationalIdentityCannotDuplicatedWhenInsertedOrUpdated(string nationalIdentity)
        {
            var result = await _doctorRepository.FindAsync(d => d.NationalIdentity == nationalIdentity);
            if (result.Any())
            {
                throw new BusinessException($"{nationalIdentity} already exists.");
            }
        }
        public async Task PhoneNumberCannotDuplicateWhenInsertedOrUpdated(string phoneNumber)
        {
            var result = await _doctorRepository.FindAsync(d => d.Phone == phoneNumber);

            if (result.Any())
            {
                throw new BusinessException($"{phoneNumber} aldready exists.");
            }
        }
        public async Task EmailCannotDuplicateWhenInsertedOrUpdated(string email)
        {
            var result = await _doctorRepository.FindAsync(d => d.Email == email);

            if (result.Any())
            {
                throw new BusinessException($"{email} already exists.");
            }
        }
        public void DateOfBirthShouldBeBiggerToday(DateTime birthDate)
        {
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            if (birthDate < Convert.ToDateTime(today)) ;
            {
                throw new BusinessException("Date of birth can't smaller than today.");
            }

        }
        public void DoctorAgeShoulBeBiggerThanTwentyTwo(DateTime birthDate)
        {
            var year = DateTime.Now.Year;
            var age = year - birthDate.Year;

            if (age <= 22)
            {
                throw new BusinessException("Doctor age should be bigger than twenty two.");
            }
        }

        public async Task DoctorShouldBeExistsWhenDeletedOrUpdated(Guid doctorId)
        {
            var result = await _doctorRepository.GetByIdAsync(doctorId);

            if (result == null)
            {
                throw new BusinessException($"Doctor cannot found. ");
            }
        }

    }
}
