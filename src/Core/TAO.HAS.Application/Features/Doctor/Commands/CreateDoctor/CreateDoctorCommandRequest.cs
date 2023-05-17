using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Doctor.Commands.CreateDoctor
{
    public class CreateDoctorCommandRequest:IRequest<CreateDoctorCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MyProperty { get; set; }
    }
}
