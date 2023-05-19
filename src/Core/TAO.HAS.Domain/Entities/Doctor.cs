using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Domain.Common;

namespace TAO.HAS.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
