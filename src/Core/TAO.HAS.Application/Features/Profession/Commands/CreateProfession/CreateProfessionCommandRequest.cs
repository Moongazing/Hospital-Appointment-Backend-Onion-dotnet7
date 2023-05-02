using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Profession.Commands.CreateProfession
{
    public class CreateProfessionCommandRequest:IRequest<CreateProfessionCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
