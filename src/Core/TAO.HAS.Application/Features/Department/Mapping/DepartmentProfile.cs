using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Features.Department.Commands.CreateDepartment;
namespace TAO.HAS.Application.Features.Department.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentCommandRequest, Domain.Entities.Department>().ReverseMap();
            CreateMap<CreateDepartmentCommandResponse, Domain.Entities.Department>().ReverseMap();
        }
    }
}
