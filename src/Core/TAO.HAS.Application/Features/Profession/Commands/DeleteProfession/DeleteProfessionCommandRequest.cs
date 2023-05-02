using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Profession.Commands.DeleteProfession
{
    public class DeleteProfessionCommandRequest:IRequest<DeleteProfessionCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
