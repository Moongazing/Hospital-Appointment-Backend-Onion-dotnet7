using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Queries.GetDepartmentByName
{
    public class GetDepartmentByNameQueryRequest:IRequest<GetDepartmentByNameQueryResponse>
    {
        public string Name { get; set; }
    }
}
