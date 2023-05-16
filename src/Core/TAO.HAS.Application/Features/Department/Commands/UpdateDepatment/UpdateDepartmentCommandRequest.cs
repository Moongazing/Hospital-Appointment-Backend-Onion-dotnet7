using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Commands.UpdateDepatment
{
    public class UpdateDepartmentCommandRequest:IRequest<UpdateDepartmentCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
