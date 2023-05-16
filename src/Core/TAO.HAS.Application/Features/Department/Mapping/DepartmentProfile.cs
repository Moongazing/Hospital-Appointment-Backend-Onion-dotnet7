using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Department.Commands.CreateDepartment;
using TAO.HAS.Application.Features.Department.Commands.DeleteDepartment;
using TAO.HAS.Application.Features.Department.Commands.UpdateDepatment;
using TAO.HAS.Application.Features.Department.Queries.GetAllDepartments;

namespace TAO.HAS.Application.Features.Department.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentCommandRequest, Domain.Entities.Department>().ReverseMap();
            CreateMap<CreateDepartmentCommandResponse, Domain.Entities.Department>().ReverseMap();

            CreateMap<DeleteDepartmentCommandRequest, Domain.Entities.Department>().ReverseMap();
            CreateMap<DeleteDepartmentCommandResponse, Domain.Entities.Department>().ReverseMap();

            CreateMap<UpdateDepartmentCommandRequest,Domain.Entities.Department>().ReverseMap();
            CreateMap<UpdateDepartmentCommandResponse, Domain.Entities.Department>().ReverseMap();

            CreateMap<Domain.Entities.Department, DepartmentDto>().ReverseMap();
        }
    }
}
