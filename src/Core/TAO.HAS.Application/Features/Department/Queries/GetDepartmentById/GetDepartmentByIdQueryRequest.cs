using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryRequest:IRequest<GetDepartmentByIdQueryResponse>
    {

        public Guid Id { get; set; }
    }
}
