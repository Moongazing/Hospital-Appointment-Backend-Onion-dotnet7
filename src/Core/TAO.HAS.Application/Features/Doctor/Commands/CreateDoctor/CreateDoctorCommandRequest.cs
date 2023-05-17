using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Domain.Entities;

namespace TAO.HAS.Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandRequest:IRequest<CreateDoctorCommandResponse>
    {
        public string NationalIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ProfessionId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
