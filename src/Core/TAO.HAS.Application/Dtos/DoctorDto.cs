using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Dtos
{
    public class DoctorDto
    {
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Profession DoctorProfession { get; set; }
        public Department DoctorDepartment { get; set; }
    }
}
