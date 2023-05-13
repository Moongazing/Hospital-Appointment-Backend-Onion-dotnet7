using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandRequest:IRequest<DeleteDepartmentCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
