using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.HAS.Application.Dtos;
using TAO.HAS.Application.Features.Doctor.Commands.CreateDoctor;
using TAO.HAS.Application.Features.Profession.Commands.CreateProfession;

namespace TAO.HAS.Application.Features.Doctor.Mapping
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<CreateDoctorCommandRequest, Domain.Entities.Doctor>().ReverseMap();
            CreateMap<CreateDoctorCommandResponse, Domain.Entities.Doctor>().ReverseMap();


            CreateMap<Domain.Entities.Doctor, DoctorDto>();                

        }

    }
}

