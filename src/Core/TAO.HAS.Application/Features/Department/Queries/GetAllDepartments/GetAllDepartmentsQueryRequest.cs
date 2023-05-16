using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryRequest:IRequest<GetAllDepartmentsQueryResponse>
    {
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
