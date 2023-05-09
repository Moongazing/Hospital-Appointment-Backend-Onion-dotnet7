using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.HAS.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryResponse
    {
        public int TotalDepartmentsCount { get; set; }
        public object Departments { get; set; }
    }
}
