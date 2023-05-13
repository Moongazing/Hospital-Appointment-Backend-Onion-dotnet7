using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandRequest:IRequest<CreateDepartmentCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
